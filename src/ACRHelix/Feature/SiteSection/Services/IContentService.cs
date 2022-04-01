using ACRHelix.Feature.SiteSection.Models;
using ACRHelix.Feature.SiteSection.ViewModels;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Services
{
    public interface IContentService
    {
        ISiteSection GetSiteSectionContent(string contentGuid);
        ISubSiteSection GetSubSiteSectionContent(string contentGuid);
        ITileHolder GetTileHolderContent(string contentGuid);

        IEnumerable<ITile> GetChildTiles(Item item);

        string GetSessionDate(TileViewModel tile);

        IdeasRichTextAndTilesModel GetIdeasRichTextAndTilesContent(string contentGuid);

        IdeasSelectedTiles GetIdeasSelectedTilesContent(string contentGuid);
    }
}