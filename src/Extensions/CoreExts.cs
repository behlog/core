using Behlog.Core;

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

    public static void ThrowIfGuidIsEmpty(this Guid value, Exception exception) {
        if (value == default)
            throw exception;
    }

    public static string ToDisplay(this BehlogValidationLevel level)
        => level switch
        {
            BehlogValidationLevel.Error => "[Error]",
            BehlogValidationLevel.Info => "[Info]",
            BehlogValidationLevel.Warning => "[Warning]",
            _=> "[!NULL]"
        };
}