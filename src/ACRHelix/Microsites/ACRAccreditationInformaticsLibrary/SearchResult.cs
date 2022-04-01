using System;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using ACR.Constants;
using Sitecore.Data.Items;

namespace ACRAccreditationInformaticsLibrary
{
    public class SearchResult : SearchResultItem
    {
        [IndexField("_group")]
        public virtual Guid Id { get; set; }

        [IndexField("_name")]
        public virtual string Name { get; set; }

        [IndexField("category")]
        public virtual string Category { get; set; }

        [IndexField("description")]
        public virtual string Description { get; set; }

        [IndexField("keywords")]
        public virtual string Keywords { get; set; }

        [IndexField("name_override")]
        public virtual string NameOverride { get; set; }

        [IndexField("content_title")]
        public virtual string ContentTitle { get; set; }     

        [IndexField("short_description")]
        public virtual string ShortDescription { get; set; }

        public string friendlyName
        {
            get
            {
                return ItemHelper.GetFieldValueOrItemName(this.GetItem(), Types.Fields.NavNameOverride);
            }
        }


        public string ItemDescription
        {
            get
            {
                Item item = this.GetItem();
                return item["Description"];
            }
        }

        public Item ResultItem
        {
            get
            {   
                return GetItem();
            }
        }

        [IndexField("_content")]
        public virtual string IndexDefaultContent { get; set; }



        //msl fields

        [IndexField("title")]
        public virtual string Title { get; set; }

        [IndexField("body")]
        public virtual string Body
        {
            get; set;
        }

        public string MSLFiendlyName
        {
            get
            {
                string title = null;
                if(this.GetItem().Fields["Title"] != null)
                    title = this.GetItem().Fields["Title"].ToString();

                if (string.IsNullOrWhiteSpace(title))
                {
                    if(this.GetItem().Fields["Navigation Title"] != null)
                        title = this.GetItem().Fields["Navigation Title"].ToString();
                }

                // Addis 4/27/2017
                if (string.IsNullOrWhiteSpace(title))
                {
                    if (this.GetItem().Fields["Name"] != null)
                        title = this.GetItem().Fields["Name"].ToString();
                }

                if (string.IsNullOrWhiteSpace(title))
                {
                    if (this.GetItem().Fields["Page Title"] != null)
                        title = this.GetItem().Fields["Page Title"].ToString();
                }

                if (string.IsNullOrWhiteSpace(title))
                {
                    if (this.GetItem().Fields["Meta Title"] != null)
                        title = this.GetItem().Fields["Meta Title"].ToString();
                }
                //---

                if (string.IsNullOrWhiteSpace(title))
                {
                    title = this.GetItem().Name;
                }
                return title;
            }
        }
    }
}
