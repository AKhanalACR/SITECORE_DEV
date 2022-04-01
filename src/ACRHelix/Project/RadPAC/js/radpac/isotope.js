$(document).ready(function(){
  function filterExec(e, target) {
    e.isotope({
      filter: target,
      transitionDuration: 0
    });
  }
  var eventsIsotope = $('.events-container').isotope({
      layoutMode: 'fitRows',
      itemSelector: '.events-item'
  });
  var filterSelector = $('#events-flters select');
  var filterButtons = $('#events-flters li');
  filterButtons.on('click', eventsIsotope, function(e) {
    $("#events-flters li").removeClass('filter-active');
    $(this).addClass('filter-active');
    var filters = $(this).data('filter');
    filterExec(e.data, filters);
  });
  filterSelector.on('change', eventsIsotope, function(e) {
    var filters = $(this).val();
    filterExec(e.data, filters);
  });



});
