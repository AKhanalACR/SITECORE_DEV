using ACRHelix.Feature.CaseInPoint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CaseInPoint.Services
{
  public interface IContentService
  {
    CaseInPointItem GetCaseInPointContent(CaseInPointContent content);

    CaseInPointItem GetMiniCaseInPointContent(MiniCaseInPointContent content);

   CaseInPointContent GetCaseInPointSCContent(string datasource);

    MiniCaseInPointContent GetMiniCaseInPointSCContent(string datasource);
  }
}