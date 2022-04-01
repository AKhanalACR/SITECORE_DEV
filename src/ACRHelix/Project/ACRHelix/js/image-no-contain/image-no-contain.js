jQuery(function ($) {
  jQuery(".addParent-image-no-contain").each(function(){  
    jQuery(this).parent().addClass('image-no-contain-outer');
  });
  jQuery('.callout-section').equalizeContent({ equalizeItem: '.box' });
});