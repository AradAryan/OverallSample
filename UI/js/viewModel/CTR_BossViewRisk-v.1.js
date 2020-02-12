function initVM(args) {
    var vm = kendo.observable({
        searchDS: new kendo.data.DataSource({

            transport: {
                read: {
                    url: 'http://localhost/UI/Risk/GetRisk',
                    type: 'POST',
                    dataType: "json",
                    data: {
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