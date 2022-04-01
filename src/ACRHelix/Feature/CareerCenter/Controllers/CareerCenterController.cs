using ACRHelix.Feature.CareerCenter.Services;
using ACRHelix.Feature.CareerCenter.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ACRHelix.Feature.CareerCenter
{
    public class CareerCenterController : Controller
    {
        private readonly IContentService _contentService;

        public CareerCenterController(IContentService contentService)
        {
            _contentService = contentService;
        }

        public ViewResult CareerCenter()
        {
            var viewModel = new CareerCenterViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var CareerCenterContent = _contentService.GetCareerCenterContent(RenderingContext.Current.Rendering.DataSource);
                if (CareerCenterContent != null)
                {
                    viewModel.Title = CareerCenterContent.Title;
                    
                }
            }
            return View(viewModel);
        }

        public ViewResult FeaturedJobs()
        {
            var viewModel = new FeaturedJobsViewModel();
            if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
            {
                var FeaturedJobsContent = _contentService.GetFeaturedJobsContent(RenderingContext.Current.Rendering.DataSource);
                if (FeaturedJobsContent != null)
                {
                    viewModel.Id = FeaturedJobsContent.Id;
                    viewModel.Title = FeaturedJobsContent.Title;
                    if(!string.IsNullOrWhiteSpace(FeaturedJobsContent.JobsFeedUrl))
                    {
                        var xmlDoc = new XmlDocument();
                        xmlDoc.Load(FeaturedJobsContent.JobsFeedUrl);
                        XmlNodeList nodeList = xmlDoc.SelectNodes("/jobs/job");
                        List<Job> Jobs = new List<Job>();
                        
                        foreach(XmlNode job in nodeList)
                        {
                            Job vMJob = new Job();
                            vMJob.JobTitle = job.SelectSingleNode("position").InnerText;
                            vMJob.JobLink = job.SelectSingleNode("link").InnerText;
                            vMJob.JobDescription = job.SelectSingleNode("description").InnerText;
                            vMJob.Company = job.SelectSingleNode("company").InnerText;
                            vMJob.Featured = job.SelectSingleNode("featured").InnerText == "Yes" ? true : false;

                            List<Location> locations = new List<Location>();
                            if(job.SelectNodes("./locations/location") != null)
                            {
                                foreach (XmlNode location in job.SelectNodes("./locations/location"))
                                {
                                    locations.Add(new Location
                                    {
                                        City = location.SelectSingleNode("city") != null ? location.SelectSingleNode("city").InnerText : "",
                                        State = location.SelectSingleNode("state_abbr") != null ? location.SelectSingleNode("state_abbr").InnerText : "",
                                        Country = location.SelectSingleNode("country") != null ? location.SelectSingleNode("country").InnerText : "",

                                    });
                                }
                                vMJob.Locations = locations;
                                Jobs.Add(vMJob);
                            }
                        }
                        viewModel.Jobs = Jobs;
                    }
                }
            }
            return View(viewModel);
        }
    }
}