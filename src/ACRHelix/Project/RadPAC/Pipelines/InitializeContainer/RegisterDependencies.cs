using System;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Project.RadPAC.Services;

namespace ACRHelix.Project.RadPAC.Pipelines.InitializeContainer
{
    public class RegisterDependencies
    {
        public void Process(InitializeContainerArgs args)
        {
            args.Container.Register<IContentService, SitecoreContentService>();
        }
    }
}