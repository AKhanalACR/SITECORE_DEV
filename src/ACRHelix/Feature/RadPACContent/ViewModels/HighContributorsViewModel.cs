
using System;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using System.Collections.Generic;

namespace ACRHelix.Feature.RadPACContent.ViewModels
{
    public class HighContributorsViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }

        public Image RightTileImage { get; set; }
        public string RightTileHeading { get; set; }

        public Image LeftTileImage { get; set; }
        public string LeftTileHeading { get; set; }

        public IEnumerable<string> Contributors { get; set; }
    }
}