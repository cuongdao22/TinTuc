$(document).ready(function(){
    $("#selectimg").click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $(".url").val(fileUrl);
            $("#imgtt").attr("src", fileUrl);
        };
        finder.popup();
    });

});


function chonTag() {
  
    
    var e = document.getElementById("selectDM");
    var strUser = e.options[e.selectedIndex].value;
    if (document.getElementById("Tag1").value == "") document.getElementById("Tag1").value += strUser;
    else document.getElementById("Tag1").value += " , " + strUser;
}