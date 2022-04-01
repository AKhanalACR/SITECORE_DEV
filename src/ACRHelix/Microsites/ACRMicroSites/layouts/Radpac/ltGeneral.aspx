<%@ Page Language="C#" AutoEventWireup="True" Inherits="ACR.layouts.Radpac.ltGeneral" Codebehind="ltGeneral.aspx.cs" %>
<%@ Register TagPrefix="acr" TagName="Header" Src="~/controls/Radpac/Header.ascx" %>
<%@ Register TagPrefix="acr" TagName="Footer" Src="~/controls/Radpac/Footer.ascx" %>
<%@ Register TagPrefix="acr" TagName="Analytics" Src="~/controls/Radpac/Analytics.ascx" %>
<%@ Register TagPrefix="radpac" TagName="PageTitle" Src="~/controls/Radpac/PageTitle.ascx" %>
<%@ Register TagPrefix="common" TagName="MetaHeaders" Src="~/controls/Common/MetaHeaders.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <radpac:PageTitle ID="PageTitle1" runat="server" />
    <common:MetaHeaders ID="MetaHeaders1" runat="server" />

    
    <link rel="stylesheet" href="/css/Radpac/screen.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="/css/Radpac/style.css" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="/css/Radpac/print.css" type="text/css" media="print"/>
    <link rel="stylesheet" href="/css/Radpac/radpac-cookie-bot-overrides.css" type="text/css" />
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>--%>
    <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
	<script language="javascript" type="text/javascript" src="/js/MammographySavesLives/migrate.js"></script>
    <!--<script type="text/javascript" src="/jquery/jquery-1.3.2.min.js"></script>-->
    <script type="text/javascript" src="/jquery/jquery.pngFix.pack.js"></script>
    <script type="text/javascript" src="/js/Radpac/common.js"></script>
    <script type="text/javascript" src="/jquery/jquery.qtip-1.0.0-rc3.min.js"></script>
    <script type="text/javascript" src="/flowplayer/flowplayer-3.2.4.min.js"></script>
    <script type="text/javascript" src="/js/Radpac/radpac-cookiebot-events.js"></script>
     <!-- Addis 5/23/2017 -->
    <script type="text/javascript" src="/js/Radpac/Radpac.Search.js"></script>
    <!--[if IE]>
    <style> #header .search_box{  padding:16px 5px 5px 5px;  } </style>
    <![endif]-->
    
    <acr:Analytics ID="acrAnalytics" runat="server" />
<%--<script id="Cookiebot" src="https://consent.cookiebot.com/uc.js" data-cbid="2bf03008-805a-43ca-a9a0-3b6cd8720291" type="text/javascript" async></script>--%>
    
    <!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-WR39F25');</script>
<!-- End Google Tag Manager -->
</head>
<body>
    <!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-WR39F25"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
    <form id="form1" runat="server">
    <div id="full-container" align="center">
        <div id="container">
            <!--googleoff: all-->
            <acr:header runat="server" id="acrHeader" xmlns:acr="http://www.sitecore.net/xhtml"></acr:header>
            <div id="content">
                <div id="content-left">
                    <!--googleon: all-->

                    <sc:placeholder runat="server" id="phLeftColumn" key="leftColumn"></sc:placeholder>
                    <!--googleoff: all-->
                </div>
                <div id="content-right">
                    <sc:placeholder runat="server" id="phRightColumn" key="rightColumn"></sc:placeholder>
                </div>
            </div>
        
            <acr:footer runat="server" id="acrFooter" xmlns:acr="http://www.sitecore.net/xhtml"></acr:footer>
        </div>
    </div>
    </form></body>
</html>
