function initView(vm) {
    $("#grid").kendoGrid({
        selectable: "multiple cell",
        autoBind: true,
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
            { field: "Row", title: "ردیف", width: "70px" },
            { field: "NationalCode", title: "کد ملی" },
            { field: "CustomerCode", title: "کد مشتری" },
            { field: "FirstName", title: " نام" },
            { field: "LastName", title: "نام خانوادگی" },
            {
                title: "نوع گزارش",
                template: '#if(RiskId == 1){#انجام تراکنش خارج از سطح نرمال مشتری #}else if(RiskId == 2){#حرکات مشکوک #}else if(RiskId == 3){#ارائه مدارک جعلی #}else if(RiskId == 4){#سایر#}else{# نامعتبر#}#'
            },
            { field: "Description", title: "توضیحات" },
        ],
        dataSource: vm.searchDS
    });
}
