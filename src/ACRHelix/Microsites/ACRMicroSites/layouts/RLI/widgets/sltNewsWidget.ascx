<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltNewsWidget.ascx.cs" Inherits="ACR.layouts.RLI.widgets.sltNewsWidget" %>
<%@ Register TagPrefix="rli" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<div class="item">
    <div class="inner">
		    <section>
			    <h2 class="cf icon"><rli:image ID="imgIcon" runat="server"/><asp:Literal Id="ltlTitle" runat="server" /></h2>
                <asp:Repeater ID="rptNews" runat="server" OnItemDataBound="rptNews_DataBound">
	                <ItemTemplate>
		                <p><asp:HyperLink ID="hlNewsItem" runat="server" /></p>
                    </ItemTemplate>
                </asp:Repeater>
		    </section>
    </div> 
</div>
