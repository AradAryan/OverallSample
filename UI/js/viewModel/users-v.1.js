
function initVM(args) {
    var vm = kendo.observable({
        firstName: '',
        lastName: '',
        nationalCode: '',


        onSearch: function (e) {
            console.log(e);
            vm.searchDS.page(0);
        },
        
        searchDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: 'json',
                    type: 'POST',
                    url: args.searchUrl,
                    data: {
                        FirstName: function () { return vm.firstName; },
                        LastName: function () { return vm.lastName; },
                        NationalCode: function () { return vm.nationalCode; }
                    }

                }
            },
            schema: {
                total: 'Total',
                data: 'Data',
                parse: function (result) {
                    console.log('data recieved');
                    console.log(result);
                    return result;
                }
            },
            pageSize: 10,
            serverPaging: true
        }),

    });
    return vm;
}