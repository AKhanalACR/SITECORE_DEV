using ACRHelix.Feature.PageContent.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
    public class ImageHolderViewModel
    {
        public ID Id { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}