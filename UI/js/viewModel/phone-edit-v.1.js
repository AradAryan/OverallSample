

function initVM(arg) {
    var vm = kendo.observable({
        id: arg.id,
        firstname: arg.firstname,
        lastname: arg.lastname,
        mobile: arg.mobile,
       
        onSave: function (e) {
            vm.saveDS.read();
        },

        saveDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: arg.saveUrl,
                    data: {
                        id: function () { return vm.id; },
                        firstname: function () { return vm.firstname; },
                        lastname: function () { return vm.lastname; },
                        mobile: function () { return vm.mobile; }
                    }
                }
            },
            schema: {
                parse: function (result) {
                    if (window.top != window) {
                        var parentVM = window.top.viewModel;
                        if (parentVM && parentVM.dialogBox && parentVM.dialogBox.data && parentVM.dialogBox.data('kendoWindow')) {
                            console.log(parentVM.dialogBox.data('kendoWindow'));
                            parentVM.dialogBox.data('kendoWindow').close();
                        }
                    }

                    return [];
                }
            }
        }),

    });
    return vm;
}
