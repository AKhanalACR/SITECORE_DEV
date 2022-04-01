<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Carousel.ascx.cs" Inherits="ACR.controls.MammographySavesLives.Carousel" %>


    <div class="home-section-primary fact-box">
            <p class="fact-box-logo"><img src="/images/MammographySavesLives/start-logo.png" alt="Start @ 40"/></p>
            
            <asp:Repeater ID="rptCarousel" runat="server">
				<HeaderTemplate>
					<div class="rotator">
						<div class="rotator-pager"></div>
						<div class="rotator-items">
				</HeaderTemplate>
				<ItemTemplate>
					<div class="rotator-item">
						<p class="rotator-image"><sc:fieldrenderer id="slideImage" runat="server" width="72" FieldName="Promo Image" /></p>
						<p class="rotator-text"><sc:fieldrenderer id="slideText" runat="server" FieldName="Promo Teaser" /></p>
					</div>
				</ItemTemplate>
				<FooterTemplate>
						</div>
					</div>
				</FooterTemplate>
            </asp:Repeater>
            
            <div class="fact-button">
                    <a href="Facts.aspx"><img src="/images/MammographySavesLives/btn-learn-more.png" /> </a>
            </div>
            
            <div class="fact-button">
                    <a href="Facts/Guidelines.aspx"><img src="/images/MammographySavesLives/btn-confused.png" /> </a>
            </div>
            
    </div>
