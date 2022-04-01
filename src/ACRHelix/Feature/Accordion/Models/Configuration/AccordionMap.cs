using Glass.Mapper.Sc.Maps;

namespace ACRHelix.Feature.Accordion.Models.Configuration
{
  public class AccordionMap : SitecoreGlassMap<Models.Accordion>
  {
    public override void Configure()
    {
      Map(config =>
      {
        config.AutoMap();
              //config.Id(f => f.Id);
              //config.Field(f => f.Title).FieldName("Title");
            });
    }
  }
}
