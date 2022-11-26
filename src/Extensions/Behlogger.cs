using System.Text;
using Behlog.Core.Contracts;
using Microsoft.Extensions.Logging;

namespace Behlog.Extensions;

public class Behlogger<T> where T : class
{
    private readonly ILogger<T> _logger;
    private readonly ISystemDateTime _dateTime;


    public Behlogger(ILogger<T> logger, ISystemDateTime dateTime)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dateTime = dateTime ?? throw new ArgumentNullException(nameof(dateTime));
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