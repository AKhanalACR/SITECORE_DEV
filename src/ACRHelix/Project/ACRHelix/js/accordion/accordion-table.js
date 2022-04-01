jQuery(function($){
  $(".accordion-details").find(".has-acr-table").each(function () {
    $(this).find('tr').each(function () {
      $(this).find('td').last().addClass('text-right');  
    });
  });
});