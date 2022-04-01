<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccreditedFacilitySearch.ascx.cs" Inherits="ACR.controls.MammographySavesLives.AccreditedFacilitySearch" %>

<asp:Panel ID="pnlFacSearch" CssClass="facilitySearchForm" Visible="true" runat="Server" DefaultButton="btnSubmit">
	<h2>Search Criteria:</h2>
  <table class="facDirSrchForm" cellpadding="0" cellspacing="0">
	  <tr>
			<td>
	      <div class="srchfld facDirFormLocal">
		      <label>Locality</label><br />
		      <asp:DropDownList ID="ACRLocality" runat="server" DataTextField="Text" DataValueField="Value" AutoPostBack="false" >
		      </asp:DropDownList>
	      </div>
      </td> 
			<td>
	      <div class="srchfld facDirFormCity">
		      <label>City</label><br />
		      <asp:TextBox ID="ACRCity"  runat="server" AutoPostBack="false" />
	      </div>
      </td>
    </tr>
	  <tr>
      <td>
	      <div class="srchfld facDirFormZip">
		      <label>Zip/Postal Code (you can search by partial zip code)</label><br />
		      <asp:TextBox ID="ACRZipCode"  runat="server" AutoPostBack="false" />
	      </div>
      </td>
			<td>
	      <div class="facDirFormSubmit">
				<asp:ImageButton ID="btnSubmit" runat="server" Text="Search" OnClick="btnSubmit_Click" ImageUrl="/images/mammographysaveslives/findCenter_btn.png" />
	      </div>
      </td>
    </tr>
  </table>
</asp:Panel>

<asp:Panel ID="pnlFacResults" runat="Server" CssClass="facResults">
	<p style="margin-top: 40px;"><strong>Accredited facilities found</strong> (<asp:Literal ID="ltlCount1" runat="server" />)</p>
	<asp:Repeater ID="rptAccrFacilities" runat="server"  onitemdatabound="rptFacilities_ItemDataBound" >
			<HeaderTemplate>
				<table class="facility-results">
				<thead>
					<tr>
						<th colspan="4">Facility</th>
						<th>Expiration</th>
					</tr>
				</thead>
				<tbody>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
				<td>
					<div class="facility-info">
						<span class="facility-name"><asp:Literal ID="ltlFacName" runat="server" /></span>
						<span class="facility-address"><asp:Literal ID="ltlFacAddr" runat="server" /></span>
						<span class="facility-address2"><asp:Literal ID="ltlFacAddr2" runat="server" /></span>
						<span class="facility-citystzip"><asp:Literal ID="ltlFacCityStZip" runat="server" /></span>
						<span class="facility-phone"><asp:Literal ID="ltlFacPhone" runat="server" /></span>
						<asp:Repeater ID="rptModules" runat="server" onitemdatabound="rptModules_ItemDataBound">
							<HeaderTemplate>
								<span class="facility-modules"><ul>
							</HeaderTemplate>
							<ItemTemplate>
								<li><asp:Literal ID="litModule" runat="server" /></li>
							</ItemTemplate>
							<FooterTemplate>
								</ul></span>
							</FooterTemplate>
						</asp:Repeater>
						</div>
				</td>
				<%--<td class="img"><asp:Literal ID="ltlImageCell" runat="server" /></td>--%>
                              <td class="img"><asp:Literal ID="ltlDicoe" runat="server" /></td>
                <td class="img"><asp:Literal ID="ltlCtLung" runat="server" /></td>                
                
                 <td class="img"><asp:Literal ID="ltlImgGently" runat="server" />
              <asp:Literal ID="ltlBicoe" runat="server" /></td>
				<td><asp:Literal ID="ltlExpDate" runat="server" /></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</tbody>
				</table>
			</FooterTemplate>
	</asp:Repeater>

	<p><strong>Facilities under review</strong> (<asp:Literal ID="ltlCount2" runat="server" />)</p>
	<asp:Repeater ID="rptUnderReview" runat="server"  onitemdatabound="rptFacilities_ItemDataBound" >
			<HeaderTemplate>
				<table class="facility-results">
				<thead>
					<tr>
						<th colspan="4">Facility</th>
						<th>Expiration</th>
					</tr>
				</thead>
				<tbody>
			</HeaderTemplate>
			<ItemTemplate>
				<tr>
				<td>
					<div class="facility-info">
						<span class="facility-name"><asp:Literal ID="ltlFacName" runat="server" /></span>
						<span class="facility-address"><asp:Literal ID="ltlFacAddr" runat="server" /></span>
						<span class="facility-citystzip"><asp:Literal ID="ltlFacCityStZip" runat="server" /></span>
						<span class="facility-phone"><asp:Literal ID="ltlFacPhone" runat="server" /></span>
						<asp:Repeater ID="rptModules" runat="server" onitemdatabound="rptModules_ItemDataBound">
							<HeaderTemplate>
								<span class="facility-modules"><ul>
							</HeaderTemplate>
							<ItemTemplate>
								<li><asp:Literal ID="litModule" runat="server" /></li>
							</ItemTemplate>
							<FooterTemplate>
								</ul></span>
							</FooterTemplate>
						</asp:Repeater>
						</div>
				</td>
				<%--<td class="img">
					<asp:Literal ID="ltlImageCell" runat="server" />
				</td>--%>

                                <td class="img"><asp:Literal ID="ltlDicoe" runat="server" /></td>
                <td class="img"><asp:Literal ID="ltlCtLung" runat="server" /></td>                
                
                 <td class="img"><asp:Literal ID="ltlImgGently" runat="server" />
              <asp:Literal ID="ltlBicoe" runat="server" /></td>
				<td><asp:Literal ID="ltlExpDate" runat="server" /></td>
				</tr>
			</ItemTemplate>
			<FooterTemplate>
				</tbody>
				</table>
			</FooterTemplate>
	</asp:Repeater>
</asp:Panel>
<div class="body-content">
	<asp:Literal runat="server" ID="litAdditionalInformation" />
</div>
