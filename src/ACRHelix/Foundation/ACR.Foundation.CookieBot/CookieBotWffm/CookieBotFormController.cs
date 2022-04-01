using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Forms.Mvc;
using Sitecore.Forms.Mvc.Attributes;
using Sitecore.Forms.Mvc.Controllers;
using Sitecore.Forms.Mvc.Controllers.Filters;
using Sitecore.Forms.Mvc.Controllers.ModelBinders;
using Sitecore.Forms.Mvc.Interfaces;
using Sitecore.Forms.Mvc.Models;
using Sitecore.Forms.Mvc.ViewModels;
using Sitecore.Mvc.Controllers;
using Sitecore.WFFM.Abstractions.Dependencies;
using Sitecore.WFFM.Abstractions.Shared;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ACR.Foundation.CookieBot.CookieBotWffm
{
  [ModelBinder(typeof(FormModelBinder))]
  public class CookieBotFormController : SitecoreController
  {

      private readonly IAnalyticsTracker analyticsTracker;

      public IFormProcessor<FormModel> FormProcessor
      {
        get;
        private set;
      }

      public IRepository<FormModel> FormRepository
      {
        get;
        private set;
      }

      public IAutoMapper<IFormModel, FormViewModel> Mapper
      {
        get;
        private set;
      }

      public CookieBotFormController() : this((IRepository<FormModel>)Factory.CreateObject(Constants.FormRepository, true), (IAutoMapper<IFormModel, FormViewModel>)Factory.CreateObject(Constants.FormAutoMapper, true), (IFormProcessor<FormModel>)Factory.CreateObject(Constants.FormProcessor, true), DependenciesManager.get_AnalyticsTracker())
      {
      }

      public CookieBotFormController(IRepository<FormModel> repository, IAutoMapper<IFormModel, FormViewModel> mapper, IFormProcessor<FormModel> processor, IAnalyticsTracker analyticsTracker)
      {
        Assert.ArgumentNotNull(repository, "repository");
        Assert.ArgumentNotNull(mapper, "mapper");
        Assert.ArgumentNotNull(processor, "processor");
        Assert.ArgumentNotNull(analyticsTracker, "analyticsTracker");
        this.FormRepository = repository;
        this.Mapper = mapper;
        this.FormProcessor = processor;
        this.analyticsTracker = analyticsTracker;
      }

      public virtual FormResult<FormModel, FormViewModel> Form()
      {
        FormResult<FormModel, FormViewModel> formResult = new FormResult<FormModel, FormViewModel>(this.FormRepository, this.Mapper)
        {
          ViewData = base.ViewData,
          TempData = base.TempData,
          ViewEngineCollection = base.ViewEngineCollection
        };
        return formResult;
      }

      [FormErrorHandler]
      [HttpGet]
      public override ActionResult Index()
      {
        return this.Form();
      }

      [FormErrorHandler]
      [HttpPost]
      [SubmittedFormHandler]
      [WffmValidateAntiForgeryToken]
      public virtual ActionResult Index([ModelBinder(typeof(FormModelBinder))] FormViewModel formViewModel)
      {
        this.analyticsTracker.InitializeTracker();
        return this.ProcessedForm(formViewModel, "");
      }

      [AllowCrossSiteJson]
      [FormErrorHandler]
      public virtual JsonResult Process([ModelBinder(typeof(FormModelBinder))] FormViewModel formViewModel)
      {
        string str;
        this.analyticsTracker.InitializeTracker();
        ProcessedFormResult<FormModel, FormViewModel> processedFormResult = this.ProcessedForm(formViewModel, "~/Views/Form/Index.cshtml");
        processedFormResult.ExecuteResult(base.ControllerContext);
        using (StringWriter stringWriter = new StringWriter())
        {
          ViewContext viewContext = new ViewContext(base.ControllerContext, processedFormResult.View, base.ViewData, base.TempData, stringWriter);
          processedFormResult.View.Render(viewContext, stringWriter);
          str = stringWriter.GetStringBuilder().ToString();
        }
        base.ControllerContext.HttpContext.Response.Clear();
        return new JsonResult()
        {
          Data = str
        };
      }

      public virtual ProcessedFormResult<FormModel, FormViewModel> ProcessedForm(FormViewModel viewModel, string viewName = "")
      {
        ProcessedFormResult<FormModel, FormViewModel> processedFormResult = new ProcessedFormResult<FormModel, FormViewModel>(this.FormRepository, this.Mapper, this.FormProcessor, viewModel)
        {
          ViewData = base.ViewData,
          TempData = base.TempData,
          ViewEngineCollection = base.ViewEngineCollection
        };
        ProcessedFormResult<FormModel, FormViewModel> processedFormResult1 = processedFormResult;
        if (!string.IsNullOrEmpty(viewName))
        {
          processedFormResult1.ViewName = viewName;
        }
        return processedFormResult1;
      }
    }
  }
}