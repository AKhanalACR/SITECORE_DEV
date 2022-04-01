using System.Linq;
using System.Web.Mvc;
using Sitecore.Data;
using Sitecore.Mvc.Presentation;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Sitecore.Foundation.SitecoreExtensions.RenderingExtensions
{
  public static class RenderingExtensions
  {
    public static string GetBackgroundClass([NotNull] this Rendering rendering)
    {
      string background = string.Empty;

      var id = MainUtil.GetID(rendering.Parameters[Constants.BackgroundCssClass.BackgroundParameterFieldName] ?? "", null);
      if (!ID.IsNullOrEmpty(id))
      {
        var item = rendering.RenderingItem.Database.GetItem(id);
        if (item != null)
        {
          background = item?[Constants.BackgroundCssClass.CssClassFieldName] ?? "";
        }
      }
      return background;
    }

    public static string GetImageLeftRightClass([NotNull] this Rendering rendering,string defaultClass)
    {
      string imageClass = defaultClass;
      var id = MainUtil.GetID(rendering.Parameters[Constants.ImageLocationCss.ImageLocationParameterFieldName] ?? "", null);
      if (!ID.IsNullOrEmpty(id))
      {
        var item = rendering.RenderingItem.Database.GetItem(id);
        if (item != null)
        {
          imageClass = item?[Constants.ImageLocationCss.CssClassFieldName] ?? "";
        }
      }
      return imageClass;
    }

    public static string GetOppositeImageLeftRightClass([NotNull] this Rendering rendering)
    {
      string imageClass = string.Empty;
      var id = MainUtil.GetID(rendering.Parameters[Constants.ImageLocationCss.ImageLocationParameterFieldName] ?? "", null);
      if (!ID.IsNullOrEmpty(id))
      {
        var item = rendering.RenderingItem.Database.GetItem(id);
        if (item != null)
        {
          imageClass = item?[Constants.ImageLocationCss.CssClassFieldName] ?? "";
        }
      }
      //tolower and then swap left and right
      imageClass = imageClass.ToLower();
      if (imageClass.Contains("left"))
      {
        imageClass = imageClass.Replace("left", "right");
      }
      else
      {
        imageClass = imageClass.Replace("right", "left");
      }

      return imageClass;
    }

    public static bool DisplayHeader([NotNull] this Rendering rendering)
    {
      bool displayHeader = false;

      string header = rendering.Parameters[Constants.Header.DisplayHeaderParamterFieldName];
      if (header != null)
      {
        if (header == "1")
        {
          displayHeader = true;
        }
      }
      return displayHeader;
    }

    public static string GetNoContainCss([NotNull] this Rendering rendering)
    {
      string css = string.Empty;
      string pfield = rendering.Parameters[Constants.ImageLocationCss.OverflowImageFieldName];
      if (pfield == "1")
      {
        css = "image-no-contain";
      }
      return css;
    }
  }
}