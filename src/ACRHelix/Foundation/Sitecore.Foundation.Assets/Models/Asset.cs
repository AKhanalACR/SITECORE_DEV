namespace Sitecore.Foundation.Assets.Models
{
  using System;

  internal class Asset
  {
    public Asset(AssetType type, ScriptLocation location, string file = null, string inline = null)
    {
      this.Type = type;
      this.File = file;
      this.Location = location;
      this.Inline = inline;
    }

    public ScriptLocation Location { get; set; }

    public string File { get; set; }

    public string Inline { get; set; }

    public AssetType Type { get; set; }
  }
}