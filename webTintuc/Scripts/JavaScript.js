$(document).ready(function(){
    $("#selectimg").click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $(".url").val(fileUrl)
        };
        finder.popup();
    });

});