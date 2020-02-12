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
        tozihat: '',


        //for searching the client with its nationalcode.
        onSearch: function (e) {
            vm.searchDS.read();
        },


        searchDS: new kendo.data.DataSource({

            transport: {
                read: {
                    url: 'http://localhost/UI/cartable/GetLoansForEtebariUser',
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
            debugger;
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest('tr'));
            vm.set('selectedItemId', dataItem.Id);
            vm.set('loanAmount', dataItem.Amount);
            var tozih = $(e.currentTarget).closest('tr').children('td').eq(6).children('textarea').val();
            vm.set('tozihat', tozih);
            if (vm.loanAmount >= 100000000 && vm.tozihat == '')
            {
                alert('برای ثبت وام های بیشتر از ده ملیون تومان ثبت توضیح اجباری است.');
                return false;
            }
            else
            {
                showLoading();
                vm.AgreeDS.read();
            }
            
        },

        AgreeDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'POST',
                    dataType: "json",
                    url: 'http://localhost/UI/Cartable/AgreedByEtebariUser',
                    data: {
                        loanId: function () { return vm.selectedItemId },
                        tozihat: function () { return vm.tozihat }
                    }
                }
            },
            schema: {
                parse: function (result) {
                    hideLoading();
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
            var tozih = $(e.currentTarget).closest('tr').children('td').eq(6).children('textarea').val();
            vm.set('tozihat', tozih);
            if (vm.tozihat == '') {
                alert('برای رد درخواست وام ثبت توضیح اجباری است.');
                return false;
            }
            else {
                showLoading();
                vm.disagreeDS.read();
            }
        },

        disagreeDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'POST',
                    dataType: "json",
                    url: 'http://localhost/UI/Cartable/RejectedByEtebariUser',
                    data: {
                        loanId: function () { return vm.selectedItemId },
                        tozihat: function () { return vm.tozihat }
                    }
                }
            },
            schema: {
                parse: function (result) {
                    hideLoading();
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