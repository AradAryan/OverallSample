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
            $.ajax({
                type: 'POST',
                url: 'http://localhost/UI/Cartable/SearchClient',
                dataType: 'json',
                data: {
                    NationalCode: function () { return vm.nationalCode },
                    ClientCode: function () { return vm.clientCode },
                },
                success: function (result) {
                    vm.set("firstName", result.FirstName);
                    vm.set("custId", result.id);

                    vm.set("lastName", result.LastName);
                    vm.set("custTypeId", result.CustTypeId);
                    if (result.CustTypeId == 1)
                    { vm.set("custType", "مشتری حقیقی"); }
                    else if (result.CustTypeId == 2)
                    { vm.set("custType", "مشتری حقوقی"); }
                    else
                    { vm.set("custType", "حساب های مشترک"); }
                    $("#clientinfo").show();

                    $('#loaninfo').show();

                }
            });
        },


        //for submitting a new load for the current client.
        onSubmitLoan: function (e) {
            $.ajax({
                type: 'POST',
                url: 'http://localhost/UI/Cartable/CreateLoan',
                dataType: 'json',
                data: {
                    LoanTypeId: function () { return vm.loanTypeId },
                    CustId: function () { return vm.custId },
                    GiveBackTime: function () { return vm.givebackTime },
                    Amount: function () { return vm.loanAmount },
                    CashierId: function () { return vm.cashierId }


                },
                success: function (result) {
                    if (result == true) {
                        alert("وام جدید برای این مشتری ثبت شد.");
                        vm.set('firstName', '');
                        vm.set('lastName', '');
                        vm.set('nationalCode', '');
                        vm.set('clientCode', '');
                        vm.set('custId', 0);
                        vm.set('custType', '');
                        vm.set('custTypeId', 0);
                        vm.set('loanTypeId', 0);
                        vm.set('loanAmount', 0);
                        vm.set('givebackTime', 0);
                        vm.set('custTypeId', 0);
                        $("#clientinfo").hide();
                        $('#loaninfo').hide();
                    } else
                    {
                        alert("خطایی رخ داده است.");
                    }
                    
                }
            });
        },


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