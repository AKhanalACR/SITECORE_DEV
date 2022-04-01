using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
    public partial class HomePageItem : CustomItem
    {

        public static readonly string TemplateId = "{76064931-8B7F-49E3-B8DF-8EEF9AB65C44}";

        #region Inherited Base Templates

        private readonly MetadataItem _MetadataItem;
        public MetadataItem Metadata { get { return _MetadataItem; } }
        private readonly PageSettingsItem _PageSettingsItem;
        public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }

        #endregion

        #region Boilerplate CustomItem Code

        public HomePageItem(Item innerItem)
            : base(innerItem)
        {
            _MetadataItem = new MetadataItem(innerItem);
            _PageSettingsItem = new PageSettingsItem(innerItem);

        }

        public static implicit operator HomePageItem(Item innerItem)
        {
            return innerItem != null ? new HomePageItem(innerItem) : null;
        }

        public static implicit operator Item(HomePageItem customItem)
        {
            return customItem != null ? customItem.InnerItem : null;
        }

        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods


        public CustomTextField SpotlightVideo
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Spotlight Video"]);
            }
        }


        public CustomImageField SpotlightImage
        {
            get
            {
                return new CustomImageField(InnerItem, InnerItem.Fields["Spotlight Image"]);
            }
        }


        public CustomTextField IntroductoryTitle
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Introductory Title"]);
            }
        }


        public CustomTextField IntroductoryText
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Introductory Text"]);
            }
        }


        public CustomCheckboxField IncludeCallout
        {
            get
            {
                return new CustomCheckboxField(InnerItem, InnerItem.Fields["Include Callout"]);
            }
        }


        public CustomTextField CalloutText
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Callout Text"]);
            }
        }


        public CustomTextField CalloutButton
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Callout Button"]);
            }
        }


        public CustomTextField NewsTitle
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["News Title"]);
            }
        }


        public CustomMultiListField NewsItems
        {
            get
            {
                return new CustomMultiListField(InnerItem, InnerItem.Fields["News Items"]);
            }
        }


        public CustomTextField TopReadsTitle
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Top Reads Title"]);
            }
        }


        public CustomTextField TopReadsText
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Top Reads Text"]);
            }
        }


        public CustomTextField CommitmentTitle
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Commitment Title"]);
            }
        }


        public CustomTextField CommitmentText
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Commitment Text"]);
            }
        }


        public CustomTextField AdditionalTitle
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Additional Title"]);
            }
        }


        public CustomTextField AdditionalText
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Additional Text"]);
            }
        }


        public CustomTextField PledgeText
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["Pledge Text"]);
            }
        }


        public CustomImageField RSNAJournalCover
        {
            get
            {
                return new CustomImageField(InnerItem, InnerItem.Fields["RSNA Journal Cover"]);
            }
        }


        public CustomTextField RSNAJournalText
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["RSNA Journal Text"]);
            }
        }


        public CustomGeneralLinkField RSNAJournalLink
        {
            get
            {
                return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["RSNA Journal Link"]);
            }
        }


        public CustomTextField RSNAJournalName
        {
            get
            {
                return new CustomTextField(InnerItem, InnerItem.Fields["RSNA Journal Name"]);
            }
        }


        #endregion //Field Instance Methods
    }
}