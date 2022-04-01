using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public interface ISubmitTestimonialPage : ICMSEntity
    {
        ID Id { get; set; }

        //[SitecoreField("Edit Profile Page Url")]
        Link EditProfilePageUrl { get; set; }

        //[SitecoreField("Edit Profile Instruction")]
        string EditProfileInstruction { get; set; }

        //[SitecoreField("Upload Image Instruction")]
        string UploadImageInstruction { get; set; }

        //[SitecoreField("YouTube Link Help Text")]
        string YouTubeLinkHelpText { get; set; }

        //[SitecoreField("Engage Profile Help Text")]
        string EngageProfileHelpText { get; set; }

        [SitecoreQuery("../*[@@templateid = '{903CEA05-1BF5-4D6E-87CD-1727E909C841}']", IsRelative = true)]
        ITestimonialFolder TestimonialsFolder { get; set; }

        [SitecoreQuery("..//*[@@templateid = '{4A77A12E-2AD2-41F8-8ABC-F416EDE2D4B2}']", IsRelative = true)]
        IEnumerable<ICategory> Categories { get; set; }
    }
}
