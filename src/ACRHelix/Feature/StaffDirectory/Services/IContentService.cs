using ACRHelix.Feature.StaffDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.StaffDirectory.Services
{
    public interface IContentService
    {
        Models.StaffDirectory GetStaffDirectoryContent(string contentGuid);
    }
}