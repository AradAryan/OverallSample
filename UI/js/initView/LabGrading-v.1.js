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
            { field: "Row", title: "ردیف", width: "60px" },
            { field: "Name", title: "نام آزمایشگاه" },
            { field: "ProcessedCount", title: "تعداد آزمایش ها", width: "250px" }
        ],
        dataSource: vm.searchDataSource
    });
}