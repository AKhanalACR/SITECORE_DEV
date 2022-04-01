using ACRHelix.Feature.ImageWiselyContent.Filters;
using ACRHelix.Feature.ImageWiselyContent.Models;
using ACRHelix.Feature.ImageWiselyContent.Services;
using ACRHelix.Feature.ImageWiselyContent.ViewModels;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ACRHelix.Feature.ImageWiselyContent
{
  public class ImageWiselyPledgeController : Controller
  {
    private readonly IContentService _contentService;
    private readonly PledgeService _pledgeService;
    private string _pledgTypeFolder = "{9CB1BDB3-A8F2-4DDF-96CC-C6B5D3BEEE97}";

    public ImageWiselyPledgeController(IContentService contentService)
    {
      _contentService = contentService;
      _pledgeService = new PledgeService();
    }

    //imaging professionals
    public ViewResult ImageWiselyContent()
    {
      var viewModel = new ImageWiselyContentViewModel();
      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var ImageWiselyContentContent = _contentService.GetImageWiselyContentContent(RenderingContext.Current.Rendering.DataSource);
        if (ImageWiselyContentContent != null)
        {
          viewModel.Title = ImageWiselyContentContent.Title;
        }
      }
      return View(viewModel);
    }



    [HttpGet]
    public ActionResult ImagingProfessionals()
    {
      var viewModel = new IndivPledgeFormViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      if (!string.IsNullOrEmpty(dataSource))
      {
        var PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
        }
      }
      _pledgeService.InitiallizeIndividualPledge(viewModel.IndividualPledge, "Imaging Professionals");
      _pledgeService.SetDefaultCountry(viewModel.IndividualPledge.Countries);
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateGoogleCaptcha]
    public ActionResult ImagingProfessionals(IndivPledgeFormViewModel viewModel)
    {
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      IPledgeForm PledgeForm = new PledgeForm();
      if (!string.IsNullOrEmpty(dataSource))
      {
        PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
          viewModel.PledgeType = PledgeForm.PledgeType;
          viewModel.SendFormDataTo = PledgeForm.SendFormDataTo;
          viewModel.ConfirmationEmailFrom = PledgeForm.ConfirmationEmailFrom;
          viewModel.ConfirmationEmailSubject = PledgeForm.ConfirmationEmailSubject;
          viewModel.ConfirmationEmailBody = PledgeForm.ConfirmationEmailBody;
          viewModel.ValidationErrorMessage = PledgeForm.ValidationErrorMessage;
        }
      }
      _pledgeService.InitiallizeIndividualPledge(viewModel.IndividualPledge);

      var isCaptchaInvalid = TempData["InvalidCaptcha"] == null ? false : (bool)TempData["InvalidCaptcha"];

      if (!ModelState.IsValid || (isCaptchaInvalid))
      {
        _pledgeService.InitiallizeIndividualPledge(viewModel.IndividualPledge, "Imaging Professionals");
        return View("ImagingProfessionals", viewModel);
      }

      //check duplicate submission
      var pledgType = _contentService.GetPledgeTypesList(_pledgTypeFolder).PledgeTypesList.Where(n => n.Name == viewModel.PledgeType).FirstOrDefault();
      if (pledgType != null)
      {
        if (_pledgeService.CheckDuplicates(viewModel.IndividualPledge.Email, pledgType.Id.ToString()))
        {
          viewModel.isEmailExists = true;
          return View(viewModel);
        }
      }

      //send email to imagewisely
      _pledgeService.SendEmail_IP(PledgeForm, viewModel.IndividualPledge);

      //save pledge to database
      var isSuccessSaved = _pledgeService.SaveImagingProfessionalsPledge(viewModel.IndividualPledge, viewModel.SendFormDataTo);

      var options = LinkManager.GetDefaultUrlOptions();
      options.AlwaysIncludeServerUrl = true;

      if (isSuccessSaved)
      {
        //send confirmation email to user
        _pledgeService.SendEmailToUser(viewModel.IndividualPledge.Email, PledgeForm);

        Item thkItem = Sitecore.Context.Database.GetItem("{EAC324E1-6553-4863-B6A1-C282360E1745}");
        return Redirect(LinkManager.GetItemUrl(thkItem, options));
      }

      Item itm = Sitecore.Context.Database.GetItem("{BB6509E7-2D10-4422-856B-68893D21A0DF}");
      return Redirect(LinkManager.GetItemUrl(itm, options));
    }

    [HttpGet]
    public ActionResult ReferringPractitioners()
    {
      var viewModel = new IndivPledgeFormViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      if (!string.IsNullOrEmpty(dataSource))
      {
        var PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
        }
      }
      _pledgeService.InitiallizeIndividualPledge(viewModel.IndividualPledge);
      _pledgeService.SetDefaultCountry(viewModel.IndividualPledge.Countries);
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateGoogleCaptcha]
    public ActionResult ReferringPractitioners(IndivPledgeFormViewModel viewModel)
    {
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();
      IPledgeForm PledgeForm = new PledgeForm();
      if (!string.IsNullOrEmpty(dataSource))
      {
        PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
          viewModel.PledgeType = PledgeForm.PledgeType;
          viewModel.SendFormDataTo = PledgeForm.SendFormDataTo;
          viewModel.ConfirmationEmailFrom = PledgeForm.ConfirmationEmailFrom;
          viewModel.ConfirmationEmailSubject = PledgeForm.ConfirmationEmailSubject;
          viewModel.ConfirmationEmailBody = PledgeForm.ConfirmationEmailBody;
          viewModel.ValidationErrorMessage = PledgeForm.ValidationErrorMessage;
        }
      }
      _pledgeService.InitiallizeIndividualPledge(viewModel.IndividualPledge);

      var isCaptchaInvalid = TempData["InvalidCaptcha"] == null ? false : (bool)TempData["InvalidCaptcha"];

      if (!ModelState.IsValid || (isCaptchaInvalid))
      {
        _pledgeService.InitiallizeIndividualPledge(viewModel.IndividualPledge);
        return View("ReferringPractitioners", viewModel);
      }

      //check duplicate submission
      var pledgType = _contentService.GetPledgeTypesList(_pledgTypeFolder).PledgeTypesList.Where(n => n.Name == viewModel.PledgeType).FirstOrDefault();
      if (pledgType != null)
      {
        if (_pledgeService.CheckDuplicates(viewModel.IndividualPledge.Email, pledgType.Id.ToString()))
        {
          viewModel.isEmailExists = true;
          return View(viewModel);
        }
      }

      //send email to imagewisely
      _pledgeService.SendEmail_IP(PledgeForm, viewModel.IndividualPledge);

      //save pledge to database
      var isSuccessSaved = _pledgeService.SaveReferringPractitionersPledge(viewModel.IndividualPledge, viewModel.SendFormDataTo);

      var options = LinkManager.GetDefaultUrlOptions();
      options.AlwaysIncludeServerUrl = true;

      if (isSuccessSaved)
      {
        //send confirmation email to user
        _pledgeService.SendEmailToUser(viewModel.IndividualPledge.Email, PledgeForm);

        Item thkItem = Sitecore.Context.Database.GetItem("{EAC324E1-6553-4863-B6A1-C282360E1745}");
        return Redirect(LinkManager.GetItemUrl(thkItem, options));
      }

      Item itm = Sitecore.Context.Database.GetItem("{BB6509E7-2D10-4422-856B-68893D21A0DF}");
      return Redirect(LinkManager.GetItemUrl(itm, options));
    }

    [HttpGet]
    public ActionResult ImagingFacilities()
    {
      var viewModel = new GroupPledgeFormViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      if (!string.IsNullOrEmpty(dataSource))
      {
        var PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
        }
      }
      _pledgeService.InitiallizeGroupPledge(viewModel.GroupPledge);
      _pledgeService.SetDefaultCountry(viewModel.GroupPledge.Countries);
      _pledgeService.SetDefaultIsDisplayOnHonorRoll(viewModel.GroupPledge);
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateGoogleCaptcha]
    public ActionResult ImagingFacilities(GroupPledgeFormViewModel viewModel)
    {
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();
      IPledgeForm PledgeForm = new PledgeForm();
      if (!string.IsNullOrEmpty(dataSource))
      {
        PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
          viewModel.PledgeType = PledgeForm.PledgeType;
          viewModel.SendFormDataTo = PledgeForm.SendFormDataTo;
          viewModel.ConfirmationEmailFrom = PledgeForm.ConfirmationEmailFrom;
          viewModel.ConfirmationEmailSubject = PledgeForm.ConfirmationEmailSubject;
          viewModel.ConfirmationEmailBody = PledgeForm.ConfirmationEmailBody;
          viewModel.ValidationErrorMessage = PledgeForm.ValidationErrorMessage;
        }
      }
      _pledgeService.InitiallizeGroupPledge(viewModel.GroupPledge);

      var isCaptchaInvalid = TempData["InvalidCaptcha"] == null ? false : (bool)TempData["InvalidCaptcha"];

      if (!ModelState.IsValid || (isCaptchaInvalid))
      {
        _pledgeService.InitiallizeGroupPledge(viewModel.GroupPledge);
        return View("ImagingFacilities", viewModel);
      }

      //check duplicate submission
      //var pledgType = _contentService.GetPledgeTypesList(_pledgTypeFolder).PledgeTypesList.Where(n => n.Name == viewModel.PledgeType).FirstOrDefault();
      //if (pledgType != null)
      //{
      //    if (_pledgeService.CheckDuplicates(viewModel.GroupPledge.Email, pledgType.Id.ToString()))
      //    {
      //        viewModel.isEmailExists = true;
      //        return View(viewModel);
      //    }
      //}

      //send email to imagewisely
      _pledgeService.SendEmail_GP(PledgeForm, viewModel.GroupPledge);

      //save pledge to database
      var isSuccessSaved = _pledgeService.SaveFacilitiesPledge(viewModel.GroupPledge, viewModel.SendFormDataTo);

      var options = LinkManager.GetDefaultUrlOptions();
      options.AlwaysIncludeServerUrl = true;

      if (isSuccessSaved)
      {
        //send confirmation email to user
        _pledgeService.SendEmailToUser(viewModel.GroupPledge.Email, PledgeForm);

        Item thkItem = Sitecore.Context.Database.GetItem("{EAC324E1-6553-4863-B6A1-C282360E1745}");
        return Redirect(LinkManager.GetItemUrl(thkItem, options));
      }

      Item itm = Sitecore.Context.Database.GetItem("{BB6509E7-2D10-4422-856B-68893D21A0DF}");
      return Redirect(LinkManager.GetItemUrl(itm, options));
    }

    [HttpGet]
    public ActionResult AssocOrEduPrograms()
    {
      var viewModel = new GroupPledgeFormViewModel();
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();

      if (!string.IsNullOrEmpty(dataSource))
      {
        var PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
        }
      }
      _pledgeService.InitiallizeGroupPledge(viewModel.GroupPledge);
      _pledgeService.SetDefaultCountry(viewModel.GroupPledge.Countries);
      _pledgeService.SetDefaultIsDisplayOnHonorRoll(viewModel.GroupPledge);
      return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ValidateGoogleCaptcha]
    public ActionResult AssocOrEduPrograms(GroupPledgeFormViewModel viewModel)
    {
      var dataSource = RenderingContext.Current.Rendering.DataSource;
      if (string.IsNullOrEmpty(dataSource))
        dataSource = Sitecore.Context.Item.ID.ToString();
      IPledgeForm PledgeForm = new PledgeForm();
      if (!string.IsNullOrEmpty(dataSource))
      {
        PledgeForm = _contentService.GetPledgeContent(dataSource);
        if (PledgeForm != null)
        {
          viewModel.Id = PledgeForm.Id;
          viewModel.Title = PledgeForm.Title;
          viewModel.SubTitle = PledgeForm.SubTitle;
          viewModel.ButtonText = PledgeForm.ButtonText;
          viewModel.PledgeType = PledgeForm.PledgeType;
          viewModel.SendFormDataTo = PledgeForm.SendFormDataTo;
          viewModel.ConfirmationEmailFrom = PledgeForm.ConfirmationEmailFrom;
          viewModel.ConfirmationEmailSubject = PledgeForm.ConfirmationEmailSubject;
          viewModel.ConfirmationEmailBody = PledgeForm.ConfirmationEmailBody;
          viewModel.ValidationErrorMessage = PledgeForm.ValidationErrorMessage;
        }
      }
      _pledgeService.InitiallizeGroupPledge(viewModel.GroupPledge);

      var isCaptchaInvalid = TempData["InvalidCaptcha"] == null ? false : (bool)TempData["InvalidCaptcha"];

      if (!ModelState.IsValid || (isCaptchaInvalid))
      {
        _pledgeService.InitiallizeGroupPledge(viewModel.GroupPledge);
        return View("AssocOrEduPrograms", viewModel);
      }

      //check duplicate submission
      //var pledgType = _contentService.GetPledgeTypesList(_pledgTypeFolder).PledgeTypesList.Where(n => n.Name == viewModel.PledgeType).FirstOrDefault();
      //if (pledgType != null)
      //{
      //    if (_pledgeService.CheckDuplicates(viewModel.GroupPledge.Email, pledgType.Id.ToString()))
      //    {
      //        viewModel.isEmailExists = true;
      //        return View(viewModel);
      //    }
      //}

      //send email to imagewisely
      _pledgeService.SendEmail_GP(PledgeForm, viewModel.GroupPledge);

      //save pledge to database
      var isSuccessSaved = _pledgeService.SaveAssosiationOrEducationalProgrammPledge(viewModel.GroupPledge, viewModel.SendFormDataTo);

      var options = LinkManager.GetDefaultUrlOptions();
      options.AlwaysIncludeServerUrl = true;

      if (isSuccessSaved)
      {
        //send confirmation email to user
        _pledgeService.SendEmailToUser(viewModel.GroupPledge.Email, PledgeForm);

        Item thkItem = Sitecore.Context.Database.GetItem("{EAC324E1-6553-4863-B6A1-C282360E1745}");
        return Redirect(LinkManager.GetItemUrl(thkItem, options));
      }

      Item itm = Sitecore.Context.Database.GetItem("{BB6509E7-2D10-4422-856B-68893D21A0DF}");
      return Redirect(LinkManager.GetItemUrl(itm, options));
    }

    public JsonResult GetProvinces()
    {
      var items = _pledgeService.GetProvinces();

      return new JsonResult()
      {
        Data = new
        {
          items
        }
      };
    }

    //[HttpGet]
    //public JsonResult GetInternationalFacilities()
    //{
    //  var internationalFacilities = _pledgeService.GetInternationalFacilities();
    //  return Json(internationalFacilities, JsonRequestBehavior.AllowGet);
    //}

    public ViewResult InternationFacilityHonorRollList()
    {
      InternationalFacilityHonorRollListViewModel viewModel = null;

      var dataSource = RenderingContext.Current.Rendering.DataSource;
      int year = 0;
      string noFacilities = null;
      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var settings = _contentService.GetInternationFacilityListSettings(dataSource);
        if (settings != null)
        {
          year = settings.Year;
          noFacilities = settings.NoFacilities;
        }
      }

      var internationalFacilities = _pledgeService.GetInternationalFacilities(year);

      viewModel = new InternationalFacilityHonorRollListViewModel(internationalFacilities);
      viewModel.NoFacilitiesText = noFacilities;


      return View(viewModel);

    }



    public JsonResult GetStates()
    {
      var items = _pledgeService.GetStates();

      return new JsonResult()
      {
        Data = new
        {
          items
        }
      };
    }


  }
}