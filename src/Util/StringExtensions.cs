using System.Text.RegularExpressions;

namespace src.Util;

internal static class StringExtensions
{
    private static Regex _onlyNumbersRegex = new Regex(@"[^\d]");

    public static string RemoveMask(this string value)
    {
        return _onlyNumbersRegex.Replace(value, string.Empty).Trim();
    }

    public static bool AllCharactersAreEqual(this string value)
    {
        return value.Distinct().Count() == 1;
    }
}