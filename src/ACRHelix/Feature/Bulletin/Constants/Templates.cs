using Sitecore.Data;

namespace ACRHelix.Feature.Bulletin.Constants
{
  public struct BulletinTemplates
  {
    public struct BulletinHomePage
    {
      public const string TemplateID = "{54D5F94C-B4EC-4FCF-BB14-0FF9FE4AD1A0}";
      public static readonly ID ID = new ID(TemplateID);
    }

    public struct Article
    {
      public const string TemplateID = "{FC9D8B10-E234-4029-B2A4-9944ED07BB05}";
      public static readonly ID ID = new ID(TemplateID);
    }

    public struct TopicPage
    {
      public const string TemplateID = "{35C5E190-2545-4B46-80B2-46866D8269F1}";
      public static readonly ID ID = new ID(TemplateID);
    }

    public struct TagListPage
    {
      public const string TemplateID = "{6C069F2A-DA82-4DD1-9C0C-ADA563DF6E9C}";
      public static readonly ID ID = new ID(TemplateID);
    }
  }

  public struct TagTypes
  {
    public const string Interests = "interest";

    public const string Modalities = "modalitity";

    public const string Specialty = "specialty";
  }
}