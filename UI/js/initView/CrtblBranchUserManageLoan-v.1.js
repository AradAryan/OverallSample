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
            { field: "ClientCode", title: "کد مشتری" },
            { field: "Amount", title: "مقدار وام" },
            { field: "GiveBackTime", title: "زمان برگشت" },
            {
                title: "نوع وام",
                template: '#if(LoanTypeId == 1){#وام مسکن#}else if(LoanTypeId == 2){#وام خرید خودرو#}else if(LoanTypeId == 3){#وام خرید لوازم خانگی ایرانی#}else if(LoanTypeId == 4){#وام ضروری#}else{#وام جعاله#}#'
            },
            {
                title: "وضعیت تایید وام",
                template: '#if(MaaliUserOK == true){#تایید شده توسط اداره مالی#}else if(MaaliUserOK == false){#رد شده توسط اداره مالی#}else if(EtebariUserOK == true){#تایید شده توسط اداره اعتبارات#}else if(EtebariUserOK == false){#رد شده توسط اداره اعتبارات#}else if(BranchBossOK == true){#تایید شده توسط رییس شعبه#}else if(BranchBossOK == false){#رد شده توسط رییس شعبه#}else{#ثبت شده توسط شعبه#}#'
            },
                        { field: "EtebariUserExplain", title: "توضیحات اداره اعتباری" },
                                    { field: "MaaliUserExplain", title: "توضیحات اداره مالی" },
           

        ],
        dataSource: vm.searchDS

    });
}
