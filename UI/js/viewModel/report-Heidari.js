function initVM(arg) {

    var vm = kendo.observable({
        hasDeleteAccess: arg.hasDeleteAccess,
        phoneImgUrl: arg.phoneImgUrl,




        ArealocationDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.getLocationsUrl,
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

        entityData: {},
        lastError: '',
        Status: '',
        city: '',
        areaName: '',
        univercity: '',
        syndromic: '',
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
                    url: arg.searchUrl,
                    data: {
                        univercity: function () { return vm.UniversityID },
                        city: function () { return vm.areaName },

                        syndromic: function () { return vm.syndromId },

                    }
                }
            },
            schema: {
                total: "Total",
                data: "Data",
                parse: function (result) {
                 
                  //  console.log(result);
                    return result;
                }
            },
            pageSize: 2,
            serverPaging: true
        }),


        onarelocationChange: function () {
            vm.UniversityProvince = $("#province").data("kendoDropDownList").text();
            if (vm.UniversityProvince == "همه موارد")
                vm.UniversityProvince = '';
            vm.UniversityID = 0;
            vm.NetworkId = 0;
            vm.CenterId = 0;
            vm.UniversityDS.read();

            vm.UniversityID = 0;
            vm.NetworkId = 0;
            vm.CenterId = 0;
            this.set('entityData.AreaLocationID', vm.areaName);
            // setarealocation(vm.AreaLocationID);
        },
        onuniversityChange: function () {
            /*debugger;*/
            vm.UniversityID = $("#university").data("kendoDropDownList").value();
            if (vm.UniversityID == "0")
                vm.UniversityID = 0;
            vm.NetworkId = 0;
            vm.CenterId = 0;

            vm.NetworkId = 0;
            vm.CenterId = 0;
            this.set('entityData.UniversityID', vm.UniversityID);
        },

        SyndromChange: function () {
            this.set('entityData.syndromId', vm.syndromId);
        },

        UniversityDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.getProUniversityUrl,
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


        SyndromDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.getAllSandromicUrl,
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
        })

    });
    return vm;
}


