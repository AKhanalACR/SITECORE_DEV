using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ACR.Constants
{
    public class Types
    {
        public struct Fields
        {
            //Content
            public const string Headline = "Headline";
            public const string MainContent = "Main Content";
            public const string Teaser = "Teaser";

            // Hero Internal
            public const string InternalHeroImage = "{1F74A4AD-EDCC-43EA-9FDB-C4A002FF74D6}";
            public const string InternalHeroHeadline = "{E8F8157F-459E-4BD3-86A5-CDF51B73F66E}";
            public const string InternalHeroContent = "{F72AD1B4-1E12-48BE-BA7C-5A4C0731A421}";
            public const string InternalHeroLink = "{A7C860E7-38D9-437D-A9A1-01B6249510B0}";
            public const string HeroLinkText = "Hero Link Text";

            public const string HeroBackgroundColorCssClass = "Color Css Class";

            //Navigation
            public const string NavNameOverride = "Name Override";
            public const string NavURLRedirect = "URL Redirect";
            public const string NavRedirectRespCode = "Redirect Response Code";
            public const string NavHidden = "Hide From Navigation";
            public const string NavAlwaysShowChildren = "Always Show Children";
            public const string Utility = "Utility HTML";
            public const string NavigationContentTitle = "Navigation Content Title";
            public const string NavigationContent = "Navigation Content";
            public const string NavigationLinks = "Navigation Links";

            //footer fields
            //top left footer links
            public const string FooterMainLinkTL = "Main Link TL";
            public const string FooterSectionLinksTL = "Section Links TL";
            //bottom left footer links
            public const string FooterMainLinkBL = "Main Link BL";
            public const string FooterSectionLinksBL = "Section Links BL";
            //middle top footer links
            public const string FooterMainLinksMT = "Main Links MT";
            public const string FooterSectionLinksMT = "Section Links MT";
            //middle bottom footer links
            public const string FooterMainLinkMB = "Main Links MB";
            public const string FooterSectionLinksMB = "Section Links MB";
            //right top footer links
            public const string FooterMainLinkRT = "Main Link RT";
            public const string FooterSectionLinksRT = "Section Links RT";
            //right bottom footer links
            public const string FooterLinksRB = "Links RB";
            //right info footer
            public const string FooterAddress = "Address";
            public const string FooterLogin = "Login Link";
            //mobile only footer
            public const string FooterTopMobileLinks = "Top Mobile Links";
            public const string FooterBottomMobileLinks = "Bottom Mobile Links";

            //Home
            public const string HomeHeroImage = "Hero Image";
            public const string HomeHeroHeadline = "Hero Headline";
            public const string HomeHeroContent = "Hero Content";
            public const string HomeHeroLink = "Hero Link";
            public const string HomeHeroBackgroundColor = "Background Color";
            public const string HomeModalityHeader = "Modality Section Header";
            public const string HomeAwardsHeader = "Award Section Header";
            public const string HomeAwardsIntro = "Award Section Intro";
            public const string HomeAwardsContent = "Award Section Content";
            public const string HomeAwardsImages = "Award Section Images";
            public const string HomeCarouselHeader= "Carousel Section Header";
            public const string HomeCarouselContent = "Carousel Section Content";
            public const string HomeCarouselLink = "Carousel Section Link";
            public const string HomeCarouselLinkText = "Carousel Link Text";
            public const string HomeImageHeader = "Image Section Header";
            public const string HomeImageIntro = "Image Section Intro";
            public const string HomeImageContent = "Image Section Content";
            public const string HomeImageWiselyGently = "Image Section Images";

            //Setting
            public const string SettingName = "Setting Name";
            public const string SettingValue = "Setting Value";
            public const string SettingText = "Setting Details";

            //Date Info
            public const string StartDate = "Start Date";
            public const string EndDate = "End Date";

            //2 column fields
            public const string ColumnOne = "Column One Content";
            public const string ColumnTwo = "Column Two Content";

            //Modalities
            public const string ModalityHalfCircleIcon = "Half Circle Icon";
            public const string ModalityFullCircleIcon = "Full Circle Icon";
            public const string ModalityLinkText = "Modality Link Text";
            public const string ModalityRelatedProducts = "Related Products";
            public const string ModalityQuestionLink = "Questions Link";

            //javascript
            public const string JavascriptInclude = "Javascript Include";
            public const string Javascript = "Javascript";

            //Related Products
            public const string RelatedProductTitle = "Title";
            public const string RelatedProductImage = "Image";
            public const string RelatedProductLink = "Link";

            //Facility Seal
            public const string SealTitle = "Seal Title";
            public const string SealContent = "Intro Content";

            public const string FacilitySealImage = "Image";
            public const string FacilitySealContent = "Content";

            // Modality Step
            public const string ModalityStepTitle = "Step Title";
            public const string ModalityStepDetail = "Step Detail";
        }

        public struct Items
        {
            public const string Home = "{9C18DFD6-DF14-4721-8126-539D9FBAA12F}";
            public const string Modality = "{97D89791-55C2-4F38-B7BA-918C8D88713F}";
            public const string UtilityNav = "{1A62D87D-664A-4E22-BF47-920AE8BD2589}";
            public const string FooterNav = "{27D61ACE-A36E-489D-859A-F81BC29C2DF2}";

            //Search
            public const string SearchErrorMessage = "{C2F7B426-3DAD-4D8C-907B-5666D4319D59}";
            public const string ItemsPerPage = "{EB032DCE-6BA6-4F83-A198-DDA3A43564F9}";
            public const string SnippetsMaxLength = "{90C3075D-114A-4E34-BA8E-334AF99509C2}";
            public const string NoResultsMessage = "{69527DB3-99E5-4401-AFFD-C6381D3C2325}";
            public const string SearchResultsOverview = "{ABDD8A27-3C26-43D5-8738-F6F75E33EBA4}";
            public const string NoSearchTermsWarning = "{CA934FEA-B003-4EF6-B7BF-C3F3BBA6E833}";
            public const string SearchIndex = "{C86C674C-25CD-4820-A707-CD7454AA1935}";
        }

        public struct ItemUrls
        {
            public const string SearchResults = "/search?q=";
        }

            public struct Templates
        {
            public const string Modality = "{0B001275-50E5-4C10-BA3B-B72BB303499B}";
            public const string ModalityStep = "{3B5303FD-AFC3-49DF-82A4-D314EACEA0A2}";
            public const string Section = "{C4FDEB80-41EB-4CCC-9145-9792486E066B}";
            public const string Standard = "{004A3147-E50D-4FAF-A0CE-100C607B5235}";
            public const string TwoColumn = "{5B16AC5C-E7F9-4DA5-AF47-436B0E257409}";
            public const string FacilitySearch = "{823DF354-EEC9-4201-9C5C-E8C3668DDB4B}";
            public const string FacilitySeal = "{41E63B2A-5415-466C-883D-11BB67D68F51}";


        }

        public struct EditorButtonSources
        {
            public const string FeaturedContent = "{DAB9D0DB-1EDF-4C72-B846-B5216BAC9499}";
            public const string Resource = "{DEFB8BD1-D0EC-4D6E-A4AA-4388F600760B}";
        }
    }
}
