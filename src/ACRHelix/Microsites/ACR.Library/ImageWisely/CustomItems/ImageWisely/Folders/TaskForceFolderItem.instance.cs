using System;
using System.Linq;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Folders
{
public partial class TaskForceFolderItem 
{
    public IEnumerable<TaskForceMemberItem> TaskForceMembers
    {
        get
        {
            IEnumerable<TaskForceMemberItem> memberItems = InnerItem.Children
                .Where(i => SitecoreUtils.IsValid(TaskForceMemberItem.TemplateId, i))
                .Select(i => (TaskForceMemberItem)i);
            return memberItems;
        }
    }
}
}