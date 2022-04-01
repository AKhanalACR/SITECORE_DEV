using System;
using System.Linq;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Folders;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
public partial class TaskForcePageItem 
{
    public IEnumerable<TaskForceMemberItem> TaskForceMembers
    {
        get
        {
            IEnumerable<TaskForceMemberItem> memberItems = InnerItem.Axes.GetDescendants()
                .Where(i => SitecoreUtils.IsValid(TaskForceMemberItem.TemplateId, i))
                .Select(i => (TaskForceMemberItem)i);
            return memberItems;
        }
    }

    public IEnumerable<TaskForceFolderItem> TaskForceFolders
    {
        get
        {
            IEnumerable<TaskForceFolderItem> folderItems = InnerItem.Axes.GetDescendants()
                .Where(i => SitecoreUtils.IsValid(TaskForceFolderItem.TemplateId, i))
                .Select(i => (TaskForceFolderItem)i);
            return folderItems;
        }
    }
}
}