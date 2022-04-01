using ACR.Library.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACR.Library.DataContexts
{
  public class AcrAfwData
  {
    public Dictionary<string, string> GetModalityEntities()
    {
      var dict = new Dictionary<string, string>();
      using (ACR_APP_DATA_Entities db = new ACR_APP_DATA_Entities())
      {
        var modalities = from entry in db.Modality_Dropdown
                         select new { theValue = entry.ModalityList_value, theText = entry.ModalityList_text };

        if (modalities.Count() == 0)
          return dict;

        foreach (var modality in modalities)
        {
          if (!dict.ContainsKey(modality.theValue))
          {
            if (modality.theText == "[None specified.]")
              dict.Add(modality.theValue, "--Select--");
            else
              dict.Add(modality.theValue, modality.theText);
          }
        }
      }
      return dict;
    }

    public Dictionary<string, string> GetLocalityEntities()
    {
      var dict = new Dictionary<string, string>();
      using (ACR_APP_DATA_Entities db = new ACR_APP_DATA_Entities())
      {
        var localities = from entry in db.Locality_Dropdown
                         select new { theValue = entry.LocalityList_value, theText = entry.LocalityList_text };

        if (localities.Count() == 0)
          return dict;

        foreach (var locality in localities)
        {
          if (!dict.ContainsKey(locality.theValue))
          {
            if (locality.theText == "[None specified.]")
              dict.Add(locality.theValue, "--Select--");
            else
              dict.Add(locality.theValue, locality.theText);
          }
        }
      }
      return dict;
    }

    public Dictionary<string, string> GetDesignationEntities()
    {
      var dict = new Dictionary<string, string>();
      using (ACR_APP_DATA_Entities db = new ACR_APP_DATA_Entities())
      {
        var designations = from entry in db.Designation_Dropdown
                           orderby entry.DesignationList_ListOrder
                           select new { theValue = entry.DesignationList_value, theText = entry.DesignationList_text };

        if (designations.Count() == 0)
          return dict;

        foreach (var designation in designations)
        {
          dict.Add(designation.theValue, designation.theText);
          //if (!dict.ContainsKey(designation.theValue))
          //{
          //    if (designation.theText == "[None specified.]")
          //        dict.Add(designation.theValue, "--Select--");
          //    else
          //        dict.Add(designation.theValue, designation.theText);
          //}
        }
      }
      return dict;
    }

  }
}
