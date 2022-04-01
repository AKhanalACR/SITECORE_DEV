<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ltGeneral.aspx.cs" Inherits="ACR.layouts.ImageWisely.ltGeneral" %>
<%@ Register TagPrefix="acr" TagName="Header" Src="~/controls/ImageWisely/Header.ascx" %>
<%@ Register TagPrefix="acr" TagName="Footer" Src="~/controls/ImageWisely/Footer.ascx" %>
<%@ Register TagPrefix="acr" TagName="Analytics" Src="~/controls/ImageWisely/Analytics.ascx" %>
<%@ Register TagPrefix="iw" TagName="PageTitle" Src="~/controls/ImageWisely/PageTitle.ascx" %>
<%@ Register TagPrefix="common" TagName="MetaHeaders" Src="~/controls/Common/MetaHeaders.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>

	<iw:PageTitle ID="PageTitle1" runat="server" />
	<common:MetaHeaders ID="MetaHeaders1" runat="server" />
    
	<link rel="stylesheet" href="/css/ImageWisely/screen.css" type="text/css" media="screen, projection" />
	<link rel="stylesheet" href="/css/ImageWisely/style.css" type="text/css" media="screen, projection" />
	<link rel="stylesheet" href="/css/ImageWisely/print.css" type="text/css" media="print"/>
    
	<!-- Updating jquery link to the latest version, hosted by google: -->
	<%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>--%>
    <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>

	<script type="text/javascript" src="/jquery/jquery.pngFix.pack.js"></script>

	<!-- New! 10/25/2012 -->
	<script type="text/javascript" src="/js/ImageWisely/Slides/source/slides.min.jquery.js"></script>
	<script type="text/javascript" src="/js/ImageWisely/jquery.betterTooltip.js"></script>
    
	<script type="text/javascript" src="/js/ImageWisely/common.js"></script>
	<script type="text/javascript" src="/jquery/jquery.qtip-1.0.0-rc3.min.js"></script>
	<script type="text/javascript" src="/flowplayer/flowplayer-3.2.4.min.js"></script>

    <!-- Addis 4/27/2017 -->
    <script src="/js/ImageWisely/ImageWisely.search.js" type="text/javascript"></script>

	<!--[if IE]>
	<style> #header .search_box{  padding:16px 5px 5px 5px;  } </style>
	<![endif]-->
    
	<acr:Analytics ID="acrAnalytics" runat="server" />

    <!-- Crazy Egg Tracking Script Heatmap -->
    <script type="text/javascript">setTimeout(function(){var a=document.createElement("script");var b=document.getElementsByTagName("script")[0];a.src=document.location.protocol+"//script.crazyegg.com/pages/scripts/0049/8406.js?"+Math.floor(new Date().getTime()/3600000);a.async=true;a.type="text/javascript";b.parentNode.insertBefore(a,b)}, 1);</script>

<script id="Cookiebot" src="https://consent.cookiebot.com/uc.js" data-cbid="1a702d60-9f3c-411f-85f6-8758d24b2593" type="text/javascript" async></script>
</head>
<body>
	<form id="form1" runat="server">
		<noindex>
			<asp:ScriptManager runat="server" ID="ScriptManager1" EnablePartialRendering="true" />
		</noindex>
		<div id="full-container" align="center">
			<div id="container">
				<!--googleoff: all-->
				<acr:Header ID="acrHeader" runat="server" />
				<div id="content">
					<!-- This is where the homepage slider will have to go -->
					<sc:Placeholder ID="phTopContent" runat="server" Key="topContent" />
					<div id="content-left">
						<!--googleon: all-->
						<sc:Placeholder ID="phLeftColumn" runat="server" Key="leftColumn" />
						<!--googleoff: all-->
					</div>
					<div id="content-right" >
						<sc:Placeholder ID="phRightColumn" runat="server" Key="rightColumn" />
					</div>
				</div>
        
				<acr:Footer ID="acrFooter" runat="server" />
			</div>
		</div>
	</form>
</body>
</html>
