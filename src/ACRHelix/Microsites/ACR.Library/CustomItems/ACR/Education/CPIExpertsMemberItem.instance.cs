using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;

namespace ACR.Library.ACR.Education
{
	public partial class CPIExpertMemberItem
	{
        public bool HasCPICategory(string id)
        {
            if (CPICategories == null || CPICategories.ListItems  == null)
            {
                return false;
            }
            return CPICategories.ListItems .Any(item => item.ID.ToString () == id);
        }

        public bool HasCPISpliceCategory(string id)
        {
            if (CPISpliceCategories == null || CPISpliceCategories.ListItems == null)
            {
                return false;
            }
            return CPISpliceCategories.ListItems.Any(item => item.ID.ToString() == id);
        }
	}
}
