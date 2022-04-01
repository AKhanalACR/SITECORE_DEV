using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface ICourseMaterials
	{
		CustomImageField CourseMaterialsImage { get; }
		CustomTextField CourseMaterialsTitle { get; }
		CustomTextField CourseMaterialsDescription { get; }
		CustomGeneralLinkField CourseMaterialsLink { get; }
	}
}