<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LtRLISubPage.aspx.cs" Inherits="ACR.layouts.RLI.LtRLISubPage" %>
<%@ Register TagPrefix="rli" TagName="HeaderBanner" Src="~/controls/RLI/HeaderBanner.ascx" %>
<%@ Register TagPrefix="rli" TagName="Header" Src="~/controls/RLI/Header.ascx" %>
<%@ Register TagPrefix="rli" TagName="Footer" Src="~/controls/RLI/Footer.ascx" %>
<%@ Register TagPrefix="rli" TagName="SideNav" Src="~/controls/RLI/LeftRail.ascx" %>
<%@ Register tagPrefix="rli" tagName="Analytics" src="/controls/RLI/Analytics.ascx" %>
<%@ Register TagPrefix="common" TagName="MetaHeaders" Src="~/controls/Common/MetaHeaders.ascx" %>
<%@ Register TagPrefix="rli" TagName="FooterAd" Src="~/controls/RLI/FooterBannerAd.ascx" %>

<!DOCTYPE html>
<!--[if IE 7 ]> <html lang="en" class="ie7"> <![endif]-->
<!--[if IE 8 ]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9 ]> <html lang="en" class="ie9"> <![endif]-->
<!--[if (gt IE 9)|!(IE)]><!--> <html lang="en"> <!--<![endif]-->
<head>
	<title><asp:Literal runat="server" ID="pageTitle" /></title>
	<meta charset="utf-8"/>
	<common:MetaHeaders ID="MetaHeaders1" runat="server" />

	<!--styles-->
	<link href="/css/RLI/rli.css" rel="stylesheet" type="text/css" />
	<link href="/css/RLI/calendar.css" rel="stylesheet" type="text/css" />

	<!--scripts-->
	<%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
	<script src="/js/plugins/jquery.cycle.all.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="/Scripts/underscore.min.js"></script>
	<script src="/js/rli/rli.eventcalendar.js" type="text/javascript"></script>
	<%--<script src="/js/rli/rli.search.js" type="text/javascript"></script>--%>

    <script>
        RLI = [];
        if (RLI == null) {
            RLI = [];
        }

        if (RLI.Search == null) {
            RLI.Search = [];
        }
        
        $(document).ready(function () {

            RLI.Search.InitializeSearchBox();
        });

        RLI.Search.InitializeSearchBox = function () {
            $('#searchbox').on("keydown", function (e) {
                var keycode = (e.keyCode ? e.keyCode : e.which);
                if (keycode == '13') {
                    if ($(e.target).prop("type") === "textarea") {
                        return;
                    }
                    e.preventDefault();
                    e.stopPropagation();
                    $('#searchlink').click();
                    return false;
                }
                return;
            });
            $('#searchlink').click(function (e) {
                e.preventDefault();
                e.stopPropagation();
                window.location.href = '/search' + '?q=' + $('#searchbox')[0].value;
            });

        }

    </script>

	<!--[if lt IE 9]>
	<script src="/js/plugins/html5shiv.js"></script>
	<script src="/js/plugins/selectivizr-min.js"></script>
	<![endif]-->
	<!--[if IE]>
	<script src="/js/plugins/jquery.placeholder.js"></script>
	<![endif]-->
	<script src="/js/RLI/custom_velir.js" type="text/javascript"></script>

	<script src="/jquery/jquery.calendario.js" type="text/javascript"></script>
	<rli:Analytics runat="server"/>
	<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-P8T58QG');</script>
<!-- End Google Tag Manager -->
    <!-- Crazy Egg Tracking Script Heatmap -->
    <script type="text/javascript">setTimeout(function(){var a=document.createElement("script");var b=document.getElementsByTagName("script")[0];a.src=document.location.protocol+"//script.crazyegg.com/pages/scripts/0049/8406.js?"+Math.floor(new Date().getTime()/3600000);a.async=true;a.type="text/javascript";b.parentNode.insertBefore(a,b)}, 1);</script>

<script id="Cookiebot" src="https://consent.cookiebot.com/uc.js" data-cbid="baa9e888-5cd6-477c-bfb3-10048c37af9f" type="text/javascript" async></script>
</head>
<body>
	<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-P8T58QG"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
	<form id="form1" runat="server">
		<rli:HeaderBanner ID="rliHeaderBanner" runat="server" />
		<rli:Header ID="rliHeader" runat="server" />
		<asp:Panel id="pnlWrapper" runat="server">
			<div class="content">
				<div class="gradientBorders sides">
					<div class="inner cf">
						<!--javascript reads this item and applies the image to styling on the fly.-->
						<div class="pageBackground">
							<asp:Image ID="imgBkd" runat="server" />
						</div>
						<rli:SideNav runat="server"/>
						<sc:Placeholder ID="phMainContent" runat="server" Key="MainContent" />
					</div>
				</div>
			</div>
			<asp:PlaceHolder ID="phWidgets" runat="server" Visible="false">
				<aside class="sidebar widgets">
					<sc:Placeholder ID="plhWidgets" runat="server" Key="RightSidebar" />  
				</aside>
			</asp:PlaceHolder>
		</asp:Panel>
         <rli:FooterAd runat="server" />
		<rli:Footer ID="rliFooter" runat="server" />
	</form>
</body>
</html>
