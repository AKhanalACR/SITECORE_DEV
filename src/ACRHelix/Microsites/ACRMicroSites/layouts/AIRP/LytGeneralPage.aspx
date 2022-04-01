<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LytGeneralPage.aspx.cs" Inherits="ACR.layouts.AIRP.LytGeneralPage" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!--[if IE 6 ]> <html lang="en" class="ie6"> <![endif]-->
<!--[if IE 7 ]> <html lang="en" class="ie7"> <![endif]-->
<!--[if IE 8 ]> <html lang="en" class="ie8"> <![endif]-->
<!--[if IE 9 ]> <html lang="en" class="ie9"> <![endif]-->
<!--[if (gt IE 9)|!(IE)]><!--> <html lang="en"> <!--<![endif]-->
<!--
	Note for Developer:
	If you would like to make the above logic server-side, please be my guest.  There
	is a decent write-up for doing so in C# in the Velir Wiki
-->
	<head>
        <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js" integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4=" crossorigin="anonymous"> </script>
        <script type="text/javascript">
            
            jQuery(document).ready(function() {
                var sourceUrl = [ 
                    "https://www.airp.org/resident-courses", 
                    "https://www.airp.org/resident-courses/four-week-course", 
                    "https://www.airp.org/resident-courses/case-submission", 
                    "https://www.airp.org/resident-courses/faculty", 
                    "https://www.airp.org/about-us", 
                    "https://www.airp.org/about-us/contact-us", 
                    "https://www.airp.org/catcourse", 
                    "https://www.airp.org/catcourse/neuro", 
                    "https://www.airp.org/catcourse/pediatric", 
                    "https://www.airp.org/catcourse/msk", 
                    "https://www.airp.org/catcourse/breast", 
                    "https://www.airp.org/catcourse/abdominal", 
                    "https://www.airp.org/catcourse/cardiothoracic", 
                    "https://www.airp.org/about-us/frequently-asked-questions" 
                ];
        
                var destUrl = [ 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP/Four-Week-Course", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP/Four-Week-Course", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP/Four-Week-Course/Case-Submission", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP/About-AIRP", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP/About-AIRP", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP/Categorical-Courses", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/Meetings-and-Course-Calendar/Neuro-Categorical", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/Meetings-and-Course-Calendar/Pediatric-Categorical", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/Meetings-and-Course-Calendar/MSK-Categorical", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/Meetings-and-Course-Calendar/Breast-Categorical", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/Meetings-and-Course-Calendar/Abdominal-Categorical", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/Meetings-and-Course-Calendar/Thoracic-Categorical", 
                        "https://www.acr.org/Lifelong-Learning-and-CME/AIRP/Four-Week-Course/Case-Submission/FAQ"
                    ];
        
                var requestUrl = window.location.href;
                var index = jQuery.inArray(requestUrl.toLowerCase(), sourceUrl);
        
                if (index > -1) {
                    document.write('<style>html { background-color: white; } body { visibility: hidden; } </style>');
                    window.location.href = destUrl[index];
                }        
            });
        </script>
		<title><asp:Literal runat="server" ID="litTitle"></asp:Literal></title>
		<meta charset="utf-8">
		<meta name="keywords" content=<%= String.Format("\"{0}\"", keywords) %>>
        <link href="/css/AIRP/styles.css" rel="stylesheet" type="text/css"  media="all" />   
        <link href="/css/AIRP/airp-cookie-bot-overrides.css" rel="stylesheet" type="text/css" />   
        <%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>--%>
        <script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
        <script src="/js/plugins/jquery.cycle.all.min.js"></script>       
        <!--[if lt IE 9]>
        <script src="/js/plugins/html5shiv.js"></script>
        <script src="/js/plugins/selectivizr-min.js"></script>
        <![endif]-->
        
        <!--[if IE]>
        <script src="/js/plugins/jquery.placeholder.js"></script>
        <![endif]-->
        
        <script src="/js/AIRP/custom_velir.js"></script>
        <script src="/js/AIRP/airp-cookiebot-events.js"></script>
        <%--<acr:GoogleAnalytics runat="server"></acr:GoogleAnalytics>--%>
        <%--<script>
          (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
          (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
          m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
          })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');
        
          ga('create', 'UA-6363462-6', 'auto');
          ga('send', 'pageview');
        
        </script>--%>
<!-- Google Tag Manager -->
<script>(function(w,d,s,l,i){w[l]=w[l]||[];w[l].push({'gtm.start':
new Date().getTime(),event:'gtm.js'});var f=d.getElementsByTagName(s)[0],
j=d.createElement(s),dl=l!='dataLayer'?'&l='+l:'';j.async=true;j.src=
'https://www.googletagmanager.com/gtm.js?id='+i+dl;f.parentNode.insertBefore(j,f);
})(window,document,'script','dataLayer','GTM-N6ZNR5V');</script>
<!-- End Google Tag Manager -->
 <!-- Crazy Egg Tracking Script Heatmap -->
 <%--<script type="text/javascript">setTimeout(function(){var a=document.createElement("script");var b=document.getElementsByTagName("script")[0];a.src=document.location.protocol+"//script.crazyegg.com/pages/scripts/0049/8406.js?"+Math.floor(new Date().getTime()/3600000);a.async=true;a.type="text/javascript";b.parentNode.insertBefore(a,b)}, 1);</script>
 <script id="Cookiebot" src="https://consent.cookiebot.com/uc.js" data-cbid="6046f478-bd77-4ea7-8f85-b635ac5af40a" type="text/javascript" async></script>--%>

</head>
	<body>
		<!-- Google Tag Manager (noscript) -->
<noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-N6ZNR5V"
height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
<!-- End Google Tag Manager (noscript) -->
		<div class="wrapper subPage cf">
			<sc:Placeholder runat="server" Key="Header" ID="plcHeader"/>
			
			<div class="content cf">
			<sc:Placeholder runat="server" Key="Banner" ID="plcBanner"/>
			<article>
			<sc:Placeholder runat="server" Key="Content" ID="plcContent"/>
			</article>
			<sc:Placeholder runat="server" Key="Sidebar" ID="plcSidebar"/>
			</div>
		</div><!-- End: wrapper -->
		<sc:Placeholder runat="server" Key="Footer" ID="plcFooter"/>
	</body>
</html>