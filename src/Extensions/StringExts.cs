using System.Text.RegularExpressions;

namespace Behlog.Extensions;

public static class StringExts 
{

    public static bool IsNullOrEmpty(this string input)
        => string.IsNullOrWhiteSpace(input);

    public static bool IsNotNullOrEmpty(this string input)
        => !IsNullOrEmpty(input);

    public static string MakeSlug(this string slug) =>
        slug == null
            ? null
            : Regex.Replace(slug,
                @"[^A-Za-z0-9\u0600-\u06FF_\.~]+", "-");
}