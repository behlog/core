namespace Behlog.Core;

public class BehlogException : Exception
{

    public BehlogException() : base()
    {
    }
    
    public BehlogException(string message) : base(message)
    {
    }
}