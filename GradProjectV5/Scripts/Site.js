function CreateAjaxRequest(url, requesttype, form_data) {
    var resultData = null;
    $.ajax({
        url: url,
        type: requesttype,
        async: false,
        datatype: 'JSON',
        contentType: "application/json",
        data: JSON.stringify(form_data),
        success: function (result) { resultData = result }
    });
    return resultData;
}




function CreateAjaxRequestUsingObjects(url, requesttype, form_data) {
    var resultData = null;
    $.ajax({
        url: url,
        type: requesttype,
        async: false,
        datatype: 'JSON',
        contentType: "application/json",
        data: form_data,
        success: function (result) { resultData = result }
    });
    return resultData;
}