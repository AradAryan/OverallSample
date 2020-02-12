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
        selectedItemId: 0,


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

        onAgree: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest('tr'));
            vm.set('selectedItemId', dataItem.Id);
            vm.AgreeDS.read();
        },

        AgreeDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'POST',
                    dataType: "json",
                    url: 'http://localhost/UI/Cartable/AgreedByBoss',
                    data: {
                        loanId: function () { return vm.selectedItemId }
                    }
                }
            },
            schema: {
                parse: function (result) {
                    if (result == true) {

                        vm.searchDS.read();
                    }
                    else {
                        alert('خطایی رخ داده است.')
                    }

                    return [];
                }
            }
        
        }),

        onDisagree: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest('tr'));
            vm.set('selectedItemId', dataItem.Id);
            vm.disagreeDS.read();
        },

        disagreeDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'POST',
                    dataType: "json",
                    url: 'http://localhost/UI/Cartable/RejectedByBoss',
                    data: {
                        loanId: function () { return vm.selectedItemId }
                    }
                }
            },
            schema: {
                parse: function (result) {
                    if (result == true) {

                        vm.searchDS.read();
                    }
                    else {
                        alert('خطایی رخ داده است.')
                    }

                    return [];
                }
            }

        }),

    });




    return vm;
}