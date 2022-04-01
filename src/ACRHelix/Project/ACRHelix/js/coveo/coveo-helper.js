
function coveoDateString(date) {
    if (date == null) {
        date = new Date();
    }

    var mm = (date.getMonth() + 1);
    var dd = date.getDate();
    if (mm < 10) {
        mm = '0' + mm;
    }
    if (dd < 10) {
        dd = '0' + dd;
    }
    var dateString = date.getFullYear() + '/' + mm + '/' + dd + '@00:00:00';
    return dateString;

}

function buildFilterExpression(coveoFieldName, filterValue, operator) {
    return '(' + coveoFieldName + operator +'"' + filterValue + '")';
}

function buildDateFilterExpression(coveoFieldName, filterValue, operator) {
    return '(' + coveoFieldName + operator + filterValue + ')';
}