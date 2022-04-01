using Sitecore.Diagnostics;
using Sitecore.Pipelines;

namespace ACR.Foundation.CookieBot.Processor
{
  public class CookieBotAnalyticsPreProcessor
  {
    public virtual void Process(PipelineArgs args)
    {
      Assert.ArgumentNotNull((object)args, "args");

      if (!CookieBotModule.CookieBotHttpModule.CookiesAllowed().StatisticCookiesAllowed)
      {

        args.AbortPipeline();
      }

    }

  }
}