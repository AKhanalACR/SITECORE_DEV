using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ACRHelix.Foundation.EditFrames
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// An extra extensions because the default ones are bugged or do not expose title
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="model"></param>
        /// <param name="buttons"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static GlassEditFrame BeginEditFrame<TModel>(this HtmlHelper htmlHelper, TModel model, string buttons, string title = "") where TModel : BaseCommon
        {
            var output = new HtmlTextWriter(htmlHelper.ViewContext.Writer);
            var editFrame = new EditFrame()
            {
                DataSource = model.Id.ToString(),
                Buttons = buttons,
                Title = title
            };
            editFrame.RenderFirstPart(output);
            return new CustomGlassEditFrame(editFrame, htmlHelper.ViewContext.Writer);
        }
    }

    public class CustomGlassEditFrame : GlassEditFrame
    {
        public CustomGlassEditFrame(string buttons, TextWriter writer, string dataSource = "") : base(buttons, writer, dataSource)
        {
        }

        public CustomGlassEditFrame(EditFrame frame) : base(frame)
        {
        }

        /// <summary>
        /// Using HtmlHelperExtensions.BeginEditFrame(EditFrame) you will miss the writer in the RenderLastPart, this extra constructor passes the writer
        /// </summary>
        /// <param name="frame"></param>
        /// <param name="writer"></param>
        public CustomGlassEditFrame(EditFrame frame, TextWriter writer)
            : base(frame.Buttons, writer, frame.DataSource)
        {

        }
    }
}
