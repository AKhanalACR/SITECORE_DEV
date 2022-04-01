<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="sltCalendar.ascx.cs" Inherits="ACR.layouts.RLI.sltCalendar" %>
<%@ Register TagPrefix="rli" TagName="CalendarView" Src="~/controls/RLI/CalendarView.ascx" %>
<%@ Register TagPrefix="rli" TagName="CalendarListView" Src="~/controls/RLI/CalendarListView.ascx" %>

<asp:HiddenField runat="server" ID="hdnFilterOptionId" ClientIDMode="Static"/>
<div class="tabbed">
	<!-- The current tab and current item are controlled by the 'selected' class -->
	<div class="tabs">
		<asp:HyperLink ID="hlCalendar" runat="server" CssClass="selected">Calendar View</asp:HyperLink>
		<asp:HyperLink ID="hlList" runat="server">List View</asp:HyperLink>
	</div>
	<rli:CalendarView runat="server"/>
	<rli:CalendarListView runat="server" />
</div>
<script>
    $('.tabbed .tabs a').each(function () {
        if ($(this).attr("ID").indexOf("hlList") != -1 && location.search.indexOf('tab=ListView') != -1) {
            ($(this).addClass('selected'));
            var selectedIndex = $(this).index() + 1;
            $('.tabbed section:nth-of-type(' + $(this).index() + ')').removeClass('selected');
            $('.tabbed section:nth-of-type(' + selectedIndex + ')').addClass('selected');
            return;
        }
        if ($(this).attr('class') == 'selected' && location.search.indexOf('tab=ListView') != -1) {
            $(this).removeClass('selected');

        }
    }) 
</script>