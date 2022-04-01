using System;
using RHEC.Website.Services;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RHEC.Website.Pipelines.InitializeContainer
{
    public class RegisterDependencies
    {
        public void Process(InitializeContainerArgs args)
        {
            args.Container.Register<IContentService, SitecoreContentService>();
        }
    }
}