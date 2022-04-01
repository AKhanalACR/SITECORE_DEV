using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;

namespace ACR.Library.CustomItems.AIRP.Interfaces
{
	[FactoryInterface]
	public interface IAIRPNav
	{
		bool IncludeInTopNav { get; }
		string NavTitle { get; }
	}
}