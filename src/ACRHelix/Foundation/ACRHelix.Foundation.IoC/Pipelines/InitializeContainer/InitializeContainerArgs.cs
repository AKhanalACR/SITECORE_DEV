using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using Sitecore.Pipelines;

namespace ACRHelix.Foundation.IoC.Pipelines.InitializeContainer
{
    public class InitializeContainerArgs : PipelineArgs
    {
        public Container Container { get; set; }

        public InitializeContainerArgs(Container container)
        {
            this.Container = container;
            this.Container.Options.ConstructorResolutionBehavior = new DefaultFirstConstructorBehavior();
        }
    }
}