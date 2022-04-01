using ACRHelix.Feature.SiteSection.Models;
using ACRHelix.Foundation.Repository.Content;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Glass.Mapper.Sc;
using ACRHelix.Feature.SiteSection.ViewModels;
using Sitecore.Data;
using ACRHelix.Feature.SiteSection.Constants;
using ACRHelix.Feature.MeetingsCalendar.Models;

namespace ACRHelix.Feature.SiteSection.Services
{
    public class SitecoreContentService : IContentService
    {
        private readonly IContentRepository _repository;
        private SitecoreService _sitecoreService;
        public SitecoreContentService(IContentRepository repository)
        {
            _repository = repository;
            _sitecoreService = new SitecoreService(Sitecore.Context.Database);
        }

        public IEnumerable<ITile> GetChildTiles(Item item)
        {
            List<ITile> tiles = new List<ITile>();
            var children = item.GetChildren().Where(x => x.IsDerived("{D7890554-C645-41C4-810B-0DB540324EF1}")).ToList();
            var sitecoreService = new SitecoreService(Sitecore.Context.Database);
            foreach (var child in children)
            {
                tiles.Add(sitecoreService.Cast<Tile>(child));
            }
            return tiles;
        }

        public ISiteSection GetSiteSectionContent(string contentGuid)
        {
            return _repository.GetContentItem<ISiteSection>(contentGuid);
        }

        public ISubSiteSection GetSubSiteSectionContent(string contentGuid)
        {
            return _repository.GetContentItem<ISubSiteSection>(contentGuid);
        }

        public ITileHolder GetTileHolderContent(string contentGuid)
        {
            return _repository.GetContentItem<ITileHolder>(contentGuid);
        }

        public string GetSessionDate(TileViewModel tile)
        {
            if (tile.TemplateID != TileConstants.Templates.ExternalTileTemplate.ID)
            {
                var item = Sitecore.Context.Database.GetItem(ID.Parse(tile.Id));
                if (item != null)
                {
                    return GetSessionDate(item);
                }
            }
            else
            {
                if (tile.Link != null)
                {
                    ID id = ID.Null;
                    if (ID.TryParse(tile.Link.TargetId, out id))
                    {
                        var item = Sitecore.Context.Database.GetItem(id);
                        if (item != null)
                        {
                            return GetSessionDate(item);
                        }
                    }
                }
            }
            return null;
        }

        private string GetSessionDate(Item item)
        {
            if (item.TemplateID == TileConstants.Templates.MeetingOrCourse.ID)
            {
                MeetingOrCourseHeader course = _sitecoreService.Cast<MeetingOrCourseHeader>(item);
                if (course != null)
                {
                    var nextCourse = course.Products.Where(x => x.MeetingStartDate >= DateTime.Now.Date).OrderBy(x => x.MeetingStartDate).FirstOrDefault();
                    if (nextCourse != null)
                    {
                        return "Next Session: " + nextCourse.MeetingStartDate.ToString("MM-dd-yyyy");
                    }
                }
            }
            return null;
        }

        public IdeasRichTextAndTilesModel GetIdeasRichTextAndTilesContent(string contentGuid)
        {
            return _repository.GetContentItem<IdeasRichTextAndTilesModel>(contentGuid);
        }

        public IdeasSelectedTiles GetIdeasSelectedTilesContent(string contentGuid)
        {
            return _repository.GetContentItem<IdeasSelectedTiles>(contentGuid);
        }
    }
}