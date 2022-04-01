using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ACR.Library.Controls.ACR.Common.Content
{
	public class ImageRichTextContentRegion : Control, INamingContainer
	{
		#region Public Properties

		/// <summary>
		/// The alt text for our content image.
		/// </summary>
		public string ContentImageAlt
		{
			get
			{
				//ensure controls have been created
				EnsureChildControls();

				//return our content image alt text
				return ContentImageControl.AlternateText;
			}
			set
			{
				//ensure controls have been created
				EnsureChildControls();

				//set our alt text
				ContentImageControl.AlternateText = value;
			}
		}

		/// <summary>
		/// The url for our content image.
		/// </summary>
		public string ContentImageUrl
		{
			get
			{
				//ensure controls have been created
				EnsureChildControls();

				//return our content image url
				return ContentImageControl.ImageUrl;
			}
			set
			{
				//ensure controls have been created
				EnsureChildControls();

				//set our url
				ContentImageControl.ImageUrl = value;

				//show or hide our content image control
				ContentImageControl.Visible = !string.IsNullOrEmpty(value);
			}
		}

		/// <summary>
		/// Our articles body text.
		/// </summary>
		public string BodyText
		{
			get
			{
				//ensure controls have been created
				EnsureChildControls();

				//return our body text from our control
				return BodyTextControl.Text;
			}
			set
			{
				//ensure controls have been created
				EnsureChildControls();

				//set our body text
				BodyTextControl.Text = value;

				//show or hide our body text control
				BodyTextControl.Visible = !string.IsNullOrEmpty(value);
			}
		}

		#endregion

		#region Child Controls

		private Image _contentImageControl;
		/// <summary>
		/// The control that will hold our content image.
		/// </summary>
		private Image ContentImageControl
		{
			get
			{
				//if we haven't yet created our content image control then do so
				if (_contentImageControl == null)
				{
					//create our content image control
					_contentImageControl = new Image();
					_contentImageControl.CssClass = "header-image";
					_contentImageControl.Visible = false;
				}

				//return our content image control
				return _contentImageControl;
			}
		}

		private Literal _bodyTextControl;
		/// <summary>
		/// The control to hold our body text.
		/// </summary>
		private Literal BodyTextControl
		{
			get
			{
				//if we haven't yet created our body text control then do so
				if (_bodyTextControl == null)
				{
					//create our body text control
					_bodyTextControl = new Literal();
					_bodyTextControl.Visible = false;
				}

				//return our body text control
				return _bodyTextControl;
			}
		}

		private HtmlGenericControl _bodyContainerControl;
		/// <summary>
		/// The control that will contain our body content.
		/// </summary>
		private HtmlGenericControl BodyContainerControl
		{
			get
			{
				//if we haven't yet created our container control then do so
				if (_bodyContainerControl == null)
				{
					//create our container control
					_bodyContainerControl = new HtmlGenericControl("div");
					_bodyContainerControl.Attributes["class"] = "article-body";

					//add our image and body controls
					_bodyContainerControl.Controls.Add(ContentImageControl);
					_bodyContainerControl.Controls.Add(BodyTextControl);
				}

				//return our container control
				return _bodyContainerControl;
			}
		}

		#endregion

		protected override void CreateChildControls()
		{
			//add our controls
			Controls.Add(BodyContainerControl);
		}
	}
}
