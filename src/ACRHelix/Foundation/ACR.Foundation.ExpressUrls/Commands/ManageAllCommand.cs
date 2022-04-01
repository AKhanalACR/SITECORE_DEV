using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Sitecore;
using Sitecore.Shell.Framework.Commands;

namespace ACR.Foundation.ExpressUrls
{
    public class ManageAllCommand : Command
    {
        public override void Execute(CommandContext context)
        {
            if (context.Items.Length == 1)
            {
                string domain = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Host;
                Sitecore.Shell.Framework.Windows.RunExternal(domain + "/layouts/ViewAllExpressUrls.aspx", "", "", "Manage All");
            }
        }
    }
}

