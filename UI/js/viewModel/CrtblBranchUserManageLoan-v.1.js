function initVM(args) {
    var vm = kendo.observable({

        firstName: '',
        lastName: '',
        nationalCode: '',
        clientCode: '',
        custId: 0,
        custType: '',
        custTypeId: '',
        loanTypeId: '',
        loanAmount: 0,
        cashierId: 2,
        givebackTime: 0,


        //for searching the client with its nationalcode.
        onSearch: function (e) {
            vm.searchDS.read();
        },


        searchDS: new kendo.data.DataSource({

            transport: {
                read: {
                    url: 'http://localhost/UI/cartable/GetLoans',
                    type: 'POST',
                    dataType: "json",
                    data: {
                        NationalCode: function () { return vm.nationalCode },
                        ClientCode: function () { return vm.clientCode },
                        CashierId: function(){return vm.cashierId}
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
        }),


        


        //datasource of loanTypes dropdownlist.
        loanTypeDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'Get',
                    dataType: 'json',
                    url: 'http://localhost/UI/Cartable/LoanType'
                },
                schema: {
                    parse: function () {
                        return [];
                    }
                }
            }
        })

    });
    return vm;
}