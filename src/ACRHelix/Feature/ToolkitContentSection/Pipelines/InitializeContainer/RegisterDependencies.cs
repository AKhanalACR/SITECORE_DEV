using System;
using ACRHelix.Feature.ToolkitContentSection.Services;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ToolkitContentSection.Pipelines.InitializeContainer
{
  public class RegisterDependencies
  {
    public void Process(InitializeContainerArgs args)
    {
      args.Container.Register<IContentService, SitecoreContentService>();
    }
  }
}