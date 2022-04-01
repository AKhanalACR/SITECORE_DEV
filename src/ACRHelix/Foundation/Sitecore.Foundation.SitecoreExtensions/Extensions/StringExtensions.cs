namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
  using System;
  using System.Text.RegularExpressions;

  public static class StringExtensions
  {
    public static string Humanize(this string input)
    {
      return Regex.Replace(input, "(\\B[A-Z])", " $1");
    }

    public static string ToCssUrlValue(this string url)
    {
      return string.IsNullOrWhiteSpace(url) ? "none" : $"url('{url}')";
    }

    public static bool ContainsIgnoreCase(this string source, string toCheck)
    {
      return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    public static string ReplaceStringIgnoreCase(this string str, string find, string replace, StringComparison comparison, bool recursive)
    {
      int index = str.IndexOf(find, comparison);

      while (index > -1)
      {
        str = str.Remove(index, find.Length);
        str = str.Insert(index, replace);

        if (!recursive)
        {
          return str;
        }
        index = str.IndexOf(find, index + replace.Length, comparison);
      }

      return str;
    }
  }
}