using System;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Feature.XBlog.Areas.XBlog.Services;

namespace Sitecore.Feature.XBlog.Areas.XBlog.Pipelines.InitializeContainer
{
  public class RegisterDependencies
  {
    public void Process(InitializeContainerArgs args)
    {
      args.Container.Register<IContentService, SitecoreContentService>();
    }
  }
}