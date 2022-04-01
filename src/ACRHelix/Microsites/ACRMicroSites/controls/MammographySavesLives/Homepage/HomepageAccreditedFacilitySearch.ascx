<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HomepageAccreditedFacilitySearch.ascx.cs" Inherits="ACR.controls.MammographySavesLives.HomepageAccreditedFacilitySearch" %>

<div class="home-section-secondary">
	<div class="text-box accredited-facility-search">
		<p class="text-box-title">
			<span class="callout-image"><sc:fieldrenderer id="fldCalloutImage" runat="server" FieldName="Module Image" /></span>
			<asp:Literal ID="litModuleTitle" runat="server" />
		</p>
		<asp:Literal ID="litModuleText" runat="server" />
		<div class="facDirSrchForm srch-home">
                <div class="srchfld-home">
                    <label>
                        State/Locality</label><br />
                    <asp:DropDownList ID="ACRLocality" runat="server" DataTextField="Text" DataValueField="Value" AutoPostBack="false" >
                    </asp:DropDownList>
                </div>
                <div class="srchfld-home city">
                    <label>
                        City</label><br />
                    <asp:TextBox ID="txtCity" runat="server" AutoPostBack="false" Width="275" />
                </div>
                <div class="srchfld-home zip">
                    <label>
                        Zip code (you can search by partial zip code)</label><br />
                    <asp:TextBox ID="txtZip" runat="server" AutoPostBack="false" MaxLength="15" Width="175"  />
                </div>
                <div class="srchfld-home-submit">
                    <asp:ImageButton ID="ImageButton1" runat="server" Text="Search" CssClass="link-attention" OnClick="btnSearch_Click"
                        ImageUrl="/images/mammographysaveslives/findCenter_btn.png" />
                </div>
    </div>
	</div>
</div>