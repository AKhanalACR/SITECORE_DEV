<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccreditationMammographyVideos.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccreditationMammographyVideos" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="bg-blue-swirl-wide">
    <section class="content v-pad-b">
        <header class="header-v-pad">
            <h2 class="uppercase">
                <sc:Text runat="server" ID="sectionTitle" />
            </h2> 
            <div style="margin-top: 15px;">
               <sc:Text runat="server" ID="sectionSubTitle" />
            </div>      
        </header>        
        <div class="row-nestled spaced-item-area horizontal-pad-outer">
            <div class="horizontal-pad-holder">
                <div class="md-col-6 lg-col-3 spaced-item horizontal-pad">
                    <div class="video-holder feature-section-img">
                        <asp:Literal runat="server" ID="youtubeOne"></asp:Literal>
                    </div>
                    <p>
                        <sc:Text runat="server" ID="youtubeText1" />
                    </p>
                    <sc:Link runat="server" ID="link1" />
                </div>

                <div class="md-col-6 lg-col-3 spaced-item horizontal-pad">
                    <div class="video-holder feature-section-img">
                        <asp:Literal runat="server" ID="youtubeTwo"></asp:Literal>
                    </div>
                    <p>
                        <sc:Text runat="server" ID="youtubeText2" />
                    </p>
                    <sc:Link runat="server" ID="link2" />
                </div>

                <div class="md-col-6 lg-col-3 spaced-item horizontal-pad">
                    <div class="video-holder feature-section-img">
                        <asp:Literal runat="server" ID="youtubeThree"></asp:Literal>
                    </div>
                    <p>
                        <sc:Text runat="server" ID="youtubeText3" />
                    </p>
                    <sc:Link runat="server" ID="link3" />
                </div>

                <div class="md-col-6 lg-col-3 spaced-item horizontal-pad">
                    <div class="video-holder feature-section-img">
                        <asp:Literal runat="server" ID="youtubeFour"></asp:Literal>
                    </div>
                    <p>
                        <sc:Text runat="server" ID="youtubeText4" />
                    </p>
                    <sc:Link runat="server" ID="link4" />
                </div>
            </div>
        </div>
    </section>
</div>
