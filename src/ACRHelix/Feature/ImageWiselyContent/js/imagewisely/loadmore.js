$(document).ready(function () {
    //initial load 
    initializeList();

});

var pgIndex1 = 1;
var nbrPages1 = 0
var pageSize1 = $('input:hidden[name=PgSize]').val();
var itemCount1 = $('input:hidden[name=ItemCount]').val();

//load more 
$(document).on('click', '#loadMore', function () {

    $('.tiles-section-list').children().each(function () {

        if ($(this).attr('page-index') == pgIndex1) {
            $(this).removeAttr("hidden");
        }
    });
    ++pgIndex1;

    //hide load more button 
    if (nbrPages1 <= pgIndex1) {
        $('#loadMore').parent().attr('hidden', 'true');
    }
});



function initializeList() {
    nbrPages1 = Math.ceil(itemCount1 / pageSize1);

    //hide load more button 
    if (nbrPages1 <= pgIndex1) {
        $('#loadMore').parent().attr('hidden', 'true');
    }
}