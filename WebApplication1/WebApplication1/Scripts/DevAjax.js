var r = 0;
var str = "";
$('#results').load('/Home/ViewDevAjax?numb=' + r + '&name1=' + str);
$(document).ready(function () {
    $('#btn1').click(function (e) {

        if (r > 0) {
            var nameVal = $('#search').val();
            nameVal = encodeURIComponent(nameVal);
            r = r - 1;
            name = encodeURIComponent(r);
            $('#results').load('/Home/ViewDevAjax?numb=' + name + '&name1=' + nameVal)
        }
    });
    $('#btn2').click(function (e) {
        if (16 > (r + 1) * 15) {
            var nameVal = $('#search').val();
            nameVal = encodeURIComponent(nameVal);
            r = r + 1;
            name = encodeURIComponent(r);
            $('#results').load('/Home/ViewDevAjax?numb=' + name + '&name1=' + nameVal)
        }
    });
    $('#submit').click(function (e) {
        var name = $('#search').val();
        name = encodeURIComponent(name);
        $('#results').load('/Home/ViewDevAjax?numb=' + 0 + '&name1=' + name);
        //r = 0;
        //$('#results').load('/Home/ViewDevAjax?numb=' + r);
    });
});