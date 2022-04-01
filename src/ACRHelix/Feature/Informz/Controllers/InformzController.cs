using ACR.Foundation.Personify.PersonifyService;
using ACRHelix.Feature.Informz.Services;
using ACRHelix.Feature.Informz.ViewModels;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ACRHelix.Feature.Informz
{
  public class InformzController : Controller
  {
    private const string InformzEmailKey = "InformzNewsletterEmail";
    private readonly IContentService _contentService;

    public InformzController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult NewsLetterSignUpFooter()
    {
      var viewModel = new NewsletterSignUp();
      var dataSource = RenderingContext.Current.Rendering.DataSource;

      if (!string.IsNullOrWhiteSpace(dataSource))
      {
        var content = _contentService.GetSignupContent(dataSource);
        if (content != null)
        {
          viewModel.Id = content.Id;
          viewModel.Title = content.Title;
          viewModel.Link = content.Link;
        }
      }
      return View(viewModel);
    }

    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public ActionResult NewsLetterSignUpFooter(NewsletterSignUp viewModel)
    //{
    //  string email = viewModel.Email;
    //  if (!string.IsNullOrWhiteSpace(email))
    //  {
    //    Session[InformzEmailKey] = email;
    //    //return Json(new { Sucess = true });
    //    return Redirect("/Sign-Up-for-ACR-Newsletters");
    //  }
    //  return View(new NewsletterSignUp());
    //  //return Json(new { Success = false });
    //  //return View(new NewsletterSignUp());
    //}

    [ValidateAntiForgeryToken]
    [HttpPost]
    public ViewResult InformzPage(InformzViewModel viewModel)
    {
      if (viewModel.HiddenCaptcha != "informz-valid")
      {
        return InformzPage("");
      }
      else
      {
        var informzContent = _contentService.GetInformzContent(Sitecore.Context.Item.ID);
        if (informzContent != null)
        {
          viewModel.InformzContent = informzContent;

          if (!string.IsNullOrWhiteSpace(viewModel.Email))
          {
            PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
            viewModel.CustomerData = svc.GetInformzCustomerData(viewModel.Email);

            //System.IO.File.WriteAllText(HttpContext.Server.MapPath("/App_Data/Personify") + "/CustomerData" + viewModel.CustomerData.EmailExists.ToString(), JsonConvert.SerializeObject(viewModel.CustomerData));

            if (!viewModel.CustomerData.EmailExists)
            {
              if (viewModel.RegistrationData != null)
              {

                //System.IO.File.WriteAllText(HttpContext.Server.MapPath("/App_Data/Personify") + "/viewmodel-registration-data", JsonConvert.SerializeObject(viewModel.RegistrationData));


                var RegistrationData = viewModel.RegistrationData;

                if (!string.IsNullOrWhiteSpace(RegistrationData.FirstName)
                  && !string.IsNullOrWhiteSpace(RegistrationData.LastName)
                  && !string.IsNullOrWhiteSpace(RegistrationData.Email)
                  && !string.IsNullOrWhiteSpace(RegistrationData.Address)
                  && !string.IsNullOrWhiteSpace(RegistrationData.City)
                  && !string.IsNullOrWhiteSpace(RegistrationData.Zip)
                  )
                {
                  var exists = svc.CustomerExists(RegistrationData.FirstName, RegistrationData.LastName, RegistrationData.City, RegistrationData.Zip);

                  //System.IO.File.WriteAllText(HttpContext.Server.MapPath("/App_Data/Personify") + "/viewmodel-registration-data", JsonConvert.SerializeObject(viewModel.RegistrationData));

                  if (exists.Exists == false)
                  {

                    string stateValue = "";
                    if (!string.IsNullOrWhiteSpace(RegistrationData.State))
                    {
                      int i = RegistrationData.State.IndexOf("|");
                      if (i > 0)
                      {
                        stateValue = RegistrationData.State.Substring(0, i);
                      }
                    }
                    var createResult = svc.CreateCustomer(RegistrationData.FirstName, RegistrationData.LastName,
                       RegistrationData.Email, RegistrationData.Address, RegistrationData.Address2,
                       RegistrationData.City, stateValue, RegistrationData.Country, RegistrationData.Zip, "");

                    if (createResult != null)
                    {
                      //viewModel.CustomerData = svc.GetInformzCustomerData(viewModel.Email);
                      //SetCheckboxes(viewModel);
                      Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "/Thank-You");
                    }
                  }
                  else
                  {
                    viewModel.Error = true;
                    //var myACR = Sitecore.Context.Database.GetItem("{CC2E0AE6-999E-4FBE-80EF-043DFC673C92}");
                    //viewModel.InformzContent.Title = "An error has occurred!";                    
                    //viewModel.ErrorMessage = string.Format("The following ACR account(s) already exist and match your information.<br>Name: {2}<br>Email: {1}<br><br>  Login to <a href=\"{0}\">My ACR</a> if you would like to make changes to your account.", LinkManager.GetItemUrl(myACR), string.Join(" | ", exists.Emails), string.Join(" | ", exists.Name));

                    viewModel.InformzContent.Title = viewModel.InformzContent.RegistrationErrorTitle;
                    viewModel.ErrorMessage = viewModel.InformzContent.RegistrationErrorMessage.Replace("#NAME#", string.Join(" | ", exists.Name)).Replace("#EMAIL#", string.Join(" | ", exists.Emails));

                  }
                }
              }
            }
            else
            {
              if (viewModel.FormSubmitted == "OptIn")
              {
                bool newslettersUpdated = false;
                bool newslettersUpdated1 = false;
                string masterCustomerID = viewModel.CustomerData.CustomerID;

                List<string> currentCodes = new List<string>();

                if (viewModel.CustomerData.OptInCodes != null)
                {
                  currentCodes = viewModel.CustomerData.OptInCodes.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                }

                if (viewModel.Checkboxes.FirstOrDefault(x => x.PersonifyCode == "UNSUBSCRIBE" && x.Checked == true) != null)
                {
                  if (svc.UnsubscribeAllNewsletters(viewModel.CustomerData.CustomerID))
                  {

                    var item = Sitecore.Context.Database.GetItem("{2F9666BF-5738-4328-93E5-2F26F6A9AF2E}");
                    if (item != null)
                    {
                      Response.Redirect(LinkManager.GetItemUrl(item));
                    }
                  }
                  else
                  {
                    Response.Redirect("/Error");
                  }
                }
                else
                {
                  List<string> codesToAdd = new List<string>();
                  List<string> codesToRemove = new List<string>();
                  foreach (var checkBox in viewModel.Checkboxes)
                  {
                    var checkBoxCodes = checkBox.PersonifyCode.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var code in checkBoxCodes)
                    {
                      if (checkBox.Checked)
                      {
                        if (!currentCodes.Contains(code))
                        {
                          codesToAdd.Add(code);
                        }
                      }
                      else
                      {
                        if (currentCodes.Contains(code))
                        {
                          codesToRemove.Add(code);
                        }
                      }
                    }
                  }

                  if (codesToAdd.Count > 0)
                  {
                    newslettersUpdated = svc.CustomerOptInNewsletters(viewModel.CustomerData.CustomerID, string.Join("|", codesToAdd));
                  }
                  else
                  {
                    newslettersUpdated = true;
                  }

                  if (codesToRemove.Count > 0)
                  {
                    newslettersUpdated1 = svc.CustomerOptOutNewsletters(viewModel.CustomerData.CustomerID, string.Join("|", codesToRemove));
                  }
                  else
                  {
                    newslettersUpdated1 = true;
                  }

                  if (newslettersUpdated && newslettersUpdated1)
                  {
                    Response.Redirect(LinkManager.GetItemUrl(Sitecore.Context.Item) + "/Thank-You-for-Updating");
                  }
                  else
                  {
                    Response.Redirect("/Error");
                  }
                }
              }
              else
              {
                SetCheckboxes(viewModel);

              }
            }

          }
        }
        return View(viewModel);
      }
    }

    [HttpGet]
    public ViewResult InformzPage(string email, string wf = "1")
    {
      var viewModel = new InformzViewModel();

      var informzContent = _contentService.GetInformzContent(Sitecore.Context.Item.ID);
      if (informzContent != null)
      {
        viewModel.InformzContent = informzContent;
        viewModel.Checkboxes = new List<ViewModelCheckbox>();
        if (Session[InformzEmailKey] != null)
        {
          string sessionEmail = Session[InformzEmailKey].ToString();
          email = sessionEmail;
          if (!string.IsNullOrWhiteSpace(email))
          {
            viewModel.Email = email;

            PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
            viewModel.CustomerData = svc.GetInformzCustomerData(email);

            if (viewModel.CustomerData.EmailExists)
            {
              viewModel.InformzContent.Title = viewModel.InformzContent.RegisterTitle; // "This email already exists";

              foreach (var cat in viewModel.InformzContent.Categories)
              {
                if (wf == "2" && !viewModel.CustomerData.IsMember)
                {
                  cat.Newsletters = cat.Newsletters.Where(x => x.IsAvailableForNonMember == true);
                }
                foreach (var news in cat.Newsletters)
                {
                  viewModel.Checkboxes.Add(new ViewModelCheckbox() { Checked = false, PersonifyCode = news.PersonifyCode });
                }
              }

              if (viewModel.CustomerData.OptInCodes != null)
              {

                string[] codes = viewModel.CustomerData.OptInCodes.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var cb in viewModel.Checkboxes)
                {
                  string[] pcodes = cb.PersonifyCode.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                  foreach (var pc in pcodes)
                  {
                    if (codes.Contains(pc))
                    {
                      cb.Checked = true;
                    }
                  }

                }
              }
            }
          }
        }
      }
      if (wf == "2")
      {
        viewModel.InformzContent.Categories = viewModel.InformzContent.Categories.Where(x => x.Newsletters.Count() > 0);
        viewModel.InformzContent.Title = viewModel.InformzContent.UpdateProfileTitle;
      }
      return View(viewModel);
    }

    [HttpGet]
    public ViewResult UpdateEmailPreferences()
    {
      var viewModel = new UpdateEmailViewModel();

      var informzContent = _contentService.GetInformzContent(Sitecore.Context.Item.ID);
      if (informzContent != null)
      {
        viewModel.InformzContent = informzContent;
      }
      Session["SubClkCount"] = null;
      return View(viewModel);
    }

    [HttpPost]
	[ValidateAntiForgeryToken]
    public ActionResult UpdateEmailPreferences(UpdateEmailViewModel viewModel)
    {
      var informzContent = _contentService.GetInformzContent(Sitecore.Context.Item.ID);
      if (informzContent != null)
      {
        viewModel.InformzContent = informzContent;

        if (!string.IsNullOrWhiteSpace(viewModel.Email))
        {
          viewModel.InformzContent.Title = "Tell us what you would like to hear about";

          PersonifyEntitiesACR svc = new PersonifyEntitiesACR();
          viewModel.CustomerData = svc.GetInformzCustomerData(viewModel.Email);

          if (viewModel.CustomerData.EmailExists)
          {
            viewModel.Email = viewModel.Email; // + "|WF2";

            return Redirect("/Sign-Up-for-ACR-Newsletters?email=" + viewModel.Email + "&wf=2");
          }
          else
          {
            if (Session["SubClkCount"] != null)
            {
              Session["SubClkCount"] = (int)Session["SubClkCount"] + 1;
              viewModel.Count = (int)Session["SubClkCount"];
            }
            else
            {
              viewModel.Count = 1;
              Session["SubClkCount"] = viewModel.Count;
            }
          }
        }
      }
      return View(viewModel);
    }

    private void SetCheckboxes(InformzViewModel viewModel)
    {
      viewModel.Checkboxes = new List<ViewModelCheckbox>();
      foreach (var cat in viewModel.InformzContent.Categories)
      {
        foreach (var news in cat.Newsletters)
        {
          viewModel.Checkboxes.Add(new ViewModelCheckbox() { Checked = false, PersonifyCode = news.PersonifyCode });
        }
      }
      if (viewModel.CustomerData.OptInCodes != null)
      {
        string[] codes = viewModel.CustomerData.OptInCodes.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var cb in viewModel.Checkboxes)
        {
          string[] pcodes = cb.PersonifyCode.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

          foreach (var pc in pcodes)
          {
            if (codes.Contains(pc))
            {
              cb.Checked = true;
            }
          }
        }
      }
    }
  }
}