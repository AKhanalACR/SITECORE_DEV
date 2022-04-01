<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccMammographySurvivorStories.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccMammographySurvivorStories" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<%@ Import Namespace="Sitecore.Data.Items" %>
<%@ Import Namespace="Sitecore.Data.Fields" %>
<div class="bg-light-gray">
    <section class="content lg-vert-line-25pct header-v-pad">
        <header">
            <h1>
                <sc:Text runat="server" ID="sectionTitle" />
            </h1>
        </header>
        <div class="row-nestled">
            <asp:Repeater runat="server" ID="StepNav" OnItemDataBound="SS_ItemDataBound">
                <ItemTemplate>   
                   <div class="md-col-6 lg-col-4 spaced-item"> 
                       <div class="lg-max-column-220px">
                           <p>
                               <sc:Link runat="server" Item="<%# Container.DataItem %>" Field="Link" >
                                   <sc:Text runat="server" Item="<%# Container.DataItem %>" Field="Title" />
                               </sc:Link>                               
                           </p>

                           <figure class="img-contain feature-section-iv">
                                <sc:Link runat="server" Item="<%# Container.DataItem %>" Field="Link" >
                                   <sc:Image runat="server" Item="<%# Container.DataItem %>" Field="Image" />
                                </sc:Link>
                           </figure>

                           <div class="has-arrow-link">
                               <sc:Link runat="server" Item="<%# Container.DataItem %>" Field="Link" ></sc:Link>
                           </div>
                       </div>
                   </div>                   
                </ItemTemplate>
            </asp:Repeater>
        </div>        
    </section>
</div>
