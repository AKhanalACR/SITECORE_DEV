using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Widgets;
using ACR.Library.Reference;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Masters;
using Sitecore;

namespace ACR.Library.InsertRules
{
	internal class WidgetInsertRule : InsertRule
	{
		public WidgetInsertRule(System.Int32 count)
		{
		}

		public override void Expand(List<Item> insertOptions, Item item)
		{
			//String widgetLocID = "{4F402508-7339-4781-952F-B3E64F80D71C}";
			//Database database = Sitecore.Data.Database.GetDatabase("master");
			//Item widgetLoc = database.GetItem(new Sitecore.Data.ID(widgetLocID));

			if (ItemReference.Templates_Widget_Location != null && ItemReference.Templates_Widget_Location.InnerItem != null)
			{
				foreach (Item i in ItemReference.Templates_Widget_Location.InnerItem.Axes.GetDescendants())
				{
					if (i.Fields["__Base template"] != null && i.Fields["__Base template"].Value.Contains(WidgetBaseItem.TemplateId))
					{
						insertOptions.Add(i);
					}

				}
			}
		}
	}
}
