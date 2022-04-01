using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.RLI.Interfaces
{
    [FactoryInterface]
    public interface IFeatured
    {
        string FeaturedTitle { get; }
        string FeaturedSubheader { get; }
        string FeaturedDescription { get; }
        string FeaturedUrl { get; }
    }
}
