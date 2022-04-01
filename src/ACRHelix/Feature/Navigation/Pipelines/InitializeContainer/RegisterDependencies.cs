using System;
using ACRHelix.Feature.Navigation.Services;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using Glass.Mapper.Pipelines.ConfigurationResolver;
using ACRHelix.Foundation.ORM.App_Start;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Navigation.Pipelines.InitializeContainer
{
  public class RegisterDependencies
  {
    public void Process(InitializeContainerArgs args)
    {
      args.Container.Register<IContentService, SitecoreContentService>();    
    }
  }
}