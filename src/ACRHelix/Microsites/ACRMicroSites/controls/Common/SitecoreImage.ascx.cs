using System;
using System.Drawing;
using ACR.Library.Utils;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace ACR.controls.Common
{
    public partial class SitecoreImage : System.Web.UI.UserControl
    {
        public string AltText { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public MediaItem MediaItem { get; set; }
        public string CssClass { get; set; }
        public string Align { get; set; }

        public void Initialize(MediaItem mediaItem)
        {
            MediaItem = mediaItem;
        }

        public void Initialize(MediaItem mediaItem, int height, int width)
        {
            MediaItem = mediaItem;
            Height = height;
            Width = width;
        }

        public void Initialize(MediaItem mediaItem, string cssClass)
        {
            MediaItem = mediaItem;
            CssClass = cssClass;
        }

        public void Initialize(MediaItem mediaItem, string cssClass, int height, int width)
        {
            MediaItem = mediaItem;
            Height = height;
            Width = width;
            CssClass = cssClass;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (MediaItem == null) return;

            if (Height != 0 && Width != 0)
            {
                MediaUrlOptions options = new MediaUrlOptions();
                options.MaxHeight = Height;
                options.MaxWidth = Width;
                options.BackgroundColor = Color.Transparent;
                options.AbsolutePath = true;
                imageTag.ImageUrl = MediaManager.GetMediaUrl(MediaItem, options);
            }
            else
            {
                imageTag.ImageUrl = LinkUtils.GetMediaUrl(MediaItem);
            }

            if (!string.IsNullOrEmpty(AltText))
            {
                //Set the Alt text and tool tip text
                imageTag.AlternateText = AltText;
                imageTag.ToolTip = AltText;
            }
            else
            {
                //Set the Alt text and tool tip text
                imageTag.AlternateText = MediaItem.Alt;
                imageTag.ToolTip = MediaItem.Alt;
            }
            if (!string.IsNullOrEmpty(CssClass))
            {
                imageTag.CssClass = CssClass;
            }

            if (!string.IsNullOrEmpty(Align))
            {
                imageTag.Attributes.Add("align", Align);
            }
        }
    }
}