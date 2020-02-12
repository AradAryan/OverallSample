function initView(vm)
{
    //کارهای مربوط به UI
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
            { field: "Mobile", title: "شماره موبایل" },
            //{ title: "موبایل سفارشی", template: kendo.template($('#customPhoneTemplate').html()) },

        ],
        dataSource: vm.searchDs,
    });
}