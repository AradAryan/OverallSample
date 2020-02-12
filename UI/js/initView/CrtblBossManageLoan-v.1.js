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
                            title: 'تایید وام',
                            command: [
                                { text: 'تایید', click: vm.onAgree },
                                { text: 'رد', click: vm.onDisagree }

                            ]
                        }

                      

        ],
        dataSource: vm.searchDS,
        dataBound: function () {
            var grid = $("#grid").data('kendoGrid');
            var data = grid.dataSource.data();

            for (var i = 0, uid; i < data.length; i++) {
                if (data[i].BranchBossOK == true) {
                    uid = data[i].uid;
                    $('tr[data-uid=' + uid + ']').addClass('text-success');   
                }
               else if (data[i].BranchBossOK == false) {
                    uid = data[i].uid;
                    $('tr[data-uid=' + uid + ']').addClass('text-danger');
                }
            }
        }

    });
}
