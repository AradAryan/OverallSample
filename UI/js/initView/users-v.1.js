
function initView(vm) {
    $("#grid").kendoGrid({
        selectable: "multiple cell",
        autoBind: false,
        scrollable: true,
        resizable: true,
        allowCopy: true,
        navigatable: true,
        pageable: {
            pageSize: 10,
            messages: {
                display: "نمایش {0}-{1} از {2}",
                empty: "اطلاعاتی موجود نیست"
            }
        },
        columns: [
            { field: "FirstName", title: "نام" },
            { field: "LastName", title: "نام خانوادگی" },
            { field: "NationalCode", title: "کد ملی " },
            {field: "IsActive", title: "وضعیت فعالیت"}
        ],
        dataSource: vm.searchDS,

    });
}