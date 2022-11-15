namespace Behlog.Core;


public interface IBehlogCommand : IBehlogMessage
{
    
}

public interface IBehlogCommand<TResult> : IBehlogMessage<TResult>
{
    
}
