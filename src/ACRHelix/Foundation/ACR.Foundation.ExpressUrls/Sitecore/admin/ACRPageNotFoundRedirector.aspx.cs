using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore;
using ACR.Foundation.ExpressUrls.Data;
using ACR.Foundation.ExpressUrls.Cache;
using ACR.Foundation.ExpressUrls.Redirector;

namespace ACR.Foundation.ExpressUrls.PageNotFound
{
  public partial class ACRPageNotFoundRedirector : System.Web.UI.Page
  {

    private ExpressUrlCache _cache;

    private ExpressUrlCache ExpressUrlCache
    {
      get
      {
        if (_cache == null)
        {
          _cache = new ExpressUrlCache(StringUtil.ParseSizeString("10MB"));
        }
        return _cache;
      }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void upload_Click(object sender, EventArgs e)
    {
      if (Sitecore.Context.User.IsAdministrator)
      {
        if (fileUpload.HasFile)
        {
          string filePath = Server.MapPath("/App_Data") + "acr-redirects.csv";
          fileUpload.SaveAs(filePath);

          using (ExpressUrlDatabase db = new ExpressUrlDatabase())
          {
            using (TextReader tr = new StreamReader(filePath))
            {
              var csv = new CsvHelper.CsvReader(tr);

              DateTime startDate = DateTime.Now.AddMinutes(2);
              int i = 0;
              while (csv.Read())
              {
                if (i > 0)
                {
                  string oldUrl = csv.GetField(0);
                  string newUrl = csv.GetField(1);

                  oldUrl = oldUrl.Replace("http://www.acr.org", "");
                  oldUrl = oldUrl.Replace("https://www.acr.org", "");
                  oldUrl = oldUrl.ToLower();

                  var url = new PageNotFoundRedirect()
                  {
                    NewUrl = newUrl,
                    NotFoundUrl = oldUrl,
                    DateModified = startDate
                  };

                  var existing = db.PageNotFoundRedirects.FirstOrDefault(x => x.NotFoundUrl == url.NotFoundUrl);
                  if (existing != null)
                  {
                    existing.NewUrl = url.NewUrl;
                    existing.DateModified = url.DateModified;
                  }
                  else
                  {
                    db.PageNotFoundRedirects.Add(url);
                  }
                  db.SaveChanges();
                }
                i++;
              }

              var deleteDate = startDate.AddMinutes(-2);
              var oldUrls = db.PageNotFoundRedirects.Where(x => x.DateModified < deleteDate);

              foreach (var old in oldUrls)
              {
                db.PageNotFoundRedirects.Remove(old);
              }
              db.SaveChanges();

            }
          }

          ExpressUrlCache.Set(PageNotFoundRedirector.PageNotFoundCacheKey, null);

        }
      }
      else
      {
        Response.StatusCode = 403;
      }
    }
  }

  public class CSVRedirectData
  {

    public string OldUrl { get; set; }

    public string NewUrl { get; set; }

  }
}