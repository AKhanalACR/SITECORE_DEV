<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainContent.aspx.cs" Inherits="ACR.layouts.ACRInformatics.MainContent" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!-->
<html class="no-js">
<!--<![endif]-->
<head runat="server">
    <sc:Placeholder Key="metaHead" runat="server" />
    <!-- Place favicon.ico and apple-touch-icon.png in the root directory if required -->
    <link rel="stylesheet" href="/css/ACRInformatics/main.css">
    <link rel="stylesheet" href="/css/ACRInformatics/slick.css" />
    <script src="/js/ACRInformatics/modernizr.custom.71565.js"></script>
    <!--[if lte IE 8]>
	<script src="js/respond.js"></script>
<![endif]-->
   <%-- <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
    <script>window.jQuery || document.write('<script src="/js/ACRInformatics/jquery-1.10.2.min.js"><\/script>')</script>--%>
    <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
</head>
<body>
    <form id="form2" runat="server">
        <header>
            <div class="content row">
                <div class="xl-col-half col-full">
                    <a href="/home" class="sprite logo-main"><span></span></a>
                    <sc:Placeholder runat="server" Key="Breadcrumbs" />
                </div>
                <div class="xl-col-half col-full text-right">
                    <sc:Placeholder Key="emailAndSearch" runat="server" />
                </div>
            </div>
        </header>
        <main class="internal">
            <div class="content">
                <div class="row xl-table-like">
                    <sc:Placeholder runat="server" Key="SideNavigation" />
                    <div class="xl-col-3-4ths md-col-2-3rds col-full">
                        <article class="main-content-area">
                            <sc:Placeholder runat="server" Key="Content" />
                            <sc:Placeholder runat="server" Key="Accordion" />
                        </article>
                    </div>
                </div>
                <footer>
                    <sc:Placeholder runat="server" Key="Footer" />
                </footer>
            </div>
        </main>


        <!-- add all other js here for preformance -->
        <script src="/js/ACRInformatics/main.js"></script>
        <script src="/js/ACRInformatics/slick.min.js"></script>
        <script src="/js/ACRInformatics/js.cookie.js"></script>
        <script src="/js/ACRInformatics/maintainPagePosition.js"></script>
        <script>
            jQuery(function ($) {
                $('.home-hero-area').slick({
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    autoplay: true,
                    autoplaySpeed: 6000,
                    dots: true,
                    arrows: false
                });
            });
        </script>
    </form>
</body>
</html>