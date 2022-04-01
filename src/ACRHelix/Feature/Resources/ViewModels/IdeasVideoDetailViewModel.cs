using System;
using System.Collections.Generic;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Feature.IdeasResources.Models;

namespace ACRHelix.Feature.IdeasResources.ViewModels
{
    public class IdeasVideoDetailViewModel
    {
        public virtual ID Id { get; set; }
       
        public virtual string Title { get; set; }

       
        public virtual Image Image { get; set; }

       
        public virtual Link Link { get; set; }

       
        public virtual bool IsYTVideo { get; set; }
        public virtual DateTime Created { get; set; }

       
        public virtual IEnumerable<ResourceType> ResourceType { get; set; }
       
        public virtual Link ResourceSubTitle { get; set; }
    }
}