using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Templates;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Resources;
using Sitecore.Shell.Applications.Dialogs.ItemLister;
using Sitecore.Shell.Applications.Dialogs.SelectItem;
using Sitecore.Shell.Applications.Dialogs.SelectItemWithThumbnail;
using Sitecore.Shell.Applications.Dialogs.SelectRendering;
using Sitecore.Shell.Controls.Splitters;
using Sitecore.Shell.DeviceSimulation;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;
using Sitecore.Web.UI.WebControls;

namespace ACRHelix.Foundation.RenderingHelper
{
  [UsedImplicitly]
  public class CustomTabbedSelectRenderingForm : SelectItemWithThumbnailForm
  {
    private const string TabGroupFieldID = "{0CFD9CB2-29C7-44D4-BB26-5E552CC1CE04}";

    protected Tabstrip Tabs;

    // Fields
    protected Scrollbox Renderings;
    protected VSplitterXmlControl TreeSplitter;
    protected Scrollbox TreeviewContainer;

    // Methods
    protected override string GetFilter(SelectItemOptions options)
    {
      Assert.ArgumentNotNull(options, "options");
      if ((options.IncludeTemplatesForDisplay.Count == 0) && (options.ExcludeTemplatesForDisplay.Count == 0))
      {
        return string.Empty;
      }
      string list = SelectItemForm.GetList(options.IncludeTemplatesForDisplay);
      string str2 = SelectItemForm.GetList(options.ExcludeTemplatesForDisplay);
      if ((options.IncludeTemplatesForDisplay.Count > 0) && (options.ExcludeTemplatesForDisplay.Count > 0))
      {
        return string.Format("(contains('{0}', ',' + @@templateid + ',') or contains('{0}', ',' + @@templatekey + ',')) and  not (contains('{1}', ',' + @@templateid + ',') or contains('{1}', ',' + @@templatekey + ','))", list, str2);
      }
      if (options.IncludeTemplatesForDisplay.Count > 0)
      {
        return string.Format("(contains('{0}', ',' + @@templateid + ',') or contains('{0}', ',' + @@templatekey + ','))", list);
      }
      string str3 = "{B4A0FB13-9758-427C-A7EB-1A406C045192}";
      string str4 = "{B87CD5F0-4E72-429D-90A3-B285F1D038CA}";
      string str5 = "{75D27C2B-5F88-4CC8-B1DE-8412A1628408}";
      return string.Format("not (contains('{0}', ',' + @@templateid + ',') or contains('{0}', ',' + @@templatekey + ',') or @@name='Placeholder Settings' or @@name='Devices' or @@name='Layouts' or @@id='{1}' or @@id='{2}' or @@id='{3}' or @@id='{4}')", new object[] { str2, str3, DeviceSimulationUtil.SimulatorsFolderId, str4, str5 });
    }

    protected bool IsItemRendering(Item item)
    {
      return ItemUtil.IsRenderingItem(item);
    }

    protected override bool IsItemSelectable(Item item)
    {
      Assert.ArgumentNotNull(item, "item");
      return this.IsItemRendering(item);
    }

    protected override void OnItemClick(Item item)
    {
      Assert.ArgumentNotNull(item, "item");
      ItemCollection children = base.DataContext.GetChildren(item);
      if ((children != null) && (children.Count > 0))
      {
        base.Treeview.SetSelectedItem(item);
        this.Renderings.InnerHtml = this.RenderPreviews(children);
      }
      else
      {
        SheerResponse.Alert("Please select a rendering item", new string[0]);
      }
      this.SetOpenPropertiesState(item);
    }

    protected override void OnLoad(EventArgs e)
    {
      Assert.ArgumentNotNull(e, "e");
      base.OnLoad(e);
      if (!Context.ClientPage.IsEvent)
      {
        this.IsOpenPropertiesChecked = Registry.GetBool("/Current_User/SelectRendering/IsOpenPropertiesChecked");
        SelectRenderingOptions options = SelectItemOptions.Parse<SelectRenderingOptions>();
        if (options.ShowOpenProperties)
        {
          this.OpenPropertiesBorder.Visible = true;
          this.OpenProperties.Checked = this.IsOpenPropertiesChecked;
        }
        if (options.ShowPlaceholderName)
        {
          this.PlaceholderNameBorder.Visible = true;
          this.PlaceholderName.Value = options.PlaceholderName;
        }
        if (!options.ShowTree)
        {
          this.TreeviewContainer.Class = string.Empty;
          this.TreeviewContainer.Visible = false;
          this.TreeSplitter.Visible = false;
          GridPanel parent = this.TreeviewContainer.Parent as GridPanel;
          if (parent != null)
          {
            parent.SetExtensibleProperty(this.TreeviewContainer, "class", "scDisplayNone");
          }
          //this.Renderings.InnerHtml = this.RenderPreviews(options.Items);
          //new code
          this.Renderings.Visible = false;
          var gruppedSublayouts = options.Items.GroupBy(i => i.Fields[TabGroupFieldID].Value).OrderBy(i => i.Key) ;

          //Add new tab for each folder
          foreach (IGrouping<string, Item> gruppedSublayout in gruppedSublayouts)
          {
            var newTab = new Tab();
            newTab.Header = gruppedSublayout.Key;
            var newScrollbox = new Scrollbox();
            newScrollbox.Class = "scScrollbox scFixSize scFixSize4";
            newScrollbox.Background = "white";
            newScrollbox.Padding = "0px";
            newScrollbox.Width = new Unit(100, UnitType.Percentage);
            newScrollbox.Height = new Unit(100, UnitType.Percentage);
            newScrollbox.InnerHtml = RenderPreviews(gruppedSublayout.OrderBy(x => x.Name));
            newTab.Controls.Add(newScrollbox);
            Tabs.Controls.Add(newTab);
          }
        }
        else
        {
          /*
          var gridPanel = Renderings.Parent as GridPanel;
          if (gridPanel != null)
          {
            gridPanel.SetExtensibleProperty(Tabs, "class",
                                            "scDisplayNone");
          }*/
        }
        this.SetOpenPropertiesState(options.SelectedItem);
      }
    }

    protected override void OnOK(object sender, EventArgs args)
    {
      Assert.ArgumentNotNull(sender, "sender");
      Assert.ArgumentNotNull(args, "args");
      if (!string.IsNullOrEmpty(base.SelectedItemId))
      {
        this.SetDialogResult(ShortID.Parse(base.SelectedItemId).ToID().ToString());
      }
      else
      {
        Item selectionItem = base.Treeview.GetSelectionItem();
        if ((selectionItem != null) && this.IsItemRendering(selectionItem))
        {
          this.SetDialogResult(selectionItem.ID.ToString());
        }
        else
        {
          SheerResponse.Alert("Please select a rendering item", new string[0]);
        }
      }
    }

    protected override void OnSelectableItemClick(Item item)
    {
      Assert.ArgumentNotNull(item, "item");
      this.SetOpenPropertiesState(item);
    }

    private string RenderEmptyPreview(Item item)
    {
      HtmlTextWriter output = new HtmlTextWriter(new StringWriter());
      output.Write("<table class='scEmptyPreview'>");
      output.Write("<tbody>");
      output.Write("<tr>");
      output.Write("<td>");
      if (item == null)
      {
        output.Write(Translate.Text("None available."));
      }
      else if (this.IsItemRendering(item))
      {
        output.Write("<div class='scImageContainer'>");
        output.Write("<span style='height:100%; width:1px; display:inline-block;'></span>");
        string icon = item.Appearance.Icon;
        int num = 0x30;
        int num2 = 0x30;
        if (!string.IsNullOrEmpty(item.Appearance.Thumbnail) && (item.Appearance.Thumbnail != Settings.DefaultThumbnail))
        {
          string str2 = UIUtil.GetThumbnailSrc(item, 0x80, 0x80);
          if (!string.IsNullOrEmpty(str2))
          {
            icon = str2;
            num = 0x80;
            num2 = 0x80;
          }
        }
        ImageBuilder builder2 = new ImageBuilder
        {
          Align = "absmiddle",
          Src = icon,
          Width = num2,
          Height = num
        };
        builder2.Render(output);
        output.Write("</div>");
        output.Write("<span class='scDisplayName'>");
        output.Write(item.GetUIDisplayName());
        output.Write("</span>");
      }
      else
      {
        output.Write(Translate.Text("Please select a rendering item"));
      }
      output.Write("</td>");
      output.Write("</tr>");
      output.Write("</tbody>");
      output.Write("</table>");
      return output.InnerWriter.ToString();
    }

    private string RenderPreviews(ItemCollection items)
    {
      Assert.ArgumentNotNull(items, "items");
      HtmlTextWriter output = new HtmlTextWriter(new StringWriter());
      foreach (Item item in items)
      {
        base.RenderItemPreview(item, output);
      }
      return output.InnerWriter.ToString();
    }

    private string RenderPreviews(IEnumerable<Item> items)
    {
      Assert.ArgumentNotNull(items, "items");
      HtmlTextWriter output = new HtmlTextWriter(new StringWriter());
      bool flag = false;
      foreach (Item item in items)
      {
        base.RenderItemPreview(item, output);
        flag = true;
      }
      if (!flag)
      {
        return this.RenderEmptyPreview(null);
      }
      return output.InnerWriter.ToString();
    }

    protected override void SetDialogResult(Item selectedItem)
    {
      Assert.ArgumentNotNull(selectedItem, "selectedItem");
      this.SetDialogResult(selectedItem.ID.ToString());
    }

    protected void SetDialogResult(string selectedRenderingId)
    {
      Assert.ArgumentNotNull(selectedRenderingId, "selectedRenderingId");
      if (!this.OpenProperties.Disabled)
      {
        Registry.SetBool("/Current_User/SelectRendering/IsOpenPropertiesChecked", this.IsOpenPropertiesChecked);
      }
      string str = selectedRenderingId;
      string formValue = WebUtil.GetFormValue("PlaceholderName");
      SheerResponse.SetDialogValue((str + "," + formValue.Replace(",", "-c-")) + "," + (this.OpenProperties.Checked ? "1" : "0"));
      SheerResponse.CloseWindow();
    }

    private void SetOpenPropertiesState(Item item)
    {
      if ((item == null) || !this.IsItemRendering(item))
      {
        this.OpenProperties.Disabled = true;
        this.OpenProperties.Checked = false;
      }
      else
      {
        string str = item["Open Properties After Add"];
        if (str != null)
        {
          if (!(str == "-") && !(str == ""))
          {
            if (!(str == "0"))
            {
              if (str == "1")
              {
                if (!this.OpenProperties.Disabled)
                {
                  this.IsOpenPropertiesChecked = this.OpenProperties.Checked;
                }
                this.OpenProperties.Disabled = true;
                this.OpenProperties.Checked = true;
              }
              return;
            }
          }
          else
          {
            this.OpenProperties.Disabled = false;
            this.OpenProperties.Checked = this.IsOpenPropertiesChecked;
            return;
          }
          if (!this.OpenProperties.Disabled)
          {
            this.IsOpenPropertiesChecked = this.OpenProperties.Checked;
          }
          this.OpenProperties.Disabled = true;
          this.OpenProperties.Checked = false;
        }
      }
    }

    [UsedImplicitly]
    protected void Treeview_Click()
    {
      Item selectionItem = base.Treeview.GetSelectionItem();
      if (selectionItem != null)
      {
        base.SelectedItemId = string.Empty;
        ItemCollection children = base.DataContext.GetChildren(selectionItem);
        this.Renderings.InnerHtml = ((children != null) && (children.Count > 0)) ? this.RenderPreviews(children) : this.RenderEmptyPreview(selectionItem);
      }
      this.SetOpenPropertiesState(selectionItem);
    }

    // Properties
    [UsedImplicitly]
    protected bool IsOpenPropertiesChecked
    {
      get
      {
        return (((string)base.ServerProperties["IsChecked"]) == "1");
      }
      set
      {
        base.ServerProperties["IsChecked"] = value ? "1" : "0";
      }
    }

    [UsedImplicitly]
    protected Checkbox OpenProperties { get; set; }

    [UsedImplicitly]
    protected Border OpenPropertiesBorder { get; set; }

    [UsedImplicitly]
    protected Edit PlaceholderName { get; set; }

    [UsedImplicitly]
    protected Border PlaceholderNameBorder { get; set; }
  }

}