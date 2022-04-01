using Sitecore.Data.Items;

namespace ACR.Library.CustomItems.ACR.Membership
{
public partial class ChapterNewsFolderItem : CustomItem
{

public static readonly string TemplateId = "{E9B00BC3-EBF8-4C0B-9481-83B6BB03924A}";


#region Boilerplate CustomItem Code

public ChapterNewsFolderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ChapterNewsFolderItem(Item innerItem)
{
	return innerItem != null ? new ChapterNewsFolderItem(innerItem) : null;
}

public static implicit operator Item(ChapterNewsFolderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}