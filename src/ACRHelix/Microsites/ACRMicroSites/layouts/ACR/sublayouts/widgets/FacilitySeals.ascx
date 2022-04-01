<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacilitySeals.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.widgets.FacilitySeals" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="seals-meaning">
    <div class="content">
        <h2 class="uppercase">
            <sc:Text runat="server" ID="sealTitle" />
        </h2>
        <p>
            <sc:Text runat="server" ID="sealContent" />
        </p>
        <asp:Repeater runat="server" ID="sealRepeater" OnItemDataBound="sealRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="seal-row">
                    <figure>
                        <sc:Image runat="server" ID="sealImage" />
                    </figure>
                    <div class="seal-content">
                        <sc:Text runat="server" ID="sealContent" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

