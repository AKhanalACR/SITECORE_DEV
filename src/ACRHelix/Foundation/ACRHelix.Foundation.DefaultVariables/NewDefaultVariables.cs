using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Data;
using Sitecore.Data.Items;

namespace ACRHelix.Foundation.DefaultVariables
{
    public class NewDefaultVariables : MasterVariablesReplacer
    {
        public override string Replace(string text, Item targetItem)
        {
            Sitecore.Diagnostics.Assert.ArgumentNotNull(text, "text");
            Sitecore.Diagnostics.Assert.ArgumentNotNull(targetItem, "targetItem");
            string tempTxt = text;

            if (text.Contains("$parentNewsType"))
            {
                var type = targetItem.Parent.Fields["Type"];
                tempTxt = text.Replace("$parentNewsType", type != null ? type.ToString(): "");
            }

            return base.Replace(tempTxt, targetItem);
        }
    }
}
