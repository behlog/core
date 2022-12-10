using Behlog.Core.Validations;

namespace Behlog.Core.Models;


public class CommandResult<TValue> : CommandResult where TValue : class
{

    protected CommandResult() : base()
    {
    }

    private CommandResult(TValue value)
    {
        Value = value;
    }
    
    public TValue Value { get; protected set; }
    
    public new static CommandResult<TValue> Create()
    {
        return new CommandResult<TValue>();
    }

    public static CommandResult<TValue> Success(TValue value)
    {
        var result = new CommandResult<TValue>(value);
        return result;
    }

    public new static CommandResult<TValue> Failed(ValidationError error)
    {
        var result = Create();
        result.AddError(error);
        return result;
    }
    
    public new static CommandResult<TValue> Failed(IEnumerable<ValidationError> errors)
    {
        var result = Create();
        foreach (var err in errors)
        {
            result.AddError(err);
        }

        return result;
    }
    
    
    public new static CommandResult<TValue> Success(TValue value, ValidationWarning warning)
    {
        var result = Create().With(value);
        result.AddWarning(warning);
        return result;
    }


    public new static CommandResult<TValue> Success(
        TValue value, IEnumerable<ValidationWarning> warnings)
    {
        var result = Create();
        foreach (var w in warnings)
        {
            result.AddWarning(w);
        }

        return result;
    }


    public new static CommandResult<TValue> Success(TValue value, ValidationInfo info)
    {
        var result = Create();
        result.AddInfo(info);
        return result;
    }

    public CommandResult<TValue> With(TValue value)
    {
        Value = value;
        return this;
    }

    
}
