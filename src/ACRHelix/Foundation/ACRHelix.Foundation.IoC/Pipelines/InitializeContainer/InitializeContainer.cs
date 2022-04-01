using System;
using System.Linq;
using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
//using Sitecore.Forms.Mvc.Controllers;

using Sitecore.Mvc.Controllers;

namespace ACRHelix.Foundation.IoC.Pipelines.InitializeContainer
{
    public class InitializeContainer
    {
        public void Process(PipelineArgs args)
        {
            var container = new Container();
            var containerArgs = new InitializeContainerArgs(container);
            
            CorePipeline.Run("initializeContainer", containerArgs);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("ACRHelix.Feature.") || a.FullName.StartsWith("ACRHelix.Foundation.") || a.FullName.StartsWith("ACR.Foundation"));
            container.RegisterMvcControllers(assemblies.ToArray());
          
            container.RegisterMvcIntegratedFilterProvider();
            //container.Register<FormController>(() => new FormController());
            //DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            IDependencyResolver customInjResolver = new CustomDependencyResolver(new SimpleInjectorDependencyResolver(container), new SitecoreDependencyResolver(DependencyResolver.Current));
            DependencyResolver.SetResolver(customInjResolver);
    }
    }
}
