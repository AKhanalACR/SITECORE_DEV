using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
    public class OurVisionTilesViewModel
  {
    public  ID Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public Image Icon { get; set; }
    public string Text { get; set; }
  }
}