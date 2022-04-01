using ACR.Library.CustomItems.ACR.Interface;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Membership
{
public partial class ChapterLandingLiteItem : IAcrChapter
{
	public CustomImageField InformationImage
	{
		get { return ContactInformationImage; }
	}

	public CustomTextField InformationDescription
	{
		get { return ContactInformationDescription; }
	}

	public CustomGeneralLinkField InformationLink
	{
		get { return ContactInformationLink; }
	}

	public string InformationHeader
	{
		get { return "Contact Information"; }
	}

	public string ChapterWebsiteUrl
	{
		get { return ChapterWebsite.Url; }
	}

	public CustomGeneralLinkField JoinUs
	{
		get { return InformationLink; }
	}

	public CustomTextField IntroText
	{
		get { return BasePage.BodyText; }
	}
}
}