using System;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.Common.Interfaces
{
		[FactoryInterface]
    public interface IPageItem
    {
        String PageTitle { get; }
        String NavTitle { get; }
        String NavUrl { get; }
        String NavTarget { get; }
    }
    
}
