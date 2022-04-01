using Sitecore.ContentSearch;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Foundation.CustomCoveo.ComputedFields
{
  interface IBaseComputedField
  {
    ID FieldID { get; set; }

    string FieldName { get; set; }

    string ReturnType { get; set; }

    object ComputeFieldValue(IIndexable p_Indexable);
  }
}
