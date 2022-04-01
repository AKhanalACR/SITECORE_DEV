using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface IAcrEducationCenterFeature
	{
		string EducationFeatureTitle { get; }
		CustomImageField EducationFeatureThumbnail { get; }
		string EducationFeatureUrl { get; }
	}
}