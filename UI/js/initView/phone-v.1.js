
function initView(vm) {
    // کارهای مربوط به UI
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
            { field: "Id", title: "شناسه", width: "60px" },
            { field: "Firstname", title: "نام" },
            { title: "نام خانوادگی", template: '<span class="bold">#=Lastname#</span>' },
            { title: "موبایل سفارشی", template: kendo.template($('#customPhoneTemplate').html()) },
            { field: "Mobile", title: "شماره موبایل" },
            {
                title: 'عملیات',
                command: [
                    { text: 'ویرایش', click: vm.onEdit },
                    { text: 'حذف', click: vm.onDelete }
                ]
            },
            {
                title: 'عملیات 2',
                template: '#if(Id % 2 == 1){#<a href="##" class="k-button k-button-icontext k-grid-activate"><span class=" "></span>فعالسازی</a>#}#'
            }
        ],
        dataSource: vm.searchDS,
        dataBound: function () {
            var grid = $("#grid").data('kendoGrid');
            var data = grid.dataSource.data();
            $('.k-grid-activate').click(function (be) {
                be.preventDefault();
                var rowUID = $(this).closest('tr').attr('data-uid');
                var item = data.filter(function (item, i) { return item.uid == rowUID })[0];
                
                alert(item.Firstname + ' ' + item.Lastname);

                return false;
            });

            for (var i = 0, uid; i < data.length; i++) {
                if (data[i].Firstname.indexOf('ر') != -1) {
                    uid = data[i].uid;
                    $('tr[data-uid=' + uid + ']').addClass('warning');
                }
            }

        }
    });
}