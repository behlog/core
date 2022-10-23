namespace Behlog.Extensions;

public static class CoreExts
{
    
    public static void ThrowExceptionIfNull(this object? obj, Exception exception)
    {
        if (obj is null) 
            throw exception;
    }

    public static void ThrowExceptionIfArgumentIsNull(this object? obj, string name = "object")
    {
        obj.ThrowExceptionIfNull(new ArgumentNullException(name));
    }

    public static void ThrowExceptionIfReferenceIsNull(this object? obj, string name = "object")
    {
        obj.ThrowExceptionIfNull(new NullReferenceException(name));
    }
}