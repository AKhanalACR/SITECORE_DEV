<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ltWebLayout.aspx.cs" Inherits="ACR.layouts.MammographySavesLives.ltWebLayout" %>

<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>
        <sc:FieldRenderer FieldName="Browser Title" ID="scPageTitle" runat="server" />
    </title>
    <%--<script id="Cookiebot" src="https://consent.cookiebot.com/uc.js" data-cbid="9cee1fbf-7846-4c23-8c10-168f18694927" type="text/javascript" async></script>--%>

    <!-- Google Tag Manager -->
    <script>(function (w, d, s, l, i) {
        w[l] = w[l] || []; w[l].push({
            'gtm.start':
                new Date().getTime(), event: 'gtm.js'
        }); var f = d.getElementsByTagName(s)[0],
            j = d.createElement(s), dl = l != 'dataLayer' ? '&l=' + l : ''; j.async = true; j.src =
                'https://www.googletagmanager.com/gtm.js?id=' + i + dl; f.parentNode.insertBefore(j, f);
        })(window, document, 'script', 'dataLayer', 'GTM-KGR5WVN');</script>
    <!-- End Google Tag Manager -->


    <link rel="stylesheet" href="/css/MammographySavesLives/reset.css" type="text/css" media="all" />
    <link rel="stylesheet" href="/css/MammographySavesLives/jquery.Jcrop.css" type="text/css" media="all" />
    <link rel="stylesheet" href="/css/MammographySavesLives/rotator.css" type="text/css" media="all" />
    <link rel="stylesheet" href="/css/MammographySavesLives/site.css" type="text/css" media="all" />
    <link rel="stylesheet" href="/css/MammographySavesLives/ui.tabs.css" type="text/css" media="all" />
    <link rel="stylesheet" href="/css/MammographySavesLives/msl-cookie-bot-overrides.css?v=10.23.1" type="text/css" />

    <script language="javascript" type="text/javascript" src="/js/MammographySavesLives/jquery-1.12.4.min.js"></script>
    <script language="javascript" type="text/javascript" src="/js/MammographySavesLives/migrate.js"></script>
    <script language="javascript" type="text/javascript" src="/js/MammographySavesLives/jquery.blockUI.js"></script>
    <script src="/js/MammographySavesLives/msl-cookiebot-events.js?v=10.23.1" ></script>

    <sc:Placeholder runat="server" Key="html-head-content" ID="phInjectScripts" />

    <sc:Placeholder runat="server" Key="html-subpage-content" ID="phStoryScripts" />

    <script language="javascript" type="text/javascript" src="/js/MammographySavesLives/main.js"></script>
    <script language="javascript" type="text/plain" data-cookieconsent="marketing" src="/js/MammographySavesLives/youtube.js"></script>

    <!--[if IE 6]>
		<script type="text/javascript" src="/Scripts/DD_belatedPNG_0.0.8a-min.js"></script>
		<script type="text/javascript">DD_belatedPNG.fix("img, .main-nav-selected .main-nav-link, .main-nav-selected .main-nav-middle, .main-nav-selected .main-nav-inner, .callout-action, .reminder, .more-link, .less-link");</script>
	<![endif]-->

</head>

<body>
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-KGR5WVN"
            height="0" width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
    <!-- End Google Tag Manager (noscript) -->

    <form id="form1" runat="server">
        <!--[if gte IE 8]> 
			<div id="ie8andup" class="ie ie8"> 
		<![endif]-->
        <!--[if IE 7]> 
			<div id="ie7only" class="ie ie7"> 
		<![endif]-->
        <!--[if IE 6]>
			<div id="ie6only" class="ie ie6">
		<![endif]-->
        <!-- begin container -->
        <div class="header">
            <sc:Placeholder runat="server" Key="header-content" />
        </div>
        <div class="container">
            <div class="main-content">
                <sc:Placeholder runat="server" Key="body-content" />
            </div>
            <sc:Placeholder runat="server" Key="sub-body-content" />
        </div>
        <div class="footer">
            <sc:Placeholder runat="server" Key="footer-content" />
        </div>
        <!-- end container -->
        <sc:Placeholder runat="server" Key="post-footer-content" />
        <!--[if IE]>
			</div>
		<![endif]-->
    </form>
    <script language="javascript" type="text/javascript" src="https://www.youtube.com/iframe_api"></script>
</body>
</html>
