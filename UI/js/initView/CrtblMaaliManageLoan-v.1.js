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
                        { field: "EtebariUserExplain", title: "توضیحات اداره اعتبارات " },
                                    {
                                        title: 'توضیحات',
                                        width: '200px',
                                        template: '#{#<textarea rows="3" id="tozihat" class="k-textbox" , style="width: 100%"></textarea>#}#'
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
                if (data[i].MaaliUserOK == true) {
                    uid = data[i].uid;
                    $('tr[data-uid=' + uid + ']').addClass('text-success');
                    $('tr[data-uid=' + uid + ']').children('td').eq(8).children('a').remove();
                    $('tr[data-uid=' + uid + ']').children('td').eq(7).children('textarea').remove();
                    $('tr[data-uid=' + uid + ']').children('td').eq(7).append('<p class="text-primary">' + data[i].MaaliUserExplain + '</p>');
                    $('tr[data-uid=' + uid + ']').children('td').eq(8).append('<p>تایید شده</p>');
                }
                else if (data[i].MaaliUserOK == false) {
                    uid = data[i].uid;
                    $('tr[data-uid=' + uid + ']').addClass('text-danger');
                    $('tr[data-uid=' + uid + ']').children('td').eq(8).children('a').remove();
                    $('tr[data-uid=' + uid + ']').children('td').eq(7).children('textarea').remove();
                    $('tr[data-uid=' + uid + ']').children('td').eq(7).append('<p class="text-primary">' + data[i].MaaliUserExplain + '</p>');
                    $('tr[data-uid=' + uid + ']').children('td').eq(8).append('<p>رد شده</p>')
                }
            }
        }

    });
}
