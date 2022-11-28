using Microsoft.Extensions.Logging.Abstractions;

namespace Behlog.Core.Validations;

public class ValidationError1 : ValidationResult1, IValidationResult
{
    
    protected ValidationError1() : base(BehlogValidationLevel.Error)
    {
    }

    protected ValidationError1(string message) : base(BehlogValidationLevel.Error, message)
    {
    }

    
    public Exception Exception { get; private set; }
    
    public string ErrorCode { get; private set; }
    

    public static ValidationError1 Create(string message)
    {
        var error = new ValidationError1(message);
        return error;
    }

    public ValidationError1 WithFieldName(string fieldName)
    {
        this.FieldName = fieldName;
        return this;
    }

    public ValidationError1 WithException(Exception exception)
    {
        this.Exception = exception;
        return this;
    }

    public ValidationError1 WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public static ValidationError1 Create(string errorCode, string message)
    {
        return new ValidationError1(message)
        {
            ErrorCode = errorCode
        };
    }

    public static ValidationError1 Create(string fieldName, string errorCode, string message)
    {
        return new ValidationError1(message)
        {
            ErrorCode = errorCode,
            FieldName = fieldName
        };
    }

    public static ValidationError1 Create(Exception exception)
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
    
}