using System.Globalization;

namespace Behlog.Extensions;

public static class PersianExts
{
    private const string _IRAN_MOBILE_PREFIX = "98";
    private static readonly System.Type _typeOfString = typeof(string);

    #region consts

    /// <summary>
    /// Arabic Ke Char \u0643 = ARABIC LETTER KAF
    /// </summary>
    public const char ArabicKeChar = (char)1603;

    /// <summary>
    /// Arabic Ye Char \u0649 = ARABIC LETTER ALEF MAKSURA
    /// </summary>
    public const char ArabicYeChar1 = (char)1609;

    /// <summary>
    /// Arabic Ye Char \u064A = ARABIC LETTER YEH
    /// </summary>
    public const char ArabicYeChar2 = (char)1610;

    /// <summary>
    /// ؠ
    /// </summary>
    public const char ArabicYeWithOneDotBelow = (char)1568;

    /// <summary>
    /// ؽ
    /// </summary>
    public const char ArabicYeWithInvertedV = (char)1597;

    /// <summary>
    /// ؾ
    /// </summary>
    public const char ArabicYeWithTwoDotsAbove = (char)1598;

    /// <summary>
    /// ؿ
    /// </summary>
    public const char ArabicYeWithThreeDotsAbove = (char)1599;

    /// <summary>
    /// ٸ
    /// </summary>
    public const char ArabicYeWithHighHamzeYeh = (char)1656;

    /// <summary>
    /// ې
    /// </summary>
    public const char ArabicYeWithFinalForm = (char)1744;

    /// <summary>
    /// ۑ
    /// </summary>
    public const char ArabicYeWithThreeDotsBelow = (char)1745;

    /// <summary>
    /// ۍ
    /// </summary>
    public const char ArabicYeWithTail = (char)1741;

    /// <summary>
    /// ێ
    /// </summary>
    public const char ArabicYeSmallV = (char)1742;

    /// <summary>
    /// Persian Ke Char \u06A9 = ARABIC LETTER KEHEH
    /// </summary>
    public const char PersianKeChar = (char)1705;

    /// <summary>
    /// Persian Ye Char \u06CC = 'ARABIC LETTER FARSI YEH
    /// </summary>
    public const char PersianYeChar = (char)1740;

    #endregion

    /// <summary>
    /// from : https://github.com/VahidN/DNTPersianUtils.Core/blob/master/src/DNTPersianUtils.Core/YeKe.cs
    /// </summary>
    /// <returns>Corrected text.</returns>
    public static string CorrectYeKe(this string? data)
    {
        if (string.IsNullOrWhiteSpace(data)) return string.Empty;

        var dataChars = data.ToCharArray();
        for (var i = 0; i < dataChars.Length; i++)
        {
            switch (dataChars[i])
            {
                case ArabicYeChar1:
                case ArabicYeChar2:
                case ArabicYeWithOneDotBelow:
                case ArabicYeWithInvertedV:
                case ArabicYeWithTwoDotsAbove:
                case ArabicYeWithThreeDotsAbove:
                case ArabicYeWithHighHamzeYeh:
                case ArabicYeWithFinalForm:
                case ArabicYeWithThreeDotsBelow:
                case ArabicYeWithTail:
                case ArabicYeSmallV:
                    dataChars[i] = PersianYeChar;
                    break;

                case ArabicKeChar:
                    dataChars[i] = PersianKeChar;
                    break;
            }
        }

        return new string(dataChars);
    }

    public static string DeNormalizePhoneNumber(this string input)
    {
        string result = input;
        if (input.StartsWith("98") && input.Length > 10)
        {
            result = "0" + result.TrimStart('9').TrimStart('8');
        }

        return result;
    }

    public static string NormalizePhoneNumber(this string input)
    {
        if (input.IsNullOrEmpty())
            return null;

        if (input.StartsWith('+'))
            return input.TrimStart('+');

        if (input.StartsWith("09"))
            return $"{_IRAN_MOBILE_PREFIX}{input.TrimStart('0')}";

        return input;
    }

    /// <summary>
    /// Converts English digits of a given string to their equivalent Persian digits.
    /// src : https://github.com/VahidN/DNTPersianUtils.Core/blob/master/src/DNTPersianUtils.Core/PersianNumbersUtils.cs
    /// </summary>
    /// <param name="data">English number</param>
    /// <returns></returns>
    public static string ToPersianNumbers(this string? data)
    {
        if (data is null)
        {
            return string.Empty;
        }

        var dataChars = data.ToCharArray();
        for (var i = 0; i < dataChars.Length; i++)
        {
            switch (dataChars[i])
            {
                case '0':
                case '\u0660':
                    dataChars[i] = '\u06F0';
                    break;

                case '1':
                case '\u0661':
                    dataChars[i] = '\u06F1';
                    break;

                case '2':
                case '\u0662':
                    dataChars[i] = '\u06F2';
                    break;

                case '3':
                case '\u0663':
                    dataChars[i] = '\u06F3';
                    break;

                case '4':
                case '\u0664':
                    dataChars[i] = '\u06F4';
                    break;

                case '5':
                case '\u0665':
                    dataChars[i] = '\u06F5';
                    break;

                case '6':
                case '\u0666':
                    dataChars[i] = '\u06F6';
                    break;

                case '7':
                case '\u0667':
                    dataChars[i] = '\u06F7';
                    break;

                case '8':
                case '\u0668':
                    dataChars[i] = '\u06F8';
                    break;

                case '9':
                case '\u0669':
                    dataChars[i] = '\u06F9';
                    break;
            }
        }

        return new string(dataChars);
    }

    /// <summary>
    /// Converts Persian and Arabic digits of a given string to their equivalent English digits.
    /// src : https://github.com/VahidN/DNTPersianUtils.Core/blob/master/src/DNTPersianUtils.Core/PersianNumbersUtils.cs
    /// </summary>
    /// <param name="data">Persian number</param>
    /// <returns></returns>
    public static string ToEnglishNumbers(this string? data)
    {
        if (data is null)
        {
            return string.Empty;
        }

        var dataChars = data.ToCharArray();
        for (var i = 0; i < dataChars.Length; i++)
        {
            switch (dataChars[i])
            {
                case '\u06F0':
                case '\u0660':
                    dataChars[i] = '0';
                    break;

                case '\u06F1':
                case '\u0661':
                    dataChars[i] = '1';
                    break;

                case '\u06F2':
                case '\u0662':
                    dataChars[i] = '2';
                    break;

                case '\u06F3':
                case '\u0663':
                    dataChars[i] = '3';
                    break;

                case '\u06F4':
                case '\u0664':
                    dataChars[i] = '4';
                    break;

                case '\u06F5':
                case '\u0665':
                    dataChars[i] = '5';
                    break;

                case '\u06F6':
                case '\u0666':
                    dataChars[i] = '6';
                    break;

                case '\u06F7':
                case '\u0667':
                    dataChars[i] = '7';
                    break;

                case '\u06F8':
                case '\u0668':
                    dataChars[i] = '8';
                    break;

                case '\u06F9':
                case '\u0669':
                    dataChars[i] = '9';
                    break;
            }
        }

        return new string(dataChars);
    }
    
    /// <summary>
    /// Converts English digits of a given number to their equivalent Persian digits.
    /// src : https://github.com/VahidN/DNTPersianUtils.Core/blob/master/src/DNTPersianUtils.Core/PersianNumbersUtils.cs
    /// </summary>
    public static string ToPersianNumbers(this int number, string format = "")
    {
        return ToPersianNumbers(!string.IsNullOrEmpty(format) ?
            number.ToString(format, CultureInfo.InvariantCulture) : number.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Converts English digits of a given number to their equivalent Persian digits.
    /// src : https://github.com/VahidN/DNTPersianUtils.Core/blob/master/src/DNTPersianUtils.Core/PersianNumbersUtils.cs
    /// </summary>
    public static string ToPersianNumbers(this long number, string format = "")
    {
        return ToPersianNumbers(!string.IsNullOrEmpty(format) ?
            number.ToString(format, CultureInfo.InvariantCulture) : number.ToString(CultureInfo.InvariantCulture));
    }
}