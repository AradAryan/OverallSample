function initVM(args) {
    var vm = kendo.observable({

        firstName: '',
        lastName: '',
        nationalCode: '',
        clientCode: '',
        gozaresh:'',
        riskTypeId: 0,
        cashierId: 3,

        onSubmit: function (e) {
            showLoading();
            $.ajax({
                type: 'POST',
                url: 'http://localhost/UI/Risk/CreateRisk',
                dataType: 'json',
                data: {
                    NationalCode: function () { return vm.nationalCode },
                    CustomerCode: function () { return vm.clientCode },
                    FirstName: function () { return vm.firstName },
                    LastName:function () { return vm.lastName } ,
                    Description: function () { return vm.gozaresh },
                    RiskId: function () { return vm.riskTypeId },
                    CashierId: function () { return vm.cashierId }

                },
                success: function (result) {
                    hideLoading();
                    if (result == true) {
                        alert("ریسک جدید برای این مشتری ثبت شد.");
                        vm.set('firstName', '');
                        vm.set('lastName', '');
                        vm.set('nationalCode', '');
                        vm.set('clientCode', '');
                        vm.set('gozaresh', '');
                        vm.set('riskTypeId', 0);
                    }
                 else {
                        alert("خطایی رخ داده است.");
        }
                }
            });
        },


       
        riskTypeDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'Get',
                    dataType: 'json',
                    url: 'http://localhost/UI/Risk/RiskType'
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