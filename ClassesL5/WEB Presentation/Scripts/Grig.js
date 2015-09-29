$(function() {
    jQuery("#company-grid").jqGrid({
        url: "/WEB/Grid/IndexData/",
        datatype: "json",
        colNames: ['Id', 'Name', 'Activity', 'City', 'Street'],
        colModel: [
            { name: 'id', index: 'Id', width: 60, sorttype: "int" },
            { name: 'name', index: 'CompanyName', width: 150 },
            { name: 'activity', index: 'Activity', width: 150, align: "right" },
            { name: 'city', index: 'City', width: 150, align: "right"},
            { name: 'street', index: 'Street', width: 250, align: "right" }

        ],
        rowNum: 5,
        rowList: [5, 10, 15],
        pager: '#page',
        sortname: 'id',
        viewrecords: true,
        sortorder: "desc",
        //loadonce: true,
        caption: "Company's Grid"
    });
});