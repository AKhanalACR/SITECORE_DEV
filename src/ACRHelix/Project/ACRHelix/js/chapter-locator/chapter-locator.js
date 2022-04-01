jQuery(document).ready(function () {
  jQuery('.locate-a-chapter').find('select').dropdown();
});

jQuery(".chapterFinderSubmitButton").click(function () {
  var val = jQuery('.chapterFinder').find('.selected').attr('data-value');
  if (val != "") {
    window.location = val;
  }
});