<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccreditationMammographySection.ascx.cs" Inherits="ACRMicroSites.layouts.ACR.sublayouts.content.AccreditationMammographySection" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<div class="content">
    <section class="content content-wide lg-vert-line-25pct v-pad-b">
       
        <header class="header-v-pad uppercase text-c">
          <%--  <h2>For Patients</h2>--%>
            <h2>
            <sc:Text runat="server" ID="sectionTitle" /></h2>
        </header>
        <div class="row-nestled">
            <div class="md-col-12 lg-col-3">
                <div class="lg-max-column-220px spaced-item-area" style="margin-top:-7px;">
                    <div class="row-nestled spaced-item">
                        <div class="col-12 text-c">
                            <figure class="img-contain float-none sm-wide-6 md-wide-4 lg-wide-12 inline-block">
                                <sc:Link runat="server" ID="leftLogoLink">
                                    <sc:Image runat="server" ID="leftlogo" />
                                </sc:Link>
                                
                                <%--<img src="/media-library/RadiologyInfo_ForPatients.png" alt="RadiologyInfo.org for patients" />--%>
                            </figure>
                            <div class="spaced-item-spacer"> </div>
                        </div>
                        <div class="md-col-4 lg-col-12">
                            <figure class="img-contain feature-section-img">
                                <sc:Link runat="server" ID="leftImageLink">
                                   <sc:Image runat="server" ID="leftImage" />
                                    </sc:Link>
                              <%--  <img src="https://via.placeholder.com/400x300" alt="Ananya's profile picture" />--%>
                            </figure>
                        </div>
                        <div class="md-col-8 lg-col-12">

                            <p><sc:Text runat="server" ID="leftText" /></p>

                            <div class="has-arrow-link">
                                <sc:Link runat="server" ID="leftLink"></sc:Link>
                        <%--        <a href="#">Visit Radiologyinfo.org to see Ananya's story</a>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="spaced-item-spacer lg-up-hide"> </div>
            <div class="md-col-12 lg-col-6 lg-text-l text-c">

                <figure class="img-contain float-none sm-wide-6 lg-wide-9 inline-block">
                    <sc:Link runat="server" ID="centerLogoLink">
                        <sc:Image runat="server" ID="centerLogo" />
                    </sc:Link>
                               
                </figure>
                <div class="spaced-item-spacer"> </div>

                <div class="row-nestled text-l spaced-item-area lg-offset-16px">
                    <div class="md-col-6 spaced-item">
                        <div class="lg-max-column-220px">
                           <%-- <figure class="img-contain feature-section-img">
                              <sc:Image runat="server" ID="centerLeftImage" />
                            </figure>--%>
                            <div class="video-holder feature-section-img">
                                <asp:Literal runat="server" ID="centerLeftVideo"></asp:Literal>
                            </div>

                            <p>
                                <sc:Text runat="server" ID="centerLeftText" />
                            </p>
                            <div class="has-arrow-link">
                                <sc:Link runat="server" ID="centerLeftLink"></sc:Link>
                            </div>
                        </div>
                    </div>
                    <div class="md-col-6 spaced-item">
                           <div class="lg-max-column-220px">
                           <%-- <figure class="img-contain feature-section-img">
                              <sc:Image runat="server" ID="centerRightImage" />
                            </figure>--%>

                            <div class="video-holder feature-section-img">
                                <asp:Literal runat="server" ID="centerRightVideo"></asp:Literal>
                            </div>

                            <p>
                                <sc:Text runat="server" ID="centerRightText" />
                            </p>
                            <div class="has-arrow-link">
                                <sc:Link runat="server" ID="centerRightLink"></sc:Link>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-12 lg-col-3">

                <aside class="row-nestled">
                    <header class="col-12 md-col-4 lg-col-12">
                        <div class="icon-left-heading">
                            <img src="/images/accredd-mammo/Compass_icon.png" class="icon-left" alt="compass icon" />
                            <h3><sc:Text runat="server" ID="rightTitle" /></h3>
                        </div>
                        <p><sc:Text runat="server" ID="rightText" />.</p>
                    </header>
                    <div ID="stateCitySearch" runat="server" class="col-12 md-col-4 lg-col-12">
                        <div class="row-nestled">
                            <div class="center sm-col-6 md-col-12">

                                <label for="ddlFindBy">Find By</label>
                                <select id="ddlFindBy">
                                    <option value="mam-zip-city">ZIP/City</option>
                                    <option value="mam-state">State</option>
                                    <option value="mam-country">Country</option>
                                    <option value="mam-facility-name">Facility Name</option>

                                </select>

                               <%-- <label for="mam-state">State</label>
                                <select id="mam-state">
                                    <option value="0">--Select a State--</option>
                                   <option value="AL">Alabama</option><option value="AK">Alaska</option><option value="AS">American Samoa</option><option value="AZ">Arizona</option><option value="AR">Arkansas</option><option value="CA">California</option><option value="CO">Colorado</option><option value="CT">Connecticut</option><option value="DE">Delaware</option><option value="DC">District of Columbia</option><option value="AE">Europe (Military)</option><option value="FL">Florida</option><option value="GA">Georgia</option><option value="GU">Guam</option><option value="HI">Hawaii</option><option value="ID">Idaho</option><option value="IL">Illinois</option><option value="IN">Indiana</option><option value="IA">Iowa</option><option value="KS">Kansas</option><option value="KY">Kentucky</option><option value="LA">Louisiana</option><option value="ME">Maine</option><option value="MD">Maryland</option><option value="MA">Massachusetts</option><option value="MI">Michigan</option><option value="MN">Minnesota</option><option value="MS">Mississippi</option><option value="MO">Missouri</option><option value="MT">Montana</option><option value="NE">Nebraska</option><option value="NV">Nevada</option><option value="NH">New Hampshire</option><option value="NJ">New Jersey</option><option value="NM">New Mexico</option><option value="NY">New York</option><option value="NC">North Carolina</option><option value="ND">North Dakota</option><option value="MP">Northern Mariana Islands</option><option value="OH">Ohio</option><option value="OK">Oklahoma</option><option value="OR">Oregon</option><option value="AP">Pacific (Military)</option><option value="PA">Pennsylvania</option><option value="PR">Puerto Rico</option><option value="RI">Rhode Island</option><option value="SC">South Carolina</option><option value="SD">South Dakota</option><option value="TN">Tennessee</option><option value="TX">Texas</option><option value="UT">Utah</option><option value="VI">Virgin Islands</option><option value="VA">Virginia</option><option value="VT">Vermont</option><option value="WA">Washington</option><option value="WV">West Virginia</option><option value="WI">Wisconsin</option><option value="WY">Wyoming</option>
                                </select>--%>

                                <label class="ddlFindByOption" for="mam-zip-city">City/ZIP</label>
                                <input class="ddlFindByOption" type="text" id="mam-zip-city" />

                                 <label class="ddlFindByOption" for="mam-state">State</label>
                                <select class="ddlFindByOption" id="mam-state" style="line-height:normal"><option value="AL">Alabama</option><option value="AK">Alaska</option><option value="AS">American Samoa</option><option value="AZ">Arizona</option><option value="AR">Arkansas</option><option value="CA">California</option><option value="CO">Colorado</option><option value="CT">Connecticut</option><option value="DE">Delaware</option><option value="DC">District of Columbia</option><option value="AE">Europe (Military)</option><option value="FL">Florida</option><option value="GA">Georgia</option><option value="GU">Guam</option><option value="HI">Hawaii</option><option value="ID">Idaho</option><option value="IL">Illinois</option><option value="IN">Indiana</option><option value="IA">Iowa</option><option value="KS">Kansas</option><option value="KY">Kentucky</option><option value="LA">Louisiana</option><option value="ME">Maine</option><option value="MD">Maryland</option><option value="MA">Massachusetts</option><option value="MI">Michigan</option><option value="MN">Minnesota</option><option value="MS">Mississippi</option><option value="MO">Missouri</option><option value="MT">Montana</option><option value="NE">Nebraska</option><option value="NV">Nevada</option><option value="NH">New Hampshire</option><option value="NJ">New Jersey</option><option value="NM">New Mexico</option><option value="NY">New York</option><option value="NC">North Carolina</option><option value="ND">North Dakota</option><option value="MP">Northern Mariana Islands</option><option value="OH">Ohio</option><option value="OK">Oklahoma</option><option value="OR">Oregon</option><option value="AP">Pacific (Military)</option><option value="PA">Pennsylvania</option><option value="PR">Puerto Rico</option><option value="RI">Rhode Island</option><option value="SC">South Carolina</option><option value="SD">South Dakota</option><option value="TN">Tennessee</option><option value="TX">Texas</option><option value="UT">Utah</option><option value="VI">Virgin Islands</option><option value="VA">Virginia</option><option value="VT">Vermont</option><option value="WA">Washington</option><option value="WV">West Virginia</option><option value="WI">Wisconsin</option><option value="WY">Wyoming</option> </select>

                                <label class="ddlFindByOption" for="mam-country">Country</label>
                                <select class="ddlFindByOption" id="mam-country" style="line-height:normal" ><option value="Bermuda">Bermuda</option><option value="Brazil">Brazil</option><option value="Canada">Canada</option><option value="Chile">Chile</option><option value="China">China</option><option value="Colombia">Colombia</option><option value="Cuba">Cuba</option><option value="Egypt">Egypt</option><option value="Germany">Germany</option><option value="India">India</option><option value="Italy">Italy</option><option value="Japan">Japan</option><option value="Kuwait">Kuwait</option><option value="Lebanon">Lebanon</option><option value="Marshall Islands">Marshall Islands</option><option value="Palau">Palau</option><option value="Panama">Panama</option><option value="Philippines">Philippines</option><option value="Poland">Poland</option><option value="Qatar">Qatar</option><option value="Saudi Arabia">Saudi Arabia</option><option value="South Africa">South Africa</option><option value="South Korea">South Korea</option><option value="Spain">Spain</option><option value="The Republic of Georgia">The Republic of Georgia</option><option value="Turkey">Turkey</option><option value="United Arab Emirates">United Arab Emirates</option><option value="United Kingdom">United Kingdom</option> </select>

                                <label class="ddlFindByOption" for="mam-facility-name">Facility Name</label>
                                <input class="ddlFindByOption" type="text" id="mam-facility-name" />

                                <div class="text-c pad-t-12">
                                    <button id="mammoSearchBtn" class="button">Search</button>
                                </div>
                            </div>
                        </div>



                    </div>
                    <div class="col-12 md-col-4 lg-col-12" style="padding-top:3em">
                        <div class="icon-left-heading">
                            <img src="/images/accredd-mammo/downloadicon.png" class="icon-left" alt="download icon" />
                            <h3><sc:Text runat="server" ID="bottomTitle" /></h3>
                        </div>
                        <p><sc:Text runat="server" ID="bottomText" /></p>
                    </div>
                </aside>
            </div>
        </div>
    </section>
</div>

