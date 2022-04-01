<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="sltEventsWidget.ascx.cs" Inherits="ACR.layouts.RLI.widgets.sltEventsWidget" %>
<%@ Register TagPrefix="rli" TagName="image" Src="~/controls/Common/SitecoreImage.ascx" %>

<div class="item" id="itemdiv">
    <div class="inner">
	    <section>
		    <h2 class="cf icon"><rli:image ID="imgIcon" runat="server"/><asp:Literal Id="ltlTitle" runat="server" /></h2>
            <asp:PlaceHolder runat="server" ID="plcEventwidget">
                <asp:Repeater ID="rptEvt" runat="server" OnItemDataBound="rptEvt_DataBound">
	                <ItemTemplate>
						<div><p>
							<asp:HyperLink ID="hlEvt" runat="server" />
							<asp:Literal runat="server" ID="litStartdate"></asp:Literal>
							<asp:Literal runat="server" ID="litLocation"></asp:Literal>
							<asp:Literal runat="server" ID="litLectureName"></asp:Literal>
							<asp:Literal runat="server" ID="litTagName"></asp:Literal>
						</p></div>
                     </ItemTemplate>
                 </asp:Repeater>
            </asp:PlaceHolder>
            <asp:PlaceHolder runat="server" ID="plcEventFeatureItem"  Visible="False">
                <asp:Repeater ID="rptEvtFeature" runat="server" OnItemDataBound="rptEvtFeature_DataBound">
	                <ItemTemplate>
						<div>
							<div style="padding-bottom: 5px;">
								<asp:HyperLink ID="hlEvt" runat="server" />
                                    <asp:PlaceHolder runat=server ID="plcEventLink" Visible="false">
                                    <asp:Literal runat="server" ID="litStartdate"></asp:Literal>
								    <asp:Literal runat="server" ID="litLocation"></asp:Literal>
								    <asp:Literal runat="server" ID="litLectureName"></asp:Literal>
								    <asp:Literal runat="server" ID="litTagName"></asp:Literal>
                                    <div style="padding-bottom: 10px;"><asp:Literal runat="server" ID="litShortdescription"></asp:Literal></div>
                                </asp:PlaceHolder>
							</div>
							
						</div>
                     </ItemTemplate>
                 </asp:Repeater>
            </asp:PlaceHolder>
	    </section>
    </div> 
</div>
<script type="text/javascript">
    if ("<%=className %>" == "HomePage") {
        $("#itemdiv").attr("class", "homeFeatureItem"); 
    }
    
</script>