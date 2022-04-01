var MergeFacilityPhysician = new Array(),
    Physician = new Array(),
    facility = new Array(),
    DynamicType = new Array(),
    mainArrya = new Array(),
    data1 = [],
    mainDataObject = {},
    StateObj = {},
    DynamicDataSet = {},
    StaticStateData = {
        AL: "Alabama",
        AK: "Alaska",
        AS: "American Samoa",
        AZ: "Arizona",
        AR: "Arkansas",
        CA: "California",
        CO: "Colorado",
        CT: "Connecticut",
        DE: "Delaware",
        DC: "District Of Columbia",
        FM: "Federated States Of Micronesia",
        FL: "Florida",
        GA: "Georgia",
        GU: "Guam",
        HI: "Hawaii",
        ID: "Idaho",
        IL: "Illinois",
        IN: "Indiana",
        IA: "Iowa",
        KS: "Kansas",
        KY: "Kentucky",
        LA: "Louisiana",
        ME: "Maine",
        MH: "Marshall Islands",
        MD: "Maryland",
        MA: "Massachusetts",
        MI: "Michigan",
        MN: "Minnesota",
        MS: "Mississippi",
        MO: "Missouri",
        MT: "Montana",
        NE: "Nebraska",
        NV: "Nevada",
        NH: "New Hampshire",
        NJ: "New Jersey",
        NM: "New Mexico",
        NY: "New York",
        NC: "North Carolina",
        ND: "North Dakota",
        MP: "Northern Mariana Islands",
        OH: "Ohio",
        OK: "Oklahoma",
        OR: "Oregon",
        PW: "Palau",
        PA: "Pennsylvania",
        PR: "Puerto Rico",
        RI: "Rhode Island",
        SC: "South Carolina",
        SD: "South Dakota",
        TN: "Tennessee",
        TX: "Texas",
        UT: "Utah",
        VT: "Vermont",
        VI: "Virgin Islands",
        VA: "Virginia",
        WA: "Washington",
        WV: "West Virginia",
        WI: "Wisconsin",
        WY: "Wyoming",
    };
function setActiveTab(a) {
    $("#MapDetailList li").removeClass("active"), (a.parentElement.className = "active");
}
function get_geolocaton(a, e, t) {
    var n = "";
    $.when(
        void $.ajax({
            type: "Get",
            url: "/api/Sitecore/IdeasContent/GetSignedUrl",
            data: { address: a },
            async: !1,
            success: function (a) {
                n = a;
            },
            error: function (a) {
                alert("Error");
            },
        })
    ).then(function () {
        "" != n &&
            $.ajax({
                url: n,
                cache: !1,
                success: function (n) {
                    successGeocode(e, n, a, t);
                },
                error: function (a) {
                    errorGeocode(a);
                },
            });
    });
}
function successGeocode(a, e, t, n) {
    var i;
    if ("OVER_QUERY_LIMIT" == e.status) $("#info_div").html("<p>Over query limit.</p>"), init_map("map", "38.943268", "-77.328751", 2, null, null);
    else if ("ZERO_RESULTS" == e.status) {
        var o = $("#inputOption").val();
        null != o && 2 == o
            ? $("#info_div").html('<p style="color:red; font-weight:bold">' + $("#PhysicianErrorMessage").val().replace("{0}", "physician") + "</p>")
            : null != o && 1 == o && $("#info_div").html('<p style="color:red; font-weight:bold">' + $("#FacilitiesErrorMessage").val().replace("{0}", "facilities") + "</p>"),
            init_map("map", "38.943268", "-77.328751", 2, null, null);
    } else if ("OK" == e.status) {
        var s = e.results;
        if (1 == s.length) {
            (i = s[0].geometry.location.lat), (lng = s[0].geometry.location.lng);
            jQuery.ajax({
                type: "Get",
                url: "/api/Sitecore/IdeasContent/GetLocations",
                accept: "application/json",
                dataType: "json",
                data: { lat: i, lng: lng, Zip: t, Type: n, miles: a },
                success: function (a) {
                    successSearch(a, i, lng);
                },
                error: function (a) {
                    errorSearch(a);
                },
            });
        } else s.length;
    }
}
function successSearch(response, lat, lng) {
    var storeLoc = [],
        markers = [],
        infoWinCnt = [];
    if (0 == response.data.length) display_loc(storeLoc), init_map("map", "38.943268", "-77.328751", 2, null, null);
    else if (response.data.length > 0) {
        for (var i = 0; i < response.data.length; i++) {
            var streetSpace = response.data[i].STREET ? response.data[i].STREET != "" ? ", " : "" : "";
            var street2Space = response.data[i].STREET2 ? response.data[i].STREET2 != "" ? ", " : "" : "";
            var citySpace = response.data[i].CITY ? response.data[i].CITY != "" ? ", " : "" : "";
            var sResult = new Object();
            if (
                ((sResult.order = i + 1),
                    (sResult.NAME = response.data[i].NAME),
                    (sResult.STREET = response.data[i].STREET + streetSpace + response.data[i].STREET2 + street2Space  ),
                    (sResult.STREET2 = response.data[i].CITY + citySpace + response.data[i].STATE_ID + "  " + response.data[i].ZIP+" | "),
                    (sResult.PHONE = response.data[i].PHONE+" "),
                    (sResult.Miles = response.data[i].Miles),
                    storeLoc.push(sResult),
                    response.data[i].LATITUDE && 0 != response.data[i].LATITUDE.length && response.data[i].LONGITUDE && 0 != response.data[i].LONGITUDE.length)
            ) {
                var marker = new Object();
                (marker.order = sResult.order),
                    (marker.title = sResult.NAME),
                    (marker.lat = eval(response.data[i].LATITUDE) + (Math.random() - 0.5) / 1500),
                    (marker.lng = eval(response.data[i].LONGITUDE) + (Math.random() - 0.5) / 1500),
                    markers.push(marker);
                var infoWindowCnt = new Object();
                (infoWindowCnt.title = sResult.NAME), (infoWindowCnt.STREET = sResult.STREET), (infoWindowCnt.STREET2 = sResult.STREET2), infoWinCnt.push(infoWindowCnt);
            }
        }
        display_loc(storeLoc), init_map("map", lat, lng, 2, markers, infoWinCnt);
    }
}
function display_loc(a) {
    var e = [];
    if (a.length > 0) {
        for (i = 0; i < a.length; i++)
            e.push(
                '<div class="row cct-pad-btm"><div style="margin-top: 10px;" class="col-xl-12 col-lg-12"><span style="margin-bottom:5px; font-weight:bold; display:block;" class="store-nm">' +
                a[i].NAME +
                '</span><div class=""><span>' +
                a[i].STREET +
                "</span><span>" +
                a[i].STREET2 +
                "</span>" + '<a href="tel: ' + a[i].PHONE + '">' + a[i].PHONE + '</a >' +                 
                "<a href=\"javascript:get_direction('" +
                a[i].STREET +
                " " +
                a[i].STREET2 +
                '\');" id="getDirection" > Get Directions </a></div></div></div>'
            );
        $("#info_div").html(e.join(""));
    } else {
        var t = $("#inputOption").val();
        null != t && 2 == t
            ? e.push('<p style="color:red; font-weight:bold">' + $("#PhysicianErrorMessage").val().replace("{0}", "physician") + "</p>")
            : null != t && 1 == t && e.push('<p style="color:red; font-weight:bold">' + $("#FacilitiesErrorMessage").val().replace("{0}", "facilities") + "</p>"),
            $("#info_div").html(e.join(""));
    }
}
function init_map(a, e, t, n, i, o) {
    var s = { zoom: n, center: new google.maps.LatLng(e, t), mapTypeId: google.maps.MapTypeId.ROADMAP },
        l = new google.maps.Map(document.getElementById(a), s),
        r = new google.maps.LatLngBounds();
    if (i && i.length > 0) {
        var c,
            d,
            u = new google.maps.InfoWindow();
        for (d = 0; d < i.length; d++) {
            var p = new google.maps.LatLng(i[d].lat, i[d].lng);
            r.extend(p);
            var g = new google.maps.MarkerImage("../../../../images/markerIcon/blank.png", null, null, null, new google.maps.Size(20, 30));
            (c = new google.maps.Marker({ position: p, map: l, title: i[d].title, icon: g })),
                google.maps.event.addListener(
                    c,
                    "click",
                    (function (a, e) {
                        return function () {
                            u.setContent(
                                '<span style="font-weight:bold">' +
                                o[e].title +
                                "</span><br />" +
                                o[e].STREET +
                                "<br />" +
                                o[e].STREET2 +
                                "<br /><a href=\"javascript:get_direction('" +
                                o[e].STREET +
                                " " +
                                o[e].STREET2 +
                                '\');" id="getDirection"> Get Directions </a>'
                            ),
                                u.open(l, a);
                        };
                    })(c, d)
                ),
                l.fitBounds(r);
        }
        l.fitBounds(r), l.setCenter(r.getCenter());
    } else {
        r = new google.maps.LatLngBounds(new google.maps.LatLng(25.82, -124.39), new google.maps.LatLng(49.38, -66.94));
        l.fitBounds(r), l.setCenter(r.getCenter());
    }
}
function get_direction(a) {
    var e = $("#inputCity").val();
    "" != $("#CurrentLocationLatlang").val() && null != $("#CurrentLocationLatlang").val() && (e = $("#CurrentLocationLatlang").val());
    var t = "https://www.google.com/maps/dir/" + e + "/" + a;
    window.open(t, "_blank");
}
function geoloc(a, e) {
    var t = !1;
    navigator && navigator.geolocation
        ? navigator.geolocation.getCurrentPosition(
            function (e) {
                t || ((t = !0), a(e.coords.latitude, e.coords.longitude));
            },
            function () {
                t || ((t = !0), e());
            }
        )
        : e();
}
function success(a, e) {
    $("#CurrentLocationLatlang").val(a + "," + e), init_map("map", a, e, 2, null, null);
}
function fail() {
    init_map("map", "38.943268", "-77.328751", 2, null, null);
}
function doSomething() {
    localStorage.setItem("PathId", $(this).attr("data-id")), SetFocusForMap();
}
function SetFocusForMap() {
    var a = document.getElementsByTagName("path");
    if (null != a && null != a) for (i = 0; i < a.length; i++) null != a[i] && a[i].dataset.id == localStorage.getItem("PathId") ? (a[i].style.fill = "rgb(51, 122, 183)") : null != a[i] && "rgb(51, 122, 183)" == a[i].style.fill && (a[i].style.fill = "");
}
$(document).ready(function () {
    var a = document.getElementById("HasMapContent");
    null != a &&
        null != a &&
        $.ajax({
            type: "GET",
            url: "/api/Sitecore/IdeasContent/GetMapData",
            datatype: "json",
            data: {},
            success: function (a) {
                for (var e = "", t = "", n = 0; n < a.StateList.length; n++) {
                    (e = ""), (facility = []), (Physician = []), (MergeFacilityPhysician = []);
                    for (var i = 0; i < a.data.length; i++)
                        a.data[i].Sta_ID == a.StateList[n] &&
                            ((e = a.data[i].Sta_name),
                                (t = a.StateList[n]),
                                1 == a.data[i].Physician
                                    ? Physician.push({ name: a.data[i].NAME, phone: a.data[i].PHONE, address: a.data[i].FullAddress })
                                    : facility.push({ name: a.data[i].NAME, phone: a.data[i].PHONE, address: a.data[i].FullAddress }),
                                delete StaticStateData[t]);
                    MergeFacilityPhysician.push({ name: e, facility: facility, physician: Physician }), (StateObj[t] = MergeFacilityPhysician[0]);
                }
                for (var o in StaticStateData)
                    (facility = []),
                        (Physician = []),
                        (MergeFacilityPhysician = []),
                        StaticStateData.hasOwnProperty(o) && (MergeFacilityPhysician.push({ name: StaticStateData[o], facility: facility, physician: Physician }), (StateObj[o] = MergeFacilityPhysician[0]));
                function s(a) {
                    var e = "";
                    return 0 == a && (e = "active"), e;
                }
                function l(a, e) {
                    var t = "";
                    if ("position" == e)
                        switch (a) {
                            case "MI":
                            case "LA":
                            case "VA":
                            case "ID":
                                t = "left";
                                break;
                            case "DE":
                            case "DC":
                            case "RI":
                            case "MN":
                            case "CA":
                                t = "right";
                                break;
                            case "NH":
                                t = "bottom";
                                break;
                            case "VT":
                            case "MD":
                                t = "top";
                                break;
                            case "FL":
                                t = "left";
                                break;
                            default:
                                t = "inner";
                        }
                    else
                        switch (a) {
                            case "MI":
                            case "VA":
                            case "CA":
                                t = -100;
                                break;
                            case "LA":
                                t = -40;
                                break;
                            case "DE":
                            case "DC":
                                t = 40;
                                break;
                            case "RI":
                                t = 30;
                                break;
                            case "NH":
                            case "MD":
                                t = -15;
                                break;
                            case "VT":
                                t = -20;
                                break;
                            case "ID":
                                t = -50;
                                break;
                            case "MN":
                                t = -90;
                                break;
                            case "FL":
                                t = -135;
                                break;
                            default:
                                t = 0;
                        }
                    return t;
                }
                function r(a) {
                    var e = {};
                    for (var t in a.data)
                        e[t] = {
                            text: { content: t, href: "#", attrs: { "font-size": "CT" == t || "MA" == t ? 13 : 16, "font-weight": 700, fill: "#edeff1" }, position: l(t, "position"), margin: l(t, "margin") },
                            myText: c(a.data[t], a.type),
                            tooltip: { content: '<div style="font-weight:bold;">' + a.data[t].name + "</div>Facilities: " + a.data[t].facility.length + "<div></div>Physician: " + a.data[t].physician.length },
                        };
                    return e;
                }
                function c(a, e) {
                    var t = "<h2>" + a.name + "</h2><br/>";
                    return (
                        (t += (function (a) {
                            var e = "";
                            if (null != a && "object" == typeof a)
                                return (
                                    (e += '<ul id="MapDetailList" class="nav mb-4 align-items-center d-flex justify-content-center">'),
                                    a.forEach(function (a, t) {
                                        e += '<li class="' + s(t) + '"><a onclick="setActiveTab(this)" class="btn btn-ideas" href="#' + a.id + '" data-toggle="tab">' + a.title + "</a></li>";
                                    }),
                                    (e += "</ul>")
                                );
                        })(e)),
                        (t += '<div class="tab-content">'),
                        e.forEach(function (e, n) {
                            t += (function (a, e, t) {
                                var n = "";
                                return (
                                    null != e &&
                                    "object" == typeof e &&
                                    ((n += '<div class="tab-pane ' + s(t) + '" id="' + a.id + '">'),
                                        e[a.id].forEach(function (a, e) {
                                            n += "<dl><dt><div style='font-weight:600;'>" + a.name + "</div><div>" + a.address + ' | <a href="tel:' + a.phone + '">' + a.phone + "</a></div></dt></dl>";
                                        }),
                                        (n += "</div>")),
                                    n
                                );
                            })(e, a, n);
                        }),
                        (t += "</div>")
                    );
                }
                (dataSet = {
                    type: [
                        { id: "physician", title: "Memory Doctor" },
                        { id: "facility", title: "PET Facility" },
                    ],
                    data: StateObj,
                }),
                    $(function () {
                        $(".mapcontainer").mapael({
                            map: {
                                name: "usa_states",
                                zoom: { enabled: !0, mousewheel: !1, animDuration: 250, animEasing: "backIn" },
                                defaultArea: {
                                    attrs: { fill: "#00456a", stroke: "#337ab7", cursor: "pointer" },
                                    attrsHover: { fill: "#8957b6", animDuration: 0 },
                                    eventHandlers: {
                                        mousedown: function (a, e, t, n, i) {
                                            void 0 !== i.myText && $(".myText span").html(i.myText).css({ display: "none" }).fadeIn("fast");
                                            var elem = document.getElementsByClassName("myText")[0];                                            
                                            elem.scrollIntoView();
                                        },
                                    },
                                },
                            },
                            areas: r(dataSet),
                        });
                    });
            },
            error: function () { },
        });
}),
    $(document).on("click", "#findLocationBtn", function (a) {
        a.preventDefault(), a.stopPropagation();
        var e = document.getElementById("map");
        if (null != e && null != e) {
            var t = !1;
            if (
                ((null != $("#inputCity").val() && "" != $("#inputCity").val()) || ($("#inputCity").css("border-color", "red"), (t = !0)),
                    (null != $("#inputOption").val() && "" != $("#inputOption").val() && "0" != $("#inputOption").val()) || ($("#inputOption").css("border-color", "red"), (t = !0)),
                    t)
            )
                return !1;
            get_geolocaton($("#inputCity").val(), $("#inputDistance").val(), "2" == $("#inputOption").val() ? "1" : "0");
        }
    }),
    $(document).ready(function () {
        var a = document.getElementById("map");
        null != a && null != a && geoloc(success, fail),
            $("#inputOption").change(function () {
                "0" != $("option:selected", $(this)).text() && $("#inputOption").css("border-color", "rgba(0, 0, 0, 0.1)");
            }),
            $("#inputCity").blur(function () {
                0 != $(this).val().length && $("#inputCity").css("border-color", "rgba(0, 0, 0, 0.1)");
            });
    }),
    $(window).on("load", function () {
        localStorage.setItem("PathId", "");
        var a = document.getElementsByTagName("path");
        if (null != a && null != a) for (i = 0; i < a.length; i++) a[i].onclick = doSomething;
    }),
    $("#HasMapContent").mouseout(function () {
        SetFocusForMap();
    });
