using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Utilities
{
  public static class XBlogUtility
  {
    public static string ParseBlogPublishDate(DateTime publishDate)
    {
      string formatedDate = "";
      string month = "";
      switch(publishDate.Month)
            {
        case 1: 
          month = "January"; break;
        case 2:
          month = "February"; break;
        case 3:
          month = "March"; break;
        case 4:
          month = "April"; break;
        case 5:
          month = "May"; break;
        case 6:
          month = "June"; break;
        case 7:
          month = "July"; break;
        case 8:
          month = "August"; break;
        case 9:
          month = "September"; break;
        case 10:
          month = "October"; break;
        case 11:
          month = "November"; break;
        case 12:
          month = "December"; break;
        default:
          month = " "; break;
      }
      string year = publishDate.Year.ToString();
      string day = publishDate.Day.ToString();
      formatedDate = month + " " + day + ", " + year;
      return formatedDate;
    }

    public static string ParseBlogCategories(string categoryIdList)
    {
      string categoyNameList = "";
      if (!String.IsNullOrEmpty(categoryIdList))
      {
        string[] categoryIds = categoryIdList.Split('|');
        foreach (var categoryId in categoryIds)
        {
          string CategoryUrl = "DSIBlog/category/" + Sitecore.Context.Database.Items.GetItem(categoryId).Name;
          CategoryUrl = CategoryUrl.Replace(" ", "%20");
          string CategoryName = Sitecore.Context.Database.Items.GetItem(categoryId).Name;
          string Categorylink = "<a href=" + CategoryUrl + ">"+ CategoryName + "</a>";
          categoyNameList = categoyNameList + Categorylink + ", ";          
        }
        char[] trimChars = { ';', ',', ' ' };
        categoyNameList = categoyNameList.TrimEnd(trimChars);
      }
      return categoyNameList;
    }

    public static string ParseBlogAuthors(string authorIdList)
    {
      string authorNameList = "";
      if (!String.IsNullOrEmpty(authorIdList))
      {
        string[] authorIds = authorIdList.Split('|');
        foreach (var authorId in authorIds)
        {
          authorNameList = authorNameList + Sitecore.Context.Database.Items.GetItem(authorId).Name + "; ";
        }
        char[] trimChars = { ';', ',', ' ' };
        authorNameList = authorNameList.TrimEnd(trimChars);
      }
      return authorNameList;
    }

    public static string SafeSubstring(this string text, int maxLength, bool dots)
    {
      if (string.IsNullOrEmpty(text) || text.Length < maxLength)
        return text;
      int length = Math.Min(text.LastIndexOf(' ', maxLength), maxLength);
      string substring = length <= 0 ? text.Substring(0, maxLength) : text.Substring(0, length);
      return string.Format("{0}{1}", substring, dots ? "..." : string.Empty);
    }
    public static string SubstringHtml(string stringValue, int length, bool dots)
    {
      var regexAllTags = new Regex(@"<[^>]*>");
      var regexIsTag = new Regex(@"<|>");
      var regexOpen = new Regex(@"<[^/][^>]*>");
      var regexClose = new Regex(@"</[^>]*>");
      var regexAttribute = new Regex(@"<[^ ]*");

      int necessaryCount = 0;
      var stringLength = regexAllTags.Replace(stringValue, "").Length;
      if (stringLength <= length)
      {
        return stringValue;
      }
      string[] split = regexAllTags.Split(stringValue);
      string counter = "";
      foreach (string item in split)
      {
        if (counter.Length < length && counter.Length + item.Length >= length)
        {
          necessaryCount = stringValue.IndexOf(item, counter.Length) + item.Substring(0, length - counter.Length).Length;
          break;
        }
        counter += item;
      }
      var x = regexIsTag.Match(stringValue, necessaryCount);
      if (x.Value == ">")
      {
        necessaryCount = x.Index + 1;
      }
      string subs = stringValue.Substring(0, necessaryCount);
      var openTags = regexOpen.Matches(subs);
      var closeTags = regexClose.Matches(subs);
      List<string> OpenTags = new List<string>();
      foreach (var item in openTags)
      {
        string trans = regexAttribute.Match(item.ToString()).Value;

        if (trans.Last() == '>')
        {
          trans = "</" + trans.Substring(1, trans.Length - 1);
        }
        else
        {
          trans = "</" + trans.Substring(1, trans.Length - 1) + ">";
        }

        OpenTags.Add(trans);
      }
      foreach (System.Text.RegularExpressions.Match close in closeTags)
      {
        OpenTags.Remove(close.Value);
      }
      subs = string.Format("{0}{1}", subs, dots ? "..." : string.Empty); ;
      for (int i = OpenTags.Count - 1; i >= 0; i--)
      {
        subs += OpenTags[i];
      }
      return subs;
    }
  }
}