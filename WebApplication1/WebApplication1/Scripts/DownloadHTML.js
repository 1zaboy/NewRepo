$(document).ready(function () {
    $("#btnExport").click(function () {
        var htmltable = document.getElementById(this);
        var html = htmltable.outerHTML;
        window.open('data:application/msword,' + '\uFEFF' + encodeURIComponent(html));
    });
});
Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.docx");