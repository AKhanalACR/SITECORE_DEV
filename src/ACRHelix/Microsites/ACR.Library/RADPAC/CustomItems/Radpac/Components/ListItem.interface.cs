using System;
using ACR.Library.Common.Interfaces;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.Library.Radpac.CustomItems.Radpac.Components
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
            get { return this.ListItemUrl.Url; }
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
    		get { return null; }
    	}

    	public DateTime LiDate
    	{
    		get { return new DateTime(); }
    	}

    	public MediaItem LiImage
        {
            get { return  this.ListImage.MediaItem  ; }
        }

        
    }
}
