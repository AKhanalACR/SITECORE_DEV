using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Layouts;
using Sitecore.StringExtensions;

namespace ACRHelix.Foundation.RenderingHelper
{
  public static class RenderingMerger
  {

    public struct Constants {

      public const string MasterDB = "master";
      public const string StandardValues = "__Standard Values";
      public const string FinalRenderings = "__Final Renderings";
    }

    /**
     ** I took this from http://www.rockpapersitecore.com/2016/07/07/merging-final-renderings-back-down-into-shared-renderings/
     **/
    public static KeyValuePair<bool, string> MergeRenderings(Item item, bool copyToTemplate)
    {
      bool sucess = false;
      string error = "";

      if (item != null)
      {
        try
        {
          var layoutField = new LayoutField(item.Fields[Sitecore.FieldIDs.LayoutField]);
          if (!string.IsNullOrWhiteSpace(layoutField.Value))
          {
            //if layout field is built from standard values, parse and save it to item
            if (!layoutField.Value.Contains("http://www.w3.org/2001/XMLSchema"))
            {
              var newLayoutField = LayoutDefinition.Parse(layoutField.Value);           
              using (new EditContext(item))
              {
                layoutField.Value = newLayoutField.ToXml();                
                item.Editing.AcceptChanges();
              }
            }
          }

          //Grab the field that contains the final layout
          var finalLayoutField = new LayoutField(item.Fields[Sitecore.FieldIDs.FinalLayoutField]);
          if (layoutField == null)
            throw new Exception("Couldn't find layout on: {0}".FormatWith(item.Name));

          if (finalLayoutField == null)
            throw new Exception("Couldn't find final layout on: {0}".FormatWith(item.Name));

          //If we don't have a final layout delta, we're good!
          if (string.IsNullOrWhiteSpace(finalLayoutField.Value))
          {
            return new KeyValuePair<bool, string>(sucess, "No final layout exists for item: " + item.ID.ToString());
          }

          //parse final layout and save to sharedlayout item
          var finalLayoutDefinition = LayoutDefinition.Parse(finalLayoutField.Value);
          using (new EditContext(item))
          {
            layoutField.Value = finalLayoutDefinition.ToXml();
            item.Fields[Constants.FinalRenderings].Reset();
            item.Editing.AcceptChanges();
          }

          //copy shared layout to standard values so it can be used for all items with same template
          if (copyToTemplate)
          {
            var templateItem = Database.GetDatabase(Constants.MasterDB).GetItem(item.TemplateID);
            var standardValues = templateItem.Children.FirstOrDefault(x => x.Name == Constants.StandardValues);
            if (standardValues != null)
            {
              var tlayout = new LayoutField(standardValues.Fields[Sitecore.FieldIDs.LayoutField]);
              using (new EditContext(standardValues))
              {
                tlayout.Value = finalLayoutDefinition.ToXml();
                standardValues.Fields[Constants.FinalRenderings].Reset();
                standardValues.Editing.AcceptChanges();
              }
            }
          }

          sucess = true;
        }
        catch (Exception ex)
        {
          return new KeyValuePair<bool, string>(sucess, ex.Message);
        }
      }
      else
      {
        error = "Could not find item";
      }
      return new KeyValuePair<bool, string>(sucess, error);
    }

    private static LayoutField GetStandardValueLayoutField(Item item)
    {
      var templateItem = Database.GetDatabase(Constants.MasterDB).GetItem(item.TemplateID);
      var standardValues = templateItem.Children.FirstOrDefault(x => x.Name == Constants.StandardValues);
      if (standardValues != null)
      {
        var tlayout = new LayoutField(standardValues.Fields[Sitecore.FieldIDs.LayoutField]);
        return tlayout;
      }
      return null;
    }
  }
}