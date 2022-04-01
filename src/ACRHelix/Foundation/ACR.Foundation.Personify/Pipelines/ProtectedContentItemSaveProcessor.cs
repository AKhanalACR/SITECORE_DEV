using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data;
using System.Collections.Generic;
using System;
using Sitecore.Events;
using AcrProtectedContent = ACR.Foundation.Personify.Constants.Templates.AcrProtectedContent;
using Sitecore.SecurityModel;

namespace ACR.Foundation.Personify.Pipelines
{
  public class ProtectedContentItemSaveProcessor
  {
    private static readonly SynchronizedCollection<ID> _inProcess = new SynchronizedCollection<ID>();

    public void OnItemSaving(object sender, EventArgs args)
    {
      SitecoreEventArgs eventArgs = args as SitecoreEventArgs;
      Sitecore.Diagnostics.Assert.IsNotNull(eventArgs, "eventArgs");
      Item item = eventArgs.Parameters[0] as Item;
      if (item != null)
      {
        if (item.Database.Name == "master")
        {
          if (item.IsDerived(AcrProtectedContent.ID))
          {
            if (_inProcess.Contains(item.ID) == false)
            {
              string originalAccess = item.Fields[AcrProtectedContent.Fields.RequiredAccess].Value;
              //if item has required products or roles, automatically set required acess to 'authentication required'
              if (item.Fields[AcrProtectedContent.Fields.RequiredAccess].Value == AcrProtectedContent.RequiredAccess.None)
              {
                if (item.Fields[AcrProtectedContent.Fields.RequiredProducts].Value.Length > 0
                  || item.Fields[AcrProtectedContent.Fields.RequiredRoles].Value.Length > 0)
                {
                  item.Fields[AcrProtectedContent.Fields.RequiredAccess].Value = AcrProtectedContent.RequiredAccess.AuthenticationRequired;// "Authentication Required";
                }
              }

             //get the original item
              Item originalItem = item.Database.GetItem(item.ID, item.Language, item.Version);
              if (originalItem != null)
              {
                //if item is different from original, stop inheriting parent values
                if (originalItem.Fields[AcrProtectedContent.Fields.RequiredAccess].Value != originalAccess
                    || originalItem.Fields[AcrProtectedContent.Fields.RequiredProducts].Value != item.Fields[AcrProtectedContent.Fields.RequiredProducts].Value
                    || originalItem.Fields[AcrProtectedContent.Fields.RequiredRoles].Value != item.Fields[AcrProtectedContent.Fields.RequiredRoles].Value)
                {
                  item.Fields[AcrProtectedContent.Fields.InheritFromParent].Value = "0";
                }

                //if changed to inherit from parent, set values to the same as the parent
                if (originalItem.Fields[AcrProtectedContent.Fields.InheritFromParent].Value == "0")
                {
                  if (item.Fields[AcrProtectedContent.Fields.InheritFromParent].Value == "1")
                  {
                    var parent = item.Parent;
                    bool foundParent = true;
                    //get the first parent that is derived from protected content template
                    while (parent.IsDerived(AcrProtectedContent.ID) == false)
                    {
                      if (parent.TemplateName == "Site Root" || parent.ID.ToString() == "{11111111-1111-1111-1111-111111111111}")
                      {
                        foundParent = false;
                        break;
                      }
                      parent = parent.Parent;
                    }
                    if (foundParent)
                    {
                      //set items values to match its parent
                      item.Fields[AcrProtectedContent.Fields.RequiredAccess].Value = parent.Fields[AcrProtectedContent.Fields.RequiredAccess].Value;
                      item.Fields[AcrProtectedContent.Fields.RequiredProducts].Value = parent.Fields[AcrProtectedContent.Fields.RequiredProducts].Value;
                      item.Fields[AcrProtectedContent.Fields.RequiredRoles].Value = parent.Fields[AcrProtectedContent.Fields.RequiredRoles].Value;
                    }                   
                  }
                }
              }

              //set child items to same as current item where marked inherit from Parent
              var children = item.Axes.SelectItems("descendant::*[@#Inherit From Parent#='1']");
              if (children != null)
              {
                //var children = item.Axes.GetDescendants().Where(x => x.IsDerived(AcrProtectedContent.ID)).ToList();
                foreach (var child in children)
                {
                  try
                  {
                    _inProcess.Add(child.ID);
                    if (child.Fields[AcrProtectedContent.Fields.InheritFromParent].Value == "1")
                    {
                      using (new SecurityDisabler())
                      {
                        child.Editing.BeginEdit();
                        child.Fields[AcrProtectedContent.Fields.RequiredAccess].Value = item.Fields[AcrProtectedContent.Fields.RequiredAccess].Value;
                        child.Fields[AcrProtectedContent.Fields.RequiredProducts].Value = item.Fields[AcrProtectedContent.Fields.RequiredProducts].Value;
                        child.Fields[AcrProtectedContent.Fields.RequiredRoles].Value = item.Fields[AcrProtectedContent.Fields.RequiredRoles].Value;
                        child.Editing.EndEdit();
                      }
                    }
                  }
                  catch (Exception ex)
                  {
                    Logger.PersonifyLogger.Logger.Error("Error updating Child Item Access and Entitlements: " + ex.Message);
                  }
                  finally
                  {
                    _inProcess.Remove(child.ID);
                  }
                }
              }
            }
          }
        }
      }
    }
  }
}