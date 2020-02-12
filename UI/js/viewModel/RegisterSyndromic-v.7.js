
function initVm(arg) {
    var vm = kendo.observable({
        SyndromDSGet: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/RegisterSyndromic/GetSyndromics',
                    type: 'Get'
                }
            },
            schema: {
                model: {
                    id: "SyndromId"
                }
            }
        }),
        SabtAhvalDS: new kendo.data.DataSource({

            transport: {

                read: {

                    // dataType: "json",
                    dataType: "JSON",
                    url: arg.customerDetailUrl + '/ProRegisterSyndromic/CheckUserWithNationalCode',
                    type: 'Post',
                    data: {
                        NationalCode: function () {
                            return vm.NationalCode;
                        }
                    }
                }
            },
            change: function (e) {
                //vm.set('entityData', e.items[0]);
            },
            sync: function (e) {

            },
            schema: {
                model: {
                },
                parse: function (response) {
                    vm.set('NameBoxIsVisible', true);

                    hideLoading();
                    if (response.BirthDate != "0") {
                        vm.set('FirstName', response.PersonInfoProperty.FirstName);
                        vm.set('LastName', response.PersonInfoProperty.LastName);
                        vm.set('FatherName', response.PersonInfoProperty.Father_FirstName);
                        vm.set('BirthDate', response.BirthDate);
                        vm.set('Gender', response.PersonInfoProperty.Gender.Coded_string);
                        vm.set('Nationality', 11);
                        // $("#show").show();
                    } else {
                        notification.show({
                            title: "خطا!",
                            message: "متاسفانه کد ملی مورد نظر یافت نشد."
                        }, "error");
                        // $("#show").show();
                    }
                    return [response];
                }
            }
        }),
        SyndromDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'POST',
                    dataType: "json",
                    url: arg.customerDetailUrl + '/RegisterSyndromic/save',
                    data: {
                        SyndromeId: function () { return vm.SyndromeId },
                        NationalCode: function () { return vm.NationalCode },
                        CellPhone: function () { return vm.PhoneNumber },
                        FirstName: function () { return vm.FirstName },
                        LastName: function () { return vm.LastName },
                        TelPhone: function () { return vm.StableNumber },
                        GenderID: function () { return vm.Gender },
                        NationalityID: function () { return vm.Nationality },
                        FirstNameFather: function () { return vm.FatherName },
                        BirthDate: function () { return vm.BirthDate || $('#BirthDate').val() },
                        AdmissionType: function () { return vm.Status },
                        hasNationalCode: function () { return vm.HasNationalCode },
                        Address: function () { return vm.Address },
                        AddressProvinceId: function () { return vm.ProvinceId },
                        AddressCityId: function () { return vm.CityId },
                        //Address: vm.Address,
                        AdmissionId: function () { return arg.AdmissionId },
                        Dates: function () { return vm.RegisterDate || $('#RegisterDate').val() }
                    }
                }
            },
            schema: {
                parse: function (response) {
                    if (response && response.futureDate) {
                        notification.show({
                            title: "خطا!",
                            message: response.message
                        }, "error");
                        hideLoading();
                        return [];
                    }
                    if (response.Result == 1) {
                        notification.show({
                            message: "اطلاعات خطی سندروم با موفقیت ذخیره گردید."
                        }, "upload-success");
                        setTimeout(function () { window.location = '/Report'; }, 1000);
                    } else {
                        hideLoading();

                        var message = typeof response.Result == 'string' ? response.Result : (typeof response == 'string' ? response : "متاسفانه ذخیره ی اطلاعات با مشکل مواجه گردید");

                        notification.show({
                            title: "خطا!",
                            message: message
                        }, "error");
                        // setTimeout(function () { location.reload(); }, 1000);
                    }
                    return [];
                }
            }
        }),
        UpdateDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/RegisterSyndromic/Update',
                    type: 'POST',
                    data: {
                        Id: arg.AdmissionId
                    }
                }
            },
            schema: {
                model: {
                    AdmissionId: "AdmissionId"
                },
                parse: function (response) {
                    debugger;
                    var props = Object.getOwnPropertyNames(response);
                    if (response.NationalCode) {
                        $("#show").show();
                    }
                    vm.set("NationalCode", response.NationalCode);
                    vm.set("HasNationalCode", !!response.NationalCode);
                    vm.set("HasNotNationalCode", !vm.HasNationalCode);
                    vm.set("FirstName", response.FirstName);
                    vm.set("PhoneNumber", response.CellPhone);
                    vm.set("LastName", response.LastName);
                    vm.set("StableNumber", response.TelPhone);
                    vm.set("FatherName", response.FirstNameFather);
                    vm.set("BirthDate", response.BirthDate);
                    vm.set("Address", response.FullAddress);
                    vm.set("Gender", response.GenderID);
                    vm.set("Status", response.Status);
                    vm.set("Nationality", response.NationalityID);
                    vm.set("SyndromeId", response.EducationID);
                    vm.set("ProvinceId", response.AddressProvinceId);
                    vm.set("CityId", response.AddressCityId);
                    vm.set("Province", { Id: response.AddressProvinceId });
                    vm.set("RegisterDate", response.Dates);
                    vm.CityDS.read();
                    hideLoading();
                    return [];
                }
            }
        }),
        ReadUpdate: function (e) {
            debugger;
            if (arg.AdmissionId) {
                vm.UpdateDS.read();
            } else {
                hideLoading();
            }
        },
        showNameBox: function () {
            // this.set('entityData.HasNationalCode', !vm._hasNotNationalCode);
            // $("#show").toggle();
            // $("#showbtn").toggle();
            // $("#NationalCodeTextBox").toggle();
            // vm.set('_hasNotNationalCode', !vm._hasNotNationalCode);
            // vm.set('HasNationalCode', !vm._hasNotNationalCode)
            setTimeout(function () {
                if (vm.HasNationalCode) {
                    // $(".handle-requiered").removeAttr("required");
                    $("#NationalCode").attr("required", "required");
                } else {
                    $("#NationalCode").removeAttr("required");
                    // $(".handle-requiered").attr("required", "required");
                }

                vm.set('NameBoxIsVisible', true);
            }, 100);
        },
        entityData: {},
        countryName: '',
        countryId: '',
        Status: '0',
        FirstName: '',
        Nationality: '0',
        PhoneNumber: '',
        FirstName: '',
        LastName: '',
        StablePhone: '',
        Gender: '0',
        FatherName: '',
        BirthDate: '',
        RegisterDate: arg.RegisterDate,
        SyndromeId: '2',
        HasNationalCode: !arg.isEdit || arg.hasNationalCode,
        HasNotNationalCode: false,
        NationalCode: '',
        Address: '',
        Province: {
            Id: arg.defaultProvinceId
        },
        City: {
            Id: arg.defaultCityId
        },
        ProvinceId: arg.defaultProvinceId || 0,
        CityId: arg.defaultCityId || 0,

        NameBoxIsVisible: arg.isEdit,
        resetIsVisible: !arg.isEdit,

        reset: function (e) {
            vm.set('countryName', '');
            vm.set('countryId', '');
            vm.set('Status', '0');
            vm.set('FirstName', '');
            vm.set('Nationality', '0');
            vm.set('PhoneNumber', '');
            vm.set('FirstName', '');
            vm.set('LastName', '');
            vm.set('StableNumber', '');
            vm.set('Gender', '0');
            vm.set('FatherName', '');
            vm.set('BirthDate', '');
            vm.set('RegisterDate', arg.RegisterDate);
            vm.set('SyndromeId', '2');
            vm.set('HasNationalCode', true);
            vm.set('HasNotNationalCode', false);
            vm.set('NationalCode', '');
            vm.set('Address', '');
            vm.set('NameBoxIsVisible', false);
        },

        save: function (e) {
            if (!vm.NameBoxIsVisible) {
                notification.show({
                    title: "خطا!",
                    message: "ابتدا باید «استعلام کد ملی» را انجام دهید (کلیک روی دکمه استعلام کد ملی)."
                }, "error");
                return false;
            }

            var validator = $("#UserForm").data("kendoValidator"),
                phoneEntered = utils.validation.atLeastOfItemFilled($('#PhoneNumber'), $('#StableNumber'));
            if (!phoneEntered) {
                notification.show({
                    title: "",
                    message: "وارد کردن حداقل یک شماره تلفن الزامی است."
                }, "error");
                return false;
            }
            if (validator.validate() || validator.errors().length == 0) {
                showLoading();

                vm.SyndromDS.read();
            } else {
                notification.show({
                    title: "خطا!",
                    message: "یک یا چند فیلد به درستی پر نشده اند."
                }, "error");
            }
        },
        onGenderChange: function () {

            this.set('entityData.Gender', vm.Gender);
        },
        onNationalityChange: function () {

            this.set('entityData.Nationality', vm.Nationality);
        },
        onStatusChange: function () {

            this.set('entityData.Status', vm.Status);
        },
        handleDate: function (input) {

            vm.BirthDate = $("#BirthDate").val();
        },
        onSyndromChange: function () {

            this.set('SyndromeId', vm.SyndromeId);
        },
        SabtAhval: function (e) {
            showLoading();
            vm.SabtAhvalDS.read();
        },

        ProvinceDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Home/GetProvinces',
                    type: 'POST'
                }
            },
            schema: {
                model: {
                    AdmissionId: "ProvinceId"
                },
                parse: function (data) {
                    return [{ Id: '', Title: '' }].concat(data);
                }
            }
        }),

        CityDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    url: arg.customerDetailUrl + '/Home/GetCities',
                    type: 'POST',
                    data: {
                        ProvinceId: function () { return vm.ProvinceId; }
                    }
                }
            },
            schema: {
                model: {
                    AdmissionId: "CityId"
                },
                parse: function (data) {
                    $.each(data, function (i, item) {
                        if (item.Id == vm.CityId) {
                            setTimeout(function () {
                                vm.set('City', { Id: item.Id });
                            }, 50);
                        }
                    });
                    return data;
                }
            }
        }),

        onProvinceChange: function (e) {
            vm.set('ProvinceId', vm.Province.Id);
            vm.CityDS.read();
        },

        onCityChange: function (e) {
            // console.log(vm.Province);
            if (vm.City) {
                vm.set('CityId', vm.City.Id);
            }
        }
    });
    return vm;
}


$(function () {
    $('#PhoneNumber').keydown(function (e) {
        var key = e.charCode || e.keyCode || 0;
        $phone = $(this);

        // Auto-format- do not expose the mask as the user begins to type
        if (key !== 8 && key !== 9) {
            if ($phone.val().length === 4) {
                $phone.val($phone.val() + '-');
            }
            if ($phone.val().length === 5) {
                $phone.val($phone.val() + '');
            }
            //if ($phone.val().length === 9) {
            //    $phone.val($phone.val() + '');
            //}
        }

        // Allow numeric (and tab, backspace, delete) keys only
        return (key == 8 ||
				key == 9 ||
				key == 46 ||
				(key >= 48 && key <= 57) ||
				(key >= 96 && key <= 105));
    }).bind('focus click', function () {
        $phone = $(this);

        if ($phone.val().length === 0) {
            $phone.val('09');
        }
        else {
            var val = $phone.val();
            $phone.val('').val(val); // Ensure cursor remains at the end
        }
    }).blur(function () {
        $phone = $(this);

        if ($phone.val() === '(') {
            $phone.val('');
        }
    });
});

$(function () {
    $('#StableNumber').keydown(function (e) {
        var key = e.charCode || e.keyCode || 0;
        $phone = $(this);

        // Auto-format- do not expose the mask as the user begins to type
        if (key !== 8 && key !== 9) {
            if ($phone.val().length === 3) {
                $phone.val($phone.val() + '-');
            }
            if ($phone.val().length === 5) {
                $phone.val($phone.val() + '');
            }
            //if ($phone.val().length === 9) {
            //    $phone.val($phone.val() + '');
            //}
        }

        // Allow numeric (and tab, backspace, delete) keys only
        return (key == 8 ||
				key == 9 ||
				key == 46 ||
				(key >= 48 && key <= 57) ||
				(key >= 96 && key <= 105));
    }).bind('focus click', function () {
        $phone = $(this);

        if ($phone.val().length === 0) {
            $phone.val('0');
        }
        else {
            var val = $phone.val();
            $phone.val('').val(val); // Ensure cursor remains at the end
        }
    }).blur(function () {
        $phone = $(this);

        if ($phone.val() === '(') {
            $phone.val('');
        }
    });
});