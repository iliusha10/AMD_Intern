$(function() {
    var dialog = $("#create-worker");
    dialog.dialog({
        autoOpen: false,
        width: 800,
        buttons: [
            {
                text: "Create",
                click: function() {
                    var form = $("#create-content form");
                    var data = form.serialize();
                    var url;
                    debugger;
                    if ($("#PersonType").val() == "Intern")
                        url = "/WEB/Workers/CreateIntern";
                    if ($("#PersonType").val() == "Contractor")
                        url = "/WEB/Workers/CreateContractor";
                    if ($("#PersonType").val() == "Employee")
                        url = "/WEB/Workers/CreateEmployee";
                    $.post(url, data, function(result, status, xhr) {
                        if (xhr.status == 200) {
                            $("#table-container").html(result);
                            dialog.dialog("close");
                        } else {
                            dialog.dialog.title("option", "title", "Could not create worker. Incomplete or incorrect information.");
                        }
                    });

                }
                //click: function() {
                //    var form = $("#create-content form");
                //    var data = form.serialize();
                //    var url = "/WEB/Workers/Create";
                //    $.post(url, data, function(result, status, xhr) {
                //        if (xhr.status == 200) {
                //            $('#table-container').html(result);
                //            dialog.dialog("close");
                //        } else {
                //            dialog.dialog.title("option", "title", "Could not create worker. Incomplete or incorrect information.")
                //        }
                //    });

                //}
            },
            {
                text: "Cancel",
                click: function() {
                    dialog.dialog("close");
                }
            }
        ]
    });

    $("#create-intern-btn").click(function(e) {
        e.preventDefault();
        $("#create-content").load("/WEB/Workers/CreateIntern", function() {
            $.validator.unobtrusive.parse("#create-content");
            dialog.dialog("open");
        });
    });

    $("#create-contr-btn").click(function(e) {
        e.preventDefault();
        $("#create-content").load("/WEB/Workers/CreateContractor", function() {
            $.validator.unobtrusive.parse("#create-content");
            dialog.dialog("open");
        });
    });

    $("#create-empl-btn").click(function(e) {
        e.preventDefault();
        $("#create-content").load("/WEB/Workers/CreateEmployee", function() {
            $.validator.unobtrusive.parse("#create-content");
            dialog.dialog("open");
        });
    });


//$("#Type").change(function () {
    //    alert(1);
    //    if ($(this).val() == "1") {
    //        $("#create-content").load('/WEB/Workers/CreateIntern', function () {
    //            $.validator.unobtrusive.parse("#create-content");
    //            debugger;
    //        });

    //    } else if ($(this).val() == "3") {
    //        $("#create-content").load('/WEB/Workers/CreateEmployee', function () {
    //            $.validator.unobtrusive.parse("#create-content");
    //            debugger;
    //        });
    //    } else if ($(this).val() == "2") {
    //        $("#create-content").load('/WEB/Workers/CreateContractor', function () {
    //            $.validator.unobtrusive.parse("#create-content");
    //            debugger;
    //        });
    //    } else $(function () {
    //        debugger;
    //    });
    //});
});


//$(function () {
//    var dialog = $("#create-worker");
//    dialog.dialog({
//        autoOpen: false,
//        width: 700,
//        buttons: [
//            {
//                text: "Create",
//                click: function() {
//                    var form = $("#create-content form");
//                    var data = form.serialize();
//                    var url = "/WEB/Workers/Create";
//                    $.post(url, data, function(result, status, xhr) {
//                        if (xhr.status == 200) {
//                            $('#table-container').html(result);
//                            dialog.dialog("close");
//                        } else {
//                            dialog.dialog.title("option", "title", "Could not create worker. Incomplete or incorrect information.")
//                        }
//                    });

//                }
//            },
//            {
//                text: "Cancel",
//                click: function() {
//                    dialog.dialog("close");
//                }
//            }
//        ]
//    });

//    $("#create-btn").click(function (e) {
//        e.preventDefault();
//        $("#create-content").load('/WEB/Workers/Create', function () {
//            //$.validator.unobtrusive.parse("#create-content");
//            dialog.dialog("open");
//        });


//    });
//});