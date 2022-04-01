using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Pages
{
public partial class GeneralSearchPageItem : CustomItem
{

public static readonly string TemplateId = "{F135072F-D036-46BB-BA4B-5318A394C3B7}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }

#endregion

#region Boilerplate CustomItem Code

public GeneralSearchPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);

}

public static implicit operator GeneralSearchPageItem(Item innerItem)
{
	return innerItem != null ? new GeneralSearchPageItem(innerItem) : null;
}

public static implicit operator Item(GeneralSearchPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField Biopsy
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Biopsy"]);
	}
}

public static string FieldName_Biopsy 
{
	get
	{
		return "Biopsy";
	}
} 


public CustomTreeListField CommutedTomography
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Commuted Tomography"]);
	}
}

public static string FieldName_CommutedTomography 
{
	get
	{
		return "Commuted Tomography";
	}
} 


public CustomTreeListField DigitalMammography
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Digital Mammography"]);
	}
}

public static string FieldName_DigitalMammography 
{
	get
	{
		return "Digital Mammography";
	}
} 


public CustomTreeListField GeneralNuclearMedicine
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["General Nuclear Medicine"]);
	}
}

public static string FieldName_GeneralNuclearMedicine 
{
	get
	{
		return "General Nuclear Medicine";
	}
} 


public CustomTreeListField LinearAcceleration
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Linear Acceleration"]);
	}
}

public static string FieldName_LinearAcceleration 
{
	get
	{
		return "Linear Acceleration";
	}
} 


public CustomTreeListField MagneticResonanceImaging
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Magnetic Resonance Imaging"]);
	}
}

public static string FieldName_MagneticResonanceImaging 
{
	get
	{
		return "Magnetic Resonance Imaging";
	}
} 


public CustomTreeListField Mammography
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Mammography"]);
	}
}

public static string FieldName_Mammography 
{
	get
	{
		return "Mammography";
	}
} 


public CustomTreeListField NuclearCardiology
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Nuclear Cardiology"]);
	}
}

public static string FieldName_NuclearCardiology 
{
	get
	{
		return "Nuclear Cardiology";
	}
} 


public CustomTreeListField NuclearMedicinePETSPECT
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Nuclear Medicine PET SPECT"]);
	}
}

public static string FieldName_NuclearMedicinePETSPECT 
{
	get
	{
		return "Nuclear Medicine PET SPECT";
	}
} 


public CustomTreeListField PETCD
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["PET CD"]);
	}
}

public static string FieldName_PETCD 
{
	get
	{
		return "PET CD";
	}
} 


public CustomTreeListField PlainFilm
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Plain Film"]);
	}
}

public static string FieldName_PlainFilm 
{
	get
	{
		return "Plain Film";
	}
} 


public CustomTreeListField PositronEmissionTomography
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Positron Emission Tomography"]);
	}
}

public static string FieldName_PositronEmissionTomography 
{
	get
	{
		return "Positron Emission Tomography";
	}
} 


public CustomTreeListField RadiographyFuoro
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Radiography Fuoro"]);
	}
}

public static string FieldName_RadiographyFuoro 
{
	get
	{
		return "Radiography Fuoro";
	}
} 


public CustomTreeListField SPECT
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["SPECT"]);
	}
}

public static string FieldName_SPECT 
{
	get
	{
		return "SPECT";
	}
} 


public CustomTreeListField Ultrasound
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Ultrasound"]);
	}
}

public static string FieldName_Ultrasound 
{
	get
	{
		return "Ultrasound";
	}
} 


public CustomTreeListField UnsealedSourceTherapy
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Unsealed Source Therapy"]);
	}
}

public static string FieldName_UnsealedSourceTherapy 
{
	get
	{
		return "Unsealed Source Therapy";
	}
} 


#endregion //Field Instance Methods
}
}