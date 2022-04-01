$(function () {
    //load location map
    getCurrentLocation();
});

//get all locations
function getAllLocations(curr) {
    var stringUrl = '/api/Sitecore/DecampFeatureRenderings/GetAllLocations';
    jQuery.ajax({
        type: 'Get',
        url: '/api/Sitecore/DecampFeatureRenderings/GetAllLocations',
        accept: 'application/json',
        dataType: 'json',
        success: function (response) {
            success(response, curr);
        },
        error: function (error) {
            error(error);
        }
    })
}

//ajax success
function success(response, curr) {
    var decampLoc = [];
    var markers = [];
    var infoWinCnt = [];
    var state_dis = [];     

    if (response.length == 0) {
        display_loc(decampLoc, null);
        init_map('map_canvas', '39.381266', '-97.922211', 13, null, null);
    } else if (response.length > 0) {

        for (var s = 0; s < response.length; s++) {
            if (response[s].State != '') {
                if (state_dis.indexOf(response[s].State) === -1) {
                    state_dis.push(response[s].State);
                }
            }
        }
        state_dis = state_dis.sort();

        for (var i = 0; i < response.length; i++) {

            var sResult = new Object();
            sResult.order = i + 1;
            sResult.siteName = response[i].SiteName;
            sResult.siteAddress = response[i].SiteAddress;
            sResult.state = response[i].State;
            sResult.pI1Name = response[i].PI1Name;
            sResult.pI1BioLink = response[i].PI1BioLink;
            sResult.pI2Name = response[i].PI2Name;
            sResult.pI2BioLink = response[i].PI2BioLink;
            sResult.researchAssociate = response[i].ResearchAssociate;
            sResult.rAEmail = response[i].RAEmail;
            sResult.curLocation = curr != '' ? curr.address : '';
            decampLoc.push(sResult);

            if (!((!(response[i].Latitude) || 0 == (response[i].Latitude).length) || (!(response[i].Longitude) || 0 == (response[i].Longitude).length))) {
                var marker = new Object();
                marker.order = sResult.order;
                marker.title = sResult.siteName;
                marker.lat = response[i].Latitude;
                marker.lng = response[i].Longitude;

                markers.push(marker);

                var infoWindowCnt = new Object();
                infoWindowCnt.title = sResult.siteName;
                infoWindowCnt.address = sResult.siteAddress;
                infoWindowCnt.pI1Name = sResult.pI1Name;
                infoWindowCnt.pI1BioLink = sResult.pI1BioLink;
                infoWindowCnt.pI2Name = sResult.pI2Name;
                infoWindowCnt.pI2BioLink = sResult.pI2BioLink;
                infoWindowCnt.researchAssociate = sResult.researchAssociate;
                infoWindowCnt.rAEmail = sResult.rAEmail;
                infoWindowCnt.curLocation = curr != '' ? curr.address : '';
                infoWinCnt.push(infoWindowCnt);
            }

        }
        display_loc(decampLoc, state_dis);
        if(curr != '')
            init_map('map_canvas', curr.lat, curr.lng, 13, markers, infoWinCnt);
        else
            init_map('map_canvas', '39.381266', '-97.922211', 13, markers, infoWinCnt);
    }
}

//ajax error
function error(error) {
    //error calling store search
}

//display locations
function display_loc(loc, st) {
    var html = [];
    if (st.length > 0) {
        for (var s = 0; s < st.length; s++) {
            html.push('<div class="decamp-location-infoContent pb-40">' + '<h3>' + st[s] + '</h3>');
            for (i = 0; i < loc.length; i++) {
                if (st[s] == loc[i].state) {
                    //var idx = i + 1;

                    var pBioLink1 = loc[i].pI1BioLink; 
                    if (pBioLink1 != undefined && pBioLink1 != '') {
                        pBioLink1 = '<a href="' + loc[i].pI1BioLink + '" target="_blank">' + loc[i].pI1Name + '</a>';
                    } else {
                        pBioLink1 = loc[i].pI1Name
                    }

                    var pBioLink2 = loc[i].pI2BioLink;
                    if (pBioLink2 != undefined && pBioLink2 != '') {
                        pBioLink2 = '<a href="' + loc[i].pI2BioLink + '" target="_blank">' + loc[i].pI2Name + '</a>';
                    } else {
                        pBioLink2 = loc[i].pI2Name
                    }

                    var reassociate = loc[i].researchAssociate;
                    if (reassociate != undefined && reassociate != '') {
                        reassociate = '<p class="mt-20 mb-0">Research Associate:</p>' + loc[i].researchAssociate + '<br /><a href=mailto:' + loc[i].rAEmail + '>' + loc[i].rAEmail + '</a>';
                    }

                    html.push('<p class="mt-20 mb-0 weight-600">' + loc[i].siteName + '</p>' +
                        '<a href="javascript:get_direction(\'' + loc[i].curLocation + '\', \'' + loc[i].siteAddress + '\');" id="getDirection"> Get Directions </a>' +
                        '<p class="mt-20 mb-0">Investigator</p>' +
                        pBioLink1 + '<br />' + pBioLink2 + reassociate);
                }

            }
            html.push('</div>');
        }
        jQuery('.decamp-location').html(html.join(''));
    } else {
        html.push('<p>No location found.</p>');
        jQuery('.decamp-location').html(html.join(''));
    }
}

//get current location
function getCurrentLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(currentLocSuccess, currLocError);
    }
};

//callback - current location success
function currentLocSuccess(position) {
    var current_loc = new Object();
       
    var latlng = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
    var geocoder = new google.maps.Geocoder();
    geocoder.geocode({ 'latLng': latlng }, function (results, status) {

        if (status == google.maps.GeocoderStatus.OK) {
            current_loc.address = results[0].formatted_address;
            current_loc.lat = position.coords.latitude;
            current_loc.lng = position.coords.longitude;
            //var address = results[0].formatted_address;
            getAllLocations(current_loc);
        }
    });
};

//callback - error
function currLocError(error) {
    getAllLocations('');
};

//initiate map
function init_map(map_canvas_id, lat, lng, zm, markers, infoWinCnt) {

    var myLatLng = new google.maps.LatLng(lat, lng);
    var options = {
        zoom: zm,
        minZoom: 4.6,
        center: myLatLng,
        gestureHandling: 'cooperative',
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var map = new google.maps.Map(document.getElementById(map_canvas_id), options);
    var bounds = new google.maps.LatLngBounds();
    if (markers && markers.length > 0) {
        var infoWindow = new google.maps.InfoWindow(), marker, j;
                
        var pos = {
          lat: lat,
          lng: lng
        };

        if(lat != '39.381266' && lng != '-97.922211') {
            var Marker = new google.maps.Marker({
                position: new google.maps.LatLng(lat, lng),
                map: map,
                animation: google.maps.Animation.DROP,            
                icon: '../../../../images/decamp/measle_blue.png'
            });
            infoWindow.setContent('Your location.');
            infoWindow.open(map);
        }        
        infoWindow.setPosition(pos);
        map.setCenter(pos);        
        
        
        var imgUrl = '../../../../images/decamp/custom-pin-icon.png';
        for (j = 0; j < markers.length; j++) {
            var position = new google.maps.LatLng(markers[j].lat, markers[j].lng);
            bounds.extend(position);
            var index = markers[j].order;
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
                    var reassociate = infoWinCnt[j].researchAssociate;
                    if (reassociate != undefined && reassociate != '') {
                        reassociate = '<br /><span style="font-weight:bold">Research Associate:</span><br />' + infoWinCnt[j].researchAssociate + '<br /><a href=mailto:' + infoWinCnt[j].rAEmail + '>' + infoWinCnt[j].rAEmail + '</a>';
                    }
                    //infoWindow.setContent('<span style="font-weight:bold">' + infoWinCnt[j].title + '</span>' + '<br />' + infoWinCnt[j].address + '<br /><a href="javascript:get_direction(\'' + infoWinCnt[j].curLocation + '\', \'' + infoWinCnt[j].address + '\');" id="getDirection"> Get Directions </a>' + '<br /><span style="font-weight:bold">Investigator</span><a href="' + infoWinCnt[j].pI1BioLink + '">' + infoWinCnt[j].pI1Name + '</a><a href="' + infoWinCnt[j].pI2BioLink + '">' + infoWinCnt[j].pI2Name + '</a>' + reassociate);
                    infoWindow.setContent('<span style="font-weight:bold">' + infoWinCnt[j].title + '</span>' + '<br />' + infoWinCnt[j].address + '<br /><a href="javascript:get_direction(\'' + infoWinCnt[j].curLocation + '\', \'' + infoWinCnt[j].address + '\');" id="getDirection"> Get Directions </a>' + reassociate);
                    infoWindow.open(map, marker);
                }
            })(marker, j));
            map.fitBounds(bounds);
        }
        //if (markers.length > 2) {
        //map.fitBounds(bounds);
        //map.setCenter(bounds.getCenter());
        //}
    }
    else {
        var bounds = new google.maps.LatLngBounds(new google.maps.LatLng(25.82, -124.39), new google.maps.LatLng(49.38, -66.94));
        map.fitBounds(bounds);
        map.setCenter(bounds.getCenter());
    }
}

//get direction
function get_direction(start, destination) {
    var dirUrl = 'https://www.google.com/maps/dir/' + start + '/' + destination;
    window.open(dirUrl, '_blank');
}
