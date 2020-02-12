function initView(vm) {
    $("#grid").kendoGrid({
        selectable: "multiple cell",
        autoBind: false,
        scrollable: true,
        resizable: true,
        allowCopy: true,
        navigatable: true,
        pageable: {
            pageSize: 15,
            messages: {
                display: "نمایش {0}-{1} از {2}",
                empty: "اطلاعاتی موجود نیست"
            }
        },
        columns: [
            { field: "Row", title: "ردیف", width: "40px" },
            //{ field: "PatientName", title: "نام بیمار" },
            //{ field: "PatientNationalCode", title: "کدملی بیمار" },
            { field: "Province", title: "استان" },
            { field: "UniversityName", title: "دانشگاه" },
            { field: "CenterName", title: "مرکز بهداشت/ بیمارستان" },
            { field: "SyndromName", title: "نوع سندروم" },
            { field: "SyndromName", title: "تعداد سندروم" }
        ],
        dataSource: vm.SearchDS,
        dataBound: function () {
            var grid = $("#grid").data("kendoGrid"),
                data = grid.dataSource.data();
            $.each(data, function (i, row) {
                if (row.Indirect) {
                    $('tr[data-uid="' + row.uid + '"]').addClass('indirect-patient');
                }
            });
        }
    });
    var grid = $("#grid").data('kendoGrid');
    $("#grid").on('click', '.do-delete', function (e) {
        e.preventDefault();
        vm.onDelete.call(grid, e);
        return false;
    }).on('click', '.do-retrieve', function (e) {
        e.preventDefault();
        vm.onRetrieve.call(grid, e);
        return false;
    }).on('click', '.do-show-details', function (e) {
        e.preventDefault();
        vm.showDetails.call(grid, e);
        return false;
    }).on('click', '.do-update', function (e) {
        e.preventDefault();
        vm.update.call(grid, e);
        return false;
    });

    $("#province").kendoDropDownList({
    });
    $("#admissionType").kendoDropDownList({
    });
    $("#SyndromicId").kendoDropDownList({
    });
    $("#university").kendoDropDownList({
    });
}
