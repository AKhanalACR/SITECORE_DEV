function ViewModel() {
    var self = this;
    self.findBy = [
        { val: "ZipCity", txt: "ZIP/City" },
        { val: "State", txt: "State" },
        { val: "Country", txt: "Country" },
        { val: "FacilityName", txt: "Facility Name" }
    ];
    self.selectedFindBy = ko.observable('ZipCity');

    self.nearZipCity = ko.observable('');
    self.zipCityValidation = ko.observable(0);
    self.validationMessage = ko.observable('');

    self.lblChoice = ko.observable('ZIP/City:');

    self.radInMile = [
        { val: "5", txt: "5 Miles" },
        { val: "10", txt: "10 Miles" },
        { val: "20", txt: "25 Miles" },
        { val: "50", txt: " 50 Miles " }
    ];
    self.selectedRadInMile = ko.observable('50');

    self.modChoice = [
        { val: "00", txt: " - Select - " },
        { val: "BMRAP", txt: "Breast MRI" },
        { val: "BUAP", txt: "Breast Ultrasound" },
        { val: "CTAP", txt: "Computed Tomography" },
        { val: "MAP", txt: "Mammography" },
        { val: "MRAP", txt: "MRI" },
        { val: "NMAP", txt: "Nuclear Medicine" },
        { val: "PETAP", txt: "PET" },
        { val: "RO", txt: "Radiation Oncology" },
        { val: "SBBAP", txt: "Stereotactic" },
        { val: "UAP", txt: "Ultrasound" }
    ]; //ko.observableArray();
    self.selectedModChoice = ko.observable('00');
    if (getUrlVars()["modality"] !== undefined && getUrlVars()["modality"] == 'CTAP') {
        self.selectedModChoice = ko.observable('CTAP');
    }

    self.desigChoice = [
        { val: "00", txt: " - Select - " },
        { val: "BICOE", txt: "Breast Imaging Center of Excellence (BICOE)" },
        { val: "DICOE", txt: "Diagnostic Imaging Center of Excellence (DICOE)" },
        { val: "ImageGently", txt: "Computed Tomography - Pediatrics" },
        { val: "LCSC", txt: "Lung Cancer Screening Center" }
    ]; //ko.observableArray(); self.desigChoice.push({ val: "00", txt: " - Select - " });
    self.selectedDesigChoice = ko.observable('00');
    if (getUrlVars()["designation"] !== undefined && getUrlVars()["designation"] == 'LCSC') {
        self.selectedDesigChoice = ko.observable('LCSC');
    }

    self.stateChoice = [
        { val: "AL", txt: "Alabama" },
        { val: "AK", txt: "Alaska" },
        { val: "AS", txt: "American Samoa" },
        { val: "AZ", txt: "Arizona" },
        { val: "AR", txt: "Arkansas" },
        { val: "CA", txt: "California" },
        { val: "CO", txt: "Colorado" },
        { val: "CT", txt: "Connecticut" },
        { val: "DE", txt: "Delaware" },
        { val: "DC", txt: "District of Columbia" },
        { val: "AE", txt: "Europe (Military)" },
        { val: "FL", txt: "Florida" },
        { val: "GA", txt: "Georgia" },
        { val: "GU", txt: "Guam" },
        { val: "HI", txt: "Hawaii" },
        { val: "ID", txt: "Idaho" },
        { val: "IL", txt: "Illinois" },
        { val: "IN", txt: "Indiana" },
        { val: "IA", txt: "Iowa" },
        { val: "KS", txt: "Kansas" },
        { val: "KY", txt: "Kentucky" },
        { val: "LA", txt: "Louisiana" },
        { val: "ME", txt: "Maine" },
        { val: "MD", txt: "Maryland" },
        { val: "MA", txt: "Massachusetts" },
        { val: "MI", txt: "Michigan" },
        { val: "MN", txt: "Minnesota" },
        { val: "MS", txt: "Mississippi" },
        { val: "MO", txt: "Missouri" },
        { val: "MT", txt: "Montana" },
        { val: "NE", txt: "Nebraska" },
        { val: "NV", txt: "Nevada" },
        { val: "NH", txt: "New Hampshire" },
        { val: "NJ", txt: "New Jersey" },
        { val: "NM", txt: "New Mexico" },
        { val: "NY", txt: "New York" },
        { val: "NC", txt: "North Carolina" },
        { val: "ND", txt: "North Dakota" },
        { val: "MP", txt: "Northern Mariana Islands" },
        { val: "OH", txt: "Ohio" },
        { val: "OK", txt: "Oklahoma" },
        { val: "OR", txt: "Oregon" },
        { val: "AP", txt: "Pacific (Military)" },
        { val: "PA", txt: "Pennsylvania" },
        { val: "PR", txt: "Puerto Rico" },
        { val: "RI", txt: "Rhode Island" },
        { val: "SC", txt: "South Carolina" },
        { val: "SD", txt: "South Dakota" },
        { val: "TN", txt: "Tennessee" },
        { val: "TX", txt: "Texas" },
        { val: "UT", txt: "Utah" },
        { val: "VI", txt: "Virgin Islands" },
        { val: "VA", txt: "Virginia" },
        { val: "VT", txt: "Vermont" },
        { val: "WA", txt: "Washington" },
        { val: "WV", txt: "West Virginia" },
        { val: "WI", txt: "Wisconsin" },
        { val: "WY", txt: "Wyoming" }
    ]; //ko.observableArray();
    self.selectedState = ko.observable('');

    self.countryChoice = [
        { val: "Bermuda", txt: "Bermuda" },
        { val: "Brazil", txt: "Brazil" },
        { val: "Canada", txt: "Canada" },
        { val: "Chile", txt: "Chile" },
        { val: "China", txt: "China" },
        { val: "Colombia", txt: "Colombia" },
        { val: "Cuba", txt: "Cuba" },
        { val: "Egypt", txt: "Egypt" },
        { val: "Germany", txt: "Germany" },
        { val: "India", txt: "India" },
        { val: "Italy", txt: "Italy" },
        { val: "Japan", txt: "Japan" },
        { val: "Kuwait", txt: "Kuwait" },
        { val: "Lebanon", txt: "Lebanon" },
        { val: "Marshall Islands", txt: "Marshall Islands" },
        { val: "Palau", txt: "Palau" },
        { val: "Panama", txt: "Panama" },
        { val: "Philippines", txt: "Philippines" },
        { val: "Poland", txt: "Poland" },
        { val: "Qatar", txt: "Qatar" },
        { val: "Saudi Arabia", txt: "Saudi Arabia" },
        { val: "South Africa", txt: "South Africa" },
        { val: "South Korea", txt: "South Korea" },
        { val: "Spain", txt: "Spain" },
        { val: "The Republic of Georgia", txt: "The Republic of Georgia" },
        { val: "Turkey", txt: "Turkey" },
        { val: "United Arab Emirates", txt: "United Arab Emirates" },
        { val: "United Kingdom", txt: "United Kingdom" }
    ]; //ko.observableArray();
    self.selectedCountry = ko.observable('');

    self.zeroResultCntr = ko.observable(0);
    self.didYouMeanCntr = ko.observable(0);
    self.showResultCntr = ko.observable(0);

    self.zeroResultMessage = ko.observable('');

    self.lat = ko.observable('');
    self.lng = ko.observable('');

    self.didYouMeanResults = ko.observableArray();
    self.searchResult = ko.observableArray();
    self.unAccSearchResult = ko.observableArray();

    self.didYouMeanSelection = function (name) {
        self.nearZipCity(name);
    };

    self.txtZipCntr = ko.observable(1);
    self.ddlMileCntr = ko.observable(1);
    self.ddlStateCntr = ko.observable(0);
    self.ddlCountryCntr = ko.observable(0);

    self.accCount = ko.observable(0);
    self.unAccCount = ko.observable(0);

    //get find by selection
    self.getFindBySelection = function () {
        if (self.selectedFindBy() == 'ZipCity') {
            self.ddlMileCntr(1);
            self.txtZipCntr(1);
            self.ddlStateCntr(0);
            self.ddlCountryCntr(0);
            self.lblChoice('ZIP/City:');

        } else if (self.selectedFindBy() == 'State') {
            self.zipCityValidation(0);
            jQuery("#txtZipCity").attr('style', 'border-color:#A9A9A9; display:none');
            self.ddlMileCntr(0);
            self.txtZipCntr(0);
            self.ddlStateCntr(1);
            self.ddlCountryCntr(0);
            //jQuery('#ddlChooseMile option:first').attr('selected', true);
            self.lblChoice('State:');
            self.didYouMeanCntr(0);

        } else if (self.selectedFindBy() == 'Country') {
            self.zipCityValidation(0);
            jQuery("#txtZipCity").attr('style', 'border-color:#A9A9A9; display:none');
            self.ddlMileCntr(0);
            self.txtZipCntr(0);
            self.ddlStateCntr(0);
            self.ddlCountryCntr(1);
            //jQuery('#ddlChooseMile option:first').attr('selected', true);
            self.lblChoice('Country:');
            self.didYouMeanCntr(0);
        } else if (self.selectedFindBy() == 'FacilityName') {
            self.ddlMileCntr(1);
            self.txtZipCntr(1);
            self.ddlMileCntr(0);
            self.ddlStateCntr(0);
            self.ddlCountryCntr(0);
            self.lblChoice('Facility Name:');
        }
    };

    //self.ddlPopulate = function () {
    //    jQuery("#ajaxSpinnerContainer").show();
    //    if ((msieversion() < 10) && window.XDomainRequest) {
    //        var xdr = new XDomainRequest();
    //        var query = 'https://srv.acraccreditation.org/api/item/ddl';
    //        if (xdr) {
    //            xdr.open('Get', query);
    //            xdr.onload = function () {
    //                self.successGetDdl(jQuery.parseJSON(xdr.responseText));
    //            };
    //            xdr.send();
    //            xdr.onerror = function () {
    //                self.errorGetDdl(xdr.error);
    //            };
    //        }
    //    } else {
    //        return jQuery.ajax({
    //            type: 'Get',
    //            url: 'https://srv.acraccreditation.org/api/item/ddl/',
    //            accept: 'application/json',
    //            timeout: 20000,
    //            cache: false,
    //            dataType: 'json',
    //            success: function (response) {
    //                self.successGetDdl(response);
    //            },
    //            error: function (error) {
    //                self.errorGetDdl(error);
    //            }
    //        });
    //    }
    //};

    //self.successGetDdl = function (response) {
    //    if (response.length == 0) {
    //        //alert('ZERO_RESULTS');
    //    } else if (response.length > 0) {
    //        for (var i = 0; i < response.length; i++) {
    //            if (response[i].keyType == 'State') {
    //                var ddlStRes = new Object();
    //                ddlStRes.txt = response[i].displayText;
    //                ddlStRes.val = response[i].selectedValue;
    //                self.stateChoice.push(ddlStRes);

    //            } else if (response[i].keyType == 'Country') {
    //                var ddlCntyRes = new Object();
    //                ddlCntyRes.txt = response[i].displayText;
    //                ddlCntyRes.val = response[i].selectedValue;
    //                self.countryChoice.push(ddlCntyRes);
    //            } else if (response[i].keyType == 'Modality') {
    //                var ddlModRes = new Object();
    //                ddlModRes.txt = response[i].displayText;
    //                ddlModRes.val = response[i].selectedValue;
    //                self.modChoice.push(ddlModRes);
    //            } else if (response[i].keyType == 'Designation') {
    //                var ddlDesRes = new Object();
    //                ddlDesRes.txt = response[i].displayText;
    //                ddlDesRes.val = response[i].selectedValue;
    //                self.desigChoice.push(ddlDesRes);
    //            }
    //        }
    //    }
    //    //jQuery('#ajaxSpinnerContainer').hide();
    //};

    //self.errorGetDdl = function (xhr, textStatus, error) {
    //    //alert('Loading Dropdowns! ' + xhr.status + " " + textStatus + " " + error);
    //};

    //runs on doc ready
    self.getCurrentLocation = function () {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(searchUsingCurrLoc, currLocError);
        }
    };

    //called from self.getCurrentLocation above
    function searchUsingCurrLoc(position) {
        jQuery("#ajaxSpinnerContainer").show();
        jQuery("#loader-open").show();
        self.lat(position.coords.latitude);
        self.lng(position.coords.longitude);

        var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
        var geocoder = new google.maps.Geocoder();
        geocoder.geocode({ 'latLng': latlng }, function (results, status) {

            if (status == google.maps.GeocoderStatus.OK) {
                var city = ''; var state = '';
                for (var i = 0, len = results[0].address_components.length; i < len; i++) {
                    if (results[0].address_components[i].types == "locality,political") city = results[0].address_components[i].short_name;
                    if (results[0].address_components[i].types == "administrative_area_level_1,political") state = results[0].address_components[i].short_name;
                }
                self.nearZipCity(city + ', ' + state);

            }
        });

        var stringUrl = 'https://srv.acraccreditation.org/api/facility/facilities/' + self.selectedModChoice() + '/' + self.selectedDesigChoice() + '/' + self.lat() + '/' + self.lng() + '/' + self.selectedRadInMile(); //self.selectedModality() + '/' + self.selectedDesignation() + '/' + self.lat() + '/' + self.lng() + '/' + self.selectedRad();
        if ((msieversion() < 10) && window.XDomainRequest) {
            var xdr = new XDomainRequest();
            if (xdr) {
                xdr.open('Get', stringUrl);
                xdr.onload = function () {
                    self.successSearch(jQuery.parseJSON(xdr.responseText));
                };
                xdr.send();
                xdr.onerror = function () {
                    self.errorSearch(xdr.error);
                };
            }
        } else {
            jQuery.ajax({
                type: 'Get',
                url: stringUrl,
                accept: 'application/json',
                dataType: 'json',
                timeout: 20000,
                cache: false,
                success: function (response) {
                    self.successSearch(response);
                },
                error: function (error) {
                    self.errorSearch(error);
                }
            });
        }
    };

    function currLocError(error) {
        //jQuery('#ajaxSpinnerContainer').hide();
        //alert('Current location error.');
    };

    //1- search button  
    self.valdiateAndSearch = function () {
        jQuery('#ajaxSpinnerContainer').show();
        jQuery("#loader-open").show();
        self.accCount(0);
        self.unAccCount(0);
        self.didYouMeanCntr(0);

        if (self.selectedFindBy() == 'ZipCity') {
            var local = self.nearZipCity();
            self.didYouMeanResults([]);
            self.searchResult([]);
            self.zeroResultMessage(local);
            var stringUrl = 'https://srv.acraccreditation.org/api/url/sign/' + local.trim();
            var signedUrl = '';

            if ((msieversion() < 10) && window.XDomainRequest) {
                var xdr = new XDomainRequest();
                if (xdr) {
                    xdr.open('Get', stringUrl);
                    xdr.onload = function () {
                        signedUrl = xdr.responseText;
                        var xdr2 = new XDomainRequest();
                        if (xdr2) {
                            xdr2.open('Get', signedUrl);
                            xdr2.onload = function () {
                                self.successGeocode(jQuery.parseJSON(xdr2.responseText));
                            };
                            xdr2.send();
                            xdr2.onerror = function () {
                                self.errorGeocode(xdr2.responseText);
                            };
                        }
                    };
                    xdr.send();
                    xdr.onerror = function () {
                        //alert('Error getting signed url');
                    };
                }
            } else {
                var getSignedUrl = function () {
                    jQuery.ajax({
                        type: 'Get',
                        url: stringUrl,
                        async: false,
                        cache: false,
                        success: function (response) {
                            jQuery("#txtZipCity").attr('style', 'border-color:#A9A9A9');
                            self.zipCityValidation(0);
                            signedUrl = response;

                        },
                        error: function (error) {
                            jQuery('#ajaxSpinnerContainer').hide();
                            if (local == '') {
                                jQuery('#txtZipCity').attr('style', 'border-color:red; border-width:1px');
                                self.validationMessage('Please enter a valid city or zip code');
                                self.zipCityValidation(1);
                            }
                        }
                    })
                };

                jQuery.when(getSignedUrl()).then(function () {
                    if (signedUrl != '') {
                        jQuery.ajax({
                            url: signedUrl,
                            cache: false,
                            success: function (response2) {
                                self.successGeocode(response2);
                            },
                            error: function (error) {
                                self.errorGeocode(error);
                            }
                        });
                    }
                });
            }
        } else if (self.selectedFindBy() == 'State' || self.selectedFindBy() == 'Country') {
            self.searchResult([]);
            self.unAccSearchResult([]);

            var serUrl = '';
            if (self.selectedFindBy() == 'State') {
                self.zeroResultMessage(self.selectedState());
                serUrl = 'https://srv.acraccreditation.org/api/facility/facilities/' + 'State/' + self.selectedState() + '/' + self.selectedModChoice() + '/' + self.selectedDesigChoice();
            }
            else if (self.selectedFindBy() == 'Country') {
                self.zeroResultMessage(self.selectedCountry());
                serUrl = 'https://srv.acraccreditation.org/api/facility/facilities/' + 'Country/' + self.selectedCountry() + '/' + self.selectedModChoice() + '/' + self.selectedDesigChoice();
            }

            if ((msieversion() < 10) && window.XDomainRequest) {
                var xdr = new XDomainRequest();
                if (xdr) {
                    xdr.open('Get', serUrl);
                    xdr.onload = function () {
                        self.successSearch(jQuery.parseJSON(xdr.responseText));
                    };
                    xdr.send();
                    xdr.onerror = function () {
                        self.errorSearch(xdr.error);
                    };
                }
            } else {
                jQuery.ajax({
                    type: 'Get',
                    url: serUrl,
                    accept: 'application/json',
                    dataType: 'json',
                    cache: false,
                    success: function (response) {
                        self.successSearch(response);
                    },
                    error: function (error) {
                        self.errorSearch(error);
                    }
                });
            }
        } else if (self.selectedFindBy() == 'FacilityName') {
            var local = self.nearZipCity();
            self.zeroResultMessage(local);
            var searchUrl = 'https://srv.acraccreditation.org/api/facility/facilities/' + self.selectedModChoice() + '/' + self.selectedDesigChoice() + '?fName=' + local.trim();
            if ((msieversion() < 10) && window.XDomainRequest) {
                var xdr = new XDomainRequest();
                if (xdr) {
                    xdr.open('Get', searchUrl);
                    xdr.onload = function () {
                        self.successSearch(jQuery.parseJSON(xdr.responseText));
                    };
                    xdr.send();
                    xdr.onerror = function () {
                        self.errorSearch(xdr.error);
                    };
                }
            } else {
                jQuery.ajax({
                    type: 'Get',
                    url: searchUrl,
                    accept: 'application/json',
                    dataType: 'json',
                    cache: false,
                    success: function (response) {
                        jQuery("#txtZipCity").attr('style', 'border-color:#A9A9A9');
                        self.zipCityValidation(0);
                        self.successSearch(response);
                    },
                    error: function (error) {
                        jQuery('#ajaxSpinnerContainer').hide();
                        if (local == '') {
                            jQuery('#txtZipCity').attr('style', 'border-color:red; border-width:1px');
                            self.validationMessage('Please enter facility name');
                            self.zipCityValidation(1);
                        }
                        self.errorSearch(error);
                    }
                });
            }
        }

    };

    //2- geocode sucess - called from self.valdiateAndSearch
    self.successGeocode = function (response) {
        if (response.status == 'OVER_QUERY_LIMIT') {
            jQuery('#ajaxSpinnerContainer').hide();
        } else if (response.status == 'ZERO_RESULTS') {
            self.zeroResultCntr(1);
            self.didYouMeanCntr(0);
            self.showResultCntr(0);
            self.init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);
            jQuery('#ajaxSpinnerContainer').hide();
        } else if (response.status == 'OK') {
            var resultsArray = response.results;
            if (resultsArray.length == 1) {
                self.lat(resultsArray[0].geometry.location.lat);
                self.lng(resultsArray[0].geometry.location.lng);

                var stringUrl = 'https://srv.acraccreditation.org/api/facility/facilities/' + self.selectedModChoice() + '/' + self.selectedDesigChoice() + '/' + self.lat() + '/' + self.lng() + '/' + self.selectedRadInMile(); //self.selectedModality() + '/' + self.selectedDesignation() + '/' + self.lat() + '/' + self.lng() + '/' + self.selectedRad();
                jQuery.ajax({
                    type: 'Get',
                    url: stringUrl,
                    accept: 'application/json',
                    dataType: 'json',
                    cache: false,
                    success: self.successSearch,
                    error: self.errorSearch
                })
            } else if (resultsArray.length > 1) {
                self.didYouMeanCntr(1);
                self.zeroResultCntr(0);
                self.showResultCntr(0);

                for (var i = 0; i < resultsArray.length; i++) {
                    var fAddress = new Object();
                    var address = ''; city = ''; county = ''; state = ''; zip = '';
                    //for (var j = 0; j < resultsArray[i].address_components.length; j++) {
                    //    if (resultsArray[i].address_components[j].types[0] == 'locality')
                    //        city = resultsArray[i].address_components[j].short_name + ', ';
                    //    if (resultsArray[i].address_components[j].types[0] == 'administrative_area_level_2')
                    //        county = resultsArray[i].address_components[j].short_name + ', ';
                    //    if (resultsArray[i].address_components[j].types[0] == 'administrative_area_level_1')
                    //        state = resultsArray[i].address_components[j].short_name + ' ';
                    //    if (resultsArray[i].address_components[j].types[0] == 'postal_code')
                    //        address = city + state + resultsArray[i].address_components[j].short_name;
                    //    else
                    //        address = city + county + state;
                    //}

                    //fAddress.name = address; 
                    fAddress.name = resultsArray[i].formatted_address;
                    self.didYouMeanResults.push(fAddress);
                }
                jQuery('#ajaxSpinnerContainer').hide();
                jQuery("#loader-open").hide();
            }
        }
    };

    //2- geocode fail
    self.errorGeocode = function (error) {
        //alert('Geocode Error! ' + error);
        jQuery('#ajaxSpinnerContainer').hide();
        jQuery("#loader-open").hide();

    };

    //3- success callback on geocode success - called from self.successGeocode
    self.successSearch = function (response) {
        if (response.length == 0) {
            self.zeroResultCntr(1);
            self.didYouMeanCntr(0);
            self.showResultCntr(0);
            self.init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);
        } else if (response.length > 0) {
            self.showResultCntr(1);
            self.zeroResultCntr(0);
            self.didYouMeanCntr(0);
            self.searchResult([]);
            self.unAccSearchResult([]);
            var markers = [];
            var infoWindowContents = [];

            for (var i = 0; i < response.length; i++) {
                var sResult = new Object();
                sResult.order = i + 1;
                sResult.name = response[i].name;
                sResult.address1 = response[i].address;
                sResult.address2 = response[i].city + ', ' + response[i].state + ' ' + response[i].zip;
                sResult.phone = response[i].phone;
                sResult.expiration = response[i].expDate;
                sResult.accredStatus = response[i].accStatus;
                sResult.module = response[i].mod;

                //added 8/18/2016
                sResult.modalities = response[i].modalities; // 'CTAP, PETAP, OR'; //

                var modChoice = self.selectedModChoice();
                sResult.expirationflag = 0;
                if (response[i].expiration != '' && modChoice != '00') {
                    sResult.expirationflag = 1;
                }

                sResult.moduleflag = 0;
                if (response[i].mod != '' && modChoice != '00') {
                    sResult.moduleflag = 1;
                }

                sResult.modalitiesflag = 0;
                sResult.modlabel = 'Modalities Offered:';
                if (response[i].modalities != '') {
                    sResult.modalitiesflag = 1;
                    if (modChoice != '00')
                        sResult.modlabel = 'Other Modalities Offered:';
                }

                sResult.mamoBit = response[i].mamFlag;
                sResult.bicoeFlage = 0;
                sResult.imgGentlyFlage = 0;
                sResult.lcsdFlage = 0;
                sResult.dicoeFlage = 0;
                var mamBin = sResult.mamoBit;
                if (mamBin & '1') {
                    sResult.bicoeFlage = 1;
                }
                if (mamBin & '8') {
                    sResult.dicoeFlage = 1;
                }
                if (mamBin & '2') {
                    sResult.imgGentlyFlage = 1;
                }
                if (mamBin & '4') {
                    sResult.lcsdFlage = 1;
                }

                sResult.destination = '';

                //
                //sResult.milage = '';
                //var directionsService = new google.maps.DirectionsService;
                //directionsService.route({
                //    origin: self.nearZipCity(),
                //    destination: 'Fairfax, VA',
                //    travelMode: google.maps.TravelMode.DRIVING
                //}, function (response, status) {
                //    if (status === google.maps.DirectionsStatus.OK) {
                //        sResult.milage = response.routes[0].legs[0].distance.text;

                //    } else {
                //        //window.alert('Directions request failed due to ' + status);
                //    }
                //});
                //

                if (response[i].accStatus == 'A')
                    self.searchResult.push(sResult);
                else
                    self.unAccSearchResult.push(sResult);

                if (!((!(response[i].lat) || 0 == (response[i].lat).length) || (!(response[i].lng) || 0 == (response[i].lng).length))) {
                    var marker = new Object();
                    marker.order = sResult.order;
                    marker.title = response[i].name;
                    marker.lat = response[i].lat;
                    marker.lng = response[i].lng;
                    markers.push(marker);

                    sResult.destination = response[i].lat + ',' + response[i].lng;

                    var infoWindowCnt = new Object();
                    infoWindowCnt.title = response[i].name;
                    infoWindowCnt.address1 = response[i].address;
                    infoWindowCnt.address2 = response[i].city + ', ' + response[i].state + ' ' + response[i].zip;
                    infoWindowContents.push(infoWindowCnt);
                }
            }

            self.accCount(self.searchResult().length);
            self.unAccCount(self.unAccSearchResult().length);
            self.init_map('map_canvas', self.lat(), self.lng(), 2, markers, infoWindowContents);

        }
        jQuery('#ajaxSpinnerContainer').hide();
        jQuery("#loader-open").hide();
    };

    //3- error callback on facility search
    self.errorSearch = function (error) {
        //alert('Search Error! ' + error); 
        jQuery('#ajaxSpinnerContainer').hide();
        jQuery("#loader-open").hide();
    };

    //mark pin on map - called from self.successSearch
    self.init_map = function (map_canvas_id, lat, lng, zoom, markers, infoWindowContents) {
        var myLatLng = new google.maps.LatLng(lat, lng);
        var options = {
            zoom: zoom,
            center: myLatLng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map_canvas1 = document.getElementById(map_canvas_id);
        var map = new google.maps.Map(map_canvas1, options);
        var bounds = new google.maps.LatLngBounds(); //new google.maps.LatLng(25.82, -124.39), new google.maps.LatLng(49.38, -66.94)
        if (markers && markers.length > 0) {
            var infoWindow = new google.maps.InfoWindow(), marker, j;
            for (j = 0; j < markers.length; j++) {
                var position = new google.maps.LatLng(markers[j].lat, markers[j].lng);
                bounds.extend(position);
                var index = markers[j].order;
                var imgUrl = '../../../../images/markerIcon/marker' + index + '.png';
                if (index > 99)
                    imgUrl = '../../../../images/markerIcon/blank.png';
                var image = new google.maps.MarkerImage(
                    imgUrl,
                    null,
                    null,
                    null,
                    new google.maps.Size(20, 30));

                marker = new google.maps.Marker({
                    position: position,
                    map: map,
                    title: markers[j].title,
                    icon: image


                });
                google.maps.event.addListener(marker, 'click', (function (marker, j) {
                    return function () {
                        infoWindow.setContent('<span style="color:blue">' + infoWindowContents[j].title + '</span>' + '<br />' + infoWindowContents[j].address1 + '<br />' + infoWindowContents[j].address2);
                        infoWindow.open(map, marker);
                    }
                })(marker, j));
                map.fitBounds(bounds);
            }
            map.fitBounds(bounds);
            map.setCenter(bounds.getCenter());
        }
        else {
            var bounds = new google.maps.LatLngBounds(new google.maps.LatLng(25.82, -124.39), new google.maps.LatLng(49.38, -66.94));
            //var marker1 = new Object();
            //marker1.title = '';
            //marker1.position = new google.maps.LatLng(lat, lng);
            //marker1.clickable = true;
            //var marker = new google.maps.Marker(marker1);
            //marker.setMap(map);
            //bounds.extend(marker.getPosition());
            map.fitBounds(bounds);
            map.setCenter(bounds.getCenter());
        }
    };
    //init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);

    //anchor click event - View Map
    self.viewMapScroll = function () {
        var mapTop = jQuery('#map_canvas').offset().top - 170;
        jQuery('html, body').animate({ scrollTop: mapTop }, 'fast');
        return false;
    };

    //anchor click event - Get Directions
    self.calculateAndDisplayRoute = function (destination) {
        var start = '';
        if (self.selectedFindBy() == 'ZipCity') {
            start = self.nearZipCity();

        } else if (self.selectedFindBy() == 'State') {
            start = self.selectedState();

        } else if (self.selectedFindBy() == 'Country') {
            start = self.selectedCountry();
        }

        var dirUrl = 'https://www.google.com/maps/dir/' + start + '/' + destination;
        window.open(dirUrl, '_blank');

        //var directionsService = new google.maps.DirectionsService;
        //var directionsDisplay = new google.maps.DirectionsRenderer;
        ////var infoWindow = new google.maps.InfoWindow();

        //var map = new google.maps.Map(document.getElementById('map_canvas'), {
        //    zoom: 2,
        //    center: { lat: 38.943268, lng: -77.328751 }
        //});
        //directionsDisplay.setMap(map);
        //directionsService.route({
        //    origin: self.nearZipCity(),
        //    destination: destination,
        //    travelMode: google.maps.TravelMode.DRIVING
        //}, function (response, status) {
        //    if (status === google.maps.DirectionsStatus.OK) {
        //        directionsDisplay.setDirections(response);
        //        //var dist = response.routes[0].legs[0].distance.text;
        //        //var position = new google.maps.LatLng(lat, lng);
        //        //marker = new google.maps.Marker({
        //        //    position: position,
        //        //    map: map,
        //        //    title: ''
        //        //});
        //        //infoWindow.setContent(dist);
        //        //infoWindow.open(map, marker);

        //    } else {
        //        window.alert('Directions request failed due to ' + status);
        //    }
        //});

        //self.viewMapScroll();
    };

    //get user agent
    function msieversion() {
        var ua = window.navigator.userAgent
        var msie = ua.indexOf("MSIE ")
        if (msie > 0)      // If Internet Explorer, return version number
            return parseInt(ua.substring(msie + 5, ua.indexOf(".", msie)));
        else                 // If another browser, return 0
            return 0;
    };

    //get query string
    function getUrlVars() {
        var vars = [], hash;
        var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            vars.push(hash[0]);
            vars[hash[0]] = hash[1];
        }
        return vars;
    }
};

//on doc ready
jQuery(function ($) {
    jQuery('#ajaxSpinnerContainer').show();
    //jQuery("#loader-open").show();
    var viewModel = new ViewModel();
    ko.applyBindings(viewModel);

    viewModel.getFindBySelection();

    viewModel.init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);

    $("#txtZipCity").keypress(function (e) {
        if (e.which == 13) {
            $("#btnFind")[0].click();
        }
    });


    var uri = new URI(window.location.href);
    var clickSearch = false;
    var uriData = uri.search(true);
    if (uriData["modality"] === "MAP") {
        $("#ddlChooseMod").val("MAP");
        viewModel.selectedModChoice = ko.observable('MAP');
        clickSearch = true;
    }

    if (uriData["cityzip"] !== undefined) {
        viewModel.selectedFindBy = ko.observable('ZipCity');


        viewModel.nearZipCity(uriData["cityzip"]);
        $("#txtZipCity").val(uriData["cityzip"]);
        clickSearch = true;
    }
    if (uriData["state"] !== undefined) {
        viewModel.selectedFindBy = ko.observable('State');
        viewModel.zipCityValidation(0);
        viewModel.lblChoice('State:');
        viewModel.ddlMileCntr(0);
        viewModel.txtZipCntr(0);
        viewModel.ddlStateCntr(1);
        viewModel.ddlCountryCntr(0);
        viewModel.didYouMeanCntr(0);
        viewModel.selectedState = ko.observable(uriData["state"]);
        $("#ddlFindBy").val("State");
        $("#ddlChooseState").val(uriData["state"]);
        //viewModel.nearZipCity(uriData["cityzip"]);
        //$("#txtZipCity").val(uriData["cityzip"]);
        clickSearch = true;
    }
    if (uriData["country"] !== undefined) {
        viewModel.selectedFindBy = ko.observable('Country');
        viewModel.zipCityValidation(0);
        viewModel.ddlMileCntr(0);
        viewModel.txtZipCntr(0);
        viewModel.ddlStateCntr(0);
        viewModel.ddlCountryCntr(1);
        viewModel.lblChoice('Country:');
        viewModel.didYouMeanCntr(0);
        $("#ddlFindBy").val("Country");
        viewModel.selectedCountry = ko.observable(uriData["country"]);
        $("#ddlChooseCountry").val(uriData["country"]);
        //viewModel.nearZipCity(uriData["cityzip"]);
        //$("#txtZipCity").val(uriData["cityzip"]);
        clickSearch = true;
    }
    if (uriData["facilityname"] !== undefined) {
        viewModel.zipCityValidation(0);
        viewModel.ddlMileCntr(1);
        viewModel.txtZipCntr(1);
        viewModel.ddlMileCntr(0);
        viewModel.ddlStateCntr(0);
        viewModel.ddlCountryCntr(0);
        viewModel.selectedFindBy = ko.observable('FacilityName');
        viewModel.lblChoice('Facility Name:');
        $("#ddlFindBy").val("FacilityName");
        viewModel.nearZipCity(uriData["facilityname"]);
        $("#txtZipCity").val(uriData["facilityname"]);
        //viewModel.nearZipCity(uriData["cityzip"]);
        //$("#txtZipCity").val(uriData["cityzip"]);
        clickSearch = true;
    }

    if (clickSearch) {
        $(window).scrollTop(200);
        $("#btnFind")[0].click();
        $("#loader-open").show();
    } else {
        viewModel.getCurrentLocation();
    }

    //if (window.location.href.indexOf("&modality=MAP") > 0) {
    //    $("#ddlChooseMod").val("MAP");

    //    if (window.location.href.indexOf("cityzip=") > 0) {
    //        var cityZip = window.location.href.substring(window.location.href.indexOf("cityzip="));
    //        if (cityZip.indexOf('&') > 0) {
    //            cityZip = cityZip.substring(0, cityZip.indexOf('&'));
    //        }
    //        var eq = cityZip.indexOf('=');
    //        if (eq > 0) {
    //            cityZip = cityZip.substring(eq + 1);
    //        }
    //        viewModel.nearZipCity(cityZip);
    //        viewModel.selectedModChoice = ko.observable('MAP');
    //        $("#txtZipCity").val(cityZip);
          
    //    }
    //}

    jQuery('#ajaxSpinnerContainer').hide();
    //$.when(viewModel.ddlPopulate()).then(function () {
    //    viewModel.getCurrentLocation();
    //    $('#ajaxSpinnerContainer').hide();
    //});

    $('.facility-tabs').on('click', 'a', function (e) {
        e.preventDefault();
        var results = $('.facility-results'),
            tabToSee = '.' + this.className.substring(4);
        tabToShow = results.find('.' + this.className.substring(4));
        results.find('.results').not(tabToSee).hide();
        results.find(tabToSee).show();
    });




});