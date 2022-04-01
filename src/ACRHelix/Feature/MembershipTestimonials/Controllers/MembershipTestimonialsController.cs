using ACR.Foundation.SSO.Users;
using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Feature.MembershipTestimonials.Services;
using ACRHelix.Feature.MembershipTestimonials.ViewModels;
using Newtonsoft.Json.Linq;
using Sitecore.Configuration;
using Sitecore.Links;
using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using Sitecore.Sites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ACRHelix.Feature.MembershipTestimonials
{
  public class MembershipTestimonialsController : Controller
  {
    private readonly IContentService _contentService;

    public MembershipTestimonialsController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult Carousel()
    {
      var viewModel = new CarouselViewModel();
      var dataSource = RenderingContext.Current.ContextItem.ID.ToString();

      if (!String.IsNullOrEmpty(dataSource))
      {
        var carouselContent = _contentService.GetFeaturedCarouselItems(dataSource);
        if (carouselContent != null)
        {
          viewModel.CarouselItems = carouselContent.CarouselItems;
        }
      }
      return View(viewModel);
    }

    //Initial load 
    public ViewResult MembershipTestimonials()
    {
      var viewModel = new MembershipTestimonialsViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource; // Reference.ItemReference.MtPageItemId; //RenderingContext.Current.ContextItem.ID.ToString();
      if (string.IsNullOrEmpty(dataSource))
      {
        dataSource = RenderingContext.Current.ContextItem.ID.ToString();
      }

      if (!string.IsNullOrEmpty(dataSource))
      {
        var testimonialsContent = _contentService.GetTestimonialsContent(dataSource);
        if (testimonialsContent != null)
        {
          viewModel.Id = testimonialsContent.Id;
          viewModel.Categories = testimonialsContent.Categories.OrderBy(n => n.Name);
          viewModel.FormUrl = testimonialsContent.FormUrl;
          viewModel.PageSize = testimonialsContent.PageSize;
          viewModel.MaxIndex = testimonialsContent.Testimonials.Count() / viewModel.PageSize + 1;
          viewModel.FormBlockTitle = testimonialsContent.FormBlockTitle;
          viewModel.FormBlockButtonText = testimonialsContent.FormBlockButtonText;
          viewModel.FeaturedItemId = testimonialsContent.FeaturedItem != null ? testimonialsContent.FeaturedItem.Id.ToString() : "";
          viewModel.BannerText = testimonialsContent.BannerText;
          viewModel.BannerLinkText = testimonialsContent.BannerLinkText;
          viewModel.Testimonials = testimonialsContent.Testimonials.OrderByDescending(x => x.DateCreated).Take(3);
        }
      }
      return View(viewModel);
    }

    //Load more items while scrolling
    public ActionResult LoadMoreTestimonials(int pageIndex, string category)
    {
      var viewModel = new MembershipTestimonialsViewModel();
      var dataSource = Reference.ItemReference.MtPageItemId; //RenderingContext.Current.ContextItem.ID.ToString();
      if (!String.IsNullOrEmpty(dataSource))
      {
        var testimonialsContent = _contentService.GetTestimonialsContent(dataSource);
        if (testimonialsContent != null)
        {
          viewModel.Categories = testimonialsContent.Categories.OrderBy(n => n.Name);
          viewModel.FormUrl = testimonialsContent.FormUrl;
          viewModel.PageSize = testimonialsContent.PageSize;
          viewModel.MaxIndex = testimonialsContent.Testimonials.Count() % viewModel.PageSize + 1;
          viewModel.Testimonials = testimonialsContent.Testimonials.OrderByDescending(x => x.DateCreated).Skip(viewModel.PageSize * pageIndex).Take(viewModel.PageSize);

          if (!string.IsNullOrWhiteSpace(category) && category != "-1")
          {
            viewModel.Testimonials = testimonialsContent.Testimonials.OrderByDescending(x => x.DateCreated).Where(t => t.Category == category).Skip(viewModel.PageSize * pageIndex).Take(viewModel.PageSize);
          }
        }
      }
      return PartialView("_Testimonials", viewModel);
    }

    //Load item filtered by category
    public ActionResult TestimonialsByCategory(string category)
    {
      var viewModel = new MembershipTestimonialsViewModel();
      var dataSource = Reference.ItemReference.MtPageItemId; //RenderingContext.Current.Rendering.DataSource

      if (!String.IsNullOrEmpty(dataSource))
      {
        var testimonialsContent = _contentService.GetTestimonialsContent(dataSource);
        if (testimonialsContent != null)
        {
          viewModel.Categories = testimonialsContent.Categories.OrderBy(n => n.Name);
          viewModel.FormUrl = testimonialsContent.FormUrl;
          viewModel.PageSize = testimonialsContent.PageSize;
          viewModel.MaxIndex = testimonialsContent.Testimonials.Count() % viewModel.PageSize + 1;
          viewModel.Testimonials = testimonialsContent.Testimonials.OrderByDescending(x => x.DateCreated).Take(viewModel.PageSize);
          List<ITestimonial> mts = new List<ITestimonial>();

          if (!string.IsNullOrEmpty(category) && category != "-1")
          {
            //foreach (var ts in testimonialsContent.Testimonials)
            //{
            //  //if (ts.Category.Any(c => c.Name == category))
            //  //{
            //  //  mts.Add(ts);
            //  //}
            //}
            //viewModel.Testimonials = mts.Take(viewModel.PageSize);
            viewModel.Testimonials = testimonialsContent.Testimonials.Where(t => t.Category == category).Take(viewModel.PageSize);
          }
        }
      }
      return PartialView("_Testimonials", viewModel);
    }

    //personal testimonial popup
    public ActionResult TestimonialDetails(string id)
    {
      var viewModel = new TestimonialDetailsViewModel();
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var testimonial = _contentService.GetTestimonial(id);
      viewModel.DetailTestimonial = testimonial;
      return View(viewModel);
    }

    //personal testimonial share page
    public ActionResult PersonalTestimony() //string id
    {
      var viewModel = new TestimonialDetailsViewModel();
      var id = RenderingContext.Current.ContextItem.ID.ToString();

      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }

      var testimonial = _contentService.GetTestimonial(id);
      viewModel.DetailTestimonial = testimonial;
      return View(viewModel);
    }

    //for other pages like rli
    public ActionResult TestimonialByCategory()
    {
      var viewModel = new TestimonialByCategoryViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!String.IsNullOrEmpty(dataSource))
      {
        var testimonialsContent = _contentService.GetTestimonialsContentByCategory(dataSource);
        if (testimonialsContent != null)
        {
          viewModel.Id = testimonialsContent.Id;
          viewModel.Title = testimonialsContent.Title;
          viewModel.Category = testimonialsContent.Category;
          viewModel.NbrOfItemsToDisplay = testimonialsContent.NbrToItemsToDisplay;
          viewModel.ArchiveLink = testimonialsContent.ArchiveLink;
          viewModel.Testimonials = testimonialsContent.Testimonials.OrderByDescending(x => x.DateCreated).Where(t => t.Category == viewModel.Category).Take(viewModel.NbrOfItemsToDisplay);
        }
      }
      return View(viewModel);
    }

    //Initail load of testimony submit form 
    [HttpGet]
    public ActionResult SubmitTestimonial()
    {
      var auth = UserManager.CurrentUserContext.CurrentUser.IsAuthenticated;
      //var isMember = UserManager.CurrentUserContext.CurrentUser.IsAcrMember;

      if (auth)
      {
        if (true) //isMember
        {
          var dataSource = RenderingContext.Current.Rendering.DataSource;
          if (string.IsNullOrEmpty(dataSource))
          {
            dataSource = RenderingContext.Current.ContextItem.ID.ToString();
          }

          if (!string.IsNullOrEmpty(dataSource))
          {
            var viewModel = new SubmitTestimonialViewModel();
            var submitTestimonialPageContent = _contentService.GetSubmitTestimonialContent(dataSource);
            if (submitTestimonialPageContent != null)
            {
              viewModel.Id = submitTestimonialPageContent.Id;
              viewModel.TestimonialFolder = submitTestimonialPageContent.TestimonialsFolder;
              viewModel.EditProfilePageUrl = submitTestimonialPageContent.EditProfilePageUrl;
              viewModel.EditProfileInstruction = submitTestimonialPageContent.EditProfileInstruction;
              viewModel.UploadImageInstruction = submitTestimonialPageContent.UploadImageInstruction;
              viewModel.YouTubeLinkHelpText = submitTestimonialPageContent.YouTubeLinkHelpText;
              viewModel.EngageProfileHelpText = submitTestimonialPageContent.EngageProfileHelpText;
              var category = submitTestimonialPageContent.Categories.OrderBy(n => n.Name);
              viewModel.Categories = new SelectList(category, "Name", "Name");
              viewModel.Testimonial.CustomerId = UserManager.CurrentUserContext.CurrentUser.MasterCustomerID;
              viewModel.Testimonial.FullName = UserManager.CurrentUserContext.CurrentUser.Profile.LabelName;
              viewModel.Testimonial.Chapter = string.IsNullOrEmpty(UserManager.CurrentUserContext.CurrentUser.Profile.Chapter) ? "" : UserManager.CurrentUserContext.CurrentUser.Profile.Chapter;
              viewModel.Testimonial.MemberDate = UserManager.CurrentUserContext.CurrentUser.Profile.MemberSince;
              return View(viewModel);
            }
            else
            {
              //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              Sitecore.Diagnostics.Log.Error("Failed to get membership testimonial page content Membership Testimonial SubmitTestimonial action.", this);
              throw new Exception("Failed to get membership testimonial page content Membership Testimonial \"SubmitTestimonial\" action.");
            }
          }
          else
          {
            Sitecore.Diagnostics.Log.Error("Failed to get context item id in Membership Testimonial SubmitTestimonial action.", this);
            throw new Exception("Failed to get context item id in Membership Testimonial \"SubmitTestimonial\" action.");
          }

        }
        else
        {
          var item = Sitecore.Context.Database.GetItem(Reference.ItemReference.NotAuthorizedPageItemId);
          return Redirect(LinkManager.GetItemUrl(item));
        }
      }
      else
      {
        var item = Sitecore.Context.Database.GetItem(Reference.ItemReference.LoginPageItemId);
        return Redirect(LinkManager.GetItemUrl(item) + "?returnUrl=" + LinkManager.GetItemUrl(RenderingContext.Current.ContextItem));
      }
    }

    //Submit button click event
    [HttpPost]
    public RedirectResult SubmitTestimonial(SubmitTestimonialViewModel viewModel, FormCollection formCol)
    {
      SiteContext targetSiteContext = SiteContext.GetSite("website");
      using (var context = new SiteContextSwitcher(targetSiteContext))
      {
        if (ModelState.IsValid)
        {
          if (viewModel != null)
          {
            //create new testimonial
            viewModel.Testimonial.Name = viewModel.Testimonial.FullName;
            if (!string.IsNullOrWhiteSpace(viewModel.Testimonial.TesimonialMessage))
            {
              viewModel.Testimonial.IntroMessage = viewModel.Testimonial.TesimonialMessage.Length > 70 ? viewModel.Testimonial.TesimonialMessage.Substring(0, 70) : viewModel.Testimonial.TesimonialMessage;
              viewModel.Testimonial.BriefMessage = viewModel.Testimonial.TesimonialMessage.Length > 140 ? viewModel.Testimonial.TesimonialMessage.Substring(0, 140) : viewModel.Testimonial.TesimonialMessage;
              viewModel.Testimonial.SubTitle = viewModel.Testimonial.BriefMessage;
              viewModel.Testimonial.TesimonialMessage = viewModel.Testimonial.TesimonialMessage.Replace(Environment.NewLine, "<br/>");
            }

            if (!string.IsNullOrEmpty(formCol["Category"]))
            {
              viewModel.Testimonial.Category = formCol["Category"];
            }

            var newItem = _contentService.CreateTestimonial(viewModel.Testimonial);
            ITestimonial testimonial = new Testimonial();

            //create new media item
            if (viewModel.ImageFile != null && viewModel.ImageFile.ContentLength > 0)
            {
              testimonial.ProfileImage = new Glass.Mapper.Sc.Fields.Image();
              var mediaName = viewModel.Testimonial.FullName + "_" + DateTime.Now.ToString("yymmssfff");
              MediaItem mediaItem = new MediaItem()
              {
                Name = mediaName,
                MimeType = viewModel.ImageFile.ContentType,
                Extension = Path.GetExtension(viewModel.ImageFile.FileName),
                Icon = "",
                Blob = viewModel.ImageFile.InputStream,
                Width = 294,
                Height = 288
              };

              //create media item
              var response = _contentService.CreateMediaItem(mediaItem);
              Sitecore.Diagnostics.Log.Info("--- vvvv item edit data media id: " + response, new object());

              //update testimonial media field
              testimonial.ProfileImage.Title = viewModel.Testimonial.Name;
              testimonial.ProfileImage.Alt = viewModel.Testimonial.Name;
              testimonial.ProfileImage.Width = mediaItem.Width;
              testimonial.ProfileImage.Height = mediaItem.Height;
              testimonial.ProfileImage.MediaId = new Guid(response);
              _contentService.Save(testimonial, newItem);

            }
            //start the workflow on the new testimonial item
            //var newItem = Factory.GetDatabase("master").GetItem(testimonial.Id.ToString());
            //var workflowId = newItem.Fields["__Default workflow"].Value;
            //var workflow = Factory.GetDatabase("master").WorkflowProvider.GetWorkflow(workflowId);
            //workflow.Start(newItem);
          }

          var item = Sitecore.Context.Database.GetItem(Reference.ItemReference.ConfirmationPageItemId);
          Sitecore.Diagnostics.Log.Info("--- vvvv from controller redirect database: " + Sitecore.Context.Database.Name, new object());
          return Redirect(LinkManager.GetItemUrl(item));

        }
        else
        {
          return null;
        }
      }
    }
  }
}