function initView(vm) {
    $("#grid").kendoGrid({
        selectable: "multiple cell",
        autoBind: true,
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
            { field: "Row", title: "ردیف", width: "70px" },
            { field: "Province", title: "استان" },
            { field: "University", title: "دانشگاه" },
            { field: "CorporateName", title: "شبکه بهداشت" },
            //{ title: "عملیات", width: "150px", template: '<a href="\GetCorporateUsers\#=vm.selectedItem#" class="k-button k-button-icontext">کاربران</a> <a href="\getusers" class="k-button k-button-icontext">ثبت کاربر جدید</a> ' }
            {
                title: 'عملیات',
                command: [
                    {text: 'کاربران' , click: vm.onShowUser},
                    { text: 'کاربر جدید', click: vm.onNewUser }
                ]
            }
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
