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

    public CommandResult<TValue> With(TValue value)
    {
        Value = value;
        return this;
    }
    
    
}