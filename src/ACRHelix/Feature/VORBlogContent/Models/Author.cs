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

  public class Author : IAuthor
  {
          
    public virtual string FullName { get; set; }

    public virtual string EmailAddress { get; set; }

      public virtual string Title { get; set; }

    public virtual string Location { get; set; }

   
    public virtual string Bio { get; set; }

  
    public virtual Image ProfileImage { get; set; }

   
    public virtual string Creator { get; set; }
    public virtual string Url { get; set; }
  }

}
