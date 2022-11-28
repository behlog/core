namespace Behlog.Core.Models;

public class CommandResult1<TValue> : CommandResult1 where TValue : class
{

    protected CommandResult1() : base()
    {
    }

    private CommandResult1(TValue value)
    {
        Value = value;
    }
    
    public TValue Value { get; protected set; }


    public new static CommandResult1<TValue> Create()
    {
        return new CommandResult1<TValue>();
    }

    public static CommandResult1<TValue> Success(TValue value)
    {
        var result = new CommandResult1<TValue>(value);
        return result;
    }

    public CommandResult1<TValue> With(TValue value)
    {
        Value = value;
        return this;
    }
    
    
}