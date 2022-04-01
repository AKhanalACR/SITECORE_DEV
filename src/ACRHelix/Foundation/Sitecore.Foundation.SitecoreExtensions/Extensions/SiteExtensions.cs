namespace Sitecore.Foundation.SitecoreExtensions.Extensions
{
  using Sitecore.Data;
  using Sitecore.Data.Items;
  using Sitecore.Sites;
  using System;

  public static class SiteExtensions
  {

    public static SiteContext GetContextSiteEE(this SiteContext context)
    {
      try
      {
        if (Sitecore.Context.PageMode.IsExperienceEditor)
        {
          if (Sitecore.Context.Item != null)
          {
            var parent = Context.Item.Parent;
            while (parent != null && parent.ID.ToString() != "{0DE95AE4-41AB-4D01-9EB0-67441B7C2450}")//sitecore/content item id
            {
              if (parent.IsDerived("{51F37B1B-DF39-4D09-9BAC-756F26CE7D2D}"))//Foundation _Site template
              {
                var path = parent.Paths.FullPath;

                foreach (var site in Sitecore.Sites.SiteManager.GetSites())
                {
                  string rootPath = site.Properties["rootPath"];
                  if (!string.IsNullOrWhiteSpace(rootPath))
                  {
                    if (path.ToLower() == rootPath.ToLower())
                    {
                      context = SiteContextFactory.GetSiteContext(site.Name);
                    }
                  }
                }
              }
              parent = parent.Parent;
            }
          }
        }
      }
      catch (Exception ex)
      {
        //Sitecore.Diagnostics.Log.Error("Error fixing site root, using default", ex, context);
      }
      return context;
    }


    public static Item GetContextItem(this SiteContext site, ID derivedFromTemplateID)
    {
      if (site == null)
        throw new ArgumentNullException(nameof(site));

      var startItem = site.GetStartItem();
      return startItem?.GetAncestorOrSelfOfTemplate(derivedFromTemplateID);
    }

    public static Item GetRootItem(this SiteContext site)
    {
      if (site == null)
        throw new ArgumentNullException(nameof(site));

      return site.Database.GetItem(site.RootPath);
    }

    public static Item GetStartItem(this SiteContext site)
    {
      if (site == null)
        throw new ArgumentNullException(nameof(site));

      return site.Database.GetItem(site.StartPath);
    }
  }
}