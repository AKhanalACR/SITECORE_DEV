<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FullStories.ascx.cs" Inherits="ACR.controls.MammographySavesLives.FullStories" %>
	
<script type="text/javascript" src="/js/MammographySavesLives/jquery.truncator.js"></script>
   <script type="text/javascript">
                $(function() {
                        $('.teaser-blurb').truncate({max_length: 300});
            });

            $(function() {
                var url = document.location.toString();
                url = url.substring(url.indexOf('?') + 1);
                var story = url.match(/story=(.*)/);
                if (story != null && story.length == 2) {
                        var anchor = '.' + story[1];
                        $(window).scrollTop($(anchor).position().top);
                        $(anchor + ' .more-link').click();
                }
                });
   </script>

<asp:Repeater ID="Repeater1" runat="server">
      <ItemTemplate>
			<div class="story-teaser" id="storyTeaserDiv" runat="server"> 
				<sc:fieldrenderer id="storyThumbnail" Height="60" Width="60" runat="server" FieldName="Story Thumbnail" />
					<div class="teaser-blurb"> 
                       <h3><sc:fieldrenderer id="storyTitle" runat="server" FieldName="Story Title" /></h3>
                         <p><sc:fieldrenderer id="storyDescription" runat="server" FieldName="Story Description" /></p>
                     </div>
             </div>
       </ItemTemplate>
</asp:Repeater>
<div class="clear"></div>