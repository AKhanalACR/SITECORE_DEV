using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ACR.Foundation.Utilities.Hash
{
  public static class HashGenerator
  {
    public static string GetHashFromString(string s)
    {
      using (SHA256 hash = SHA256Managed.Create())
      {
        return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(s)).Select(x => x.ToString("x2")));
      }
    }

    public static string GetHashFromFile(string filePath)
    {
      string version = "1";
      try
      {
        if (System.IO.File.Exists(filePath))
        {
          byte[] contents = System.IO.File.ReadAllBytes(filePath);
          using (SHA256 hash = SHA256Managed.Create())
          {
            version = string.Concat(hash.ComputeHash(contents).Select(x => x.ToString("x2")));
          }
        }
      }
      catch (Exception ex)
      {
        return DateTime.Now.Ticks.ToString();
      }
      return version;
    }
  }
}