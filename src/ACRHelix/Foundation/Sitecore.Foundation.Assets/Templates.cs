namespace Sitecore.Foundation.Assets
{
  using Sitecore.Data;

  public struct Templates
  {
    public struct RenderingAssets
    {
      public static readonly ID ID = new ID("{2610B1D5-B993-448B-A230-BA55A371559D}");

      public struct Fields
      {
        public static readonly ID ScriptFiles = new ID("{32C44493-6ABE-418E-94E0-ECE2535E19EA}");
        public static readonly ID StylingFiles = new ID("{E3095A7D-8809-459A-919C-9DDC445DA5D1}");
        public static readonly ID InlineScript = new ID("{72990241-DE42-4692-ACD3-797819150772}");
        public static readonly ID InlineStyling = new ID("{1916389C-A466-4C79-B4EE-71951BDD780F}");
        //public static readonly ID ExpereinceEditorScripts = new ID("{F769FB4A-3B92-4D02-B038-3DEB0664FDB1}");
      }
    }

    public struct SiteAssets
    {
      public static readonly ID ID = new ID("{73C3B666-75C4-49DC-A482-B45528B3DC73}");

      public struct Fields
      {
        public static readonly ID JavaScript = new ID("{AC89CF9C-4A9E-4784-AFCB-3256C88217AC}");
        public static readonly ID Css = new ID("{2440C90C-BA00-481B-AE0F-3E4CC4993ADF}");
        public static readonly ID Fonts = new ID("{AFA83286-F5FF-4DA7-B367-2A8E67A00DD5}");
        public static readonly ID Favicons = new ID("{AB967514-B3EB-43EA-AACD-F381993BE5D2}");

        public static readonly ID BodyAssets = new ID("{515DA747-B2AB-4DE6-B2B5-64EFACDF5434}");
        public static readonly ID VersionedCSS = new ID("{42B320FC-62BE-43A2-B272-DA132455F3E5}");
        public static readonly ID VersionedJS = new ID("{C29A5C09-0604-4E21-AFB2-049437C967BB}");
      }
    }

    public struct HasTheme
    {
      //public static readonly ID ID = new ID("{5B6F8720-3A93-4DA1-92A0-C3E85E01219A}");

      public struct Fields
      {
        //public static readonly ID Theme = new ID("{53B5AF0A-265F-4E60-B2B2-4576CE0BECCF}");
      }
    }
  }
}