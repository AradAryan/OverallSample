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
            { field: "QustionText", title: "متن پرسش" },
            { field: "AnswerText", title: "متن پاسخ" },
            {
                title: "نام سامانه", template: '#if(SystemId==1){#وزارت بهداشت#}else if(SystemId==2){#بانک آینده#}else{#بانک ملت#}#'
            },
            { field: "ImageFileName", title: "نام فایل عکس" },

            {
                title: 'عملیات',

                command: [
                    { text: 'ویرایش', click: vm.onUpdateUser },
                    { text: 'حذف', click: vm.onDeleteUser },
                    { text: 'غیرفعالسازی', click: vm.onDeactiveUser }
                ]
            }
        ],
        dataSource: vm.searchDS,
        dataBound: function () {
            var grid = $("#grid").data('kendoGrid');
            var data = grid.dataSource.data();

            for (var i = 0, uid; i < data.length; i++) {
                if (data[i].Enabled != 1) {
                    uid = data[i].uid;
                    $('tr[data-uid=' + uid + ']').addClass('text-danger');
                    $('tr[data-uid=' + uid + '] .k-grid-غیرفعالسازی').remove();
                    $('tr[data-uid=' + uid + ']').children('td').eq(5).append('<a class="k-button k-button-icontext c-retrieve" href=# ><span class=" "></span>فعالسازی</a>');
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

    $("#files").kendoUpload({
        async: {
            saveUrl: "http://localhost/UI/faq/PostImg",
            removeUrl: "http://my-app.localhost/remove"
        },
        localization: {
            dropFilesHere: "DropFilesHere"
        },
        multiple: false,
        validation: {
            allowedExtensions: [".jpg"]
        },
        complete: vm.onComplete,
        success: vm.onSuccess,
        clear: vm.onClear
    });

}   
