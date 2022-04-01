using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Items;
using Glass.Mapper.Sc.Configuration.Attributes;
using ACR.Foundation.Personify.Models.Base;
using ACR.Foundation.Personify.Models.Taxonomy;
using Glass.Mapper.Sc.Configuration;
using ACR.Foundation.Personify.Models.Taxonomy.RLI;

namespace ACR.Foundation.Personify.Models.Products
{
  [SitecoreType(TemplateId = TemplateID, AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class ProductStubItem : PersonifyTags, IBasePersonifyItem
  {
    public new const string TemplateID = "{62BEEA1D-6B79-4E0C-A98F-E337E321DBBE}";

    public virtual string Name { get; set; }

    public virtual IBasePersonifyItem Parent { get; set; }

    #region PersonifyFields
    [SitecoreField("Personify ID")]
    public virtual string PersonifyID { get; set; }

    [SitecoreField("Name")]
    public virtual string PName { get; set; }

    [SitecoreField("Long Name")]
    public virtual string LongName { get; set; }

    [SitecoreField("Status")]
    public virtual string Status { get; set; }

    [SitecoreField("Web Display")]
    public virtual bool WebDisplay { get; set; }

    [SitecoreField("Web Display Start Date")]
    public virtual DateTime WebDisplayStartDate { get; set; }

    [SitecoreField("Web Display End Date")]
    public virtual DateTime WebDisplayEndDate { get; set; }

    [SitecoreField("Date Modified")]
    public virtual DateTime DateModified { get; set; }

    [SitecoreField("Stock Status")]
    public virtual string StockStatus { get; set; }

    [SitecoreField("List Price")]
    public virtual string ListPrice { get; set; }

    [SitecoreField("Member Price")]
    public virtual string MemberPrice { get; set; }

    [SitecoreField("MIT Price")]
    public virtual string MITPrice { get; set; }

    [SitecoreField("Technologists Price")]
    public virtual string TechnologistsPrice { get; set; }

    [SitecoreField("Image Small Url")]
    public virtual string ImageSmallUrl { get; set; }

    [SitecoreField("Image Large Url")]
    public virtual string ImageLargeUrl { get; set; }

    //[SitecoreField("Short Description", ReadOnly = true)]
    //public virtual string ShortDescription { get; set; }

    //[SitecoreField("Long Description", ReadOnly = true)]
    //public virtual string LongDescription { get; set; }

    [SitecoreField("Short Description", Setting = SitecoreFieldSettings.RichTextRaw)]
    public virtual string ShortDescription_Raw { get; set; }

    [SitecoreField("Long Description", Setting = SitecoreFieldSettings.RichTextRaw)]
    public virtual string LongDescription_Raw { get; set; }

    [SitecoreField("Product Url")]
    public virtual string ProductUrl { get; set; }

    [SitecoreField("Product Area", FieldType = SitecoreFieldType.DropTree)]
    public virtual PersonifyTaxonomyItem ProductArea { get; set; }

    [SitecoreField("Product Class", FieldType = SitecoreFieldType.DropTree)]
    public virtual PersonifyTaxonomyItem ProductClass { get; set; }

    [SitecoreField("Product Type", FieldType = SitecoreFieldType.DropTree)]
    public virtual PersonifyTaxonomyItem ProductType { get; set; }

    [SitecoreField("Keywords")]
    public virtual string Keywords { get; set; }

    [SitecoreField("Related Products", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<ProductStubItem> RelatedProducts { get; set; }

    [SitecoreField("Related Topics", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> RelatedTopics { get; set; }

    [SitecoreField("Delivery Method", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> DeliveryMethods { get; set; }

    [SitecoreField("ABR Codes", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> ABRCodes { get; set; }

    [SitecoreField("Credit Types", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<PersonifyTaxonomyItem> CreditTypes { get; set; }

    //section course meeting details
    [SitecoreField("Meeting Start Date")]
    public virtual DateTime MeetingStartDate { get; set; }

    [SitecoreField("Meeting End Date")]
    public virtual DateTime MeetingEndDate { get; set; }

    [SitecoreField("Meeting Last Registration Date")]
    public virtual DateTime MeetingLastRegistrationDate { get; set; }

    [SitecoreField("Meeting Facility Name")]
    public virtual string MeetingFacilityName { get; set; }

    [SitecoreField("Meeting Label Name")]
    public virtual string MeetingLabelName { get; set; }

    [SitecoreField("Meeting City")]
    public virtual string MeetingCity { get; set; }

    [SitecoreField("Meeting State")]
    public virtual string MeetingState { get; set; }

    [SitecoreField("CME Credit")]
    public virtual string CMECredit { get; set; }

    [SitecoreField("Meeting Registration Form Url")]
    public virtual string MeetingRegistrationFormUrl { get; set; }
    #endregion

    #region RLIFields

    [SitecoreField("CREDIT", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<RLIPersonifySubCode> Credit { get; set; }

    [SitecoreField("DOMAIN", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<RLIPersonifySubCode> Domain { get; set; }

    [SitecoreField("INTERESTS", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<RLIPersonifySubCode> Interests { get; set; }

    [SitecoreField("TOPIC", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<RLIPersonifySubCode> Topic { get; set; }

    [SitecoreField("DELIVERY", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<RLIPersonifySubCode> Delivery { get; set; }

    [SitecoreField("LEVEL", FieldType = SitecoreFieldType.Treelist)]
    public virtual IEnumerable<RLIPersonifySubCode> Level { get; set; }

    [SitecoreField("HasRLI")]
    public virtual bool HasRLI { get; set; }

    [SitecoreField("IsMeeting")]
    public virtual bool IsMeeting { get; set; }

    [SitecoreInfo(SitecoreInfoType.Url)]
    public virtual string Url { get; set; }

    #endregion

    public override bool Equals(object obj)
    {
      var other = obj as ProductStubItem;
      if (other != null)
      {
        return this.ID == other.ID;
      }
      return false;
    }

    public override int GetHashCode()
    {
      return ID.GetHashCode();
    }

  }
}
