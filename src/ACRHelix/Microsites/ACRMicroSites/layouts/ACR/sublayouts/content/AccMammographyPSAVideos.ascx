<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccMammographyPSAVideos.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccMammographyPSAVideos" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="ACRAccreditationInformaticsLibrary" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="Sitecore.Data.Fields" %>

<section class="content header-v-tpad">
    <header>
        <h2 runat="server" id="header">
            <sc:Text runat="server" ID="Title" />
        </h2>        
    </header>
    <p runat="server" id="paraSubTitle"><sc:Text runat="server" ID="subTitle" /></p>
    <div class="row-nestled">      
       <asp:Repeater runat="server" ID="PSAVideos" OnItemDataBound="PSA_ItemDataBound">
           <ItemTemplate>   
              <div class="md-col-6 lg-col-4 spaced-item"> 
                  <div class="lg-max-column-220px">
                      <p style="<%# ItemHelper.GetFieldValue(Container.DataItem as Item,"Youtube Embed Link") == "" ? "display:none;" : "" %>">
                          <sc:Link runat="server" Item="<%# Container.DataItem %>" Field="Read More Link" >
                              <sc:Text runat="server" Item="<%# Container.DataItem %>" Field="Title" />
                          </sc:Link>                               
                      </p>
                      <div class="video-holder feature-section-iv">     
                          <iframe width="100%" height="100%" src="<%# ItemHelper.GetFieldValue(Container.DataItem as Item,"Youtube Embed Link") %>" frameborder="0" allow="autoplay; encrypted-media" allowfullscreen ></iframe>                              
                       </div>                                                      
                      <div class="has-arrow-link">
                          <sc:Link runat="server" Item="<%# Container.DataItem %>" Field="Read More Link" >
                              <sc:Text runat="server" Item="<%# Container.DataItem %>" Field="Video Text" />
                          </sc:Link>
                      </div>
                  </div>
              </div>                   
           </ItemTemplate>
       </asp:Repeater>
    </div>
    <p><sc:Text runat="server" ID="richText" /></p>
</section>
