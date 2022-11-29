namespace Behlog.Core.Validations;


public class ValidationError : ValidationResult, IValidationResult
{
    
    protected ValidationError() : base(BehlogValidationLevel.Error)
    {
    }

    protected ValidationError(string message) : base(BehlogValidationLevel.Error, message)
    {
    }

    
    public Exception Exception { get; private set; }
    
    public string ErrorCode { get; private set; }
    

    public static ValidationError Create(string message)
    {
        var error = new ValidationError(message);
        return error;
    }

    public ValidationError WithFieldName(string fieldName)
    {
        this.FieldName = fieldName;
        return this;
    }

    public ValidationError WithException(Exception exception)
    {
        this.Exception = exception;
        return this;
    }

    public ValidationError WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public static ValidationError Create(string errorCode, string message)
    {
        return new ValidationError(message)
        {
            ErrorCode = errorCode
        };
    }

    public static ValidationError Create(string fieldName, string errorCode, string message)
    {
        return new ValidationError(message)
        {
            ErrorCode = errorCode,
            FieldName = fieldName
        };
    }

    public static ValidationError Create(Exception exception)
    {
        var baseException = exception.GetBaseException();
        
        return Create(baseException.Message)
            .WithErrorCode(baseException.HResult.ToString())
            .WithException(baseException);
    }
    
    
    public void ThrowIfHasAnyException(Exception exception = null)
    {
        if(exception is null && this.Exception is null)
            throw new ArgumentNullException(nameof(exception));


        if (exception is null && this.Exception != null)
            throw exception;
    }


    public override string ToString()
    {
        if (Exception != null)
        {
            return $"Exception : {Exception.GetBaseException().Message}" + Environment.NewLine +
                   $"StackTrace : {Exception.GetBaseException().StackTrace}";
        }

        return $"[Error] {FieldName}: {ErrorCode} {Message}";
    }
}