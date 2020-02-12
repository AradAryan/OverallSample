function initVm(arg) {

    var vm = kendo.observable({
        hasDeleteAccess: arg.hasDeleteAccess,
        phoneImgUrl: arg.phoneImgUrl,

        DeleteDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/RegisterSyndromic/Delete',
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
                            message: "حذف آیتم با موفقیت انجام شد."
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

        ArealocationDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetLocation',
                    type: 'POST',
                    data: {
                        Areatype: 1
                    }
                },
                destroy: {
                    url: arg.customerDetailDeleteUrl,
                    data: {
                        id: arg.customerId
                    }
                }
            },
            schema: {
                model: {
                    id: "SyndromicId"
                },
                errors: function (response) {
                    lastError = response.Result;
                    Status = response.Status;
                    if (response.Errors) alert(response.Errors);
                }
            },
            change: function (e) {

                vm.set('entityData', e.items[0]);
            },
            sync: function (e) {
                hideProgress();
                if (Status == 0) {
                    showMessage(lastError, 'success');
                }
                else if (Status == 1 || Status == 2) {
                    showMessage('خطا.' + lastError, 'error');
                }
                $('#btnSave').removeAttr('disabled');

            }
        }),
        showDetails: function (e) {

            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            window.open(arg.customerDetailUrl + '/Report/Details/' + dataItem.Id, '_blank');
            // window.location.href = arg.customerDetailUrl + '/Report/Details/' + dataItem.Id;

        },
        onDelete: function (e) {
            e.preventDefault();
            if (confirm('آیا از حذف آیتم مینیمم اطمینان دارید؟ ')) {
                showLoading();
                var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
                vm.set('selectedItemId', dataItem.Id);
                vm.DeleteDS.read();
            }
        },
        onRetrieve: function (e) {
            e.preventDefault();
            showLoading();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('selectedItemId', dataItem.Id);
            vm.RetrieveDS.read();
        },
        update: function (e) {
            debugger;
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
                    url: arg.customerDetailUrl + '/Report/Search2',
                    data: {
                        university: function () { return vm.UniversityID },
                        province: function () { return vm.AreaLocationID },
                        //family: function () { return vm.family },
                        //name: function () { return vm.name },
                        //National_Code: function () { return vm.nationalCode },
                        syndromId: function () { return vm.syndromId },
                        syndromCount: function () { return vm.syndromCount },
                        CenterId: function () { return vm.CenterId },
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

        onExport: function (e) {
            var validator = $("#Form").data("kendoValidator");
            if (validator.validate()) {
                $("#Form").submit();
            }
        },
        onarelocationChange: function () {
            vm.UniversityProvince = $("#province").data("kendoDropDownList").text();
            if (vm.UniversityProvince == "همه موارد")
                vm.UniversityProvince = '';
            vm.UniversityID = 0;
            vm.NetworkId = 0;
            vm.CenterId = 0;
            vm.UniversityDS.read();
            vm.NetworkDS.read();
            vm.CenterDS.read();
            vm.UniversityID = 0;
            vm.NetworkId = 0;
            vm.CenterId = 0;
            this.set('entityData.AreaLocationID', vm.AreaLocationID);
            // setarealocation(vm.AreaLocationID);
        },
        onuniversityChange: function () {
            /*debugger;*/
            vm.UniversityID = $("#university").data("kendoDropDownList").value();
            if (vm.UniversityID == "0")
                vm.UniversityID = 0;
            vm.NetworkId = 0;
            vm.CenterId = 0;
            vm.CenterDS.read();
            vm.NetworkDS.read();
            vm.NetworkId = 0;
            vm.CenterId = 0;
            this.set('entityData.UniversityID', vm.UniversityID);
        },
        onNetworkChange: function () {
            /*debugger;*/
            vm.NetworkId = $("#Network").data("kendoDropDownList").value();
            if (vm.NetworkId == "0")
                vm.NetworkId = 0;
            vm.CenterId = 0;
            vm.CenterDS.read();
            vm.CenterId = 0;
            this.set('entityData.NetworkId', vm.NetworkId);
        },
        onCenterChange: function () {
            /*debugger;*/
            this.set('entityData.CenterId', vm.CenterId);
        },
        SyndromChange: function () {
            this.set('entityData.syndromId', vm.syndromId);
        },
        admissionTypeChange: function () {

            this.set('entityData.admissionTypeId', vm.admissionTypeId);
        },
        UniversityDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetProUniversity',
                    data: {
                        province: function () { return vm.UniversityProvince }
                    }
                }
            },
            schema: {
                model: {
                    id: "UniversityID"
                },
                //ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
                parse: function (e) {
                    debugger;
                    if (e.length == 1)
                        vm.set("UniversityID", e[0].Id);

                    return e;
                }
            }


        }),
        NetworkDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetProNetwork',
                    data: {
                        UniversityID: function () { /*debugger;*/ return vm.UniversityID },
                        province: function () { return vm.UniversityProvince }
                    }
                }
            },
            schema: {
                model: {
                    id: "NetworkId"
                },
                //ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
                parse: function (e) {
                    debugger;
                    if (e.length == 1)
                        vm.set("NetworkId", e[0].Id);

                    return e;
                }
            }

        }),
        CenterDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetProCenter',
                    data: {
                        NetworkId: function () { return vm.NetworkId },
                        UniversityID: function () { /*debugger;*/ return vm.UniversityID },
                        province: function () { return vm.UniversityProvince }
                    }
                }
            },
            schema: {
                model: {
                    id: "CenterId"
                },
                //ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss
                parse: function (e) {
                    debugger;
                    if (e.length == 1)
                        vm.set("CenterId", e[0].Id);

                    return e;
                }
            }



        }),
        SyndromDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Report/GetAllSyndromics',
                    type: 'Get',
                    data: {
                        addEmptyItem: true
                    }
                }
            },
            schema: {
                model: {
                    id: "syndromId"
                }
            }
        }),
    });
    return vm;
}


