
jQuery(function ($) {
    jQuery('.cct-section').find('select').val("50");
    jQuery('.cct-section').find('select').dropdown();
    init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);
    getCurrentLocation();

    jQuery(jQuery('.cct-section').find('#txtAddress')).keypress(function (e) {
        if (e != undefined && e.which == 13) {
            jQuery('.cct-section #findLocationBtn')[0].click();
        }
    });
});

jQuery(document).on('click', '.cct-section #findLocationBtn', function () {
    //address text box validation
    if (jQuery(jQuery('.cct-section').find('#txtAddress')).val() == undefined || jQuery(jQuery('.cct-section').find('#txtAddress')).val() == '') {
        jQuery(jQuery('.cct-section').find('#txtAddress')).css('border-color', 'red');
        return false
    }

    var address = jQuery('.cct-section').find('#txtAddress').val();
    var miles = jQuery(jQuery('.cct-section').find('.cct-milesDdl')).find('.selected').attr('data-value');
    get_geolocaton(address, miles);

});

//address box border reset
jQuery(document).on('change', '.cct-section #txtAddress', function () {
    jQuery(this).removeAttr('style');    
});

//get location geocode
function get_geolocaton(address, miles) {
    var signedUrl = '';
    //get signed url
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
                        successGeocode(miles, jQuery.parseJSON(xdr2.responseText));
                    };
                    xdr2.send();
                    xdr2.onerror = function () {
                        errorGeocode(xdr2.responseText);
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
                url: '/api/Sitecore/MyCtColonography/GetSignedUrl',
                data: { "address": address },
                async: false,
                success: function (response) {
                    signedUrl = response;
                },
                error: function (error) {
                    //Please enter a valid city or zip code
                }
            })
        };

        //get location geocode
        jQuery.when(getSignedUrl()).then(function () {
            if (signedUrl != '') {
                jQuery.ajax({
                    url: signedUrl,
                    cache: false,
                    success: function (response2) {
                        successGeocode(miles, response2);
                    },
                    error: function (error) {
                        errorGeocode(error);
                    }
                });
            }
        });
    }   
}

//success geocode 
function successGeocode(miles, response) {
    var lat, lgn = '';
    if (response.status == 'OVER_QUERY_LIMIT') {
        jQuery('#cct_parent').html('<p>Over query limit.</p>');
        init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);
    } else if (response.status == 'ZERO_RESULTS') {
        jQuery('#cct_parent').html('<p>No location found.</p>');
        init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);       
    } else if (response.status == 'OK') {
        var resultsArray = response.results;
        
        if (resultsArray.length == 1) {
            lat = resultsArray[0].geometry.location.lat;
            lng = resultsArray[0].geometry.location.lng;
            
            var stringUrl = '/api/Sitecore/MyCtColonography/GetLocations';
            jQuery.ajax({
                type: 'Get',
                url: stringUrl,
                accept: 'application/json',
                dataType: 'json',
                data: { "lat": lat, "lng": lng, "miles": miles},
                success: function (response) {
                    successSearch(response, lat, lng);
                },
                error: function (error) {
                    errorSearch(error);
                }
            })
        } else if (resultsArray.length > 1) {
            //did you mean code
        }
    }
}

//error getting geocode
function errorGeocode(error) {

}

//search success
function successSearch(response, lat, lng) {
    var storeLoc = [];
    var markers = [];
    var infoWinCnt = [];

    if (response.length == 0) {
        display_loc(storeLoc);
        init_map('map_canvas', '38.943268', '-77.328751', 6, null, null);        
    } else if (response.length > 0) {
        for (var i = 0; i < response.length; i++) {
            var sResult = new Object();
            sResult.order = i + 1;
            sResult.store = response[i].Store;
            sResult.address1 = response[i].Address1 + ' ' + response[i].Address2;
            sResult.address2 = response[i].City + ', ' + response[i].State + ' ' + response[i].Zip;
            sResult.phone = response[i].Phone;
            sResult.url = response[i].URL;
            sResult.miles = response[i].Miles;
            storeLoc.push(sResult);
            if (!((!(response[i].Latitude) || 0 == (response[i].Latitude).length) || (!(response[i].Longitude) || 0 == (response[i].Longitude).length))) {
                var marker = new Object();
                marker.order = sResult.order;
                marker.title = sResult.store;
                marker.lat = response[i].Latitude;
                marker.lng = response[i].Longitude;
                markers.push(marker);

                var infoWindowCnt = new Object();
                infoWindowCnt.title = sResult.store;
                infoWindowCnt.address1 = sResult.address1;
                infoWindowCnt.address2 = sResult.address2;
                infoWindowCnt.phone = sResult.phone;
                infoWindowCnt.url = sResult.url;
                infoWinCnt.push(infoWindowCnt);
            }
        }
        display_loc(storeLoc);
        init_map('map_canvas', lat, lng, 8, markers, infoWinCnt);
    }   
}

//search error
function errorSearch(error) {
    //error calling store search
}

//initiate map
function init_map(map_canvas_id, lat, lng, zm, markers, infoWinCnt) {
    var myLatLng = new google.maps.LatLng(lat, lng);
    var options = {
        zoom: zm,
        center: myLatLng,
        gestureHandling: 'cooperative',
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById(map_canvas_id), options);
    var bounds = new google.maps.LatLngBounds(); 
    if (markers && markers.length > 0) {
        var infoWindow = new google.maps.InfoWindow(), marker, j;
        for (j = 0; j < markers.length; j++) {
            var position = new google.maps.LatLng(markers[j].lat, markers[j].lng);
            bounds.extend(position);
            var index = markers[j].order;
            var imgUrl = '../../../../images/markerIcon/blank.png';
            
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
                    var website = '';
                    var url1 = infoWinCnt[j].url.trim();
                    if (infoWinCnt[j].url != undefined && infoWinCnt[j].url.trim() != '') {
                        if (!(infoWinCnt[j].url.trim().startsWith('https') || infoWinCnt[j].url.trim().startsWith('http'))) {
                            url1 = 'http://' + infoWinCnt[j].url.trim();
                        }
                        website = '<br /><a href="' + url1 + '" target="_blank"> Website </a>';
                    }
                    infoWindow.setContent('<span style="font-weight:bold">' + infoWinCnt[j].title + '</span>' + '<br />' + infoWinCnt[j].address1 + '<br />' + infoWinCnt[j].address2 + '<br /><a href="javascript:get_direction(\'' + infoWinCnt[j].address1 + ' ' + infoWinCnt[j].address2 + '\');" id="getDirection"> Get Directions </a>' + website + '<br /><br />Phone: ' + infoWinCnt[j].phone);
                    infoWindow.open(map, marker);
                }
            })(marker, j));

            if (markers.length > 2) {
                map.fitBounds(bounds);
            }            
        }
        if (markers.length > 2) {
            map.fitBounds(bounds);
            map.setCenter(bounds.getCenter());
        }
   
    }
    else {
        var bounds = new google.maps.LatLngBounds(new google.maps.LatLng(25.82, -124.39), new google.maps.LatLng(49.38, -66.94));
        map.fitBounds(bounds);
        map.setCenter(bounds.getCenter());
    }
}

//display locations
function display_loc(loc) {
    var html = [];
    if (loc.length > 0) {
        for (i = 0; i < loc.length; i++) {
            var idx = i + 1;
            var website = '';
            var url1 = loc[i].url.trim();
            if (loc[i].url != undefined && loc[i].url.trim() != '') {
                if (!(loc[i].url.trim().startsWith('https') || loc[i].url.trim().startsWith('http'))) {
                    url1 = 'http://' + loc[i].url.trim();
                }
                website = '<a href="' + url1 + '" target="_blank"> Website </a><br />';
            }
            html.push('<div class="row cct-pad-btm"><div class="xl-col-6 lg-col-12"><span class="store-nm">' + idx + '- ' + loc[i].store + '</span><p>' + loc[i].miles + ' miles</p></div><div class="xl-col-6 lg-col-12"><span>' + loc[i].address1 + '</span><span>' + loc[i].address2 + '</span><span>' + loc[i].phone + '</span>' + website + '<a href="javascript:get_direction(\'' + loc[i].address1 + ' ' + loc[i].address2 + '\');" id="getDirection" > Get Directions </a></div></div>');
        }
        jQuery('#cct_parent').html(html.join(''));
    } else {
        html.push('<p>No location found.</p>');
        jQuery('#cct_parent').html(html.join(''));
    }
}

function get_direction (destination) {
    var start = jQuery(jQuery('.cct-section').find('#txtAddress')).val();
    var dirUrl = 'https://www.google.com/maps/dir/' + start + '/' + destination;
    window.open(dirUrl, '_blank');
}

//get current location
function getCurrentLocation () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(searchUsingCurrLoc, currLocError);
    }
};

//callback - current location success
function searchUsingCurrLoc(position) {
    var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': latlng }, function (results, status) {

        if (status == google.maps.GeocoderStatus.OK) {
            var city = ''; var state = '';
            for (var i = 0, len = results[0].address_components.length; i < len; i++) {
                if (results[0].address_components[i].types == "locality,political") city = results[0].address_components[i].short_name;
                if (results[0].address_components[i].types == "administrative_area_level_1,political") state = results[0].address_components[i].short_name;
            }
            var address = jQuery(jQuery('.cct-section').find('#txtAddress')).val(city + ', ' + state);
            var miles = jQuery(jQuery('.cct-section').find('.cct-milesDdl')).find('.selected').attr('data-value');
            if (address != '' || undefined) {
                jQuery('.cct-section #findLocationBtn')[0].click();
            }           
        }
    });
};

//callback - error
function currLocError(error) {    
    get_geolocaton_block("Washington DC", "6000");   
};

//geo location for all facilities
function get_geolocaton_block(address, miles) {
    var signedUrl = '';
    //get signed url
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
                        successGeocodeBlocked(miles, jQuery.parseJSON(xdr2.responseText));
                    };
                    xdr2.send();
                    xdr2.onerror = function () {
                        errorGeocode(xdr2.responseText);
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
                url: '/api/Sitecore/MyCtColonography/GetSignedUrl',
                data: { "address": address },
                async: false,
                success: function (response) {
                    signedUrl = response;
                },
                error: function (error) {
                    //Please enter a valid city or zip code
                }
            })
        };

        //get location geocode
        jQuery.when(getSignedUrl()).then(function () {
            if (signedUrl != '') {
                jQuery.ajax({
                    url: signedUrl,
                    cache: false,
                    success: function (response2) {
                        successGeocodeBlocked(miles, response2);
                    },
                    error: function (error) {
                        errorGeocode(error);
                    }
                });
            }
        });
    }
}

//success geocode 
function successGeocodeBlocked(miles, response) {
    var lat, lgn = '';
    if (response.status == 'OVER_QUERY_LIMIT') {
        jQuery('#cct_parent').html('<p>Over query limit.</p>');
        init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);
    } else if (response.status == 'ZERO_RESULTS') {
        jQuery('#cct_parent').html('<p>No location found.</p>');
        init_map('map_canvas', '38.943268', '-77.328751', 2, null, null);
    } else if (response.status == 'OK') {
        var resultsArray = response.results;

        if (resultsArray.length == 1) {
            lat = resultsArray[0].geometry.location.lat;
            lng = resultsArray[0].geometry.location.lng;

            var stringUrl = '/api/Sitecore/MyCtColonography/GetLocations';
            jQuery.ajax({
                type: 'Get',
                url: stringUrl,
                accept: 'application/json',
                dataType: 'json',
                data: { "lat": lat, "lng": lng, "miles": miles },
                success: function (response) {
                    successSearchBlocked(response, lat, lng);
                },
                error: function (error) {
                    errorSearch(error);
                }
            })
        } else if (resultsArray.length > 1) {
            //did you mean code
        }
    }
}

//search success
function successSearchBlocked(response, lat, lng) {
    var storeLoc = [];
    var markers = [];
    var infoWinCnt = [];

    if (response.length == 0) {
        jQuery('#cct_parent').html("<p>Enter an address or zip code and click the find locations button.</p>");
        init_map('map_canvas', '38.943268', '-77.328751', 6, null, null);
    } else if (response.length > 0) {
        for (var i = 0; i < response.length; i++) {
            var sResult = new Object();
            sResult.order = i + 1;
            sResult.store = response[i].Store;
            sResult.address1 = response[i].Address1 + ' ' + response[i].Address2;
            sResult.address2 = response[i].City + ', ' + response[i].State + ' ' + response[i].Zip;
            sResult.phone = response[i].Phone;
            sResult.url = response[i].URL;
            sResult.miles = response[i].Miles;
            storeLoc.push(sResult);
            if (!((!(response[i].Latitude) || 0 == (response[i].Latitude).length) || (!(response[i].Longitude) || 0 == (response[i].Longitude).length))) {
                var marker = new Object();
                marker.order = sResult.order;
                marker.title = sResult.store;
                marker.lat = response[i].Latitude;
                marker.lng = response[i].Longitude;
                markers.push(marker);

                var infoWindowCnt = new Object();
                infoWindowCnt.title = sResult.store;
                infoWindowCnt.address1 = sResult.address1;
                infoWindowCnt.address2 = sResult.address2;
                infoWindowCnt.phone = sResult.phone;
                infoWindowCnt.url = sResult.url;
                infoWinCnt.push(infoWindowCnt);
            }
        }
        jQuery('#cct_parent').html("<p>Enter an address or zip code and click the find locations button.</p>");
        init_map('map_canvas', lat, lng, 8, markers, infoWinCnt);
    }
}

//get user agent
function msieversion() {
    var ua = window.navigator.userAgent
    var msie = ua.indexOf("MSIE ")
    if (msie > 0)      // If Internet Explorer, return version number
        return parseInt(ua.substring(msie + 5, ua.indexOf(".", msie)));
    else                 // If another browser, return 0
        return 0;
};