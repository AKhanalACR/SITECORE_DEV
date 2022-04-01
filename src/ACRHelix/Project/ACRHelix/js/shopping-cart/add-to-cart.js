
jQuery(document).on('click','.addCartBtn',function () {

    var productId = jQuery(this).attr('data-personifyId');
    var url = "/personifycart/addtocart/" + productId;
    var stockStatus = jQuery(this).attr('data-stockStatus');
    if (stockStatus == 'Available' || stockStatus == "In Stock") {
        jQuery.ajax({
            type: "POST", url: url, contentType: "application/json", cache: false, error: function () { alert("error posting to cart service."); }, success:
            function (data) {
                //alert('post successful');
                //alert(data.Result);    
                if (data.Added) {
                    createDialog(' to your cart.');
                    jQuery('#cartDialog').dialog();
                    jQuery('#cartDialog').dialog("option", "minWidth", 500);
                    jQuery('#product-name').text(data.ProductName);
                    jQuery('.sc-cart-link').attr('href', data.CartUrl);
                    setCartCount();
                } else {
                    alert('Error adding product to cart');
                }
            }
        });
        return false;
    } 

});

function createDialog(text)
{
    jQuery('#cartDialog').detach();
        jQuery('main').first().append('<div id="cartDialog" title="ACR Shopping Cart" style="display:none"><p>You have added <span id="product-name"></span>' + text + '</p><a class="sc-cart-link" target="_blank">View Cart and Checkout</a></div>');
    
}

jQuery(document).on('click','.save-later-link', function () {
    var productId = jQuery(this).attr('data-personifyId');

    var stockStatus = jQuery(this).attr('data-stockStatus');
    if (stockStatus == 'Available' || stockStatus == "In Stock") {
        var url = "/personifycart/saveforlater/" + productId;
        jQuery.ajax({
            type: "POST", url: url, contentType: "application/json", cache: false, error: function () { alert("error posting to cart service."); }, success:
            function (data) {
                //alert('post successful');
                //alert(data.Result);    
                if (data.Added) {
                    createDialog(' to your saved for later cart.');
                    jQuery('#cartDialog').dialog();
                    jQuery('#cartDialog').dialog("option", "minWidth", 500);
                    jQuery('#product-name').text(data.ProductName);
                    jQuery('.sc-cart-link').attr('href', data.CartUrl);
                    setCartCount();
                } else {
                    alert('Error adding product to your save for later list');
                }
            }
        });
        return false;
    } 
});