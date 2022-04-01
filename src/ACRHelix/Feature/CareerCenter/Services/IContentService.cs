using ACRHelix.Feature.CareerCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CareerCenter.Services
{
    public interface IContentService
    {
        ICareerCenter GetCareerCenterContent(string contentGuid);

        IFeaturedJobs GetFeaturedJobsContent(string contentGuid);
    }
}