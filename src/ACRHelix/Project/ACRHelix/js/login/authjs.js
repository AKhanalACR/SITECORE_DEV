jQuery("#main-nav-login").find('a').text('Log Out');
jQuery("#main-nav-login").find('a').attr('href', '/LogOut');
jQuery("#main-nav-login").addClass('log-out');
jQuery(".top-utility-nav").find('ul').prepend('<li><a class=\"logged-in-username\">Welcome, ' + jQuery('#user_full_name').val() + '</a></li>');

var keyTakeways = jQuery(".header-share-opts");
if (keyTakeways.length > 0) {
    keyTakeways.attr('data-authenticated', 'true');
}