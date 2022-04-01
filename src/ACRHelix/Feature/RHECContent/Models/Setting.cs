using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;

namespace ACRHelix.Feature.RhecContent.Models
{
  [SitecoreType(TemplateId = "{D8C39BE2-DB79-47FC-A7FE-F7E0EE2EC349}", AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Setting : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("{6093A1F1-810A-41A7-B44E-8AD9EB57110C}", SitecoreFieldType.SingleLineText)]
    public virtual string ResourceHomeUrl { get; set; }
    [SitecoreField("{338182F3-F08C-450A-B753-4CEA92428D2C}", SitecoreFieldType.Integer)]
    public virtual int SummaryLength { get; set; }
    [SitecoreField("{B49758D9-8015-410E-9696-40483D09BC59}", SitecoreFieldType.Integer)]
    public virtual int PageSize { get; set; }
    [SitecoreField("{6A134C54-B9A3-44EB-AB04-123AE58822C8}", SitecoreFieldType.Integer)]
    public virtual int NumberOfTopics { get; set; }
    [SitecoreField("{B2C2233F-0B89-4965-824C-B19ABB92D70E}", SitecoreFieldType.Checkbox)]
    public virtual bool DisplayTopics { get; set; }
    [SitecoreField("{AB4F08C9-0478-470C-964A-9BD3774AFD2C}", SitecoreFieldType.Checkbox)]
    public virtual bool Filter { get; set; }
    [SitecoreField("{C1509006-9AEE-4F4D-9EB2-483B02C03A56}", SitecoreFieldType.Checkbox)]
    public virtual bool RemoveTopicsOnCount { get; set; }
    [SitecoreField("{1FC1EA97-C5EA-4C96-B79A-C4CAFB53541D}", SitecoreFieldType.SingleLineText)]
    public virtual string TopicSourceId { get; set; }
    [SitecoreField("{225C31E3-A7CB-459E-8A73-FB2C09EFF97A}", SitecoreFieldType.SingleLineText)]
    public virtual string ResourceTemplateID { get; set; }
    [SitecoreField("{1BB6922E-D0E3-4573-AE12-B65750149CCF}", SitecoreFieldType.SingleLineText)]
    public virtual string ResourcePageId { get; set; }
    [SitecoreField("{728B0042-61B5-41D0-9D56-359F64001275}", SitecoreFieldType.SingleLineText)]
    public virtual string NoResourceText { get; set; }
    [SitecoreField("{9338B446-F2C4-4875-B778-FA11976FC2FA}", SitecoreFieldType.SingleLineText)]
    public virtual string PledgeErrorUrl { get; set; }
    [SitecoreField("{2F9FF668-9D92-4CCD-872D-3327F05867BD}", SitecoreFieldType.SingleLineText)]
    public virtual string PledgeSuccessUrl { get; set; }
    [SitecoreField("{CC18AAC8-61A6-4E21-94DC-0E47F5982AB6}", SitecoreFieldType.SingleLineText)]
    public virtual string PledgePageId { get; set; }

    [SitecoreField("{71875DAE-A35E-4C5C-AAD2-743A315B39AA}", SitecoreFieldType.SingleLineText)]
    public string PledgeEmailExistsError { get; set; }   
  }
}