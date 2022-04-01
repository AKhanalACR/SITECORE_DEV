using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sitecore.Feature.XBlog.Areas.XBlog.ItemMapper;
using Sitecore.Feature.XBlog.Areas.XBlog.ItemMapper.Configuration.Attributes;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using ACRHelix.Foundation.Model;


namespace Sitecore.Feature.XBlog.Areas.XBlog.Items.Blog
{
  [SitecoreItemTemplate("{364475A2-A952-40F6-8860-1808A7FA1E25}")]
  public class VORBlogEmail : SitecoreItem, ICMSEntity
  {

        [SitecoreItemField("{7FF29454-F062-449C-AC53-EB34F4A89E44}")]
        public virtual string From{get; set; }

        [SitecoreItemField("{19E0B0D9-4F2F-48F1-99DF-EDA1A19F0BEB}")]
        public virtual string TO { get; set; }

        [SitecoreItemField("{08F09720-173B-49D3-A84F-463B8257AA7A}")]
        public virtual string Body { get; set; }

        [SitecoreItemField("{3D9D6156-0756-4665-BD16-796E4FE48158}")]
        public virtual string Subject { get; set; }

    
  }
}
