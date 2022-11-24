using System.Text;
using Behlog.Extensions;

namespace Behlog.Core.Validations;


public class ValidatorResult
{

    public bool HasError => _items.Any(_ => _.IsError);

    public bool IsValid => !HasError;

    public bool HasWarning => _items.Any(_ => _.IsWarning);

    protected ValidatorResult()
    {
        _items = new List<ValidationResult>();
    }
    
    public override string ToString()
    {
        if (_items.Any())
        {
            var sb = new StringBuilder();
            foreach (var item in _items)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        
        return "[Success] No Validation items!";
    }

    public static ValidatorResult Create()
    {
        return new ValidatorResult();
    }

    private ICollection<ValidationResult> _items;

    public IReadOnlyCollection<ValidationResult> Items => _items.ToList();
    
    public void Add(ValidationResult result)
    {
        _items.Add(result);
    }

    public void AddError(ValidationError error)
    {
        _items.Add(error);
    }

    public void AddInfo(string filedName, string message)
    {
        _items.Add(ValidationResult.Create(BehlogValidationLevel.Info)
            .WithFiledName(filedName)
            .WithMessage(message)
            .Build()
        );
    }

    public void AddWarning(string fieldName, string message)
    {
        _items.Add(ValidationResult.Create(BehlogValidationLevel.Warning)
            .WithFiledName(fieldName)
            .WithMessage(message)
            .Build()
        );
    }

    public void AddError(string fieldName, string message, string errorCode)
    {
        _items.Add(ValidationResult.Create()
            .WithFiledName(fieldName)
            .WithMessage(message)
            .WithErrorCode(errorCode)
            .Build()
        );
    }

    public ValidatorResult HasMaxLenght(
        string? value, int maxLen,
        string fieldName, string errorMessage, string errorCode = "")
    {
        if (value.IsNullOrEmptySpace())
            return this;

        if (value.Length > maxLen)
        {
            AddError(fieldName, errorMessage, errorCode);
        }
        return this;
    }

    public ValidatorResult IsNotNullOrEmpty(
        string value, string fieldName, string errorMessage, string errorCode = "")
    {
        if (value.IsNullOrEmptySpace())
        {
            AddError(fieldName, errorMessage, errorCode);
        }

        return this;
    }

    public ValidatorResult IsEmailFormatCorrect(
        string email, string fieldName, string errorMessage, string errorCode = "")
    {
        if (email.IsNullOrEmptySpace()) 
            throw new ArgumentNullException(nameof(email));
        
        if (!EmailValidator.IsValid(email))
        {
            AddError(fieldName, errorMessage, errorCode);
        }

        return this;
    }
    
}