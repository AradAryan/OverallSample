function initVm(arg) {
	var vm = kendo.observable({
		showIncompleteItems: false,
		hasDeleteAccess: arg.hasDeleteAccess,

		entityData: {},
		startDate: '',
		endDate: '',  

		onSearch: function (e) {
			var validator = $("#Form").data("kendoValidator");
			if (validator.validate()) {
				vm.SearchDS.read();
			}
		},
		SearchDS: new kendo.data.DataSource({
			transport: {
				read: {
					dataType: "json",
					type: 'POST',
					url: arg.searchUrl,
					data: {
						university: function () { return vm.UniversityID },
						province: function () { return vm.AreaLocationID },
						startDate: function () { return vm.startDate },
						endDate: function () { return vm.endDate },
						NetworkId: function () { return vm.NetworkId },
						CenterId: function () { return vm.CenterId; }
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
		SyndromChange: function () {
			this.set('entityData.syndromId', vm.syndromId);
		},
		admissionTypeChange: function () {

			this.set('entityData.admissionTypeId', vm.admissionTypeId);
		},
		onExport: function (e) {
		    var validator = $("#Form").data("kendoValidator");
		    if (validator.validate()) {
		        $("#Form").submit();
		    }
		},
	});
	return vm;
}


