<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Standard.aspx.cs" Inherits="ACR.layouts.ACR.Standard" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
    <head>
        <sc:placeholder key="metaHead" runat="server" />
        <link rel="stylesheet" href="/css/main.css">
        <link rel="stylesheet" href="/css/ACR/acraccreditation-cookie-bot-overrides.css?v=10.23.1" type="text/css" />
        <script src="/js/ACR/acraccreditation-cookiebot-events.js?v=10.23.1" ></script>
		<script src="/js/modernizr.custom.71565.js"></script>
        <!--[if lte IE 8]>
        	<script src="/js/respond.js"></script>
		<![endif]-->

        <!-- Crazy Egg Tracking Script Heatmap -->
        <%--<script type="text/javascript">setTimeout(function(){var a=document.createElement("script");var b=document.getElementsByTagName("script")[0];a.src=document.location.protocol+"//script.crazyegg.com/pages/scripts/0049/8406.js?"+Math.floor(new Date().getTime()/3600000);a.async=true;a.type="text/javascript";b.parentNode.insertBefore(a,b)}, 1);</script>
        <script id="Cookiebot" src="https://consent.cookiebot.com/uc.js" data-cbid="4caa2549-6205-4abe-8783-01744dad47c5" type="text/javascript" async></script>--%>
    </head> 
    <body>
        <!-- Google Tag Manager -->
<noscript><iframe src="//www.googletagmanager.com/ns.html?id=GTM-KKFW2N"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'//www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-KKFW2N');</script>
<!-- End Google Tag Manager -->
        <form id="form1" runat="server">      
            <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>    
        <header>
            <sc:Placeholder key="header" runat="server" />
	        <div class="content" id="header-main">
		        <a href="/" class="icon header-logo"></a>
                <sc:Placeholder key="headerMain" runat="server" />
	        </div>
        </header>           
        <sc:Placeholder runat="server" Key="contentMain" />                               
        <footer>
	       <sc:Placeholder runat="server" Key="footer" />
        </footer>
        </form>
        <%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="/js/jquery-1.10.2.min.js"><\/script>')</script>--%>
        <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
        <script>jQuery.noConflict();</script>
         <script src="/js/js.cookie.js" ></script>
        <script src="/js/jquery.cycle2.min.js" rel='script'></script>
        <script src="/js/acraccreditation-main.js"></script>
        <script src="/js/maintainPagePosition.js" ></script>
        <sc:Placeholder Key="customJavascripts" runat="server" />     
    </body>
</html>