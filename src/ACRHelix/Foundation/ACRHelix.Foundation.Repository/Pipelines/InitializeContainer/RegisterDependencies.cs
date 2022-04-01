using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using ACRHelix.Foundation.Repository.Content;
using ACRHelix.Foundation.Repository.Search;

namespace ACRHelix.Foundation.Repository.Pipelines.InitializeContainer
{
    public class RegisterDependencies
    {
        public void Process(InitializeContainerArgs args)
        {
            args.Container.Register<IContentRepository, SitecoreContentRepository>();
            args.Container.Register<ISearchRepository, SitecoreSearchRepository>();
        }
    }
}