var r = 0;
$('#results').load('/Home/ViewCardAjax?numb=' + r);
$(document).ready(function () {
    $('#btn1').click(function (e) {

        if (r > 0) {
            r = r - 1;
            name = encodeURIComponent(r);
            $('#results').load('/Home/ViewCardAjax?numb=' + name)
        }
    });
    $('#btn2').click(function (e) {
        if (16 > (r + 1) * 15) {
            r = r + 1;
            name = encodeURIComponent(r);
            $('#results').load('/Home/ViewCardAjax?numb=' + name)
        }
    });
});
