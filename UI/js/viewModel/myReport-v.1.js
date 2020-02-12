function initVM(arg) {
    var vm = kendo.observable({
        entityData: {},
        provinceId: 0,
        provinceTitle: '',
        universityId: 0,
        networkId: 0,
        centerId: 0,
        syndromicId: 0,
        startDate: '',
        endDate: '',

        provinceDataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetLocation',
                    type: 'POST',
                    data: {
                        Areatype: 1
                    }
                }
            },
            //change: function (e) {
            //    vm.set('entityData', e.items[0]);
            //},
        }),

        onProvinceChange: function () {
            vm.provinceTitle = $("#province").data("kendoDropDownList").text();
            vm.provinceId = $("#province").data("kendoDropDownList").value();
            if (vm.provinceTitle == "همه موارد") {
                vm.provinceTitle = '';
                vm.provinceId = 0;
            }

            vm.universityDataSource.read();

            vm.universityId = 0;
            vm.networkId = 0;
            vm.centerId = 0;
            vm.universityDataSource.read();
            vm.networkDataSource.read();
            vm.centerDataSource.read();
            vm.universityId = 0;
            vm.networkId = 0;
            vm.centerId = 0;
            //<this.set('entityData.ProvinceId', vm.provinceId);
        },

        universityDataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetProUniversity',
                    data: {
                        ProvinceTitle: function () { return vm.provinceTitle }
                    }
                }
            }
        }),

        onUniversityChange: function () {
            vm.universityId = $("#university").data("kendoDropDownList").value();
            if (vm.universityId == "0")
                vm.universityId = 0;

            vm.networkId = 0;
            vm.centerId = 0;
            vm.centerDataSource.read();
            vm.networkDataSource.read();
            vm.networkId = 0;
            vm.centerId = 0;
            //<this.set('entityData.UniversityId', vm.universityId);
        },

        networkDataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetProNetwork',
                    data: {
                        ProvinceTitle: function () { return vm.provinceTitle },
                        UniversityId: function () { return vm.universityId }
                    }
                }
            }
        }),

        onNetworkChange: function () {
            vm.networkId = $("#Network").data("kendoDropDownList").value();
            if (vm.networkId == "0")
                vm.networkId = 0;

            vm.centerId = 0;
            vm.centerDataSource.read();
            vm.centerId = 0;
            //<this.set('entityData.NetworkId', vm.networkId);
        },

        centerDataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetProCenter',
                    data: {
                        ProvinceTitle: function () { return vm.provinceTitle },
                        UniversityId: function () { return vm.universityId },
                        NetworkId: function () { return vm.networkId }
                    }
                }
            },
        }),

        onCenterChange: function () {
            vm.centerId = $("#Center").data("kendoDropDownList").value();
            if (vm.centerId == "0")
                vm.centerId = 0;
            //<this.set('entityData.CenterId', vm.centerId);
        },

        syndromDataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetAllSyndromics',
                    type: 'Get',
                    data: {
                        addEmptyItem: true
                    }
                }
            }
        }),

        onSyndromChange: function () {
            vm.syndromicId = $("#SyndromicId").data("kendoDropDownList").value();
            if (vm.syndromicId == "0")
                vm.syndromicId = 0;
            //<this.set('entityData.SyndromicId', vm.syndromicId);
        },

        onSearch: function (e) {
            vm.searchDataSource.page(0);
        },

        searchDataSource: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: arg.searchUrl,
                    data: {
                        ProvinceId: function () { return vm.provinceId },
                        ProvinceTitle: function () { return vm.provinceTitle },
                        UniversityId: function () { return vm.universityId },
                        NetworkId: function () { return vm.networkId },
                        CenterId: function () { return vm.centerId; },
                        SyndromicId: function () { return vm.syndromicId; },
                        StartDate: function () { return vm.startDate },
                        EndDate: function () { return vm.endDate }
                    }
                }
            },
            schema: {
                total: "Total",
                data: "Data"
            },
            pageSize: 10,
            serverPaging: true
        }),

        onDetail: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.dialogBox = $('<div id="details-box"/>').appendTo('body');
            vm.dialogBox.kendoWindow({
                iframe: true,
                content: 'Detail/' +
                          dataItem.CenterId + "," +
                          vm.endDate + "," +
                          dataItem.NetworkId + "," +
                          dataItem.ProvinceId + "," +
                          vm.startDate + "," +
                          dataItem.SyndromicId + "," +
                          dataItem.UniversityId,
                title: 'جزئیات',
                close: function (e) {
                    alert('Closing...');
                    vm.dialogBox.remove();
                }
            });
            vm.dialogBox.data('kendoWindow').open().maximize();

            return false;
        },
    });
    return vm;
}