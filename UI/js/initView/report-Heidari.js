
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
            { field: "Row", title: "ردیف", width: "60px" },
            { field: "Univercity", title: "نام دانشگاه" },

            { field: "City", title: "نام شهر" },
                 { field: "Syndromic", title: "نام سندروم" },
            { field: "Count", title: "تعداد سندروم" },
            {
                title: 'عملیات',
                //command: [
                //    { text: 'ویرایش', click: vm.onEdit },
                //    { text: 'حذف', click: vm.onDelete }
                //]
            },
          //  {
              //  title: 'عملیات 2',
               // template: '#if(Id % 2 == 1){#<a href="##" class="k-button k-button-icontext k-grid-activate"><span class=" "></span>فعالسازی</a>#}#'
            //}
        ],
        dataSource: vm.SearchDS,
        dataBound: function () {
            var grid = $("#grid").data("kendoGrid"),
                data = grid.dataSource.data();
            $.each(data, function (i, row) {
                if (row.Indirect) {
                    $('tr[data-uid="' + row.uid + '"]').addClass('indirect-patient');
                }
            });
        }
    });
}