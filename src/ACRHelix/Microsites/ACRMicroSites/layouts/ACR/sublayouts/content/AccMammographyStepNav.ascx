<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccMammographyStepNav.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccMammographyStepNav" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="Sitecore.Data.Fields" %>

<div class="content">
    <div ID="imageSection" runat="server" class="text-c">       
        <figure class="img-contain float-none inline-block acc-msl-nav">
            <a id="lnkMslHome" href="/mammography-saves-lives">
                <sc:Image runat="server" ID="headerImage" />
            </a>
        </figure>
        <div class="spaced-item-spacer"> </div>
    </div>
    <h1 class="uppercase">
        <sc:Text runat="server" ID="contentTitle" />
    </h1>
    <div class="starter-steps has-arrow-link fff">
        <asp:Repeater runat="server" ID="StepNav" OnItemDataBound="StepNav_ItemDataBound">
            <ItemTemplate>
                <div class="step-box desktop-n<%# ((Container.ItemIndex%4) + 1) %> n<%# ((Container.ItemIndex%3) + 1) %>"> 
                    <span class="step-num">
                        <asp:Literal ID="stepNumber" runat="server" />
                    </span>   
                    <sc:Link runat="server" Item="<%# Container.DataItem %>" Field="Link" CssClass="step-link">
                        <sc:Text runat="server" Item="<%# Container.DataItem %>" Field="Link Title" />
                    </sc:Link>                 
                    
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div style="background: none; padding: 15px; border: none; display: block; float: left; border: 1px solid #fff; height: 3.875em; color: #fff;">          
            <asp:Literal runat="server" ID="socialLinks"></asp:Literal> 
        </div>
    </div>
</div>