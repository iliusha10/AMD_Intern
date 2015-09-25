$(function() {
    //////////////For Evbd///////////////////
    var fullUrl;


    //////////////Creating Form///////////////////
    var createDialog = $("#create-worker");
    createDialog.dialog({
        autoOpen: false,
        show: { effect: "clip", duration: 800 },
        hide: { effect: "clip", duration: 400 },
        width: 800,
        buttons: [
            {
                text: "Create",
                click: function() {
                    var form = $("#create-content form");
                    var data = form.serialize();
                    $.post(fullUrl, data, function(result, status, xhr) {
                        if (xhr.status == 200) {
                            $("#table-container").html(result);
                            $(".edit-Employee").click(editEmployee);
                            $(".edit-Intern").click(editIntern);
                            $(".edit-Contractor").click(editContractor);
                            $("#create-intern-btn").click(createIntern);
                            $("#create-contr-btn").click(createContractor);
                            $("#create-empl-btn").click(createEmployee);
                            $(".details-Employee").click(detailsEmployee);
                            $(".details-Intern").click(detailsIntern);
                            $(".details-Contractor").click(detailsContractor);
                            $(".delete-Employee").click(deleteEmployee);
                            $(".delete-Intern").click(deleteIntern);
                            $(".delete-Contractor").click(deleteContractor);
                            createDialog.dialog("close");
                        } else {
                            createDialog.dialog.title("option", "title", "Could not create worker. Incomplete or incorrect information.");
                        }
                    });

                }
            },
            {
                text: "Cancel",
                click: function() {
                    createDialog.dialog("close");
                }
            }
        ]
    });

    $("#create-intern-btn").click(createIntern);
    $("#create-contr-btn").click(createContractor);
    $("#create-empl-btn").click(createEmployee);

    function createIntern(e) {
        e.preventDefault();
        fullUrl = "/WEB/Workers/CreateIntern";
        $("#create-content").load(fullUrl, function() {
            $("#datepicker").datepicker()
                .datepicker("option", "dateFormat", "yy-mm-dd");
            $.validator.unobtrusive.parse("#create-content");
            createDialog.dialog("open");
        });
    };

    function createContractor(e) {
        e.preventDefault();
        fullUrl = "/WEB/Workers/CreateContractor";
        $("#create-content").load(fullUrl, function() {
            $("#datepicker").datepicker()
                .datepicker("option", "dateFormat", "yy-mm-dd");
            $.validator.unobtrusive.parse("#create-content");
            createDialog.dialog("open");
        });
    };

    function createEmployee(e) {
        e.preventDefault();
        fullUrl = "/WEB/Workers/CreateEmployee";
        $("#create-content").load(fullUrl, function() {
            $("#datepicker").datepicker()
                .datepicker("option", "dateFormat", "yy-mm-dd");
            $.validator.unobtrusive.parse("#create-content");
            createDialog.dialog("open");
        });
    };


//////////////Editing Form///////////////////
    var dialogEdit = $("#edit-worker");
    dialogEdit.dialog({
        autoOpen: false,
        show: { effect: "clip", duration: 800 },
        hide: { effect: "clip", duration: 400 },
        width: 800,
        buttons: [
            {
                text: "Save",
                click: function() {
                    var form = $("#edit-content form");
                    var data = form.serialize();
                    $.post(fullUrl, data, function(result, status, xhr) {
                        if (xhr.status == 200) {
                            $("#table-container").html(result);
                            $(".edit-Employee").click(editEmployee);
                            $(".edit-Intern").click(editIntern);
                            $(".edit-Contractor").click(editContractor);
                            $("#create-intern-btn").click(createIntern);
                            $("#create-contr-btn").click(createContractor);
                            $("#create-empl-btn").click(createEmployee);
                            $(".details-Employee").click(detailsEmployee);
                            $(".details-Intern").click(detailsIntern);
                            $(".details-Contractor").click(detailsContractor);
                            $(".delete-Employee").click(deleteEmployee);
                            $(".delete-Intern").click(deleteIntern);
                            $(".delete-Contractor").click(deleteContractor);
                            dialogEdit.dialog("close");
                        } else {
                            dialogEdit.dialog.title("option", "title", "Could not edit worker. Incomplete or incorrect information.");
                        }
                    });
                }
            },
            {
                text: "Cancel",
                click: function() {
                    dialogEdit.dialog("close");
                }
            }
        ]
    });


    $(".edit-Employee").click(editEmployee);
    $(".edit-Intern").click(editIntern);
    $(".edit-Contractor").click(editContractor);

    function editEmployee(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/EditEmployee/" + id;
        $("#edit-content").load(fullUrl, function() {
            $("#datepicker").datepicker()
                .datepicker("option", "dateFormat", "yy-mm-dd");
            $.validator.unobtrusive.parse("#edit-content");
            dialogEdit.dialog("open");
        });
    };

    function editIntern(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/EditIntern/" + id;
        $("#edit-content").load(fullUrl, function() {
            $("#datepicker").datepicker()
                .datepicker("option", "dateFormat", "yy-mm-dd");
            $.validator.unobtrusive.parse("#edit-content");
            dialogEdit.dialog("open");
        });
    };

    function editContractor(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/EditContractor/" + id;
        $("#edit-content").load(fullUrl, function() {
            $("#datepicker").datepicker()
                .datepicker("option", "dateFormat", "yy-mm-dd");
            $.validator.unobtrusive.parse("#edit-content");
            dialogEdit.dialog("open");
        });
    };


    //////////////Details Form///////////////////
    var dialogDetails = $("#details-worker");
    dialogDetails.dialog({
        autoOpen: false,
        show: { effect: "clip", duration: 800 },
        hide: { effect: "clip", duration: 400 },
        width: 400,
        buttons: [
            {
                text: "Thanks",
                click: function() {
                    dialogDetails.dialog("close");
                }
            }
        ]
    });

    $(".details-Employee").click(detailsEmployee);
    $(".details-Intern").click(detailsIntern);
    $(".details-Contractor").click(detailsContractor);

    function detailsEmployee(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/DetailsEmployee/" + id;
        $("#details-content").load(fullUrl, function() {
            dialogDetails.dialog("open");
        });
    };

    function detailsIntern(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/DetailsIntern/" + id;
        $("#details-content").load(fullUrl, function() {
            dialogDetails.dialog("open");
        });
    };

    function detailsContractor(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/DetailsContractor/" + id;
        $("#details-content").load(fullUrl, function() {
            dialogDetails.dialog("open");
        });
    };


    //////////////Delete Form///////////////////
    var dialogDelete = $("#delete-worker");
    dialogDelete.dialog({
        autoOpen: false,
        show: { effect: "clip", duration: 800 },
        hide: { effect: "clip", duration: 400 },
        width: 400,
        buttons: [
            {
                text: "Delete",
                click: function () {
                    $.post(fullUrl, function (result, status, xhr) {
                        if (xhr.status === 200) {
                            $("#table-container").html(result);
                            $(".edit-Employee").click(editEmployee);
                            $(".edit-Intern").click(editIntern);
                            $(".edit-Contractor").click(editContractor);
                            $("#create-intern-btn").click(createIntern);
                            $("#create-contr-btn").click(createContractor);
                            $("#create-empl-btn").click(createEmployee);
                            $(".details-Employee").click(detailsEmployee);
                            $(".details-Intern").click(detailsIntern);
                            $(".details-Contractor").click(detailsContractor);
                            $(".delete-Employee").click(deleteEmployee);
                            $(".delete-Intern").click(deleteIntern);
                            $(".delete-Contractor").click(deleteContractor);
                            dialogDelete.dialog("close");
                        } else {
                            alert("Error");
                        }
                    });
                }
            },
            {
                text: "Cancel",
                click: function () {
                    dialogDelete.dialog("close");
                }
            }
        ]
    });

    $(".delete-Employee").click(deleteEmployee);
    $(".delete-Intern").click(deleteIntern);
    $(".delete-Contractor").click(deleteContractor);

    function deleteEmployee(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/DeleteEmployee/" + id;
        $("#delete-content").load(fullUrl, function () {
            dialogDelete.dialog("open");
        });
    };

    function deleteIntern(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/DeleteIntern/" + id;
        $("#delete-content").load(fullUrl, function () {
            dialogDelete.dialog("open");
        });
    };

    function deleteContractor(e) {
        e.preventDefault();
        var id = $(this).attr("id");
        fullUrl = "/WEB/Workers/DeleteContractor/" + id;
        $("#delete-content").load(fullUrl, function () {
            dialogDelete.dialog("open");
        });
    };

});


