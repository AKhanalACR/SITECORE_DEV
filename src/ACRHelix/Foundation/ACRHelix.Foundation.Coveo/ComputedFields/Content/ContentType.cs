using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using ACR.Foundation.Personify.Models.Products;
using ACRHelix.Foundation.CustomCoveo.Services;
using ACR.Foundation.Personify.Helpers;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields.Content
{
  public class ContentType : IComputedIndexField
  {
    public string FieldName { get; set; }
    public string ReturnType
    {
      get
      {
        return CoveoConstants.CoveoFieldTypes.CoveoString;
      }
      set
      {

      }
    }

    //private static string[] TestimonialTemplates = new string[]{
    //  "{C724C02E-F356-47A0-BF8B-40EB0546D7F6}", //testimonial form
    //  "{47B5C367-07EB-4A15-AF4E-97D970DD7479}", //testimonial page
    //  "{F8C25D64-FEA9-49A2-A763-78DF7A277FF8}" //testimonial
    //};

    private static string[] NewsTemplates = new string[]{
      "{DEA31E9E-89A7-4524-9D97-CED66286746F}", //news issue
      "{69A72F21-1AE2-4688-B9E1-D051A07D8A68}", //news landing
      "{1D76D814-A3D0-4263-94C9-3B34A87EC8CD}", //news list page
      "{CE0F48F7-65A2-4D60-BB97-0CBD290FAF7B}", //news article
      "{77068398-6B99-4FD9-8C5F-3A083EC2FDD2}", //newsletter
      "{832E794A-54C0-4B36-B168-AEBFF2BC03AD}", //news issue list

      "{AB86861A-6030-46C5-B394-E8F99E8B87DB}" //DSI new blog article
    };

    private static string[] ContentTemplates = new string[]{
      "{F212EE88-6B77-4EC0-8734-56C760B28DDA}", //login page
      "{00AD2366-30CB-431A-A0CE-3A96665E0ED3}", //search page
      "{8C7D8671-9E03-44AF-A424-FFC97B5BE8BC}", //social media page
      "{ADF43766-D8AC-43C8-BACB-8FEA221228D3}", //home
      "{0CEA0658-0891-4FE2-897A-79FF8BB21523}", //external content page

      "{C724C02E-F356-47A0-BF8B-40EB0546D7F6}", //testimonial form
      "{47B5C367-07EB-4A15-AF4E-97D970DD7479}", //testimonial page
      "{F8C25D64-FEA9-49A2-A763-78DF7A277FF8}", //testimonial

      "{A07D5846-E7D2-43F9-8DB1-D7CCB51E49F6}", //IW Article List Page
      "{04C2E154-2A0E-4C33-A235-39B376B77AB6}", //IW News List Page
      "{54D5F94C-B4EC-4FCF-BB14-0FF9FE4AD1A0}", //Bulletin home page

      "{185E7629-5035-4764-8439-ABC39402C4DC}", //Chapter page
      "{B9D9616B-0850-4340-9F1D-11952B20BEEF}", //marketingproductspage
      "{3719498A-EB08-4D13-852C-FF6CDC43245E}"  //ProductMarketingPage
    };

    public object ComputeFieldValue(IIndexable indexable)
    {
      SitecoreIndexableItem indexableItem = indexable as SitecoreIndexableItem;
      if (indexableItem != null)
      {
        string templateId = indexableItem.Item.TemplateID.ToString();

        if (templateId == "{57271EE9-5A71-4DE4-B5EC-F48750AD051A}")
        {
          return "Press Release";
        }

        if (templateId == "{6C0A1097-31B1-4406-8922-D5D4BB9E8925}") //meetingorcourse
        {
          return "Meeting / Course";        
        }

        if (templateId == SitecoreConstants.Templates.MeetingNoProductStub.TemplateID)
        {
          return "Meeting / Course";
        }

        if (templateId == ProductStubItem.TemplateID) //product stub
        {
          var productStub = CoveoSitecoreService.Service.Cast<ProductStubItem>(indexableItem.Item);
          if (productStub.ProductHasMeetingUrl())
          {
            return "Meeting / Course";
          }
          return "Product";
        }

        if (templateId == "{61638935-4C4D-4423-A446-3705DF33905B}") //toolkit content
        {
          return "Toolkit";
        }

        if (ContentTemplates.Contains(templateId))
        {
          return "Content Page";
        }

        //if (TestimonialTemplates.Contains(templateId))
        //{
        //  return "Testimonial";
        //}

        if (NewsTemplates.Contains(templateId))
        {
          return "News";
        }

        if (indexableItem.Item.IsDerived("{777F0C76-D712-46EA-9F40-371ACDA18A1C}")) //unversioned document
        {
          //return "Document";
          return "File";
        }

        if (indexableItem.Item.IsDerived("{2A130D0C-A2A9-4443-B418-917F857BF6C9}")) //versioned document
        {
          //return "Document";
          return "File";
        }

        if (indexableItem.Item.IsDerived("{962B53C4-F93B-4DF9-9821-415C867B8903}")) //unversioned file
        {
          return "File";
        }

        if (indexableItem.Item.IsDerived("{611933AC-CE0C-4DDC-9683-F830232DB150}")) //versioned file
        {
          return "File";
        }
        
        if (templateId == "{2EAD1608-9E8C-444F-AF66-766578E687F8}")
        {
          return "Video Resource";
        }


        return indexableItem.Item.TemplateName;
      }
      return null;
    }
  }
}