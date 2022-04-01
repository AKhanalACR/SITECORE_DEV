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
    [SitecoreItemTemplate(CommentTemplateId)]
    public class VORBlogComment : SitecoreItem, ICMSEntity
  {
    public const string CommentTemplateName = "VOR Blog Comments";
        public const string CommentTemplateId = "{24361175-3EC2-4F90-88E1-D17B14A9D47E}";
        public const string CommentFieldId = "{A29D5B5A-F910-4151-98B1-6A3D69F75162}";
        public const string CommentNameFieldId = "{3EAF6A5C-23F0-4B12-B59E-AFB3132D0164}";
        public const string CommentEmailFieldId = "{48689D9E-1FBD-44BB-80F2-48871E316A85}";
        public const string CommentParentItemFieldId = "{793E851E-225F-4982-A00A-9039121EBB41}";

    [SitecoreItemField(CommentFieldId)]
        public virtual string Comment{get; set; }

        [SitecoreItemField(CommentNameFieldId)]
        public virtual string CommentName { get; set; }

        [SitecoreItemField(CommentEmailFieldId)]
        public virtual string Email { get; set; }

        [SitecoreItemField(CommentParentItemFieldId)]
        public virtual string ParentItemId { get; set; }

    
  }
}
