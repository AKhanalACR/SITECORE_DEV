using ACRHelix.Project.ImageWisely.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.ImageWisely.Services
{
    public interface IContentService
    {
        ISearchSettings GetSearchSettingsContent(string contentGuid);
    }
}