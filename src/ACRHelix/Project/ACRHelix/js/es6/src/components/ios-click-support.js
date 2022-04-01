const iosOutsideClickSupport = {
    styleAdded: false,
    is_ios: navigator.userAgent.toLowerCase().match(/(iphone|ipod|ipad)/) ? true : false,
    add: function () {
        "use strict";
        var _ = this;
        if (_.is_ios && !_.styleAdded) {
            $('body').css({ cursor: 'pointer' });
            //console.log('added once ' + _.styleAdded);
            _.styleAdded = true;
        }
    }
};

export default iosOutsideClickSupport;
