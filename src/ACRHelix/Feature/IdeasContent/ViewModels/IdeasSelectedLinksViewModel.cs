using System.Collections.Generic;

namespace ACRHelix.Feature.IdeasContent.ViewModels
{
    public class IdeasSelectedLinksViewModel
    {
        public string PublicationsTitle { get; set; }
        public IdeasSelectedLinksViewModel()
        {
            PublicationsItems = new List<Models.LinkMenuItem>();
        }

        public Models.IdeasSelectedLinks LinksParent { get; set; }
        public List<Models.LinkMenuItem> PublicationsItems { get; set; }
    }
}