using ACRHelix.Feature.Accordion.Services;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;


namespace ACRHelix.Feature.Accordion.Pipelines.InitializeContainer
{
  public class RegisterDependencies
  {
    public void Process(InitializeContainerArgs args)
    {
      args.Container.Register<IContentService, SitecoreContentService>();
    }
  }
}