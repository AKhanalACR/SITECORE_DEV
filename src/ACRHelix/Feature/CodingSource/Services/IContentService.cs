using ACRHelix.Feature.CodingSource.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CodingSource.Services
{
  public interface IContentService
  {
    CodingSourceList GetCodingSourceListContent(string contentGuid);
  }
}