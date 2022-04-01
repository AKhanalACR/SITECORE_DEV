using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.RLI.Pages;
using Sitecore;
using Sitecore.CodeDom.Scripts;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Layouts;
using Sitecore.Reflection;
using Sitecore.Rules;
using Sitecore.Rules.Actions;
using Sitecore.Rules.ConditionalRenderings;
using Sitecore.Rules.Conditions;

namespace ACR.Library.CustomSitecore.RulesEngine
{
	[UsedImplicitly]
	public class SetFeaturedWidgets<T> : RuleAction<T>
		where T : ConditionalRenderingsRuleContext
	{
		public override void Apply(T ruleContext)
		{
			//make sure we get a rule context
			Assert.ArgumentNotNull(ruleContext, "ruleContext");

			//if we aren't dealing with the first rendering reference, then return
			//we do this because we only want to add our widgets once.  This code will execute
			//for each Reference in the References collection and this is a way to eliminate
			//executing more than once.
			if (!ruleContext.Reference.RenderingID.Equals(ruleContext.References[0].RenderingID))
			{
				return;
			}

            IFeaturedWidgetsPage featuredWidgetsItem = ItemInterfaceFactory.GetItem<IFeaturedWidgetsPage>(ruleContext.Item);
            if (featuredWidgetsItem == null)
                return;

            List<Item> widgets = GetFeaturedWidgets(featuredWidgetsItem);

			//if we don't have any widgets, just return
			if (widgets == null || !widgets.Any())
			{
				return;
			}

			int widgetCount = 0;

			//loop through each widget - only add as many as the Max number of widgets specified
			foreach (Item widget in widgets)
			{
                if (widgetCount == featuredWidgetsItem.MaxNumberOfWidgets)
                    break;

                if (widget == null)
                    return;

				//get our widget as a widget base
                IWidgetItem widgetItem = ItemInterfaceFactory.GetItem<IWidgetItem>(widget);
                if (widgetItem == null)
                    return;

                
				//validate if we should display this widget,
				//if not continue to the next
                if (!DisplayWidget(ruleContext, widgetItem))
				{
					continue;
				}

				//create our rendering reference from our sublayout item.  We will add this to our
				//rendering references collection
                RenderingReference rendRef = new RenderingReference(widgetItem.WidgetSublayout);

				//set our datasource and placeholder for our rendering reference.
				rendRef.Settings.DataSource = widget.Paths.FullPath;
                rendRef.Placeholder = "FeaturedWidgets";
				rendRef.UniqueId = "widget" + widgetCount++;
                

				//add our rendering reference to our collection
				ruleContext.References.Add(rendRef);
			}
		}

	    /// <summary>
	    /// Will get widgets selected for the RLI HomePage
	    /// </summary>
	    /// <param name="widgetPage">The widget page to pull out widgets from.</param>
	    /// <returns>A list of widget items to add to the page.</returns>
        private List<Item> GetFeaturedWidgets(IFeaturedWidgetsPage widgetPageItem)
		{
			//if we don't have a widget page then return empty list
			if (widgetPageItem == null)
			{
				return new List<Item>(0);
			}

			//get our widgets from our widget page
			List<Item> widgets = new List<Item>();

            if (widgetPageItem.FeaturedWidgetItems != null)
            {
                widgets = widgetPageItem.FeaturedWidgetItems;
            }

			//return our widgets
			return widgets;
		}

		/// <summary>
		/// Will get the widgets conditional rules.
		/// </summary>
		/// <param name="widget">The widget to pull the rules from.</param>
		/// <returns>The widgets conditional rules.</returns>
		private List<RuleCondition<T>> GetWidgetRules(IWidgetItem widget)
		{
			//if we don't have a widget then return empty list
			if (widget == null)
			{
				return new List<RuleCondition<T>>(0);
			}

			//get any conditional validators we should run to validate our widget should be displayed
			//this was originally coded for multiple conditionals, but turns out there will only be one selected.
			//kept the code to handle multiple to be nice in case it was requested in the future.
			List<Item> conditionalItems = new List<Item>();
            if (widget.WidgetDisplayWhen != null)
			{
                conditionalItems.Add(widget.WidgetDisplayWhen);
			}

			//go through each item and pull out the conditional types
			List<Type> conditionalTypes = new List<Type>();
			foreach (Item conditionalItem in conditionalItems)
			{
				//if our conditional item is null then it doesn't have a proper type.
				//continue to the next
				if (conditionalItem == null)
				{
					continue;
				}

				//get our generic type from our item
				Type genericType = ItemScripts.GetGenericType<T>(conditionalItem);

				//if we have a generic type then add it to our list
				if (genericType != null)
				{
					conditionalTypes.Add(genericType);
				}
			}

			//for each type create our conditional rule
			List<RuleCondition<T>> conditionalRules = new List<RuleCondition<T>>();
			foreach (Type conditionalType in conditionalTypes)
			{
				//get our conditional rule from our type
				RuleCondition<T> conditionalRule = ReflectionUtil.CreateObject(conditionalType) as RuleCondition<T>;

				//if we have a conditional rule then add it to our list
				if (conditionalRule != null)
				{
					conditionalRules.Add(conditionalRule);
				}
			}

			//return our conditional rules
			return conditionalRules;
		}

		/// <summary>
		/// Whether or not we should display our widget.
		/// </summary>
		/// <param name="ruleContext">The rules context.</param>
		/// <param name="widget">The widget to display.</param>
		/// <returns>Whether or not the widget should be displayed.</returns>
		private bool DisplayWidget(T ruleContext, IWidgetItem widget)
		{
			if (widget == null)
			{
				return false;
			}

			//if our widget base doesn't have a selected sublayout, then return false.
			//we need a sublayout to render.
			if (widget.WidgetSublayout == null)
			{
				return false;
			}

			//get any conditional validators we should run to validate our widget should be displayed
			List<RuleCondition<T>> conditionalRules = GetWidgetRules(widget);

			//if we don't have any conditional rules then return true.
			if (conditionalRules == null || !conditionalRules.Any())
			{
				return true;
			}

			//run through our rules
			RuleStack ruleResults = new RuleStack();
			conditionalRules.ForEach(i => i.Evaluate(ruleContext, ruleResults));

			//return if any of our rules are false.
			//if any rules fail then we should not display
			return ruleResults.All(i => (bool) i);
		}
	}
}
