import $ from "jquery";
import queryString from "query-string";

class BulletinTagList {
  constructor(selectID, listAreaID) {
    const select = $(selectID);
    const listArea = $(listAreaID);

    if (select.length > 0 && listArea.length > 0) {
      this.Select = select;
      this.ListArea = listArea;
      this.TagID = listArea.attr("data-tag");
      this.FirstLoad = true;
      this.Init();
    }
  }

  Init() {
    this.Select.dropdown({
      onChange: (value, text, selItem) => {
        this.LoadArticles(value);
      }
    });

    let loadFromQuery = false;
    const qs = queryString.parse(window.location.search);
    if (qs.year !== undefined) {
      const options = this.Select.find("option");
      let values = $.map(options, function(option) {
        return option.value;
      });

      if (values.indexOf(qs.year) > -1) {
        this.LoadArticles(qs.year);
        loadFromQuery = true;
      }
    }
    if (!loadFromQuery) {
      this.LoadArticles(this.Select.val());
    }
  }

  LoadArticles(year) {
    $("#ajaxLoader").show();
    jQuery.ajax({
      type: "POST",
      url: "/api/Sitecore/Bulletin/GetTagArticles",
      datatype: "json",
      data: { tag: this.TagID, year: year },
      success: data => {
        this.ListArea.children().remove();
        this.ListArea.append(data);
        if (!this.FirstLoad) {
          const qs = queryString.parse(window.location.search);
          qs.year = year;
          window.history.pushState(
            null,
            null,
            window.location.pathname + "?" + queryString.stringify(qs)
          );
        } else {
          this.FirstLoad = false;
        }
        $("#ajaxLoader").hide();
      },
      error: function() {
        alert("Error loading articles.");
      }
    });
  }
}

export default BulletinTagList;
