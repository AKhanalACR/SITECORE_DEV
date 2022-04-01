using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;
using Sitecore.Data.Items;

namespace ACR.Library.Common.Interfaces
{
    [FactoryInterface]
    public interface IWidgetPage
    {
        List<Item> WidgetItems { get; }
    }
}
