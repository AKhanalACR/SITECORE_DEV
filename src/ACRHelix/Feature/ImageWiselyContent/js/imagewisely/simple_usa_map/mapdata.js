jQuery(function ($) {
    var typeUrl = (window.location.href).split('#')[1];
    if (typeUrl != undefined && typeUrl.trim() != '') {
        typeUrl = '#' + typeUrl;
        $('#lnkFilter a').each(function () {
            $(this).removeClass('active');
            if ($(this).attr('href').indexOf(typeUrl) != -1) {
                $(this).addClass('active');
            }
        });
    }
    var type = $('#lnkFilter').find('a.active').text();
    type != undefined ? type : 'Facilities';
    LoadMapWithData(type);
});

$(document).on('click', '#lnkFilter a', function () {

    $('#lnkFilter').find('a.active').removeClass('active');
    $(this).addClass('active');
    var type = $('#lnkFilter').find('a.active').text();
    //$('#fitlerTitle').text('<span>Filter by</span>' + type);
    LoadMapWithData(type);
});

var StatesData = {
    AK: "Alaska",
    AL: "Alabama",
    AR: "Arkansas",
    //AS: "American Samoa",
    AZ: "Arizona",
    CA: "California",
    CO: "Colorado",
    CT: "Connecticut",
    DC: "District Of Columbia",
    DE: "Delaware",
    FL: "Florida",
    GA: "Georgia",
    GU: "Guam",
    HI: "Hawaii",
    IA: "Iowa",
    ID: "Idaho",
    IL: "Illinois",
    IN: "Indiana",
    KS: "Kansas",
    KY: "Kentucky",
    LA: "Louisiana",
    MA: "Massachusetts",
    MD: "Maryland",
    ME: "Maine",
    MI: "Michigan",
    MN: "Minnesota",
    MO: "Missouri",
    MP: "Northern Mariana Islands",
    MS: "Mississippi",
    MT: "Montana",
    NC: "North Carolina",
    ND: "North Dakota",
    NE: "Nebraska",
    NH: "New Hampshire",
    NJ: "New Jersey",
    NM: "New Mexico",
    NV: "Nevada",
    NY: "New York",
    OH: "Ohio",
    OK: "Oklahoma",
    OR: "Oregon",
    PA: "Pennsylvania",
    PR: "Puerto Rico",
    RI: "Rhode Island",
    SC: "South Carolina",
    SD: "South Dakota",
    TN: "Tennessee",
    TX: "Texas",
    UT: "Utah",
    VA: "Virginia",
    //VI: "Virgin Islands",
    VT: "Vermont",
    WA: "Washington",
    WI: "Wisconsin",
    WV: "West Virginia",
    WY: "Wyoming"
}

var JsonCodes2 = [
    { "state": "AK", "Count": 0 },
    { "state": "AL", "Count": 0 },
    { "state": "AR", "Count": 0 },
    //{"state" :"AS", "Count": 0},
    { "state": "AZ", "Count": 0 },
    { "state": "CA", "Count": 0 },
    { "state": "CO", "Count": 0 },
    { "state": "CT", "Count": 0 },
    //{"state" :"CZ", "Count": 0},
    { "state": "DC", "Count": 0 },
    { "state": "DE", "Count": 0 },
    { "state": "FL", "Count": 0 },
    { "state": "GA", "Count": 0 },
    { "state": "GU", "Count": 0 },
    { "state": "HI", "Count": 0 },
    { "state": "IA", "Count": 0 },
    { "state": "ID", "Count": 0 },
    { "state": "IL", "Count": 0 },
    { "state": "IN", "Count": 0 },
    { "state": "KS", "Count": 0 },
    { "state": "KY", "Count": 0 },
    { "state": "LA", "Count": 0 },
    { "state": "MA", "Count": 0 },
    { "state": "MD", "Count": 0 },
    { "state": "ME", "Count": 0 },
    //{"state" :"MH", "Count": 0},
    { "state": "MI", "Count": 0 },
    { "state": "MN", "Count": 0 },
    { "state": "MO", "Count": 0 },
    { "state": "MP", "Count": 0 },
    { "state": "MS", "Count": 0 },
    { "state": "MT", "Count": 0 },
    { "state": "NC", "Count": 0 },
    { "state": "ND", "Count": 0 },
    { "state": "NE", "Count": 0 },
    { "state": "NH", "Count": 0 },
    { "state": "NJ", "Count": 0 },
    { "state": "NM", "Count": 0 },
    { "state": "NV", "Count": 0 },
    { "state": "NY", "Count": 0 },
    { "state": "OH", "Count": 0 },
    { "state": "OK", "Count": 0 },
    { "state": "OR", "Count": 0 },
    { "state": "PA", "Count": 0 },
    { "state": "PR", "Count": 0 },
    //{"state" :"PW", "Count": 0},
    { "state": "RI", "Count": 0 },
    { "state": "SC", "Count": 0 },
    { "state": "SD", "Count": 0 },
    { "state": "TN", "Count": 0 },
    { "state": "TX", "Count": 0 },
    { "state": "UT", "Count": 0 },
    { "state": "VA", "Count": 0 },
    //{"state" :"VI", "Count": 0},
    { "state": "VT", "Count": 0 },
    { "state": "WA", "Count": 0 },
    { "state": "WI", "Count": 0 },
    { "state": "WV", "Count": 0 },
    { "state": "WY", "Count": 0 }
]

var LatLanData = [
    { "lat": "19.599", "lng": " -155.519", "name": "Hawaii", "Code": "HI" },
    { "lat": " 63.174", "lng": " -153.704", "name": "Alaska", "Code": "AK" },
    { "lat": " 28.493", "lng": " -82.472", "name": "Florida", "Code": "FL" },
    { "lat": " 43.686", "lng": " -71.578", "name": "New Hampshire", "Code": "NH" },
    { "lat": " 44.075", "lng": " -72.663", "name": "Vermont", "Code": "VT" },
    { "lat": " 45.315", "lng": " -69.204", "name": "Maine", "Code": "ME" },
    { "lat": " 41.489", "lng": " -71.454", "name": "Rhode Island", "Code": "RI" },
    { "lat": " 40.715", "lng": " -74.007", "name": "New York", "Code": "NY" },
    { "lat": " 40.897", "lng": " -77.839", "name": "Pennsylvania", "Code": "PA" },
    { "lat": " 40.139", "lng": " -74.677", "name": "New Jersey", "Code": "NJ" },
    { "lat": " 39.008", "lng": " -75.467", "name": "Delaware", "Code": "DE" },
    { "lat": " 38.953", "lng": " -76.701", "name": "Maryland", "Code": "MD" },
    { "lat": " 37.513", "lng": " -78.698", "name": "Virginia", "Code": "VA" },
    { "lat": " 38.642", "lng": " -80.614", "name": "West Virginia", "Code": "WV" },
    { "lat": " 40.413", "lng": " -82.711", "name": "Ohio", "Code": "OH" },
    { "lat": " 39.92", "lng": " -86.282", "name": "Indiana", "Code": "IN" },
    { "lat": " 40.114", "lng": " -89.159", "name": "Illinois", "Code": "IL" },
    { "lat": " 41.574", "lng": " -72.738", "name": "Connecticut", "Code": "CT" },
    { "lat": " 44.642", "lng": " -89.737", "name": "Wisconsin", "Code": "WI" },
    { "lat": " 35.539", "lng": " -79.185", "name": "North Carolina", "Code": "NC" },
    { "lat": " 38.906", "lng": " -77.017", "name": "District of Columbia", "Code": "DC" },
    { "lat": " 42.156", "lng": " -71.566", "name": "Massachusetts", "Code": "MA" },
    { "lat": " 35.843", "lng": " -86.343", "name": "Tennessee", "Code": "TN" },
    { "lat": " 34.9", "lng": " -92.439", "name": "Arkansas", "Code": "AR" },
    { "lat": " 38.368", "lng": " -92.478", "name": "Missouri", "Code": "MO" },
    { "lat": " 32.648", "lng": " -83.445", "name": "Georgia", "Code": "GA" },
    { "lat": " 33.904", "lng": " -80.894", "name": "South Carolina", "Code": "SC" },
    { "lat": " 37.527", "lng": " -85.288", "name": "Kentucky", "Code": "KY" },
    { "lat": " 32.767", "lng": " -86.84", "name": "Alabama", "Code": "AL" },
    { "lat": " 30.967", "lng": " -91.852", "name": "Louisiana", "Code": "LA" },
    { "lat": " 32.722", "lng": " -89.656", "name": "Mississippi", "Code": "MS" },
    { "lat": " 42.075", "lng": " -93.5", "name": "Iowa", "Code": "IA" },
    { "lat": " 46.349", "lng": " -94.198", "name": "Minnesota", "Code": "MN" },
    { "lat": " 35.583", "lng": " -97.509", "name": "Oklahoma", "Code": "OK" },
    { "lat": " 31.463", "lng": " -99.333", "name": "Texas", "Code": "TX" },
    { "lat": " 34.421", "lng": " -106.108", "name": "New Mexico", "Code": "NM" },
    { "lat": " 38.485", "lng": " -98.38", "name": "Kansas", "Code": "KS" },
    { "lat": " 41.527", "lng": " -99.811", "name": "Nebraska", "Code": "NE" },
    { "lat": " 44.436", "lng": " -100.231", "name": "South Dakota", "Code": "SD" },
    { "lat": " 47.446", "lng": " -100.469", "name": "North Dakota", "Code": "ND" },
    { "lat": " 43", "lng": " -107.552", "name": "Wyoming", "Code": "WY" },
    { "lat": " 47.033", "lng": " -109.645", "name": "Montana", "Code": "MT" },
    { "lat": " 38.999", "lng": " -105.548", "name": "Colorado", "Code": "CO" },
    { "lat": " 39.324", "lng": " -111.678", "name": "Utah", "Code": "UT" },
    { "lat": " 34.293", "lng": " -111.665", "name": "Arizona", "Code": "AZ" },
    { "lat": " 39.356", "lng": " -116.655", "name": "Nevada", "Code": "NV" },
    { "lat": " 43.939", "lng": " -120.559", "name": "Oregon", "Code": "OR" },
    { "lat": " 48.839", "lng": " -121.559", "name": "Washington", "Code": "WA" },
    { "lat": " 37.255", "lng": " -119.618", "name": "California", "Code": "CA" },
    { "lat": " 44.863", "lng": " -85.735", "name": "Michigan", "Code": "MI" },
    { "lat": " 44.389", "lng": " -114.659", "name": "Idaho", "Code": "ID" },
    { "lat": " 36.907", "lng": " -89.829", "name": "Guam", "Code": "GU" },
    //{"lat" : " 39.496" , "lng" : " -98.99" , "name" :"Virgin Islands", "Code":"VI"},
    { "lat": " 26.65", "lng": " -98.351", "name": "Puerto Rico", "Code": "PR" },
    { "lat": " 16.617", "lng": " 145.617", "name": "Northern Mariana Islands", "Code": "MP" }
]

var dict = new Object();

var latLang = new Object();

function LoadMapWithData(type) {
    var assoc = 1;
    assoc = (type == "Associations and Educational Programs") ? 2 : assoc;

    //reset count
    Customstate_specific('', 0, type);

    $.ajax({
        type: "GET",
        url: "/api/Sitecore/ImageWiselyContent/GetAssocFacilitiesPledgeCount",
        datatype: "json",
        data: { t: assoc },
        success: function (data) {
            $.each(data, function (index, d) {
                //console.log(d.State + ' ' + d.Count);
                simplemaps_usmap_mapdata.state_specific.description = Customstate_specific(d.State, d.Count, type);
            });
            simplemaps_usmap.load();
        },
        error: function () {
            //alert("Dynamic content load failed.");
        }
    });
}

var Customstate_specific = function Customstate_specific(st, cnt, type) {
    var Count = parseInt(cnt);
    var _FilObj = LatLanData.filter(function (a) {
        return a.Code == st;
    });

    if (_FilObj[0] != undefined) {
        var incItemInt = Object.keys(latLang).length;
        var incItem = "\"'" + incItemInt + "'\"";

        dict[st] = {
            name: _FilObj[0].name,
            description: Count + ' ' + type + ' (' + _FilObj[0].Code + ')',
            color: ColorDiffernce(Count, _FilObj[0].Code, type),
            hover_color: "default",
            url: "javascript:Openpop('" + Count + "," + _FilObj[0].Code + "," + type + "')"
        };

    }
    return dict;
}

function ColorDiffernce(count, StateCode, type) {
    var Count = parseInt(count);

    if (Count <= 0) {
        return '#224b81';
    } else {
        var _FilObj = LatLanData.filter(function (a) {
            return a.Code == StateCode;
        });
        if (_FilObj[0] != undefined) {
            var incItemInt = Object.keys(latLang).length;
            var incItem = "\"'" + incItemInt + "'\"";

            latLang[incItem] = {
                name: _FilObj[0].name,
                lat: parseInt(_FilObj[0].lat),
                lng: parseInt(_FilObj[0].lng),
                description: Count + ' ' + type + ' (' + _FilObj[0].Code + ')',
                color: "default",
                url: "javascript:Openpop('" + count + "," + _FilObj[0].Code + "," + type + "')",
                type: "image",
                size: "default",
                image_url: '/images/imagewisely/owl_icon.png'
            }
        }
        return '#224b81';
    }
}

var simplemaps_usmap_mapdata = {
    main_settings: {
        //General settings
        width: 'responsive',
        background_color: "#FFFFFF",
        background_transparent: "yes",
        popups: "detect",

        //State defaults
        state_description: "State description",
        state_color: "#224b81",
        state_hover_color: "#8a6a51",
        // state_url: "https://simplemaps.com",
        border_size: 1,
        border_color: "#20558b",
        all_states_inactive: "no",
        all_states_zoomable: "no",

        //Location defaults
        //location_description: "Location description",
        location_color: "#FF0067",
        location_opacity: 0.8,
        location_hover_opacity: 1,
        location_url: "",
        location_size: 25,
        location_type: "square",
        location_border_color: "#fff",
        location_border: 1,
        location_hover_border: 1,
        all_locations_inactive: "no",
        all_locations_hidden: "no",

        //Label defaults
        label_color: "#4e759e",
        label_hover_color: "#4e759e",
        label_size: 16,
        label_font: "Oswald, sans-serif",
        hide_labels: "no",

        //Zoom settings
        manual_zoom: "no",
        back_image: "no",
        arrow_box: "no",
        navigation_size: "40",
        navigation_color: "#f7f7f7",
        navigation_border_color: "#636363",
        initial_back: "no",
        initial_zoom: -1,
        initial_zoom_solo: "no",
        region_opacity: 1,
        region_hover_opacity: 0.6,
        zoom_out_incrementally: "yes",
        zoom_percentage: 0.99,
        zoom_time: 0.5,

        //Popup settings
        popup_color: "white",
        popup_opacity: 0.9,
        popup_shadow: 1,
        popup_corners: 5,
        //popup_font: "12px/1.5 Verdana, Arial, Helvetica, sans-serif",
        popup_nocss: "no",

        //Advanced settings
        div: "map",
        auto_load: "no",
        rotate: "0",
        url_new_tab: "yes",
        images_directory: "default",
        import_labels: "no",
        fade_time: 0.1,
        link_text: "View more"
    },
    state_specific: Customstate_specific(),
    locations: latLang,
    labels: {
        NH: {
            parent_id: "NH",
            x: "932",
            y: "183",
            pill: "yes",
            width: 45,
            display: "all"
        },
        VT: {
            parent_id: "VT",
            x: "883",
            y: "243",
            pill: "yes",
            width: 45,
            display: "all"
        },
        RI: {
            parent_id: "RI",
            x: "932",
            y: "273",
            pill: "yes",
            width: 45,
            display: "all"
        },
        NJ: {
            parent_id: "NJ",
            x: "883",
            y: "273",
            pill: "yes",
            width: 45,
            display: "all"
        },
        DE: {
            parent_id: "DE",
            x: "883",
            y: "303",
            pill: "yes",
            width: 45,
            display: "all"
        },
        MD: {
            parent_id: "MD",
            x: "932",
            y: "303",
            pill: "yes",
            width: 45,
            display: "all"
        },
        DC: {
            parent_id: "DC",
            x: "884",
            y: "332",
            pill: "yes",
            width: 45,
            display: "all"
        },
        MA: {
            parent_id: "MA",
            x: "932",
            y: "213",
            pill: "yes",
            width: 45,
            display: "all"
        },
        CT: {
            parent_id: "CT",
            x: "932",
            y: "243",
            pill: "yes",
            width: 45,
            display: "all"
        },
        HI: {
            parent_id: "HI",
            x: 305,
            y: 565,
            pill: "yes"
        },
        AK: {
            parent_id: "AK",
            x: "113",
            y: "495"
        },
        FL: {
            parent_id: "FL",
            x: "773",
            y: "510"
        },
        ME: {
            parent_id: "ME",
            x: "893",
            y: "85"
        },
        NY: {
            parent_id: "NY",
            x: "815",
            y: "158"
        },
        PA: {
            parent_id: "PA",
            x: "786",
            y: "210"
        },
        VA: {
            parent_id: "VA",
            x: "790",
            y: "282"
        },
        WV: {
            parent_id: "WV",
            x: "744",
            y: "270"
        },
        OH: {
            parent_id: "OH",
            x: "700",
            y: "240"
        },
        IN: {
            parent_id: "IN",
            x: "650",
            y: "250"
        },
        IL: {
            parent_id: "IL",
            x: "600",
            y: "250"
        },
        WI: {
            parent_id: "WI",
            x: "575",
            y: "155"
        },
        NC: {
            parent_id: "NC",
            x: "784",
            y: "326"
        },
        TN: {
            parent_id: "TN",
            x: "655",
            y: "340"
        },
        AR: {
            parent_id: "AR",
            x: "548",
            y: "368"
        },
        MO: {
            parent_id: "MO",
            x: "548",
            y: "318"
        },
        GA: {
            parent_id: "GA",
            x: "718",
            y: "405"
        },
        SC: {
            parent_id: "SC",
            x: "760",
            y: "371"
        },
        KY: {
            parent_id: "KY",
            x: "680",
            y: "300"
        },
        AL: {
            parent_id: "AL",
            x: "655",
            y: "405"
        },
        LA: {
            parent_id: "LA",
            x: "550",
            y: "435"
        },
        MS: {
            parent_id: "MS",
            x: "600",
            y: "405"
        },
        IA: {
            parent_id: "IA",
            x: "518",
            y: "210"
        },
        MN: {
            parent_id: "MN",
            x: "495",
            y: "124"
        },
        OK: {
            parent_id: "OK",
            x: "440",
            y: "360"
        },
        TX: {
            parent_id: "TX",
            x: "425",
            y: "472"
        },
        NM: {
            parent_id: "NM",
            x: "305",
            y: "390"
        },
        KS: {
            parent_id: "KS",
            x: "430",
            y: "290"
        },
        NE: {
            parent_id: "NE",
            x: "415",
            y: "225"
        },
        SD: {
            parent_id: "SD",
            x: "405",
            y: "160"
        },
        ND: {
            parent_id: "ND",
            x: "410",
            y: "96"
        },
        WY: {
            parent_id: "WY",
            x: "300",
            y: "180"
        },
        MT: {
            parent_id: "MT",
            x: "277",
            y: "103"
        },
        CO: {
            parent_id: "CO",
            x: "320",
            y: "275"
        },
        UT: {
            parent_id: "UT",
            x: "215",
            y: "270"
        },
        AZ: {
            parent_id: "AZ",
            x: "205",
            y: "360"
        },
        NV: {
            parent_id: "NV",
            x: "140",
            y: "260"
        },
        OR: {
            parent_id: "OR",
            x: "100",
            y: "120"
        },
        WA: {
            parent_id: "WA",
            x: "130",
            y: "55"
        },
        ID: {
            parent_id: "ID",
            x: "200",
            y: "170"
        },
        CA: {
            parent_id: "CA",
            x: "79",
            y: "285"
        },
        MI: {
            parent_id: "MI",
            x: "663",
            y: "185"
        },
        /*
        PR: {
          parent_id: "PR",
          x: "620",
          y: "545"
        },
        */
        GU: {
            parent_id: "GU",
            x: "550",
            y: "540"
        },
        /*VI: {
          parent_id: "VI",
          x: "680",
          y: "519"
        },
        */
        MP: {
            parent_id: "MP",
            x: "570",
            y: "575"
        }
        /*,
        AS: {
          parent_id: "AS",
          x: "665",
          y: "580"
        }
        */
    }
};

function Openpop(sttype) {
    var cnt = sttype.split(',')[0];
    var statuscode = sttype.split(',')[1];
    var type = sttype.split(',')[2];

    $.each(JsonCodes2, function (index, value) {
        var count = parseInt(value.Count);
        if (value.state == statuscode) {
            var states = LatLanData.filter(function (a) {
                return a.Code == value.state;
            });
            count = parseInt(cnt);
            var _statename = states[0].name;
            $("#ModelStateName").text(_statename + ' ' + type + ' (' + count + ')');
            $("#ModelNoStateName").text(_statename + ' ' + type + ' (' + count + ')');
        }
    });

    var assoc = 1;
    assoc = (type == "Associations and Educational Programs") ? 2 : assoc;

    $.ajax({
        type: "GET",
        url: "/api/Sitecore/ImageWiselyContent/GetStateAssocFacilitiesPledge",
        datatype: "json",
        data: { state: statuscode, t: assoc },
        success: function (data) {
            var cities = [];
            $.each(data, function (index, d) {
                cities.push(d.City);
            });

            var uCities = [];
            $.each(cities, function (i, e) {
                if ($.inArray(e, uCities) == -1)
                    uCities.push(e);
            });

            var html = [];
            $.each(uCities, function (index, d) {
                html.push('<div class="child" style="padding-bottom:10px;"><h4>' + d + '</h4>');
                $.each(data, function (ii, dd) {
                    if (d == dd.City) {
                        html.push('<p style="padding-left:10px; margin-top:5px; margin-bottom:5px;">' + dd.Institution + '</p>');
                    }
                });
                html.push('</div>');
            });
            if (html.length > 0) {
                $('#parent').html(html.join(''));
                $("#FacilityModal").modal('show');
            } else {
                $("#NoFacilityModal").modal('show');
            }
        },
        error: function () {
            //alert("Dynamic content load failed.");
        }
    });
}
