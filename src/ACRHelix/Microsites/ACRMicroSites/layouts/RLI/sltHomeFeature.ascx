<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltHomeFeature.ascx.cs" Inherits="ACR.layouts.RLI.sltHomeFeature" %>
<%@ Register TagPrefix="rli" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<asp:Repeater ID="rptFeatures" runat="server" OnItemDataBound="rptFeatures_DataBound">
	<ItemTemplate>
        <div class="item">
            <div class="inner">
                <section >
		            <h2><asp:Literal ID="ltlHeader" runat="server"/></h2>
		            <rli:image ID="imgFeatured" runat="server" />
		            <asp:Literal ID="ltlSubheader" runat="server"/>
		            <asp:Literal ID="ltlBody" runat="server"/>
                    <p><asp:HyperLink ID="hlLearnMore" runat="server"></asp:HyperLink></p>
	            </section>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
		
								
