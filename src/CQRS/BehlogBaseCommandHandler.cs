using System.Text;
using Microsoft.Extensions.Logging;
using Behlog.Core.Contracts;
using Behlog.Extensions;

namespace Behlog.Core;

/// <summary>
/// Base class for all Behlog CommandHandlers (see: <see cref="BehlogCommandHandler{TCommand,TResult}"/>>,
/// Providing EventPublishing and logging capabilities for <see cref="IAggregateRoot{TId}"/>
/// </summary>
public class BehlogHelper : IBehlogHelper
{
    private readonly ILogger<BehlogHelper> _logger;
    private readonly IBehlogManager _manager;
    private readonly ISystemDateTime _dateTime;

    protected BehlogHelper(
        ILogger logger, IBehlogManager manager, ISystemDateTime dateTime)
    {
        _manager = manager ?? throw new ArgumentNullException(nameof(manager));
        _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
        logger = _logger ?? throw new ArgumentNullException(nameof(logger));
    }


    public async Task PublishAsync<TAggregate, TId>(
        TAggregate aggregate, CancellationToken cancellationToken = default) 
            where TAggregate : IAggregateRoot<TId>
    {
        var typeName = typeof(TAggregate).Name;
        _logger.LogInformation($"Publishing {typeName} started...");

        await _manager.PublishAsync(aggregate.GetAllEvents(), cancellationToken);
        
        _logger.LogInformation($"All events for '{typeName}' published successfully.");
    }


    private string get_log_time()
    {
        var now = _dateTime.UtcNow;
        return $"{now.Year}-{now.Month}-{now.Day} {now.Hour}:{now.Minute}:{now.Second}-{now.Millisecond}";
    }
    
    public void LogInfo(string what)
    {
        if(what.IsNullOrEmpty()) return;
        
        _logger.LogInformation($"{get_log_time()} [Behlog.Info]: {what}");
    }

    public void LogError(string error)
    {
        if(error.IsNullOrEmpty()) return;
        
        _logger.LogError($"{get_log_time()} [Behlog.Error]: {error}");
    }

    public void LogException(Exception exception)
    {
        exception.ThrowExceptionIfArgumentIsNull(nameof(exception));

        var baseException = exception.GetBaseException();
        var message = baseException.Message;
        var stackTrace = baseException.StackTrace;
        var hResult = baseException.HResult;

        var sb = new StringBuilder();
        sb.AppendLine("************Exception**************");
        sb.AppendLine($"{get_log_time()} [Behlog.Exception]:");
        sb.AppendLine($"-HResult: {hResult}");
        sb.AppendLine($"-Message: {message}");
        sb.AppendLine($"-StackTrace: {stackTrace}");
        sb.AppendLine("***********************************");

        _logger.LogDebug(sb.ToString());
    }
    
}