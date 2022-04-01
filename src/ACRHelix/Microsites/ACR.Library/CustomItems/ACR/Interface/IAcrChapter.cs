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
	public interface IAcrChapter
	{
		CustomImageField ChapterHeaderImage { get; }
		CustomImageField InformationImage { get; }
		CustomTextField InformationDescription { get; }
		CustomGeneralLinkField InformationLink { get; }
		string InformationHeader { get; }
		CustomImageField MembershipImage { get; }
		CustomTextField MembershipDescription { get; }
		CustomGeneralLinkField MembershipLink { get; }
		string ChapterWebsiteUrl { get; }
		CustomGeneralLinkField JoinUs { get; }
		CustomTreeListField ChapterResources { get; }
		CustomImageField ChapterLogo { get; }
		CustomTextField IntroText { get; }
	}
}
