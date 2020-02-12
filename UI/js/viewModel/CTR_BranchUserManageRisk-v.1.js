function initVM(args) {
    var vm = kendo.observable({
        cashierId: 2,
        searchDS: new kendo.data.DataSource({

            transport: {
                read: {
                    url: 'http://localhost/UI/Risk/GetRisksByCashierId',
                    type: 'POST',
                    dataType: "json",
                    data: {
                        id: function () { return vm.cashierId }
                    }
                }
            },
            schema: {
                total: "Total",
                data: "Data",
                parse: function (result) {
                    console.log('data recieved')
                    console.log(result)
                    return result;
                }
            },
            pageSize: 10,
            serverPaging: true
        })

    });




    return vm;
}