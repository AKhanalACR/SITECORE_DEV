<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YouTubePlaylistTabs.ascx.cs" Inherits="ACR.controls.MammographySavesLives.YouTubePlaylistTabs" %>
<%@ Register TagPrefix="acr" TagName="YouTubeVideo" src="~/controls/MammographySavesLives/YouTubeVideo.ascx" %>

<asp:Label ID="ErrorLabel" runat="server" Visible="false" ForeColor="Red" />

<div class="video-player-outline">
	<div class="video-player">
		<ul class="video-player-tab-area">
			<li><a class="video-player-tab personal-stories-tab" href="#stories">Personal Stories</a></li>
			<li><a class="video-player-tab tv-ads-tab" href="#tv-ads">TV Ads</a></li>
		</ul>

		<div id="stories">
			<div class="video-area">
				<acr:YouTubeVideo id="StoriesVideo" runat="server" Chromeless="false" CssClass="video" ShowDescriptionBox="true" />
			</div>
                
			<div class="channel-area">
				<asp:Repeater ID="StoriesRepeater" runat="server">
					<ItemTemplate>
						<div class="video-thumb">
							<a href="?pl=stories&item=<%# Container.ItemIndex %>#stories"><img class="video-thumb-image" src="<%# Eval("Snippet.Thumbnails.Default__.Url") %>" alt="<%# Eval("snippet.title") %>"/></a>
							<h4 class="video-thumb-title"><a href="?pl=stories&item=<%# Container.ItemIndex %>#stories"><%# Eval("snippet.title") %></a></h4>
							<p><%# Eval("Statistics.ViewCount") %> views - <%# GetDateDifference((DateTime)(Container.DataItem as Google.Apis.YouTube.v3.Data.Video).Snippet.PublishedAt) %> ago</p>
						</div>
					</ItemTemplate>
				</asp:Repeater>
			</div>       
		</div>  
            
		<div id="tv-ads">
			<div class="video-area">
				<acr:YouTubeVideo id="AdsVideo" runat="server" Chromeless="false" CssClass="video" ShowDescriptionBox="true" />
			</div>
                
			<div class="channel-area">
				<asp:Repeater ID="AdsRepeater" runat="server">
					<ItemTemplate>
						<div class="video-thumb">
							<a href="?pl=ads&item=<%# Container.ItemIndex %>#tv-ads"><img class="video-thumb-image" src="<%# Eval("Snippet.Thumbnails.Default__.Url") %>" alt="<%# Eval("snippet.title") %>"/></a>
							<h4 class="video-thumb-title"><a href="?pl=ads&item=<%# Container.ItemIndex %>#tv-ads"><%# Eval("snippet.title") %></a></h4>
							<p><%# Eval("Statistics.ViewCount") %> views - <%# GetDateDifference((DateTime)(Container.DataItem as Google.Apis.YouTube.v3.Data.Video).Snippet.PublishedAt) %> ago</p>
						</div>
					</ItemTemplate>
				</asp:Repeater>
			</div>       
		</div>


		<div class="clear"></div>
	</div>
</div>