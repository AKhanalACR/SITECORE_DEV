<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YourStories Mini.ascx.cs" Inherits="ACR.controls.MammographySavesLives.YourStories_Mini" %>

<div class="secondary-section">
    <h2>Your Stories</h2>  
        <asp:Repeater ID="StoryRepeater" runat="server">
              <ItemTemplate>
				<div class="story"> 
					<sc:fieldrenderer id="storyThumbnail" Height="60" Width="60" runat="server" FieldName="Story Thumbnail" />
					<div class="story-text"> 
                       <h4><a class="story-title" id="titleLink" runat="server"><sc:fieldrenderer id="storyTitle" runat="server" FieldName="Story Title" /></h4></a>
                         <p><sc:fieldrenderer id="storyTeaser" runat="server" FieldName="Story Teaser" />
                         <a class="callout-action" id="moreLink" runat="server"><sc:fieldrenderer id="storyMoreLink" runat="server" FieldName="Story More Link" />More</a></p>
                     </div>
                 </div>
                 <div class="clear" id="divClear" runat="server"></div>
               </ItemTemplate>
         </asp:Repeater>
        <p><a class="callout-action view-all" id="sectionTitleLink" href="Survivor%20Stories/More%20Stories.aspx">View All Stories</a></p>
    </div>
