using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;

namespace ACRHelix.Feature.Bulletin.Models
{
  [SitecoreType(TemplateId = Constants.BulletinTemplates.Article.TemplateID, AutoMap = true, EnforceTemplate = Glass.Mapper.Sc.Configuration.SitecoreEnforceTemplate.Template)]
  public class Article : ICMSEntity
  {
    public virtual ID Id { get; set; }

    [SitecoreField("Title")]
    public virtual string Title { get; set; }

    [SitecoreField("Topic")]
    public virtual Topic Topic { get; set; }

    [SitecoreField("Author")]
    public virtual string Author { get; set; }

    [SitecoreField("Author Title")]
    public virtual string AuthorTitle { get; set; }

    [SitecoreField("DatePosted")]
    public virtual DateTime DatePosted { get; set; }

    [SitecoreField("Article Text")]
    public virtual string ArticleText { get; set; }

    [SitecoreField("ENDNOTES")]
    public virtual string EndNotes { get; set; }

    [SitecoreField("Article Quote")]
    public virtual string Quote { get; set; }

    [SitecoreField("Quote By")]
    public virtual string QuoteBy { get; set; }

    [SitecoreField("MainArticleImage")]
    public virtual Image MainArticleImage { get; set; }

    [SitecoreField("Parallax Image")]
    public virtual Image ParallaxImage { get; set; }

    [SitecoreField("Mobile Parallax Image")]
    public virtual Image MobileParallaxImage { get; set; }

    [SitecoreField("Strong Gradient")]
    public virtual bool StrongGradient { get; set; }

    public virtual string Url { get; set; }

    [SitecoreField("Link Text")]
    public virtual string TileLinkText { get; set; }

    [SitecoreField("Tile Text")]
    public virtual string TileText { get; set; }

    [SitecoreField("Image")]
    public virtual Image TileImage { get; set; }
  }
}