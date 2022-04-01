$(function() {
  $(".mapcontainer").mapael({
    map: {
      name: "usa_states",
      defaultArea: {
        attrs: {
          fill: "#00456a",
          stroke: "#337ab7"
        },
        href: "site-locator-state.html",
        attrsHover: {
          fill: "#8957b6",
          animDuration: 10
        }
      }
    },


  });
});
