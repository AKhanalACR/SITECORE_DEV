using ACR.Library.CustomItems.ACR.Interface;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ACR.Membership
{
public partial class ChapterLandingItem : IAcrChapter
{
	public CustomImageField InformationImage
	{
		get { return AboutUsImage; }
	}

	public CustomTextField InformationDescription
	{
		get { return AboutUsDescription; }
	}

	public CustomGeneralLinkField InformationLink
	{
		get { return AboutUsLink; }
	}

	public string InformationHeader
	{
		get { return "About Us"; }
	}

	public string ChapterWebsiteUrl
	{
		get { return string.Empty; }
	}

	public CustomTextField IntroText
	{
		get { return BasePage.BodyText; }
	}
}
}