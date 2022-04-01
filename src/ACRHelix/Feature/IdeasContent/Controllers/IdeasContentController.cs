using ACRHelix.Feature.IdeasContent.Services;
using ACRHelix.Feature.IdeasContent.ViewModels;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ACR.Library.Ideas.Data;
using System.Data.SqlClient;


namespace ACRHelix.Feature.IdeasContent
{
    public class IdeasContentController : Controller
    {
        private readonly IContentService _contentService;
        private LocationService _locationService;


        public IdeasContentController(IContentService contentService)
        {
            _contentService = contentService;
            _locationService = new LocationService();
        }

        public ViewResult IdeasPageContent()
        {
            var viewModel = new IdeasPageContentViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var PageTitleContent = _contentService.GetIdeasPageContentContent(Sitecore.Context.Item.ID.ToString());
            if (PageTitleContent != null)
            {
                viewModel.Id = PageTitleContent.Id;
                viewModel.Title = PageTitleContent.Title;
                viewModel.SubTitle = PageTitleContent.SubTitle;
                viewModel.RichText = PageTitleContent.RichText;
                viewModel.Date = PageTitleContent.Date;
                viewModel.EnableShareLink = PageTitleContent.EnableShareLink;
        if (PageTitleContent.Tags != null)
        {
          foreach (var tag in PageTitleContent.Tags)
          {
            viewModel.Tags.Add(tag);
          }
        }
            }

            return View(viewModel);
        }
        public ViewResult IdeasRichText()
        {
            var viewModel = new IdeasRichTextViewModel();

            var dataSource = RenderingContext.Current.Rendering.DataSource;

            if (String.IsNullOrEmpty(dataSource))
            {
                dataSource = Sitecore.Context.Item.ID.ToString();
            }
            var PageTitleContent = _contentService.GetIdeasPageContentContent(dataSource);
            if (PageTitleContent != null)
            {
                viewModel.Id = PageTitleContent.Id;
                viewModel.Title = PageTitleContent.Title;
                viewModel.RichText = PageTitleContent.RichText;

            }

            return View(viewModel);
        }

        #region Map module
        public ViewResult IdeasMapDetails()
        {
            var viewModel = new IdeasPageContentViewModel();
            var PageTitleContent = _contentService.GetIdeasPageContentContent(Sitecore.Context.Item.ID.ToString());
            if (PageTitleContent != null)
            {
                viewModel.Id = PageTitleContent.Id;
                viewModel.Title = PageTitleContent.Title;
            }

            return View(viewModel);
        }

        public JsonResult GetMapData()
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["IdeasDataEntities"].ConnectionString;
            var data = new List<FacilitiesAndPhysicianDB>();
            data = ACR.Library.DataAccess.IdeasDataAccess.GetMapData(connection);
            return Json(new { data = data, StateList = data.Select(item => item.Sta_ID).Distinct().ToList() }, JsonRequestBehavior.AllowGet);
        }

        public ViewResult SiteLocatorByZip()
        {
            var viewModel = new IdeasMapdetailsViewModel();

            var PageTitleContent = _contentService.GetMapDetailsContent(Sitecore.Context.Item.ID.ToString());
            if (PageTitleContent != null)
            {
                viewModel.Id = PageTitleContent.Id;
                viewModel.AddressPlaceholder = PageTitleContent.AddressPlaceholder;
                viewModel.NoResultsMessage = PageTitleContent.NoResultsMessage;
            }
            return View(viewModel);
        }

        public string GetSignedUrl(string address)
        {
            return _locationService.GetSignedUrl(address);
        }

        public JsonResult GetLocations(string lat, string lng, string Zip, string Type, string miles)
        {
            string connection = System.Configuration.ConfigurationManager.ConnectionStrings["IdeasDataEntities"].ConnectionString;
            var data = new List<FacilitiesAndPhysicianByZipCodeDB>();
            data = ACR.Library.DataAccess.IdeasDataAccess.GetMapByZipData(connection, lat, lng, Zip, miles, Type);
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);

            //var Data = _locationService.GetLocations(connection, lat, lng, miles, Zip, Type);
            //return Json(Data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ViewResult IdeasPublications()
        {
            var viewModel = new IdeasSelectedLinksViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var linksRoot = _contentService.GetSelectedLinksContent(RenderingContext.Current.Rendering.DataSource);
                if (linksRoot != null)
                {
                    viewModel.LinksParent = linksRoot;
                    viewModel.PublicationsTitle = linksRoot.PublicationsTitle;
                    foreach (var child in linksRoot.Children.Take(linksRoot.NoOfLinks))
                    {
                        if (!string.IsNullOrEmpty(child.Title) && child.Link != null)
                        {
                            viewModel.PublicationsItems.Add(child);
                        }
                    }
                }
            }
            return View(viewModel);
        }
        public ViewResult IdeasNewsLetters()
        {
            var viewModel = new IdeasSelectedLinksViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var linksRoot = _contentService.GetSelectedLinksContent(RenderingContext.Current.Rendering.DataSource);
                if (linksRoot != null)
                {
                    viewModel.LinksParent = linksRoot;
                    foreach (var child in linksRoot.Children.Take(linksRoot.NoOfLinks))
                    {
                        if (!string.IsNullOrEmpty(child.Title) && child.Link != null)
                        {
                            viewModel.PublicationsItems.Add(child);
                        }
                    }
                }
            }
            return View(viewModel);
        }

        public ViewResult IdeasMapWidget()
        {
            var viewModel = new IdeasMapWidgetViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var mapData = _contentService.GetMapWidgetContent(RenderingContext.Current.Rendering.DataSource);
                if (mapData != null)
                {
                    viewModel.Id = mapData.Id;
                    viewModel.Title = mapData.Title;
                    viewModel.FindByStateLink = mapData.FindByStateLink;
                    viewModel.FindByStateLinkText = mapData.FindByStateLinkText;
                    viewModel.FindByZipLink = mapData.FindByZipLink;
                    viewModel.FindByZipLinkText = mapData.FindByZipLinkText;
                    viewModel.MapLink = mapData.MapLink;
                    viewModel.MapImage = mapData.MapImage;
                }
            }
            return View(viewModel);
        }
    public ViewResult IdeasMapWidgetText()
    {
      var viewModel = new Models.IdeasMapWidgetText();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var mapDataText = _contentService.GetMapWidgetTextContent(RenderingContext.Current.Rendering.DataSource);
        if (mapDataText != null)
        {
          viewModel = mapDataText;
        }
      }
      return View(viewModel);
    }
    public ViewResult IdeasHero()
    {
      var viewModel = new Models.IdeasHero();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var IdeasHeroContent = _contentService.GetIdeasHeroContent(RenderingContext.Current.Rendering.DataSource);
        if (IdeasHeroContent != null)
        {
          viewModel = IdeasHeroContent;
        }
      }
      return View(viewModel);
    }
    public ViewResult IdeasPatientTiles()
    {
      var viewModel = new Models.IdeasPatientTitleTilesButton();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var IdeasHeroContent = _contentService.GetIdeasPatientTilesContent(RenderingContext.Current.Rendering.DataSource);
        if (IdeasHeroContent != null)
        {
          viewModel = IdeasHeroContent;
        }
      }
      return View(viewModel);
    }
    public ViewResult IdeasRichTextImageSection()
    {
      var viewModel = new Models.IdeasTextImageSection();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.GetTextImageContent(dataSource);
      }

      return View(viewModel);
    }

    public ViewResult IdeasPatientTitleTwoColumn()
    {
      var viewModel = new Models.IdeasPatientTitle2Column();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.IdeasPatientTitleTwoColumn(dataSource);
      }

      return View(viewModel);
    }
    public ViewResult IdeasPatientTwoImagesColumn()
    {
      var viewModel = new Models.IdeasPatientTwoImagesColumn();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.IdeasPatientTwoImagesColumn(dataSource);
      }

      return View(viewModel);
    }
    
  }
}