using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Pipelines.HttpRequest;
using Sitecore.Data.Items;
using Sitecore.Pipelines.RenderLayout;

namespace Brookings.Library.CustomSitecore.Pipeline
{
    /// <summary>
    /// Custom Processor for tagging NewRelic transaction names with Sitecore Data Template name
    /// </summary>
    class NewRelicResolver : InsertRenderings
    {
        public override void Process(RenderLayoutArgs args)
        {
            Item currentItem = Sitecore.Context.Item;
            if(currentItem != null && !string.IsNullOrEmpty(currentItem.TemplateName))
            {
                NewRelic.Api.Agent.NewRelic.SetTransactionName("Webpage", currentItem.TemplateName);
            }          
        }
    }
}
