using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace ACR.Library.CustomSitecore.RulesEngine
{
  public class HasWidgetPageTemplate<T> : WhenCondition<T>
      where T : RuleContext
  {
    protected override bool Execute(T ruleContext)
    {
      //get our item from the rule context.
      //we will check our item for the appropriate base template.
      Item item = ruleContext.Item;

      //if we don't have an item then return false.
      //null doesn't have widget base template.
      if (item == null)
      {
        return false;
      }

      return item.IsDerived(ACR.Base.WidgetPageItem.TemplateId) || item.IsDerived(RLI.Base.WidgetPageBaseItem.TemplateId);
    }
  }
}
