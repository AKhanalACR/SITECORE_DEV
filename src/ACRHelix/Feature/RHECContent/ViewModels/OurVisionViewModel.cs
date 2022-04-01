using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Feature.RhecContent.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.ViewModels
{
    public class OurVisionViewModel
  {
    public  ID Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public Image Image { get; set; }
    public string LinkText { get; set; }
    public Link Link { get; set; }

    public IEnumerable<OurVisionTilesViewModel> Tiles { get; set; }
    
    }
}