using Sitecore.Data.Items;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.CustomItems.ACR.Pages
{
public partial class CareerCenterPageItem : CustomItem
{

public static readonly string TemplateId = "{EE919C51-D1EB-4B4E-BDA3-8F2169C6B057}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly NavigationOptionsItem _NavigationOptionsItem;
public NavigationOptionsItem NavigationOptions { get { return _NavigationOptionsItem; } }
private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly RelatedDocumentsPageItem _RelatedDocumentsPageItem;
public RelatedDocumentsPageItem RelatedDocumentsPage { get { return _RelatedDocumentsPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CareerCenterPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_NavigationOptionsItem = new NavigationOptionsItem(innerItem);
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_RelatedDocumentsPageItem = new RelatedDocumentsPageItem(innerItem);

}

public static implicit operator CareerCenterPageItem(Item innerItem)
{
	return innerItem != null ? new CareerCenterPageItem(innerItem) : null;
}

public static implicit operator Item(CareerCenterPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField EmployerText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Employer Text"]);
	}
}

public static string FieldName_EmployerText 
{
	get
	{
		return "Employer Text";
	}
} 


public CustomTextField JobseekerText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Jobseeker Text"]);
	}
}

public static string FieldName_JobseekerText 
{
	get
	{
		return "Jobseeker Text";
	}
} 


public CustomTextField EmployerResourcesTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Employer Resources Title"]);
	}
}

public static string FieldName_EmployerResourcesTitle 
{
	get
	{
		return "Employer Resources Title";
	}
} 


public CustomTextField JobseekerResourcesTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Jobseeker Resources Title"]);
	}
}

public static string FieldName_JobseekerResourcesTitle 
{
	get
	{
		return "Jobseeker Resources Title";
	}
} 


public CustomTreeListField EmployerResources
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Employer Resources"]);
	}
}

public static string FieldName_EmployerResources 
{
	get
	{
		return "Employer Resources";
	}
} 


public CustomTreeListField JobseekerResources
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Jobseeker Resources"]);
	}
}

public static string FieldName_JobseekerResources 
{
	get
	{
		return "Jobseeker Resources";
	}
} 


#endregion //Field Instance Methods
}
}