function setCartCount() {
    jQuery.ajax({
        type: "POST", url: '/personifycart/cartcount', contentType: "application/json", cache: false, error: function () { console.log('error updating cart count'); }, success:
        function (data) {
            var cartCount = data.CartCount;
            if (cartCount > 0) {
                if (jQuery('.cart-count').length == 0) {
                    jQuery('.icon-shop').first().parent().prepend('<span class="cart-count">' + cartCount + '</span > ')
                } else {

                    jQuery('.cart-count').text(cartCount)
                }
            } else {
                jQuery('.cart-count').detach();
            }
        }
    });    
}
setCartCount();