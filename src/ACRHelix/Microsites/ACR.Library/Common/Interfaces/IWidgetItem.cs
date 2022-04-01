using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.Common.Interfaces
{
    [FactoryInterface]
    public interface IWidgetItem
    {
        Item WidgetSublayout { get; }
        Item WidgetDisplayWhen { get; }
    }
}
