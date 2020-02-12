function initVM(args) {
    var vm = kendo.observable({
        id: 0,
        idOfUser: args.userId,
        corporateId: args.corpId,
        name: '',
        lastName: '',
        nationalCode: '',
        password: '',
        mobile: '',
        tel: '',
        email: '',
        positionId: '',
        positionDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'GET',
                    url: 'http://localhost/UI/Corporate/GetPosition',
                    data: {
                        addEmptyItem: true
                    }
                }
            },
            schema: {
                parse: function(result){
                    console.log('data recieved');
                    console.log(result);
                    return result;
                }



            }
        }),

        onSave: function (e) {
            vm.saveDS.read();

        },

        saveDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: 'json',
                    type: 'POST',
                    url: 'http://localhost/UI/Corporate/SaveUser',
                    data: {
                        Id: function () { return vm.idOfUser },
                        FirstName: function () { return vm.name },
                        LastName: function () { return vm.lastName },
                        NationalCode: function () { return vm.nationalCode },
                        Mobile: function () { return vm.mobile },
                        Tel: function () { return vm.tel },
                        Password: function () { return vm.password },
                        Email: function () { return vm.email },
                        PositionId: function () { return vm.positionId },
                        CorporateId: function() {return vm.corporateId}
                    }
                }
            },
            schema: {
                parse: function (result) {
                    if (result) {
                        alert('کاربر با موفقیت اضافه شد.')
                        location.href = args.centerUrl;
                    }
                    else {
                        alert('خطایی رخ داده است.')
                        location.href = args.centerUrl;
                    }
                }
            }
        })
    });
    return vm;
}