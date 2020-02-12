

function initVM(arg) {
    var vm = kendo.observable({
        firstname: '',
        lastname: '',
        mobile: '',
        phoneTypeId: 0,
        titleIsVisible: true,
        selectedId: 0,

        onSearch: function (e) {
            vm.searchDS.page(0);
        },


        onTypeChange: function (e) {
            console.log('phone type changed');
            console.log(viewModel.phoneTypeId);
            vm.set('titleIsVisible', viewModel.phoneTypeId != 41);
        },

        phoneTypesDS: new kendo.data.DataSource({
            transport: {
                read: {
                    url: arg.getTypesUrl
                }
            }
        }),

        searchDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: arg.searchUrl,
                    data: {
                        firstname: function () { return vm.firstname; },
                        lastname: function () { return vm.lastname; },
                        mobile: function () { return vm.mobile; }
                    }
                }
            },
            schema: {
                total: "Total",
                data: "Data",
                parse: function (result) {
                    console.log('data received');
                    console.log(result);
                    return result;
                }
            },
            pageSize: 2,
            serverPaging: true
        }),

        deleteDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: arg.deleteUrl,
                    data: {
                        id: function () { return vm.selectedId; }
                    }
                }
            },
            schema: {
                parse: function (succeed) {
                    if (succeed == true) {
                        alert('عملیات با موفقیت انجام شد');
                        vm.searchDS.read();
                    }
                    return [];
                }
            }
        }),

        onEdit: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            
            vm.dialogBox = $('<div id="details-box"/>').appendTo('body');
            vm.dialogBox.kendoWindow({
                iframe: true,
                content: arg.editUrl + '/' + dataItem.Id,
                title: 'ویرایش',
                close: function (e) {
                    vm.dialogBox.remove();
                    vm.searchDS.read();
                },
                width: 500,
                height: 'auto'
            });
            vm.dialogBox.data('kendoWindow').open().maximize();

            return false;
        },

        onDelete: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('selectedId', dataItem.Id);

            // blockUI(1);
            vm.deleteDS.read();

            return false;
        }
    });
    return vm;
}
