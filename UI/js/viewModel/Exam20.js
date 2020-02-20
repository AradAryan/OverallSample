
function initVm(arg) {

    var vm = kendo.observable({
        hasDeleteAccess: arg.hasDeleteAccess,
        phoneImgUrl: arg.phoneImgUrl,

        onSearch: function (e) {
            //alert('asda');
            vm.SearchDS.page(0);
        },

        SearchDS: new kendo.data.DataSource({
            transport: {

                read: {

                    dataType: "json",
                    type: 'POST',
                    url: arg.customerDetailUrl + '/Exam20/Search',
                    data: {
                        UniversityID: function () { debugger; return vm.UniversityID },
                        ProvinceId: function () { return vm.AreaLocationID },
                        CenterId: function () { return vm.NetworkId },
                        EnName: function () { return vm.sepasId },
                        NationalCode: function () { return vm.nationalCode },
                        CorporateName: function () { return vm.corporateName },
                        Center: function () { return vm.corporateName },
                        Site: function () { return vm.corporateName }
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
        }
    });
    return vm;
}


