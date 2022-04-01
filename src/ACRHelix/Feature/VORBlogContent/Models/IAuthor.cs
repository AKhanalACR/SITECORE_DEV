using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data.Fields;
using Glass.Mapper.Sc.Fields;

namespace Sitecore.Feature.VORBlogContent
{
  [SitecoreType(TemplateId = "{F3FDFC91-C3D6-480D-83EB-74333EC2DE1C}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.TemplateAndBase)]
  public interface IAuthor : ICMSEntity
  {
          
    [SitecoreField("{AE1B3CA1-21B0-4D6A-9327-17D5571335DF}")]
      string FullName { get; set; }
    [SitecoreField("{FE4CF004-52B4-46E4-93A3-99DBA835337A}")]
      string EmailAddress { get; set; }

    [SitecoreField("{91843C0E-FB61-494C-B949-3A8DABAD20C1}")]
      string Title { get; set; }

    [SitecoreField("{3138C2A2-0370-430D-986A-255454AFAC61}")]
    string Location { get; set; }

    [SitecoreField("{F84E5DD5-3919-46EA-80F2-CFA105888C68}")]
     string Bio { get; set; }

    [SitecoreField("{247F2F57-7523-4EDD-A340-AB03C1BEEBF1}")]
     Image ProfileImage { get; set; }

    [SitecoreField("{5C6C7A6F-2DC1-47A2-A28B-C224DF0CC0F2}")]
     string Creator { get; set; }
    string Url { get; set; }
  }

}
