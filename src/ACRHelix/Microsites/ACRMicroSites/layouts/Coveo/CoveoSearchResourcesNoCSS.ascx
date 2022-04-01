<%@ Control Language="c#" AutoEventWireup="true" Inherits="Coveo.UI.CoveoSearchResources" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="coveoui" Namespace="Coveo.UI.Controls" Assembly="Coveo.UIBase" %>

<!-- When customizing this component, ensure to use "Coveo.$" instead of the regular jQuery "$" to
     avoid any conflicts with Sitecore's Page Editor/Experience Editor.  -->

<coveoui:ErrorSummary runat="server" />
<coveoui:WhenConfigured runat="server">
    <%--
    CSS has been moved to rli-main.css
  <link rel="stylesheet" href="/Coveo/css/CoveoFullSearchNewDesign.css" />
    --%>

    <link rel="stylesheet" href="/Coveo/css/CoveoComponent.css" />
    <script type="text/javascript" src="/Coveo/js/CoveoJsSearch.WithDependencies.min.js"></script>
    <% if (IsInSitecore80ExperienceEditor())
        { %>
    <script>
        jQuery.noConflict();
    </script>
    <% } %>
    <script type="text/javascript" src="/Coveo/js/CoveoForSitecorePolyfills.js"></script>
    <script type="text/javascript" src="/Coveo/js/CoveoForSitecore.min.js"></script>

    <% if (SitecoreContext.IsEditingInPageEditor())
        { %>
    <script type="text/javascript" src="/Coveo/js/PageEditorDeferRefresh.js"></script>
    <% } %>

    <asp:PlaceHolder ID="PHPageEditor" runat="server">
        <div>Coveo Search Resources</div>
    </asp:PlaceHolder>
</coveoui:WhenConfigured>