<%@ Control Language="C#" AutoEventWireup="true" Inherits="ACR.layouts.ImageWisely.sltHonorRoll" Codebehind="sltHonorRoll.ascx.cs" %>
<%@ Import Namespace="ACR.layouts.ImageWisely" %>
<%@ Register TagPrefix="acr" TagName="pledgeFacilitiesList" Src="~/controls/ImageWisely/PledgeFacilitiesList.ascx" %>

<style type="text/css">
.style2
{
	width: 80px;
	background-color: White;
	color: Black;
	vertical-align: top;
}
.tdright
{
	font-weight: bold;
	font-size: medium;
	background-color: white;
}
.trstyle
{
	text-align: left;
	background-color: White;
}
</style>

<table>
	<tr>
		<td width="200px">
			See the Honor Roll for:
		</td>
		<td align="left">
			<asp:DropDownList ID="lstPledgeType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstPledgeType_SelectedIndexChanged">
				<asp:ListItem Text="-- Select --" Selected="True" />
				<asp:ListItem Text="Associations and Educational Programs" />
				<asp:ListItem Text="Facilities" />
			</asp:DropDownList>
		</td>
	</tr>
</table>
<table>
	<tr>
		<td>
			<asp:Panel ID="pnlAssociations" runat="server" Visible="false">
				<div id="div10" runat="server" style="width: 660px; position: relative;">
					<table>
						<tr>
							<td width="100%" runat="server" id="td7" style="font-weight: bold; font-size: medium;"
								align="center">
								<div id="div15" style="position: absolute; top: 0; left: 0; width: 25%; height: auto;
									text-decoration: underline;">
									Associations
								</div>
							</td>
						</tr>
					</table>
				</div>
				<div id="div5" runat="server" style="height: 900px; width: 660px; position: relative;
					overflow: auto; overflow-x: hidden">
					<table>
						<tr>
							<td width="25%" id="tdGrdAssociations">
								<div id="div-1a" style="position: absolute; top: 0; left: 0; width: 100%; height: auto;">
									<asp:GridView ID="grdPledgeHonorRollAssociation" runat="server" RowStyle-BackColor="White"
										AutoGenerateColumns="false" ShowHeader="false">
										<Columns>
											<asp:TemplateField ItemStyle-Font-Size="Small" ItemStyle-VerticalAlign="Top" ItemStyle-Width="100%"
												ItemStyle-BackColor="White" SortExpression="Institution">
												<ItemTemplate>
													<b>
														<asp:Label ID="lblAssociation" runat="server" Text='<%# (Eval("Institution").ToString().ToUpper()) %>' />
													</b>
													<br />
													<asp:Label ID="lblAssociationCity0" runat="server" Text='<%# (Eval("city").ToString().ToUpper()) %>' />,&nbsp;<asp:Label
														ID="lblAssociationState0" runat="server" Text='<%# (Eval("StateProvince").ToString().ToUpper()) %>' />
													&nbsp;&nbsp;
												</ItemTemplate>
											</asp:TemplateField>
										</Columns>
										<RowStyle BackColor="White" CssClass="" />
                                        
									</asp:GridView>
								</div>
							</td>
						</tr>
					</table>
				</div>
			</asp:Panel>
			<asp:Panel ID="pnlFacilities" runat="server" Visible="false" Style="">
				<div class="honorRoll cf">
					<table class="honorRollLegend" cellpadding="0" cellspacing="0" border="0">
						<tr>
							<td>
								These facilities participate in a dose index registry that includes routine evaluation of examination performance and dose indices. In addition, they have earned accreditation from an organization that evaluates the following radiation-related attributes:
							</td>
						</tr>
						<tr>
							<td>
								<ul>
									<li>
										Facility’s radiation dose indices and compliance with accreditation pass/fail thresholds
									</li>
									<li>
										Clinical and phantom image quality
									</li>
									<li>
										Facility personnel qualifications
									</li>
								</ul>
							</td>
						</tr>
						<tr>
							<td>
								<p>
									The facilities listed below have taken the pledge to Image Wisely.
								</p>
							</td>
						</tr>
					</table>
					<ul class="levelNav">
						<li class="active" runat="server" ID="liHonorRoll"></li>
						<li runat="server" id="liInternational"></li>
					</ul>

					<acr:pledgeFacilitiesList ID="pflHonorRoll" runat="server" />
					<acr:pledgeFacilitiesList ID="pflInternational" runat="server" />

<%--					<asp:Repeater ID="rptLevel1State" runat="server"  OnItemDataBound="rptLevel1State_ItemDataBound">
						<HeaderTemplate>
							<div class="listWrap level1 active">
								<h2><span>Level 1</span> &ndash; These associations and facilities have <span>pledged</span> to <span>IMAGE WISELY</span></h2>
						</HeaderTemplate>
						<ItemTemplate>
							<div class="listItem">
								<h3><asp:Literal ID="litState" runat="server" /></h3>
								<div class="inner">
									<asp:Repeater ID="rptLevel1Facility" runat="server"  OnItemDataBound="rptLevel1Facility_ItemDataBound">
										<HeaderTemplate>
											<table cellspacing="0" cellpadding="0" border="0">
										</HeaderTemplate>
										<ItemTemplate>
											<tr>
												<td>
													<p><asp:Literal ID="litFacilityName" runat="server" /></p>
													<p><asp:Literal ID="litFacilityLocation" runat="server" /></p>
												</td>
												<td>
													<p>Medical Center Enterprise</p>
													<p>Enterprise, AL</p>
												</td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
											</table>
										</FooterTemplate>
									</asp:Repeater>
								</div>
							</div>
						</ItemTemplate>
						<FooterTemplate>
							</div>
						</FooterTemplate>
					</asp:Repeater>

					<asp:Repeater ID="rptLevel2State" runat="server"  OnItemDataBound="rptLevel2State_ItemDataBound">
						<HeaderTemplate>
							<div class="listWrap level2">
								<h2><span>Level 2</span> &ndash; These associations and facilities have <span>pledged</span> to <span>IMAGE WISELY</span></h2>
						</HeaderTemplate>
						<ItemTemplate>
							<div class="listItem">
								<h3><asp:Literal ID="litState" runat="server" /></h3>
								<div class="inner">
									<asp:Repeater ID="rptLevel2Facility" runat="server"  OnItemDataBound="rptLevel2Facility_ItemDataBound">
										<HeaderTemplate>
											<table cellspacing="0" cellpadding="0" border="0">
										</HeaderTemplate>
										<ItemTemplate>
											<tr>
												<td>
													<p><asp:Literal ID="litFacilityName" runat="server" /></p>
													<p><asp:Literal ID="litFacilityLocation" runat="server" /></p>
												</td>
												<td>
													<p>Medical Center Enterprise</p>
													<p>Enterprise, AL</p>
												</td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
											</table>
										</FooterTemplate>
									</asp:Repeater>
								</div>
							</div>
						</ItemTemplate>
						<FooterTemplate>
							</div>
						</FooterTemplate>
					</asp:Repeater>

					<asp:Repeater ID="rptLevel3State" runat="server"  OnItemDataBound="rptLevel3State_ItemDataBound">
						<HeaderTemplate>
							<div class="listWrap level3">
								<h2><span>Level 3</span> &ndash; These associations and facilities have <span>pledged</span> to <span>IMAGE WISELY</span></h2>
						</HeaderTemplate>
						<ItemTemplate>
							<div class="listItem">
								<h3><asp:Literal ID="litState" runat="server" /></h3>
								<div class="inner">
									<asp:Repeater ID="rptLevel3Facility" runat="server"  OnItemDataBound="rptLevel3Facility_ItemDataBound">
										<HeaderTemplate>
											<table cellspacing="0" cellpadding="0" border="0">
										</HeaderTemplate>
										<ItemTemplate>
											<tr>
												<td>
													<p><asp:Literal ID="litFacilityName" runat="server" /></p>
													<p><asp:Literal ID="litFacilityLocation" runat="server" /></p>
												</td>
												<td>
													<p>Medical Center Enterprise</p>
													<p>Enterprise, AL</p>
												</td>
											</tr>
										</ItemTemplate>
										<FooterTemplate>
											</table>
										</FooterTemplate>
									</asp:Repeater>
								</div>
							</div>
						</ItemTemplate>
						<FooterTemplate>
							</div>
						</FooterTemplate>
					</asp:Repeater>--%>
				</div>
			</asp:Panel>
		</td>
	</tr>
</table>