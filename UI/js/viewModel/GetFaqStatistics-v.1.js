function initVM(args) {
    var vm = kendo.observable({
        onPrint: function (e) {
            vm.printDS.read();
        },

        printDS: new kendo.data.DataSource({
            transport: {
                read: {
                    url: "http://localhost/UI/faq/GetExcel"
                }
            }
        })
    });
}