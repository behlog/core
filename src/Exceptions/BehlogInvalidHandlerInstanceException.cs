namespace Behlog.Core;

public class BehlogInvalidHandlerInstanceException : BehlogException
{

    public BehlogInvalidHandlerInstanceException(string handlerName) 
        : base(message: $"Handler '{handlerName}'")
    {
    }
}