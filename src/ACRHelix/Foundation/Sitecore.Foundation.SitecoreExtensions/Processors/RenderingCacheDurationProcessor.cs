using Sitecore.Diagnostics;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Foundation.SitecoreExtensions.Processors
{
  public class RenderingCacheDurationProcessor : RenderRenderingProcessor
  {
    private const string ParamKey = "CacheDuration";
    public override void Process(RenderRenderingArgs args)
    {
      Assert.ArgumentNotNull(args, nameof(args));
      if (args.Rendered || !args.Cacheable || string.IsNullOrEmpty(args.CacheKey)) return;

      var rendering = args.PageContext.Database.GetItem(args.Rendering.RenderingItem.ID);
      if (string.IsNullOrEmpty(rendering?[ParamKey])) return;

      int duration;
      if (!int.TryParse(rendering[ParamKey], out duration) || duration <= 0) return;

      var timeStamp = RoundUp(DateTime.UtcNow, TimeSpan.FromMinutes(duration));
      args.CacheKey += "_#timeStamp:" + timeStamp.ToString("s");
    }

    private static DateTime RoundUp(DateTime dateTime, TimeSpan timeSpan)
    {
      return new DateTime((dateTime.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks * timeSpan.Ticks);
    }
  }
}