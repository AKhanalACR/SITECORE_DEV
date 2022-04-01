export default function multiFieldDatePicker(dateYear, dateParent, changeTheYear) {
	/*
	dependencies: jquery.ui
	*/
    if (typeof jQuery.fn.datepicker !== 'function') {
        console.log('install some jquery ui! Thanks :-)');
    }

    //we got a picker!
    jQuery((dateYear || ".date-hidden")).datepicker({
        showOn: 'button',
        buttonText: "",
        dateFormat: 'mm/dd/yy',
        changeYear: (changeTheYear !== 'undefined' ? changeTheYear : false),
        onSelect: function (dateText, picker) {
            var dateArr = dateText.split('/');
            jQuery(this).siblings('.date-month').val(dateArr[0]);
            jQuery(this).siblings('.date-day').val(dateArr[1]);
            jQuery(this).siblings('.date-year').val(dateArr[2]);

            //plop in the hidden field!
            jQuery(this).val(dateText);
        }
    });

    //read from the date field and populate
    jQuery((dateParent || '.date-multi-field')).each(function () {
        var $dateHidden = $(this).find('.date-hidden');

        if (/\//.test($dateHidden.val())) {
            var dateArr = $dateHidden.val().split('/');

            jQuery(this).find('.date-month').val(dateArr[0]);
            jQuery(this).find('.date-day').val(dateArr[1]);
            jQuery(this).find('.date-year').val(dateArr[2]);
        }
    });

    //change triggered on one of the fields to update the hidden
    jQuery((dateParent || '.date-multi-field')).on('change', 'input', function () {
        var $dateHidden = $(this).siblings('.date-hidden'),
            $parent = $(this).parent((dateParent || '.date-multi-field')),
            mm = $parent.find('.date-month').val(),
            dd = $parent.find('.date-day').val(),
            yyyy = $parent.find('.date-year').val();

        $dateHidden.val(mm + "\/" + dd + "\/" + yyyy);

    });
}
