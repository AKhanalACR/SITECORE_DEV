using System;
using System.Collections.Generic;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.Common.Interfaces
{
		[FactoryInterface]
    public interface IListPage
    {
        IEnumerable<IListItem> ListItems { get; }
        IEnumerable<String> HeaderTitles { get; }
        Boolean DisplayHeaderBookmarks { get; }
    }
}
