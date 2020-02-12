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
            { field: "RowNumber", title: "ردیف" },
            { field: "ProvinceTitle", title: "استان" },
            { field: "UniversityTitle", title: "دانشگاه" },
            { field: "NetworkTitle", title: "شبکه بهداشت" },
            { field: "CenterTitle", title: "مرکز بهداشت" },
            { field: "SyndromicTitle", title: "نوع سندرم" },
            { field: "Count", title: "تعداد" },
            {
                title: "عملیات",
                command: [
                    { name: 'جزئیات', title: "", click: vm.onDetail }
                ]
            }
        ],
        dataSource: vm.searchDataSource
    });
}