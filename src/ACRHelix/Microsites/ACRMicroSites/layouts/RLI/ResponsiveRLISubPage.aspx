<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResponsiveRLISubPage.aspx.cs" Inherits="ACR.layouts.RLI.ResponsiveRLISubPage" %>

<%@ Import Namespace="ACR.controls.RLI.Responsive" %>
<%@ Register TagPrefix="rli" TagName="HeaderBanner" Src="~/controls/RLI/Responsive/HeaderBanner.ascx" %>
<%@ Register TagPrefix="rli" TagName="Header" Src="~/controls/RLI/Responsive/Header.ascx" %>
<%@ Register TagPrefix="rli" TagName="Footer" Src="~/controls/RLI/Responsive/Footer.ascx" %>
<%--<%@ Register TagPrefix="rli" TagName="SideNav" Src="~/controls/RLI/LeftRail.ascx" %>--%>
<%@ Register TagPrefix="rli" TagName="Analytics" Src="/controls/RLI/Analytics.ascx" %>
<%@ Register TagPrefix="common" TagName="MetaHeaders" Src="~/controls/Common/MetaHeaders.ascx" %>
<%@ Register TagPrefix="rli" TagName="FooterAd" Src="~/controls/RLI/FooterBannerAd.ascx" %>

<!DOCTYPE html>
<!--[if IE 7 ]> <html lang="en" class="ie7"> <![endif]-->
<!--[if IE 8 ]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9 ]> <html lang="en" class="ie9"> <![endif]-->
<!--[if (gt IE 9)|!(IE)]><!-->
<html lang="en">
<!--<![endif]-->
<head>
    <title>
        <asp:Literal runat="server" ID="pageTitle" /></title>
    <meta charset="utf-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <common:MetaHeaders ID="MetaHeaders1" runat="server" />

    <!--styles-->
	<link href="/css/RLI/rli.css" rel="stylesheet" type="text/css" />
    <!--styles-->
    <link href="/css/RLI/rli-main.css" rel="stylesheet" type="text/css" />
    <%--	<link href="/css/RLI/calendar.css" rel="stylesheet" type="text/css" />--%>

    <!--scripts-->
    <%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
    <script src="/js/RLI/rli-main.js"></script>
    <%--	<script src="/js/plugins/jquery.cycle.all.min.js" type="text/javascript"></script>
	<script type="text/javascript" src="/Scripts/underscore.min.js"></script>
	<script src="/js/rli/rli.eventcalendar.js" type="text/javascript"></script>--%>
    <%--	<script src="/js/rli/rli.search.js" type="text/javascript"></script>--%>

    <!--[if lt IE 9]>
	<script src="/js/plugins/html5shiv.js"></script>
	<script src="/js/plugins/selectivizr-min.js"></script>
	<![endif]-->
    <!--[if IE]>
	<script src="/js/plugins/jquery.placeholder.js"></script>
	<![endif]-->
    <%--	<script src="/js/RLI/custom_velir.js" type="text/javascript"></script>

	<script src="/jquery/jquery.calendario.js" type="text/javascript"></script>--%>
    <rli:Analytics runat="server" />
	
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
	
</head>
<body>
    <form id="form1" runat="server">
        <rli:HeaderBanner ID="rliHeaderBanner" runat="server" />
        <rli:Header ID="rliHeader" runat="server" />
        <main role="main">
            <div class="content row">
                <div class="col-12">
                    <!--SHOULD be the breadcrumb, taken and shrunked up some from ACR.org-->
                    <div class="nav-breadcrumbs">
                        <ul>
                            <li><a id="content_1_breadcrumb_hlHome" class="print-media" href="/">Home</a><span class="slash">/</span></li>
                            <li class="current">Catalog</li>
                        </ul>
                    </div>
                    <!-- end breadcrumb -->
                </div>
            </div>
            <div class="content">
                <sc:Placeholder ID="phMainContent" runat="server" Key="MainContent" />
            </div>
        </main>
         <rli:FooterAd runat="server" />
        <rli:Footer ID="rliFooter" runat="server" />
    </form>
</body>
</html>
