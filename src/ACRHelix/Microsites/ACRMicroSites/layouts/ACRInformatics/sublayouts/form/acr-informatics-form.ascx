<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="acr-informatics-form.ascx.cs" Inherits="ACR.layouts.ACRInformatics.sublayouts.form.acr_informatics_form" %>
<%@ Register TagPrefix="sc" Namespace="Sitecore.Web.UI.WebControls" Assembly="Sitecore.Kernel" %>

<link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
<style>
    .validationMessage {
        color: #f00;
    }
</style>
<div class="content row facility-search acc-main-cont">

    <!-- ko if: suc -->
        <div class="content txt-align-center" data-bind="style: { fontSize: 'inherit', padding: '.5em' }" >
            <div data-bind="style: { fontSize: 'inherit'}">Your request has been successfully submitted.</div> <br />
            <button id="btnPrevious" type="button" class="button" data-bind="click: function (data) { location.reload(); }, style: { fontSize: 'inherit' }" >Refresh</button>
        </div>
    <!-- /ko -->
    <!-- ko if: err -->
        <div class="content txt-align-center" data-bind="style: { fontSize: 'inherit', padding: '.5em' }">Error: please contact <a href="mailto:itsuport@acr.org">ACR IT Support</a>. </div>
    <!-- /ko -->

    <!-- ko ifnot: suc -->
        <div class="content row facility-search ">
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtDsn" >DSN</label>
                <input id="txtDsn" type="text" data-bind="textInput: dsn, style: { fontSize: 'inherit' }" />
            </div>
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtDateStamp" >Date of Service</label>
                <input id="txtDateStamp" type="text" data-bind="textInput: datefurnishedService, style: { fontSize: 'inherit', width: '100%' } "  />
            </div>
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtAucid" >AUC ID</label>
                <input id="txtAucid" type="text" data-bind="textInput: auicd, style: { fontSize: 'inherit' }" />
            </div>
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtIndication" >Indication</label>
                <input id="txtIndication" type="text" data-bind="textInput: indication, style: { fontSize: 'inherit' }" />
            </div>
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtScore" >Score</label>
                <input id="txtScore" type="text" data-bind="textInput: score, style: { fontSize: 'inherit' }" />
            </div>
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtCpt" >CPT</label>
                <input id="txtCpt" type="text" data-bind="textInput: cpt, style: { fontSize: 'inherit' }" />
            </div>
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtSubscriberId" >Subscriber ID</label>
                <input id="txtSubscriberId" type="text" data-bind="textInput: subscriberId, style: { fontSize: 'inherit' }" />
            </div>
            <div class="col-half mobile-col-half ipad-col-half ">
                <label for="txtFpnpi" >NPI – Furnishing Provider</label>
                <input id="txtFpnpi" type="text" data-bind="textInput: fpnpi, style: { fontSize: 'inherit' }" />
            </div>
            <div class="col-half mobile-col-half ipad-col-half " >
                <div class="label-space">&nbsp;</div>
            </div>
            <div class="col-half mobile-col-half ipad-col-half txt-align-right " >
                <div class="label-space">&nbsp;</div>
                <button id="btnSubmit" type="button" class="button" data-bind="click: function (data) { valdiateAndSubmit(); }, style: { fontSize: 'inherit' }" >Submit</button>
            </div>
        </div>
    <!-- /ko -->
</div>
<script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js"></script>
<script src="/js/knockout-3.3.0.js"></script>
<script src="/js/ACRInformatics/knockout.validation.min.js"></script>
<script>
    function ViewModel() {
        var self = this;
        self.suc = ko.observable(false);
        self.err = ko.observable(false);

        self.dsn = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });
        self.fpnpi = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });
        self.datefurnishedService = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });
        self.subscriberId = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });
        self.auicd = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });
        self.indication = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });
        self.score = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });
        self.cpt = ko.observable('').extend({
            required: {
                message: 'Required'
            }
        });

        self.valdiateAndSubmit = function () {
            var dtHeader = {
                dartheader: {
                    partnerid: ko.observable("NDSC"),
                    appid: ko.observable("DART"),
                    dartprojectid: ko.observable("479"),
                    projectname: ko.observable("CDS Demo"),
                    programdartid: ko.observable("29"),
                    programname: ko.observable("CDSR"),
                    mediatype: ko.observable("csv"),
                    objecttype: ko.observable("Registry_data"),
                    headertype: ko.observable("CDSRegistry"),
                    programspecificdata: {
                        providertype: ko.observable("all"),
                        dsn: self.dsn(),
                        fpnpi: self.fpnpi(),
                        datefurnishedservice: self.datefurnishedService(),
                        subscriberid: self.subscriberId()
                       
                    }
                },
                payload: {
                    auicd: self.auicd(),
                    indication: self.indication(),
                    score: self.score(),
                    cpt: self.cpt(),
                    dsn: self.dsn(),
                    fpnpi: self.fpnpi(),
                    datefurnishedservice: self.datefurnishedService(),
                    subscriberid: self.subscriberId()
                }
            };
            var jsonData = ko.toJSON(dtHeader);
            //alert(jsonData.toString());
            if (viewModel.errors().length === 0) {
                //alert('Thank you.');
                if ((msieversion() < 10) && window.XDomainRequest) {
                    var xdr = new XDomainRequest();
                    if (xdr) {
                        xdr.open('Post', 'http://10.11.202.44/dartcs/cdsregistry/fp');
                        xdr.onload = function () {
                            self.successSubmissionl(jQuery.parseJSON(xdr.responseText));
                        };
                        xdr.send();
                        xdr.onerror = function () {
                            self.errorSubmission(xdr.error);
                        };
                    }
                } else {
                    jQuery.ajax({
                        type: 'Post',
                        url: 'http://10.11.202.44/dartcs/cdsregistry/fp',
                        contentType: 'application/json;charset-uf8',
                        data: jsonData,
                        crossDomain: true,
                        success: self.successSubmission,
                        error: self.errorSubmission
                    });
                }
            }
            else {
                //alert('Please check your submission.');
                viewModel.errors.showAllMessages();
            }
        };

        self.successSubmission = function (response, status, jqXHR) {
            self.suc(true);
            //alert(status + ' ' + jqXHR.status);
        };
        self.errorSubmission = function (jqXHR, status, thrownError) {
            self.err(true);
            //alert(status + ' ' + jqXHR.status);
        };

        self.historyBackWFallback = function () {
            if (window.history.length == 0) {
                window.location.href = 'http://devacraccreditation/';
            } else {
                window.history.go(-1);
            }
        };

        function msieversion() {
            var ua = window.navigator.userAgent
            var msie = ua.indexOf("MSIE ")
            if (msie > 0)      // If Internet Explorer, return version number
                return parseInt(ua.substring(msie + 5, ua.indexOf(".", msie)));
            else                 // If another browser, return 0
                return 0;
        };


    };

    var viewModel = new ViewModel();
    viewModel.errors = ko.validation.group(viewModel);
    ko.applyBindings(viewModel);
</script>
<script>
    jQuery(function ($) {
        $('#txtDateStamp').datepicker();
    });
</script>