using ACRHelix.Feature.Identity.Services;
using ACRHelix.Feature.Identity.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.Identity
{
    public class IdentityController : Controller
    {
        private readonly IContentService _contentService;

        public IdentityController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult LocationsFooter()
        {
            var viewModel = new LocationsFooterViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetLocationsFooterContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Link = IdentityContent.Link;
                    viewModel.LinkText = IdentityContent.LinkText;
                    viewModel.Text = IdentityContent.Text;
                    viewModel.Locations = IdentityContent.Locations.Select(l => new LocationViewModel
                    {
                        Id = l.Id,
                        Address1 = l.Address1,
                        City = l.City,
                        Phone = l.Phone,
                        State = l.State,
                        Title = l.Title,
                        Zip = l.Zip
                    });
                }
            }
            return View(viewModel);
        }

        public ViewResult Logo()
        {
            var viewModel = new LogoViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetIdentityContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Title = IdentityContent.Title;
                }
            }
            return View(viewModel);
        }

        public ViewResult ContactsFooter()
        {
            var viewModel = new ContactsFooterViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetContactsFooterContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Column1 = IdentityContent.Column1;
                    viewModel.Column2 = IdentityContent.Column2;
                    viewModel.Column3 = IdentityContent.Column3;
                    viewModel.Column4 = IdentityContent.Column4;
                }
            }
            return View(viewModel);
        }

        public ViewResult CopyrightFooter()
        {
            var viewModel = new CopyrightFooterViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetCopyrightFooterContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Copyright = IdentityContent.Copyright;
                }
            }
            return View(viewModel);
        }

        public ViewResult DsiCopyrightFooter()
        {
            var viewModel = new CopyrightFooterViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetCopyrightFooterContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Copyright = IdentityContent.Copyright;
                }
            }
            return View(viewModel);
        }

        public ViewResult IWLogo()
        {
            var viewModel = new IWLogoViewModel();
            if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var LogoContent = _contentService.GetLogoContent(RenderingContext.Current.Rendering.DataSource);
                if (LogoContent != null)
                {
                    viewModel.Logo = LogoContent;
                }
            }
            return View(viewModel);
        }

        public ViewResult IWCopyright()
        {
            var viewModel = new IWCopyrightViewModel();
            if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetCopyrightFooterContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.CopyrightItem  = IdentityContent;
                    
                }
            }
            return View(viewModel);
        }

        public ViewResult IWFooterTopSection()
        {
            var viewModel = new IWFooterTopSectionViewModel();
            if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IWFooterContent = _contentService.GetIWFooterSectionContent(RenderingContext.Current.Rendering.DataSource);
                if (IWFooterContent != null)
                {
                    viewModel.IWFooterSection = IWFooterContent;

                }
            }
            return View(viewModel);
        }

        public ViewResult IWFooterLinks()
        {
            var viewModel = new IWFooterTopSectionViewModel();
            if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IWFooterContent = _contentService.GetIWFooterSectionContent(RenderingContext.Current.Rendering.DataSource);
                if (IWFooterContent != null)
                {
                    viewModel.IWFooterSection = IWFooterContent;

                }
            }
            return View(viewModel);
        }

        public ViewResult IdeasLogo()
        {
            var viewModel = new IdeasLogoViewModel();
            if (!string.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var LogoContent = _contentService.GetLogoContent(RenderingContext.Current.Rendering.DataSource);
                if (LogoContent != null)
                {
                    viewModel.Logo = LogoContent;
                }
            }
            return View(viewModel);
        }

        public ViewResult IdeasContactsFooter()
        {
            var viewModel = new IdeasContactsFooterViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetContactsFooterContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Column1 = IdentityContent.Column1;
                    viewModel.Column2 = IdentityContent.Column2;
                    viewModel.Column3 = IdentityContent.Column3;
                }
            }
            return View(viewModel);
        }
    public ViewResult IdeasPatientContactsFooter()
    {
      var viewModel = new IdeasContactsFooterViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var IdentityContent = _contentService.GetContactsFooterContent(RenderingContext.Current.Rendering.DataSource);
        if (IdentityContent != null)
        {
          viewModel.Id = IdentityContent.Id;
          viewModel.Column1 = IdentityContent.Column1;
          viewModel.Column2 = IdentityContent.Column2;
          viewModel.Column3 = IdentityContent.Column3;
        }
      }
      return View(viewModel);
    }

    public ViewResult IdeasCopyrightFooter()
        {
            var viewModel = new CopyrightFooterViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetCopyrightFooterContent(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Copyright = IdentityContent.Copyright;
                }
            }
            return View(viewModel);
        }

        public ViewResult IdeasNewsContacts()
        {
            var viewModel = new IdeasNewsContactsViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var IdentityContent = _contentService.GetIdeasNewsContacts(RenderingContext.Current.Rendering.DataSource);
                if (IdentityContent != null)
                {
                    viewModel.Id = IdentityContent.Id;
                    viewModel.Contacts = IdentityContent.Contacts;
                }
            }
            return View(viewModel);
        }

    }
}