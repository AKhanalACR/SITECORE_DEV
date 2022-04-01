using ACRHelix.Feature.PageContent.Services;
using ACRHelix.Feature.PageContent.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Foundation.SitecoreExtensions.RenderingExtensions;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Feature.PageContent.Models;
using Glass.Mapper.Sc.Web.Mvc;

namespace ACRHelix.Feature.PageContent
{
  public class PageContentController : Controller
  {
    private readonly IContentService _contentService;

    public PageContentController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult Author()
    {

      if (Sitecore.Context.Item != null)
      {
        var author_field = Sitecore.Context.Item.Fields["Author"];
        if (author_field != null)
        {
          string authorName = author_field.Value;
          if (!string.IsNullOrWhiteSpace(authorName))
          {
            return View(new AuthorViewModel() { AuthorName = authorName });
          }
        }
      }
      return null;
    }


    public ViewResult PageTitleWithImage()
    {
      var viewModel = new PageTitleWithImageViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleWithImageContent = _contentService.GetPageTitleWithImageContent(dataSource);
      var PageTitleContent = _contentService.GetPageTitleContent(Sitecore.Context.Item.ID.ToString());
      if (PageTitleWithImageContent != null)
      {
        viewModel.Id = PageTitleWithImageContent.Id;
        viewModel.TitleImage = PageTitleWithImageContent.TitleImage;
        viewModel.PageTitle = new PageTitleViewModel { Id = PageTitleContent.Id, Title = PageTitleContent.Title, SubTitle = PageTitleContent.SubTitle };
      }

      return View(viewModel);
    }

    public ViewResult PageTitle()
    {
      var viewModel = new PageTitleViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var PageTitleContent = _contentService.GetPageTitleContent(Sitecore.Context.Item.ID.ToString());
      if (PageTitleContent != null)
      {
        viewModel.Id = PageTitleContent.Id;
        viewModel.Title = PageTitleContent.Title;
        viewModel.SubTitle = PageTitleContent.SubTitle;
        viewModel.RichText = PageTitleContent.RichText;
        viewModel.Date = PageTitleContent.Date == null ? DateTime.MinValue : PageTitleContent.Date;

      }

      return View(viewModel);
    }


    public ViewResult LinkSection()
    {
      var viewModel = new LinkSectionViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var LinkSectionContent = _contentService.GetLinkSectionContent(dataSource);
      if (LinkSectionContent != null)
      {
        viewModel.Id = LinkSectionContent.Id;
        viewModel.Title = LinkSectionContent.Title;
        viewModel.SubTitle = LinkSectionContent.SubTitle;
        viewModel.Links = LinkSectionContent.Links;

        viewModel.DisplayHeader = RenderingContext.Current.Rendering.DisplayHeader();
      }

      return View(viewModel);
    }

    public ViewResult LinkSectionNoHeader()
    {
      var viewModel = new LinkSectionViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var LinkSectionContent = _contentService.GetLinkSectionContent(dataSource);
      if (LinkSectionContent != null)
      {
        viewModel.Id = LinkSectionContent.Id;
        //viewModel.Title = LinkSectionContent.Title;
        //viewModel.SubTitle = LinkSectionContent.SubTitle;
        viewModel.Links = LinkSectionContent.Links;
      }
      return View(viewModel);
    }

    public ViewResult FormSection()
    {
      var viewModel = new FormSectionViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var FormSectionContent = _contentService.GetFormSectionContent(dataSource);
      if (FormSectionContent != null)
      {
        viewModel.Id = FormSectionContent.Id;
        viewModel.Title = FormSectionContent.Title;
      }

      return View(viewModel);
    }

    public ViewResult RichTextSection()
    {
      var viewModel = new RichTextSectionViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var RichTextSectionContent = _contentService.GetRichTextSectionContent(dataSource);
      if (RichTextSectionContent != null)
      {
        viewModel.Id = RichTextSectionContent.Id;
        viewModel.Title = RichTextSectionContent.Title;
        viewModel.RichText = RichTextSectionContent.RichText;
      }

      return View(viewModel);
    }
    public ViewResult ImageHolder()
    {
      var viewModel = new ImageHolderViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var ImageHolderContent = _contentService.GetImageHolderContent(dataSource);
      if (ImageHolderContent != null)
      {
        viewModel.Id = ImageHolderContent.Id;
        viewModel.Images = ImageHolderContent.Images;
      }

      return View(viewModel);
    }
    public ViewResult ImageHolderWithLink()
    {
      var viewModel = new ImageHolderWithLinkViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var ImageHolderWithLinkContent = _contentService.GetImageHolderWithLinkContent(dataSource);
      if (ImageHolderWithLinkContent != null)
      {
        viewModel.Id = ImageHolderWithLinkContent.Id;
        viewModel.Images = ImageHolderWithLinkContent.Images;
        viewModel.RedirectUrl = ImageHolderWithLinkContent.RedirectUrl;
      }

      return View(viewModel);
    }

    public ViewResult VideoSection()
    {
      var viewModel = new VideoSectionViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var VideoSectionContent = _contentService.GetVideoSectionContent(dataSource);
      if (VideoSectionContent != null)
      {
        viewModel.Id = VideoSectionContent.Id;
        viewModel.Title = VideoSectionContent.Title;
        viewModel.SubTitle = VideoSectionContent.SubTitle;
        viewModel.VideoLink = VideoSectionContent.VideoLink;
        viewModel.Videos = VideoSectionContent.Videos;
      }

      return View(viewModel);
    }
    public ViewResult VideoSectionRadpac()
    {
      var viewModel = new VideoSectionViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!String.IsNullOrEmpty(dataSource))
      {
        var VideoSectionContent = _contentService.GetVideoSectionContent(dataSource);
        if (VideoSectionContent != null)
        {
          viewModel.Id = VideoSectionContent.Id;
          viewModel.Title = VideoSectionContent.Title;
          viewModel.SubTitle = VideoSectionContent.SubTitle;
          viewModel.VideoLink = VideoSectionContent.VideoLink;
          viewModel.Videos = VideoSectionContent.Videos;
        }
      }     
      return View(viewModel);
    }

    public ViewResult TwoColumnSection()
    {
      var viewModel = new SectionTitleWithPlaceholderViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var SectionTitleWithPlaceholderContent = _contentService.GetSectionTitleWithPlaceholderContent(dataSource);
      if (SectionTitleWithPlaceholderContent != null)
      {
        viewModel.Id = SectionTitleWithPlaceholderContent.Id;
        viewModel.Title = SectionTitleWithPlaceholderContent.Title;
      }

      return View("2ColumnSection", viewModel);
    }

    public ViewResult SectionTitleWithPlaceholder()
    {
      var viewModel = new SectionTitleWithPlaceholderViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var SectionTitleWithPlaceholderContent = _contentService.GetSectionTitleWithPlaceholderContent(dataSource);
      if (SectionTitleWithPlaceholderContent != null)
      {
        viewModel.Id = SectionTitleWithPlaceholderContent.Id;
        viewModel.Title = SectionTitleWithPlaceholderContent.Title;
      }

      return View(viewModel);
    }

    public ViewResult TextImageSection()
    {
      var viewModel = new TextImageSection();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.GetTextImageContent(dataSource);
      }

      return View("TextImageSection", viewModel);
    }

    public ViewResult TextImageSectionWithHeader()
    {
      var viewModel = new TextImageSection();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.GetTextImageContent(dataSource);
      }

      return View("TextImageSectionWithHeader", viewModel);
    }

    public ViewResult TextSection()
    {
      var viewModel = new TextSection();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.GetTextContent(dataSource);
      }

      return View("TextSection", viewModel);
    }


    public ViewResult TextContentCallout()
    {
      var viewModel = new TextSectionCallout();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.GetTextContentCallout(dataSource);
      }
      return View("TextContentCallout", viewModel);
    }

    public ViewResult KeyTakeaways()
    {
      var viewModel = new KeyTakeawaysViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var keyTakeway = _contentService.GetKeyTakeaway(dataSource);

        if (keyTakeway != null)
        {
          viewModel.Instructions = keyTakeway.Instructions;
          viewModel.Title = keyTakeway.Title;
          viewModel.Id = keyTakeway.Id;
          viewModel.Takeaways = keyTakeway.Takeaways;

        }

      }
      return View("KeyTakeaways", viewModel);
    }

    public ViewResult SideContent()
    {
      var viewModel = new SideContent();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var sideContent = _contentService.GetSideContent(dataSource);
        if (sideContent != null)
        {
          viewModel = sideContent;
        }
      }
      return View("SideCOntent", viewModel);
    }

    public ViewResult TextVideoSection()
    {
      var viewModel = new TextVideoSectionViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var content = _contentService.GetTextVideoSectionContent(dataSource);
        if (viewModel != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;
          viewModel.SubTitle = content.SubTitle;
          viewModel.Text = content.Text;
          viewModel.Video = content.Video;
        }
      }
      return View("TextVideoSection", viewModel);
    }

    public ViewResult RichTextTableSection()
    {
      var viewModel = new RichTextSectionViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var RichTextSectionContent = _contentService.GetRichTextSectionContent(dataSource);
      if (RichTextSectionContent != null)
      {
        viewModel.Id = RichTextSectionContent.Id;
        viewModel.Title = RichTextSectionContent.Title;
        viewModel.RichText = RichTextSectionContent.RichText;
      }
      return View("RichTextTable", viewModel);
    }

    public ViewResult BlueLinksList()
    {
      var viewModel = new BlueLinkList();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.GetBlueLinkedListContent(dataSource);
      }
      return View("BlueLinksList", viewModel);
    }

    public ViewResult LinkSectionCustomLinks()
    {
      var viewModel = new BlueLinkList();
      string dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        viewModel = _contentService.GetBlueLinkedListContent(dataSource);
        //set rendering params
        viewModel.DisplayHeader = RenderingContext.Current.Rendering.DisplayHeader();
      }
      return View("LinkSectionCustomLinks", viewModel);
    }

    public ViewResult DismissibleNotification()
    {
      var viewModel = new DismissibleNotificationViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var DismissibleNotificationContent = _contentService.GetDismissibleNotificationContent(dataSource);
      if (DismissibleNotificationContent != null)
      {
        viewModel.Id = DismissibleNotificationContent.Id;
        viewModel.NotificationText = DismissibleNotificationContent.NotificationText;
      }

      return View(viewModel);

    }

    public ViewResult RliPageTitleSection()
    {
        var viewModel = new RliPageTitleSectionViewModel();

        var dataSource = RenderingContext.Current.Rendering.DataSource;

        if (String.IsNullOrEmpty(dataSource))
        {
            dataSource = Sitecore.Context.Item.ID.ToString();
        }
        var rliPageTitleSection = _contentService.GetRliPageTitleSectionContent(dataSource);
        
        if (rliPageTitleSection != null)
        {
            viewModel.RliPageTitleSection = rliPageTitleSection;   
        }
        return View(viewModel);
    }

    public ViewResult WelcomeHub()
    {
      var viewModel = new WelcomeHubViewModel();

      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (String.IsNullOrEmpty(dataSource))
      {
        dataSource = Sitecore.Context.Item.ID.ToString();
      }
      var welcomeHub = _contentService.GetWelcomeHubContent(dataSource);

      if (welcomeHub != null)
      {
        viewModel.Id = welcomeHub.Id;
        viewModel.Title = welcomeHub.Title;
        viewModel.Image = welcomeHub.Image;
        viewModel.Link = welcomeHub.Link;
        viewModel.BgColor = welcomeHub.BgColor;
        viewModel.WelcomeHubItems = welcomeHub.WelcomeHubItems.Take(3);
      }
      return View("WelcomeHub", viewModel);
    }

    public ViewResult Countdown()
    {
      var viewModel = new CountdownViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (!string.IsNullOrEmpty(dataSource))
      {
        var CountdownContent = _contentService.GetCountdownContent(dataSource);
        if (CountdownContent != null)
        {
          viewModel.Id = CountdownContent.Id;
          viewModel.Title = CountdownContent.Title;
          viewModel.SubTitle = CountdownContent.SubTitle;
          viewModel.Image = CountdownContent.Image;
          viewModel.Link = CountdownContent.Link;
          viewModel.TargetDate = CountdownContent.TargetDate;
          viewModel.DisplayType = CountdownContent.DisplayType;
        }
      }
      return View(viewModel);
    }
  }
}