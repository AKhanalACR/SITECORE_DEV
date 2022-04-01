using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
    public partial class ListItem : IListItem
    {
        public string LiTopic
        {
            get
            {
                if(this.InnerItem.Parent.TemplateID.ToString() == ListHeaderItem.TemplateId)
                {
                    ListHeaderItem listHeaderItem = this.InnerItem.Parent;
                    return listHeaderItem.Title.Text;
                }

                return String.Empty;
            }
        }

        public string LiTitle
        {
            get { return this.ListItemTitle.Text; }
        }

        public string LiDescription
        {
            get { return this.ListItemDescription.Rendered; }
        }

        public string LiUrl
        {
					get { return LinkUtils.GetLinkFieldUrl(this.ListItemUrl.Field); }
        }

        public string LiLinkTarget
        {
            get { return LinkUtils.GetLinkFieldTarget(this.ListItemUrl.Field); }
        }

        public bool LiIsPdf
        {
            get { return LinkUtils.IsPdfLink(this.ListItemUrl.Field); }
        }

        public string LiAssociatedPdfUrl
        {
            get
            {
                if (this.ListItemUrl.Field.IsInternal && ListItemUrl.Field.InternalPath != null)
                {
                    Item item = Sitecore.Context.Database.GetItem(ListItemUrl.Field.TargetItem.Paths.Path);
                    if(item != null && SitecoreUtils.IsValid(GeneralPageItem.TemplateId,item))
                    {
                        GeneralPageItem generalPageItem = item;
                        return generalPageItem.AssociatedPdfUrl;
                    }
                }
                return String.Empty;
            }
        }

    	public string LiType
    	{
				get { return string.Empty; }
    	}

    	public DateTime LiDate
    	{
    		get { return DateTime.MinValue; }
    	}

    	public MediaItem LiImage
        {
            get { return null; }
        }

        
    }
}
