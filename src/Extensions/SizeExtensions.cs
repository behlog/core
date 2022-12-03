using Behlog.Core;

namespace Behlog.Extensions;


public static class SizeExtensions
{

    public static long FromKillobytes(this double value)
    {
        return Convert.ToInt64(
            Math.Floor(value / 1024));
    }

    public static double ToKillobytes(this long value)
    {
        return value / 1024;
    }

    public static long FromMegabytes(this double value)
    {
        return Convert.ToInt64(
            Math.Floor(value / Math.Pow(1024, 2)));
    }

    public static double ToMegabytes(this long value)
    {
        return value / (1024 * 1024);
    }

    public static string DisplayInFileSize(this long value, FileSizeUnit sizeUnit)
    {
        return (value / Math.Pow(1024, (Int64)sizeUnit)).ToString("0.00");
    }
    
}