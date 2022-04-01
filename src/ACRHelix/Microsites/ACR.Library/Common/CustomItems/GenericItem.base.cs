using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sitecore.Data.Items;

namespace ACR.Library.Common.CustomItems
{
    public partial class GenericItem : CustomItem
    {
        #region Boilerplate CustomItem Code

        public GenericItem(Item innerItem)
            : base(innerItem)
        {
        }

        public static implicit operator GenericItem(Item innerItem)
        {
            return innerItem != null ? new GenericItem(innerItem) : null;
        }
        #endregion //Boilerplate CustomItem Code


        #region Field Instance Methods
        #endregion //Field Instance Methods
    }
}
