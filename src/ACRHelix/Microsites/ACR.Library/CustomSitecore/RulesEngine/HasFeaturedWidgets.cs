using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace ACR.Library.CustomSitecore.RulesEngine
{
	public class HasFeaturedWidgets<T> : WhenCondition<T>
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

			
            IFeaturedWidgetsPage featuredWidgetsItem = ItemInterfaceFactory.GetItem<IFeaturedWidgetsPage>(ruleContext.Item);

            return featuredWidgetsItem != null;
		}
	}
}
