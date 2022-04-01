<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ModalityStepListing.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.listing.ModalityStepListing" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="ACR.Constants" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>

      
            <div class="content">
	            <h1 class="uppercase"><sc:Text runat="server" ID="contentTitle" /><a name="top"></a></h1>
	            <div class="starter-steps has-arrow-link fff">
	                <asp:Repeater runat="server" ID="StepNav" OnItemDataBound="StepNav_ItemDataBound">
                        <ItemTemplate>
                            <div class="step-box desktop-n<%# ((Container.ItemIndex%4) + 1) %> n<%# ((Container.ItemIndex%3) + 1) %>"> 
                                <span class="step-num"><asp:Literal ID="stepNumber" runat="server" /></span> 
                                <a href="#s<%# (Container.ItemIndex + 1) %>" class="step-link">
                                    <%# ItemHelper.GetFieldValueOrItemName(Container.DataItem as Item, "Step Title") %>
                                </a>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
	            </div>
            </div>
            <div class="content">
            <br />
                <p class="txt-align-center"><sc:Link ID="stillHaveQuestionsLink" runat="server" CssClass="stillHaveQuestions" /></p>
	
            <sc:FieldRenderer ID="mainContent" runat="server" />
      
            <asp:Repeater runat="server" ID="StepList" OnItemDataBound="StepList_ItemDataBound">
                <ItemTemplate>
                    <h2><span class="step-num"><asp:Literal ID="stepNumber" runat="server" />
                        <a name="s<%# (Container.ItemIndex + 1) %>"></a></span>
                        <%# ItemHelper.GetFieldValueOrItemName(Container.DataItem as Item, "Step Title") %>
                    </h2>
                   <%-- <%# ItemHelper.GetFieldValue(Container.DataItem as Item, "Step Detail") %>--%>
                    <sc:Text runat="server" ID="stepDetail" Field="Step Detail" />
                    <div class="hr-to-top"><a href="#top">Back to top</a></div>
                </ItemTemplate>
            </asp:Repeater>

    </div>