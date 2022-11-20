using System.Text;
using Behlog.Extensions;
using Behlog.Core.Domain;
using Microsoft.Extensions.Logging;

namespace Behlog.Core.CQRS;

public static class CommandHandlerExts
{

    public static async Task PublishEventsAsync<T>(
        this AggregateRoot<T> aggregateRoot,
        IBehlogManager manager,
        CancellationToken cancellationToken = default)
    {
        await manager.PublishAsync(aggregateRoot.GetAllEvents(), cancellationToken);
    }


    public static void LogException<T>(
        this IBehlogMessageHandler<T> messageHandler, Exception exception) where T : IBehlogMessage
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
        
    }


    public static void LogError<T>(this IBehlogMessageHandler<T> messageHandler, ILogger logger, string error)
        where T : IBehlogMessage
    {
        if(error.IsNullOrEmpty()) return;
        
        logger.ThrowExceptionIfArgumentIsNull(nameof(logger));

        logger.LogError($"{get_log_time()} [Behlog.Error]: {error}");
    }
    
    
    private static string get_log_time()
    {
        var now = DateTime.UtcNow;
        return $"{now.Year}-{now.Month}-{now.Day} {now.Hour}:{now.Minute}:{now.Second}-{now.Millisecond}";
    }
    
    
}