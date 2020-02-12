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
            { field: "FirstName", title: "نام" },
            { field: "LastName", title: "نام خانوادگی" },
            { field: "UserName", title: "نام کاربری" },
            { field: "Mobile", title: "موبایل" },
            { field: "Email", title: "پست الکترونیکی" },
           
            {
                title: 'عملیات',

                command: [
                    {text: 'بروزرسانی', click: vm.onUpdateUser },
                    { text: 'حذف', click: vm.onDeleteUser }
                ]
            }
        ],
        dataSource: vm.searchDS,
        dataBound: function () {
            debugger;
            var grid = $("#grid").data('kendoGrid');
            var data = grid.dataSource.data();

            for (var i = 0, uid; i < data.length; i++) {
                if (data[i].IsActive != 1) {
                    uid = data[i].uid;
                    $('tr[data-uid=' + uid + ']').addClass('text-danger');
                    $('tr[data-uid=' + uid + ']').children('td').eq(6).children('a').remove();
                    $('tr[data-uid=' + uid + ']').children('td').eq(6).append('<a class="k-button k-button-icontext c-retrieve" href=# ><span class=" "></span>بازیابی</a>');
                }
            }


            $('.c-retrieve').click(function (be) {
                debugger;
                be.preventDefault();
                var rowUID = $(this).closest('tr').attr('data-uid');
                var item = data.filter(function (item, i) { return item.uid == rowUID })[0];
                vm.onRetrieveUser(item.Id);
                return false;
            });
        }
    });
}
