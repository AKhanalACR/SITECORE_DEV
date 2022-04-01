function radiosCheckboxes(parent, preFn) {

    //use the preFn in case we need to do some
    //kind of routine to wrap the checkboxes and labels
    //into the wrapper if we cannot hard-code it

    if (typeof preFn !== 'undefined' && typeof preFn === 'function') {
        preFn();
    }

    var $parent = $((parent || 'main'));

    $('.acr-checkbox,.acr-radio').each(function () {

        $(this).prepend('<i></i>');
        var $input = $('input', this);

        $input.is(':checked') && $(this).addClass('input-checked');
        $input.is(':disabled') && $(this).addClass('disabled-input');
    });

    $parent.on('click radiosCheckboxes', '.acr-checkbox,.acr-radio', function () {

        if ($(this).hasClass('disabled-input')) { return }

        var $input = $('input', this),
            isRadio = $input[0].type.toUpperCase() === "RADIO";

        if ($input.is(':checked')) {
            if (!isRadio) {
                $input.prop('checked', false);
                $(this).removeClass('input-checked');
            }
        } else {
            $input.prop('checked', true);
            $(this).addClass('input-checked');
        }
        //create the change event in case it
        //didn't register
        $input.trigger('change');

        $('input[id=' + $input.attr('id') + ']')
            .not(':checked')
            .parent('.acr-radio')
            .removeClass('input-checked');

    });
}
