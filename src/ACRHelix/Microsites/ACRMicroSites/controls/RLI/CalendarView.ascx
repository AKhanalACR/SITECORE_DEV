<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CalendarView.ascx.cs" Inherits="ACR.controls.RLI.CalendarView" %>
<script src="/js/RLI/underscore.min.js"></script>

<section class="calendar cf selected">
	<fieldset class="calendarFilter cf">
		<label>Filter By:</label>
		<asp:DropDownList runat="server" id="ddEventTags" cssclass="fltrEvtTag" ClientIDMode="Static" />
		<span id="chgFilters" class="button red event-filter">Go &raquo;</span>
	</fieldset>

	<div class="calendar">
		<div class="custom-calendar-wrap">
			<div id="custom-inner" class="custom-inner">
				<div class="custom-header clearfix">
					<nav>
						<span id="custom-prev" class="custom-prev"></span>
						<span id="custom-next" class="custom-next"></span>
					</nav>
					<h2  class="custom-month"><span id="custom-month"></span> <span id="custom-year" ></span></h2>
				</div>
				<div id="calendar" class="fc-calendar-container"></div>
			</div>
			<div id="calpop"></div>
		</div>
	</div>

</section>