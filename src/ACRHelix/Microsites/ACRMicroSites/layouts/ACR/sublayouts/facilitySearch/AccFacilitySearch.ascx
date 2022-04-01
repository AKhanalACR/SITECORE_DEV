<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AccFacilitySearch.ascx.cs" Inherits="ACR.layouts.ACR.sublayouts.facilitySearch.AccFacilitySearch" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<style type="text/css">
    .facility-search { margin-bottom:1.2em !important;}
    .acc-dwn-lk { margin-bottom:.5em; }
    .acc-img { height: 80px; width: auto; }
    .acc-main-cont { margin-top:1.2em; }
    #ajaxSpinnerContainer {
        display: inline;
	margin-left:0.65em;
        /*display: none;
        position: fixed;
        right: 0px;
        top: 0px;
        width: 100%;
        height: 100%; */
        z-index: 101;
    }
    #ajaxSpinnerImage{
        /*position: absolute;
        top: 50%;
        left: 45%;*/
    }
    .labels {
     color: white;
     background-color: red;
     font-family: "Lucida Grande", "Arial", sans-serif;
     font-size: 8px;
     text-align: center;
     width: 100px;     
     white-space: nowrap;
   }
   #btnFind {
       display: inline;
   }
   .facility-search select{
       margin-top:0;
       border-radius: .3125em;
       border: solid 1px #A9A9A9;
       padding-left: 5px;
       height: 1.875em;
   }
   .facility-search input[type=text]{
       border-radius: .3125em;
       border: solid 1px #A9A9A9;
       padding-left: 5px;
       height: 1.875em;
   }

   .loader-outer {
    position: absolute;
    top: 0;
    left: 0;
    right: 0;
    bottom: 0;
    background: rgba(255,255,255,.5);
    -webkit-transition: 80ms opacity ease-out;
    transition: 80ms opacity ease-out
}

.lds-roller {
    display: inline-block;
    position: relative;
    width: 64px;
    height: 64px;
    position: absolute;
    top: 590px;
    left: 50%;
    margin-left: -64px
}

.lds-roller div {
    -webkit-animation: lds-roller 1.2s cubic-bezier(.5,0,.5,1) infinite;
    animation: lds-roller 1.2s cubic-bezier(.5,0,.5,1) infinite;
    -webkit-transform-origin: 32px 32px;
    -ms-transform-origin: 32px 32px;
    transform-origin: 32px 32px
}

.lds-roller div:after {
    content: " ";
    display: block;
    position: absolute;
    width: 6px;
    height: 6px;
    border-radius: 50%;
    background: #3c8bfd;
    margin: -3px 0 0 -3px
}

.lds-roller div:nth-child(1) {
    -webkit-animation-delay: -36ms;
    animation-delay: -36ms
}

.lds-roller div:nth-child(1):after {
    top: 50px;
    left: 50px
}

.lds-roller div:nth-child(2) {
    -webkit-animation-delay: -72ms;
    animation-delay: -72ms
}

.lds-roller div:nth-child(2):after {
    top: 54px;
    left: 45px
}

.lds-roller div:nth-child(3) {
    -webkit-animation-delay: -108ms;
    animation-delay: -108ms
}

.lds-roller div:nth-child(3):after {
    top: 57px;
    left: 39px
}

.lds-roller div:nth-child(4) {
    -webkit-animation-delay: -144ms;
    animation-delay: -144ms
}

.lds-roller div:nth-child(4):after {
    top: 58px;
    left: 32px
}

.lds-roller div:nth-child(5) {
    -webkit-animation-delay: -.18s;
    animation-delay: -.18s
}

.lds-roller div:nth-child(5):after {
    top: 57px;
    left: 25px
}

.lds-roller div:nth-child(6) {
    -webkit-animation-delay: -216ms;
    animation-delay: -216ms
}

.lds-roller div:nth-child(6):after {
    top: 54px;
    left: 19px
}

.lds-roller div:nth-child(7) {
    -webkit-animation-delay: -252ms;
    animation-delay: -252ms
}

.lds-roller div:nth-child(7):after {
    top: 50px;
    left: 14px
}

.lds-roller div:nth-child(8) {
    -webkit-animation-delay: -288ms;
    animation-delay: -288ms
}

.lds-roller div:nth-child(8):after {
    top: 45px;
    left: 10px
}

@-webkit-keyframes lds-roller {
    0% {
        -webkit-transform: rotate(0);
        transform: rotate(0)
    }

    100% {
        -webkit-transform: rotate(360deg);
        transform: rotate(360deg)
    }
}

@keyframes lds-roller {
    0% {
        -webkit-transform: rotate(0);
        transform: rotate(0)
    }

    100% {
        -webkit-transform: rotate(360deg);
        transform: rotate(360deg)
    }
}
   
</style>

<div class="content row facility-search acc-main-cont">
    
    <div class="col-third mobile-col-half ipad-col-third">
        <label for="ddlFindBy">Find by:</label>
        <select id="ddlFindBy" data-bind="options: findBy, optionsText: 'txt', optionsValue: 'val', value: selectedFindBy, event: { change: function (data) { $root.getFindBySelection(); } }, clickBubble: false"> </select>
    </div>

    <div class="col-third mobile-col-half ipad-col-third">
        <label for="txtZipCity" data-bind="text: lblChoice" ></label>
        <input id="txtZipCity" type="text" data-bind="visible: txtZipCntr, textInput: nearZipCity, style: { fontSize: 'inherit' }" />
        <span id="lblZipCity" data-bind="text: validationMessage, visible: zipCityValidation, style: { color: 'red', fontSize: '10pt' }" style="display:none"></span>
        <select id="ddlChooseState" data-bind="visible: ddlStateCntr, options: stateChoice, optionsText: 'txt', optionsValue: 'val', value: selectedState" style="display:none"> </select>
        <select id="ddlChooseCountry" data-bind="visible: ddlCountryCntr, options: countryChoice, optionsText: 'txt', optionsValue: 'val', value: selectedCountry" style="display:none"> </select>
    </div>
    <div class="col-third mobile-col-half ipad-col-third">
        <label for="ddlChooseMile">Within: </label><br />
        <select id="ddlChooseMile" data-bind="enable: ddlMileCntr, options: radInMile, optionsText: 'txt', optionsValue: 'val', value: selectedRadInMile"> </select>
    </div>
    <div class="col-third mobile-col-half ipad-col-third">
        <label for="ddlChooseMod">Modality:  </label>
        <select id="ddlChooseMod" data-bind="options: modChoice, optionsText: 'txt', optionsValue: 'val', value: selectedModChoice"> </select>
    </div>
    <div class="col-third mobile-col-half ipad-col-third">
        <label for="ddlChooseDesig">Designation:  </label>
        <select id="ddlChooseDesig" data-bind="options: desigChoice, optionsText: 'txt', optionsValue: 'val', value: selectedDesigChoice"> </select>
    </div>
    <div class="col-third mobile-col-half ipad-col-third">
        <div class="label-space">&nbsp;</div>
        <button id="btnFind" type="button" class="button" data-bind="click: function (data) { valdiateAndSearch(); return false; }, clickBubble: false, style: { fontSize: 'inherit' }" value="Search" >Search</button>
        <div id="ajaxSpinnerContainer">
             <img id="ajaxSpinnerImage" src="../../../../images/ajax-loader .gif" title="loading...">  
        </div>
     </div>
    
</div>

<div id="didYouMean" class="content" data-bind="visible: didYouMeanCntr" >
    <strong>Did you mean...</strong>
    <ol data-bind="foreach: didYouMeanResults">
        <li >
            <span data-bind="text: name"> </span>
            <a href="#" data-bind="click: function (data) { $root.didYouMeanSelection(name); }, clickBubble: false">Select</a>
        </li>
    </ol>
</div>

<div class="not-on-mobile content acc-dwn-lk">
        <a href="https://accreditationfacilitylist.acr.org" ><span class='txt-blue'><br>Download a list of all ACR-accredited facilities</span></a>
       <br /> <br />
	<p>This list covers all modalities and includes facilities whose applications for accreditation are still under review. It provides patients, providers and third-party payers with information critical to selecting appropriate facilities for imaging needs. It is not intended as nor should this list be used for marketing or research purposes.</p>
</div>

  <div class="loader-outer" id="loader-open" style="display:none">
            <div class="lds-roller">
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
                <div></div>
            </div>
        </div>

<div id="map_canvas" class="content facility-map acc-dwn-lk">
	
</div>

<div id="zeroResult" class="facility-results content" data-bind="visible: zeroResultCntr" >
    <br />
    <p>There are no facilities within or near <span data-bind="text: zeroResultMessage"></span>. Please try again ... </p>
</div>

<div class="facility-results acc-dwn-lk" data-bind="visible: showResultCntr" > 
    <div class="content row">
		<div class="col-half inline-block facility-tabs">
			<a href="#" class="tab-current-facilities"> <strong data-bind="text: accCount"></strong> Accredited facilities</a>
			<a href="#" class="tab-facilites-in-process"> <strong data-bind="text: unAccCount"></strong> Facilities in process</a>
		</div>
	</div>
    <div class="current-facilities results" data-bind="foreach: searchResult" >
        <div class="row" data-bind="style: $index() % 2 === 0 ? { background: '#ECEBF9' } : { background: 'inherit' }">
           <div class="content">
                <div class="col-fourth mobile-col-half ipad-col-third" >
                    <h4 data-bind="text: order + ') ' + name "></h4>
                    <!-- ko if: expirationflag -->
		                <p><strong>Expiration: </strong> <span data-bind="text: expiration"> </span></p>
                    <!-- /ko -->
                </div>
                <div class="col-fourth r-address mobile-col-half ipad-col-third" >
                    <span data-bind="text: address1" ></span> <br />
                    <span data-bind="text: address2" ></span> <br />
                    <a href="#" data-bind="click: function () { $root.viewMapScroll(); }" >View Map</a> | <a href="#" data-bind="    click: function () { $root.calculateAndDisplayRoute(destination); }, clickBubble: false">Get Directions</a> <br />
                    <span data-bind="text: phone" ></span>		
			    </div>
                <div class="col-half icons-holder ipad-col-third not-on-mobile" >
                    <!-- ko if: bicoeFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/accfac_bicoe_small.gif" alt="BICOE" />
                    <!-- /ko -->
		            <!-- ko if: dicoeFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/DICOE_logo.png" alt="DICOE" />
                    <!-- /ko -->
                    <!-- ko if: lcsdFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/Lung_Cancer_seal_small2.jpg" alt="LCSD" />
                    <!-- /ko -->
                    
                    <!-- ko if: imgGentlyFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/accfac_Image_Gently.gif" alt="Image Gently" />
                    <!-- /ko -->
                </div>
            </div>
           <div class="content">
                <div class="col-full" style="padding-top:5px">
                    <!-- ko if: moduleflag -->
                        <p><strong>Module: </strong> <span data-bind="text: module"> </span></p>
                    <!-- /ko -->
                    <!-- ko if: modalitiesflag -->
                        <p><strong><span data-bind="text: modlabel"> </span> </strong> <span data-bind="    text: modalities"> </span></p>
                    <!-- /ko -->
                </div>
            </div>
        </div>
    </div>
    <div class="facilites-in-process results" style="display:none;" data-bind="foreach: unAccSearchResult" >
        <div class="row" data-bind="style: $index() % 2 === 0 ? { background: '#D7E2E4' } : { background: 'inherit' }" >
            <div class="content">
                <div class="col-fourth mobile-col-half ipad-col-third" >
                    <h4 data-bind="text: order + ') ' + name"></h4>
                    <!-- ko if: expirationflag -->
				        <p><strong>Expiration: </strong><span data-bind="text: expiration"> </span></p>
                    <!-- /ko -->
                </div>
                <div class="col-fourth r-address mobile-col-half ipad-col-third" >
                    <span data-bind="text: address1" ></span> <br />
                    <span data-bind="text: address2" ></span> <br />
                    <a href="#" data-bind="click: function () { $root.viewMapScroll(); }" >View Map</a> | <a href="#" data-bind="    click: function () { $root.calculateAndDisplayRoute(destination); }, clickBubble: false">Get Directions</a> <br />
                    <span data-bind="text: phone" ></span>		
			    </div>
                <div class="col-half icons-holder ipad-col-third not-on-mobile" >
                    <!-- ko if: bicoeFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/accfac_bicoe_small.gif" alt="BICOE" />
                    <!-- /ko -->
		            <!-- ko if: dicoeFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/DICOE_logo.png" alt="DICOE" />
                    <!-- /ko -->
                    <!-- ko if: lcsdFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/Lung_Cancer_seal_small2.jpg" alt="LCSD" />
                    <!-- /ko -->
		            <!-- ko if: imgGentlyFlage -->
                       <img class="acc-img" src="/~/media/Images/Accredited-Facility-Seals/accfac_Image_Gently.gif" alt="Image Gently" />
                    <!-- /ko -->
                </div>
            </div>
            <div class="content">
                <div class="col-full" style="padding-top:5px">
                    <!-- ko if: moduleflag -->
                        <p><strong>Module: </strong> <span data-bind="text: module"> </span></p>
                    <!-- /ko -->
                    <!-- ko if: modalitiesflag -->
                        <p><strong ><span data-bind="text: modlabel"> </span></strong> <span data-bind="    text: modalities"> </span></p>
                    <!-- /ko -->
                </div>
            </div>
        </div>
    </div>
</div>


<%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
<script>window.jQuery || document.write('<script src="/js/jquery-1.10.2.min.js"><\/script>')</script>--%>
<script type="text/javascript" src="/js/jquery-1.10.2.min.js"></script>
<script>jQuery.noConflict();</script>
<script type="text/javascript" src="/js/knockout-3.3.0.js"></script>
<script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB5a_4LhytzwYPShrITESVWV9IQER8xGco"></script>
<script src="/js/URI.js"></script>
<script src="/js/Accreditation/facilty-search.js"></script>
