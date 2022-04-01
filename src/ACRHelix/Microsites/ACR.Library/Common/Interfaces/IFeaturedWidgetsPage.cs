using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;
using Sitecore.Data.Items;

namespace ACR.Library.Common.Interfaces
{
    [FactoryInterface]
    public interface IFeaturedWidgetsPage
    {
        List<Item> FeaturedWidgetItems { get; }
        int MaxNumberOfWidgets { get; }
    }
}
