using Behlog.Extensions;

namespace Behlog.Core.Validations;

internal class MinLenValidator
{

    public static bool IsValid(string? value, int minLen)
    {
        if (value.IsNullOrEmptySpace())
            return false;

        if (value.Length < minLen)
            return false;

        return true;
    }
    
}