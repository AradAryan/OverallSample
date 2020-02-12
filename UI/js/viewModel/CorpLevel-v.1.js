;
function addCorpLevels(vm) {
    var loadedDDLs = [];
    $.extend(vm, {
        AreaLocationID: vm.AreaLocationID || vm.provinceId || 0,
        UniversityID: vm.UniversityID || vm.universityId || 0,
        UniversityProvince: vm.UniversityProvince || '',
        NetworkId: vm.NetworkId || vm.networkId || 0,
        CenterId: vm.CenterId || vm.centerId || 0,
        entityData: vm.entityData || {},

        ArealocationDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: corpVars.provinceUrl,
                    type: 'POST',
                    data: {
                        Areatype: 1
                    }
                }
            },
            schema: {
                model: {
                    id: "AreLocationId"
                },
                parse: function (response) {
                    loadedDDLs.push(1);
                    vm.checkAllParametersAreLoadedAndHideLoading();
                    return response;
                }
            }
        }),

        CityDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: corpVars.citiesUrl,
                    type: 'POST',
                    data: {
                        ProvinceId: function () { return vm.AreaLocationID; }
                    }
                }
            }
            // ,
            // schema: {
            //     parse: function (data) {
            //         // loading data
            //         // todo: change the way of data-binding
            //         $.each(data, function (i, item) {
            //             if (item.Id == vm.CityId) {
            //                 setTimeout(function () {
            //                     vm.set('City', { Id: item.Id });
            //                 }, 50);
            //             }
            //         });
            //         return data;
            //     }
            // }
        }),


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

            if ($('#cityId').length) {
                vm.CityDS.read();
            }

            //setarealocation(vm.AreaLocationID);
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
        UniversityDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: corpVars.universityUrl,
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
                    loadedDDLs.push(1);
                    vm.checkAllParametersAreLoadedAndHideLoading();
                    if (e.length == 1) {
                        vm.set("UniversityID", e[0].Id);
                    }
                    return e;
                }
            }
        }),
        NetworkDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: corpVars.networkUrl,
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
                parse: function (e) {
                    loadedDDLs.push(1);
                    vm.checkAllParametersAreLoadedAndHideLoading();
                    if (e.length == 1) {
                        vm.set("NetworkId", e[0].Id);
                    }
                    return e;
                }
            }
        }),
        CenterDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: corpVars.centerUrl,
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
                parse: function (e) {
                    loadedDDLs.push(1);
                    vm.checkAllParametersAreLoadedAndHideLoading();
                    if (e.length == 1) {
                        vm.set("CenterId", e[0].Id);
                    }
                    return e;
                }
            }
        }),

        checkAllParametersAreLoadedAndHideLoading: function () {
            if (loadedDDLs.length >= 4) {
                hideLoading();
            }
        }
    });
}
;