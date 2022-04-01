using ACRHelix.Feature.SiteSection.Models;
using ACRHelix.Feature.SiteSection.Services;
using ACRHelix.Feature.SiteSection.ViewModels;
using PagedList;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACRHelix.Feature.SiteSection.RenderingExtensions;
using ACRHelix.Feature.SiteSection.Constants;
using Sitecore.Data;

namespace ACRHelix.Feature.SiteSection
{
    public class SiteSectionController : Controller
    {
        private readonly IContentService _contentService;

        public SiteSectionController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult SiteSection()
        {
            var viewModel = new SiteSectionViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var SiteSectionContent = _contentService.GetSiteSectionContent(dataSource);
            if (SiteSectionContent != null)
            {
                viewModel.Title = SiteSectionContent.Title;
                viewModel.HeaderImage = SiteSectionContent.HeaderImage;
                viewModel.Heading = SiteSectionContent.Heading;
                viewModel.Id = SiteSectionContent.Id;
            }

            return View(viewModel);
        }
        /*
            public ViewResult SubSiteSection()
            {
                var viewModel = new SubSiteSectionViewModel();

                var dataSource = RenderingContext.Current.Rendering.DataSource;

                if (String.IsNullOrEmpty(dataSource))
                {
                    dataSource = Sitecore.Context.Item.ID.ToString();
                }

                var SiteSectionContent = _contentService.GetSubSiteSectionContent(dataSource);
                if (SiteSectionContent != null)
                {
                    viewModel.Title = SiteSectionContent.Title;
                    viewModel.Description = SiteSectionContent.Description;
                    viewModel.Heading = SiteSectionContent.Heading;
                    viewModel.Id = SiteSectionContent.Id;
                    viewModel.Tiles = SiteSectionContent.Tiles != null ? SiteSectionContent.Tiles.Select(t => new TileViewModel
                    {
                        Id = t.Id,
                        Image = t.Image,
                        Url = t.Url,
                        TileText = t.TileText,
                        Title = t.Title
                    }) : null;
          }

                return View(viewModel);
            }*/


        private TileHolderViewModel GetTileHolderViewModel(ITileHolder tileHolder, int? page)
        {
            var viewModel = new TileHolderViewModel();

            int pageSize = tileHolder.TilesPerPage ?? 0;
            int pageNumber = (page ?? 1);

            viewModel.Id = tileHolder.Id;
            viewModel.Title = tileHolder.Title;
            //viewModel.LinkText = SiteSectionContent.LinkText;
            if (!tileHolder.DisplayAllChildren)
            {
                if (tileHolder.Tiles != null)
                {
                    var tiles = pageSize != 0 ? tileHolder.Tiles.ToPagedList(pageNumber, pageSize) : tileHolder.Tiles;
                    viewModel.Tiles = tiles.Select(t => new TileViewModel
                    {
                        Id = t.Id,
                        Image = t.Image,
                        TileText = t.TileText,
                        Title = t.Title,
                        Url = t.Url,
                        LinkText = t.LinkText,
                        Link = t.Link,
                        TemplateID = t.TemplateID,
                        ShortTitle = t.ShortTitle,
                    });
                }
            }
            else
            {
                var children = _contentService.GetChildTiles(Sitecore.Context.Item);
                var tiles = pageSize != 0 ? children.ToPagedList(pageNumber, pageSize) : children;
                viewModel.Tiles = tiles.Select(t => new TileViewModel
                {
                    Id = t.Id,
                    Image = t.Image,
                    TileText = t.TileText,
                    Title = t.Title,
                    Url = t.Url,
                    LinkText = t.LinkText,
                    TemplateID = t.TemplateID,
                    ShortTitle = t.ShortTitle
                });
            }

            var tileList = viewModel.Tiles.ToList();
            foreach (var tile in tileList)
            {
                if (tile.TemplateID != TileConstants.Templates.ExternalTileTemplate.ID)
                {
                    tile.Link = new Glass.Mapper.Sc.Fields.Link()
                    {
                        Url = tile.Url,
                        TargetId = tile.Id,
                        Target = "_self",
                        Type = Glass.Mapper.Sc.Fields.LinkType.Internal
                    };


                }
                //try to get next session dates for education courses / meetings
                tile.NextSessionDate = _contentService.GetSessionDate(tile);
            }
            viewModel.Tiles = tileList;

            viewModel.PageCount = pageSize != 0 ? Math.Max(tileHolder.Tiles.Count() / pageSize, 1) : 0;
            viewModel.PageNumber = pageSize != 0 ? pageNumber : 0;

            //rendering params
            var tilesRow = RenderingContext.Current.Rendering.GetTilesPerRow();
            viewModel.TilesPerRow = tilesRow;
            viewModel.TileCssClass = RenderingContext.Current.Rendering.GetTileColumnCss();
            viewModel.HiddenTiles = 0;

            var missingTiles = (viewModel.Tiles.Count() % tilesRow);
            if (missingTiles > 0)
            {
                viewModel.HiddenTiles = tilesRow - missingTiles;
            }



            return viewModel;
        }

        public ViewResult TextTile(int? page)
        {
            var viewModel = new TileHolderViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var SiteSectionContent = _contentService.GetTileHolderContent(dataSource);
            if (SiteSectionContent != null)
            {
                viewModel = GetTileHolderViewModel(SiteSectionContent, page);
            }
            return View(viewModel);
        }

        public ViewResult TileHolder(int? page)
        {
            var viewModel = new TileHolderViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var SiteSectionContent = _contentService.GetTileHolderContent(dataSource);
            if (SiteSectionContent != null)
            {
                viewModel = GetTileHolderViewModel(SiteSectionContent, page);
            }
            return View(viewModel);
        }

        public ViewResult HoverTileHolder(int? page)
        {
            var viewModel = new TileHolderViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var SiteSectionContent = _contentService.GetTileHolderContent(dataSource);
            if (SiteSectionContent != null)
            {
                viewModel = GetTileHolderViewModel(SiteSectionContent, page);
            }

            return View(viewModel);
        }

        public ViewResult LaunchpadList(int? page)
        {
            var viewModel = new TileHolderViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }

            var SiteSectionContent = _contentService.GetTileHolderContent(dataSource);
            if (SiteSectionContent != null)
            {
                viewModel = GetTileHolderViewModel(SiteSectionContent, page);
            }

            return View(viewModel);
        }
        public ViewResult IdeasRichTextAndTilesHome()
        {
            var viewModel = new IdeasRichTextAndTilesModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdeasTilesContent = _contentService.GetIdeasRichTextAndTilesContent(RenderingContext.Current.Rendering.DataSource);
                if (IdeasTilesContent != null)
                {
                    viewModel = IdeasTilesContent;
                }
            }
            return View(viewModel);
        }
        public ViewResult IdeasTiles()
        {
            var viewModel = new IdeasSelectedTiles();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdeasTilesContent = _contentService.GetIdeasSelectedTilesContent(RenderingContext.Current.Rendering.DataSource);
                if (IdeasTilesContent != null)
                {
                    viewModel = IdeasTilesContent;
                }
            }
            return View(viewModel);
        }
    }
}