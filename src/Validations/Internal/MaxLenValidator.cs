using Behlog.Extensions;

namespace Behlog.Core.Validations;

internal static class MaxLenValidator
{

    public static bool IsValid(string? value, int maxLen)
    {
        if (value.IsNullOrEmptySpace())
            return true;

        if (value.Length > maxLen)
            return false;
        
        return true;
    }
}