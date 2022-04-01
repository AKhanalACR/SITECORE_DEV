using System;
using ACRHelix.Project.ImageWisely.Services;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Project.ImageWisely.Pipelines.InitializeContainer
{
    public class RegisterDependencies
    {
        public void Process(InitializeContainerArgs args)
        {
            args.Container.Register<IContentService, SitecoreContentService>();
        }
    }
}