using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Behlog.Extensions;

public static class PersianExts 
{

    private const string _IRAN_MOBILE_PREFIX = "98";
    private static readonly System.Type _typeOfString = typeof(string);

    public const char ArabicYeChar = (char)1610;
    public const char PersianYeChar = (char)1740;

    public const char ArabicKeChar = (char)1603;
    public const char PersianKeChar = (char)1705;

    public static string CorrectYeKe(this string data) {
        return string.IsNullOrWhiteSpace(data) ?
            data :
            data.Replace(ArabicYeChar, PersianYeChar)
                .Replace(ArabicKeChar, PersianKeChar)
                .Trim();
    }

    public static string DeNormalizePhoneNumber(this string input) {
        string result = input;
        if(input.StartsWith("98") && input.Length > 10) {
            result = "0" + result.TrimStart('9').TrimStart('8');
        }
        return result;
    }

    public static string NormalizePhoneNumber(this string input) {
        if (input.IsNullOrEmpty())
            return null;

        if (input.StartsWith('+'))
            return input.TrimStart('+');

        if (input.StartsWith("09"))
            return $"{_IRAN_MOBILE_PREFIX}{input.TrimStart('0')}";

        return input;
    }

    public static bool IsPhoneNumber(this string input)
        => input.IsValidIranianMobileNumber();
}