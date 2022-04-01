using Glass.Mapper.Sc.Maps;

namespace ACRHelix.Feature.Navigation.Models.Configuration
{
  public class NavigableItemMap : SitecoreGlassMap<NavigationRoot>
  {
    public override void Configure()
    {
      Map(config =>
      {
        config.AutoMap();
        //config.Field(f => f.Title).FieldName("Title");
      });
    }
  }
}