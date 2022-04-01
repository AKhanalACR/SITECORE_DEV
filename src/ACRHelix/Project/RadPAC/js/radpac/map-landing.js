var dataSet = {
    AL: {
        name: 'Alabama'
    },
    AZ: {
        name: 'Arizona'
    },
    CA: {
        name: 'California'
    },
    CO: {
        name: 'Colorado'
    },
    CT: {
        name: 'Connecticut'
    },
    DE: {
        name: 'Delaware'
    },
    FL: {
        name: 'Florida'
    },
    GA: {
        name: 'Georgia'
    },
    IL: {
        name: 'Illinois'
    },
    IN: {
        name: 'Indiana'
    },
    KS: {
        name: 'Kansas'
    },
    KY: {
        name: 'Kentucky'
    },
    LA: {
        name: 'Louisiana'
    },
    ME: {
        name: 'Maine'
    },
    MD: {
        name: 'Maryland'
    },
    MA: {
        name: 'Massachusetts'
    },
    MI: {
        name: 'Michigan'
    },
    MN: {
        name: 'Minnesota'
    },
    MS: {
        name: 'Mississippi'
    },
    MO: {
        name: 'Missouri'
    },
    NE: {
        name: 'Nebraska'
    },
    NV: {
        name: 'Nevada'
    },
    NH: {
        name: 'New Hampshire'
    },
    NJ: {
        name: 'New Jersey'
    },
    NY: {
        name: 'New York'
    },
    NC: {
        name: 'North Carolina'
    },
    OH: {
        name: 'Ohio',
    },
    OK: {
        name: 'Oklahoma',
    },
    OR: {
        name: 'Oregon',
    },
    PA: {
        name: 'Pennsylvania',
    },
    RI: {
        name: 'Rhode Island',
    },
    SC: {
        name: 'South Carolina',
    },
    TN: {
        name: 'Tennessee',
    },
    TX: {
        name: 'Texas',
    },
    UT: {
        name: 'Utah',
    },
    VA: {
        name: 'Virginia',
    },
    DC: {
        name: 'District of Columbia',
    },
    WA: {
        name: 'Washington',
    },
    WV: {
        name: 'West Virginia',
    },
    WI: {
        name: 'Wisconsin',
    },
    VT: {
        name: 'Vermont',
    },
    AR: {
        name: 'Arkansas',
    },
    NM: {
        name: 'New Mexico',
    },
    IA: {
        name: 'Iowa',
    },
    SD: {
        name: 'South Dakota',
    },
    ND: {
        name: 'North Dakota',
    },
    MT: {
        name: 'Montana',
    },
    WY: {
        name: 'Wyoming',
    },
    ID: {
        name: 'Idaho',
    },
    AK: {
        name: 'Alaska',
    },
    HI: {
        name: 'Hawaii',
    },
    PR: {
        name: 'Puerto Rico'
    }
};

$(function () {
    $(".mapcontainer").mapael({
        map: {
            name: "usa_states",           
            defaultArea: {
                attrs: {
                    fill: "#164c82",
                    stroke: "#337ab7",
                    cursor: "pointer"
                },
                text: {
                    attrs: {
                        "font-size": 16,

                        "font-weight": 700,
                        fill: "#edeff1"
                    }
                },
                eventHandlers: {
                    click: function (e, id) {
                        if (typeof id != 'undefined') {
                            var pUrl = $('#mapcontainer').attr('data-parent-item');
                            if (pUrl == '' || pUrl == undefined) {
                                var pUrl = $('#ddl-state-selector-2').attr('data-parent-item');
                            }
                            window.location.href = pUrl + '/' + dataSet[id].name.replace(/ /g, '-');
                        }
                    }
                },
                attrsHover: {
                    fill: "#e02a2e",
                    animDuration: 0
                }
            }
        },
        areas: {
            "AL": {
                attrs: {
                    fill: (function () { if (hightState("AL")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "AL"
                }
            },
            "AZ": {
                attrs: {
                    fill: (function () { if (hightState("AZ")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "AZ"
                }
            },
            "CA": {
                attrs: {
                    fill: (function () { if (hightState("CA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "CA",
                    margin: { x: -20, y: 0 }
                }
            },
            "CO": {
                attrs: {
                    fill: (function () { if (hightState("CO")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "CO"
                }
            },
            "CT": {
                attrs: {
                    fill: (function () { if (hightState("CT")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "CT"
                }
            },
            "DE": {
                attrs: {
                    fill: (function () { if (hightState("DE")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "DE",
                    margin: { x: 60, y: 0 }
                }
            },
            "FL": {
                attrs: {
                    fill: (function () { if (hightState("FL")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "FL",
                    margin: { x: 50, y: 0 }
                }
            },
            "GA": {
                attrs: {
                    fill: (function () { if (hightState("GA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "GA"
                }
            },
            "IL": {
                attrs: {
                    fill: (function () { if (hightState("IL")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "IL"
                }
            },
            "IN": {
                attrs: {
                    fill: (function () { if (hightState("IN")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "IN"
                }
            },
            "IL": {
                attrs: {
                    fill: (function () { if (hightState("IL")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "IL"
                }
            },
            "KS": {
                attrs: {
                    fill: (function () { if (hightState("KS")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "KS"
                }
            },
            "KY": {
                attrs: {
                    fill: (function () { if (hightState("KY")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "KY",
                    margin: { x: 20, y: 0 }
                }
            },
            "LA": {
                attrs: {
                    fill: (function () { if (hightState("LA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "LA",
                    margin: { x: -20, y: 0 }
                }
            },
            "ME": {
                attrs: {
                    fill: (function () { if (hightState("ME")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "ME"
                }
            },
            "MD": {
                attrs: {
                    fill: (function () { if (hightState("MD")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "MD",
                    margin: { x: 90, y: 15 }
                }
            },
            "MA": {
                attrs: {
                    fill: (function () { if (hightState("MA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "MA"
                }
            },
            "MI": {
                attrs: {
                    fill: (function () { if (hightState("MI")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "MI",
                    margin: { x: 25, y: 25 }
                }
            },
            "MN": {
                attrs: {
                    fill: (function () { if (hightState("MN")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "MN",
                    margin: { x: -20, y: 0 }
                }
            },
            "MS": {
                attrs: {
                    fill: (function () { if (hightState("MS")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "MS"
                }
            },
            "MO": {
                attrs: {
                    fill: (function () { if (hightState("MO")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "MO"
                }
            },
            "NE": {
                attrs: {
                    fill: (function () { if (hightState("NE")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "NE"
                }
            },
            "NV": {
                attrs: {
                    fill: (function () { if (hightState("NV")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "NV"
                }
            },
            "NH": {
                attrs: {
                    fill: (function () { if (hightState("NH")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "NH"
                }
            },
            "NJ": {
                attrs: {
                    fill: (function () { if (hightState("NJ")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "NJ"
                }
            },
            "NY": {
                attrs: {
                    fill: (function () { if (hightState("NY")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "NY"
                }
            },
            "NC": {
                attrs: {
                    fill: (function () { if (hightState("NC")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "NC"
                }
            },
            "OH": {
                attrs: {
                    fill: (function () { if (hightState("OH")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "OH"
                }
            },
            "OK": {
                attrs: {
                    fill: (function () { if (hightState("OK")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "OK",
                    margin: { x: 20, y: 0 }
                }
            },
            "OR": {
                attrs: {
                    fill: (function () { if (hightState("OR")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "OR"
                }
            },
            "PA": {
                attrs: {
                    fill: (function () { if (hightState("PA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "PA",
                }
            },
            "RI": {
                attrs: {
                    fill: (function () { if (hightState("RI")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "RI",
                    margin: { x: 10, y: 30 }
                }
            },
            "SC": {
                attrs: {
                    fill: (function () { if (hightState("SC")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "SC"
                }
            },
            "TN": {
                attrs: {
                    fill: (function () { if (hightState("TN")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "TN"
                }
            },
            "TX": {
                attrs: {
                    fill: (function () { if (hightState("TX")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "TX"
                }
            },
            "UT": {
                attrs: {
                    fill: (function () { if (hightState("UT")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "UT"
                }
            },
            "VA": {
                attrs: {
                    fill: (function () { if (hightState("VA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "VA",
                    margin: { x: 20, y: 0 }
                }
            },
            "DC": {
                attrs: {
                    fill: (function () { if (hightState("DC")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "DC",
                    margin: { x: 85, y: 40 }
                }
            },
            "WA": {
                attrs: {
                    fill: (function () { if (hightState("WA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "WA"
                }
            },
            "WV": {
                attrs: {
                    fill: (function () { if (hightState("WV")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "WV"
                }
            },
            "WI": {
                attrs: {
                    fill: (function () { if (hightState("WI")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "WI"
                }
            },
            "VT": {
                attrs: {
                    fill: (function () { if (hightState("VT")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "VT"
                }
            },
            "AR": {
                attrs: {
                    fill: (function () { if (hightState("AR")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "AR"
                }
            },
            "WA": {
                attrs: {
                    fill: (function () { if (hightState("WA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "WA"
                }
            },
            "NM": {
                attrs: {
                    fill: (function () { if (hightState("NM")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "NM"
                }
            },
            "IA": {
                attrs: {
                    fill: (function () { if (hightState("IA")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "IA"
                }
            },
            "SD": {
                attrs: {
                    fill: (function () { if (hightState("SD")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "SD"
                }
            },
            "ND": {
                attrs: {
                    fill: (function () { if (hightState("ND")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "ND"
                }
            },
            "MT": {
                attrs: {
                    fill: (function () { if (hightState("MT")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "MT"
                }
            },
            "WY": {
                attrs: {
                    fill: (function () { if (hightState("WY")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "WY"
                }
            },
            "ID": {
                attrs: {
                    fill: (function () { if (hightState("ID")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "ID",
                    margin: { x: 0, y: 30 }
                }
            },
            "AK": {
                attrs: {
                    fill: (function () { if (hightState("AK")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "AK"
                }
            },
            "HI": {
                attrs: {
                    fill: (function () { if (hightState("HI")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "HI"
                }
            },
            "PR": {
                attrs: {
                    fill: (function () { if (hightState("PR")) { return "#e02a2e"; } else { return "#164c82"; } })()
                },
                text: {
                    content: "PR"
                }
            }
        }
    });
});


//get page url
function hightState(id) {
    var vars = window.location.href.split('/');
    var hashes = vars[vars.length - 1].toLowerCase().replace(/-/g, ' ');
    if (dataSet[id].name.toLowerCase() == hashes) {
        return true;
    } else {
        return false;
    }
}