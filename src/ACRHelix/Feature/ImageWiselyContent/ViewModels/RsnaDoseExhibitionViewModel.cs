using ACRHelix.Feature.ImageWiselyContent.Models;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ImageWiselyContent.ViewModels
{
    public class RsnaDoseExhibitionViewModel
    {
        public ID Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public int ItemsToDisplay { get; set; }

        public IEnumerable<IArticlePage> ArticlePagesList { get; set; }

        public IEnumerable<IContentPage> ListPage { get; set; }

        public IEnumerable<IArticlePage> GeneralRadiationSafety
        {
            get
            {
                IEnumerable<IArticlePage> generalRS = new List<IArticlePage>();
                foreach(var topic in ListPage)
                {
                    generalRS = ArticlePagesList.OrderByDescending(d => d.Date).Where(x => x.Topic == "General Radiation Safety").Take(4).ToList();
                }
                
                return generalRS;
            }
        }

        public IEnumerable<IArticlePage> Dose
        {
            get
            {
                IEnumerable<IArticlePage> dose = new List<IArticlePage>();
                dose = ArticlePagesList.OrderByDescending(d => d.Date).Where(x => x.Topic == "Dose").Take(4).ToList();
                return dose;
            }
        }

    }
}