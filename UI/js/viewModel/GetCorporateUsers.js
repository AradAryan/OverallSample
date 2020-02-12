function initVM(args) {
    var vm = kendo.observable({

        firstName: '',
        lastName: '',
        userName: '',
        mobile: '',
        email: '',
        selecteditem: args.corpId,
        selectedItemId: 0,

        onSearch: function (e) {
            vm.searchDS.read();
            // vm.searchDS.page(0);
        },

        searchDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: args.searchUrl,
                    data: {
                        Id: function () { return vm.selecteditem; },
                        FirstName: function () { return vm.firstName; },
                        LastName: function () { return vm.lastName; },
                        UserName: function () { return vm.userName; },
                        Mobile: function () { return vm.mobile; },
                        Email: function () { return vm.email; }
                    }
                }
            },

            schema: {
                total: "Total",
                data: "Data",
                parse: function (result) {
                    console.log('data recieved');
                    console.log(result);
                    return result;
                }
            },
            pageSize: 10,
            serverPaging: true
        }),
        onNewUser: function (e) {
            e.preventDefault();
            location.href = 'http://localhost/UI/Corporate/NewUser?corporateId=' + vm.selecteditem;
        },

        onDeleteUser: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('selectedItemId', dataItem.Id);
            if (confirm(' آیا مایل به حذف این کاربر هستید؟')) {
                showLoading();
                vm.deleteDS.read();
            };
            return false;
        },

        deleteDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: 'json',
                    type: 'POST',
                    url: 'http://localhost/UI/Corporate/Delete',
                    data: {
                        id: function () { return vm.selectedItemId }
                    }
                }
            },
            schema: {
                parse: function (response) {
                    hideLoading();
                    if (response == true) {
                        vm.searchDS.read();
                        alert("حذف آیتم با موفقیت انجام شد.")
                    } else {
                        alert("حذف آیتم با خطایی روبرو شد.")
                    }
                    return [];
                }
            }
        }),

        onUpdateUser: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('selectedItemId', dataItem.Id);
            location.href = 'http://localhost/UI/Corporate/NewUser?corporateId=' + vm.selecteditem + '&userId=' + vm.selectedItemId;
        },

        onRetrieveUser: function (id) {
            debugger;
            //e.preventDefault();
            //var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('selectedItemId', id);
            showLoading();
            vm.retrieveDS.read();
        },

        retrieveDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: 'json',
                    type: 'POST',
                    url: 'http://localhost/UI/Corporate/Retrieve',
                    data: {
                        Id: function () { return vm.selectedItemId }
                    }
                }
            },
            schema: {
                parse: function (response) {
                    hideLoading();
                    if (response == true) {
                        alert("بازیابی با موفقیت انجام شد.")
                        vm.searchDS.read();
                    } else {
                        alert("بازیابی با خطا روبرو شد.")
                    }

                    return [];
                }

            }
        }),

    });
    return vm;
}