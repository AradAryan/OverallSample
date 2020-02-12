function initVm(arg) {

    var vm = kendo.observable({
        hasDeleteAccess: arg.hasDeleteAccess,
        phoneImgUrl: arg.phoneImgUrl,

        RetrieveDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/RegisterSyndromic/Retrieve',
                    type: 'POST',
                    data: {
                        id: function () { return vm.selectedItemId; }
                    }
                }
            },
            schema: {
                parse: function (response) {
                    hideLoading();
                    if (response == true) {
                        var grid = $('#grid').data('kendoGrid'),
                            currentPage = grid.dataSource.page();
                        grid.dataSource.page(currentPage);
                        notification.show({
                            message: "بازیابی آیتم با موفقیت انجام شد."
                        }, "upload-success");
                    } else {
                        notification.show({
                            title: "خطا!",
                            message: "خطایی در اجرای عملیات رخ داده است."
                        }, "error");
                    }
                    return [];
                }
            }
        }),

        showDetails: function (e) {

            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            window.open(arg.customerDetailUrl + '/Report/Details/' + dataItem.Id, '_blank');
            // window.location.href = arg.customerDetailUrl + '/Report/Details/' + dataItem.Id;

        },

        onRetrieve: function (e) {
            e.preventDefault();
            showLoading();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('selectedItemId', dataItem.Id);
            vm.RetrieveDS.read();
        },
        update: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            window.open(arg.customerDetailUrl + '/RegisterSyndromic/Index/' + dataItem.Id, '_blank');
        },
        entityData: {},
        lastError: '',
        Status: '',
        admissionTypeId: 0,
        AreaLocationID: 0,
        syndromId: 0,
        UniversityID: 0,
        startDate: '',
        UniversityProvince: '',
        endDate: '',
        name: '',
        paper: '',
        family: '',
        NetworkId: 0,
        CenterId: 0,
        nationalCode: '',
        deleted: false,
        indirect: false,
        duplicate: false,

        onSearch: function (e) {
            vm.SearchDS.page(0);
        },
        SearchDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: arg.customerDetailUrl + '/MyReport/Search2',
                    data: {
                        university: function () { return vm.UniversityID },
                        admissionType: function () { return vm.admissionTypeId },
                        province: function () { return vm.AreaLocationID },
                        startdate: function () { return vm.startDate },
                        enddate: function () { return vm.endDate },
                        family: function () { return vm.family },
                        name: function () { return vm.name },
                        paper: function () { return vm.paper },
                        National_Code: function () { return vm.nationalCode },
                        syndromId: function () { return vm.syndromId },
                        NetworkId: function () { return vm.NetworkId },
                        CenterId: function () { return vm.CenterId },
                        deleted: function () { return vm.deleted },
                        indirect: function () { return vm.indirect },
                        duplicate: function () { return vm.duplicate }
                    }
                }
            },
            schema: {
                model: {
                    id: "SyndromRegisterId"
                },
                total: "Total",
                data: "Data"
            },
            pageSize: 10,
            serverPaging: true
        }),
    });
    return vm;
}


