using ACRHelix.Feature.Bulletin.Helpers;
using ACRHelix.Feature.Bulletin.Services;
using ACRHelix.Foundation.IoC.Pipelines.InitializeContainer;
using Glass.Mapper.Sc;

namespace ACRHelix.Feature.Bulletin.Pipelines.InitializeContainer
{
  public class RegisterDependencies
  {
    public void Process(InitializeContainerArgs args)
    {
      args.Container.Register<IContentService, SitecoreContentService>();
      args.Container.RegisterSingleton<BulletinHelper>();
      args.Container.Register<SitecoreService>(() => new SitecoreService(Sitecore.Context.Database));
    }
  }
}