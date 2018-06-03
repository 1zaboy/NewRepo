$(".hover").mouseleave(
    function () {
        $(this).removeClass("hover");
    }
);
    

$("textarea").ready(function () {
    if (this.value.length > 10)
        this.value = this.value.substr(0, 10);
});