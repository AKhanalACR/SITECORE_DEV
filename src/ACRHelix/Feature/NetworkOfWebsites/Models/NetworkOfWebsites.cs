
using System.Collections.Generic;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using Sitecore.Links;

namespace ACRHelix.Feature.NetworkOfWebsites.Models
{

[SitecoreType(TemplateId = "{F1AD85E8-DBB8-421A-9947-664CD5C04AA9}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
public class NetworkOfWebsites : ICMSEntity
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }
    [SitecoreField(FieldName = "Image",FieldType = Glass.Mapper.Sc.Configuration.SitecoreFieldType.Image)]
    public virtual Image Image { get; set; }

    [SitecoreChildren]
    public virtual IEnumerable<NetworkCategory> Children { get; set; } = new List<NetworkCategory>();

    public string GetImageUrl()
    {
      string url = "";

      if (Image != null)
      {
        if (!string.IsNullOrEmpty(Image.Src))
        {
          url = Image.Src;
        }
        else if(Image.MediaId != null)
        {
          if (Image.MediaId != Guid.Empty)
          {
            var mediaItem = Sitecore.Context.Database.GetItem(new ID(Image.MediaId));
            if (mediaItem != null)
            {
              var options = LinkManager.GetDefaultUrlOptions();
              url = LinkManager.GetItemUrl(mediaItem, options);
            }
          }
        }
      }
      return url;
    }
  }
}