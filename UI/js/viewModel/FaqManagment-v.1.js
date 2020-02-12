function initVM(args) {
    var vm = kendo.observable({

        questionText: '',
        answerText: '',
        systemId: '',
        isActive: '',
        imgName:'',
        id: 0,
        activityId: 0,
        samaneId: 0,


        onSearch: function (e) {
            vm.searchDS.page(0);
        },

        searchDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: 'http://localhost/UI/Faq/SearchFaq',
                    data: {
                        QustionText: function () { return vm.questionText },
                        AnswerText: function () { return vm.answerText },
                        SystemId: function () { return vm.samaneId }
                    }
                }
            },

            schema: {
                total: "Total",
                data: "Data",
            
            },
            pageSize: 10,
            serverPaging: true
        }),

        onComplete: function onComplete(e) {
            var upload = $("#files").data("kendoUpload");
            upload.disable();
        },

        onSuccess: function (e) {
            vm.set('imgName', e.response.Name);
        },

        onClear: function (e) {
            var upload = $("#files").data("kendoUpload");
            upload.clearAllFiles();
        },



        onNewUser: function (e) {
            e.preventDefault();
            showLoading();
            vm.newUserDS.read();
        },


        newUserDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: "json",
                    type: 'POST',
                    url: 'http://localhost/UI/Faq/InsertFaq',
                    data: {
                        Id: function () { return vm.id },
                        QustionText: function () { return vm.questionText },
                        AnswerText: function () { return vm.answerText },
                        SystemId: function () { return vm.samaneId },
                        Enabled: function () { if (vm.activityId == 1) { return true; } else { return false; } },
                        ImageFileName: function () { return vm.imgName } 
                    }
                }
            }
            ,
            schema: {
                parse: function (fd) {
                    if (fd == true) {
                        if (vm.id == 0) {
                            alert('سوال جدید با موفقیت اضافه شد.')
                        }
                        else {
                            alert('سوال با موفقیت ویرایش شد.')
                        }

                        hideLoading();
                        vm.set('questionText', "");
                        vm.set('answerText', '');
                        vm.set('samaneId', 0);
                        vm.set('activityId', 0);
                        vm.set('id', 0);
                        vm.set('imgName', '');
                        $('#newuserbtn').html('ایجاد مورد جدید');
                        $('#searchbtn').show();
                        vm.onClear();
                        vm.searchDS.read();
                    }
                    else {
                        alert('خطایی رخ داده است.');
                        hideLoading();
                    }
                    return [];
                }
            }

        }),








        onDeleteUser: function (e) {
            debugger;
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('id', dataItem.Id);
            if (confirm(' آیا مایل به حذف این FAQ هستید؟')) {
                // showLoading();
                vm.deleteDS.read();
                vm.set('selectedItemId', 0);
            };
            return false;
        },

        deleteDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: 'json',
                    type: 'POST',
                    url: 'http://localhost/UI/Faq/DeleteFaq',
                    data: {
                        id: function () { return vm.id }
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
            vm.set('id', dataItem.Id);
            vm.set('questionText', dataItem.QustionText);
            vm.set('answerText', dataItem.AnswerText);
            vm.set('samaneId', dataItem.SystemId);
            vm.set('activityId', dataItem.Enabled);
            $('#newuserbtn').html('ویرایش');
            $('#searchbtn').hide();

        },




        onRetrieveUser: function (id) {
            debugger;
            vm.set('id', id);
            showLoading();
            vm.retrieveDS.read();
            vm.set('id', 0);
        },

        retrieveDS: new kendo.data.DataSource({
            transport: {
                read: {
                    dataType: 'json',
                    type: 'POST',
                    url: 'http://localhost/UI/Faq/ActivateFaq',
                    data: {
                        Id: function () { return vm.id }
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

        onDeactiveUser: function (e) {
            e.preventDefault();
            var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
            vm.set('id', dataItem.Id);
            showLoading();
            vm.deactiveUserDS.read();
            vm.set('id', 0);
        },


        deactiveUserDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'POST',
                    dataType: 'json',
                    url: 'http://localhost/UI/Faq/DeactivateFaq',
                    data: {
                        id: function () { return vm.id }
                    }
                }
            },
            schema: {
                parse: function (result) {
                    hideLoading();
                    if (result == true) {
                        alert("غیرفعالسازی با موفقیت انجام شد.");
                        vm.searchDS.read();
                    }
                    else {
                        alert("غیرفعالسازی با خطا روبرو شد.");
                    }
                    return [];
                }
            }

        }),

        onUpload: function (e) {
            href.location = 'http://localhost/UI/Faq/PostImg';
        },



        activityDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'GET',
                    dataType: 'json',
                    url: 'http://localhost/UI/faq/GetActivityState',
                    data: {
                        addEmptyItem: true
                    }
                }
            }
        }),

        samaneDS: new kendo.data.DataSource({
            transport: {
                read: {
                    type: 'GET',
                    dataType: 'json',
                    url: 'http://localhost/UI/faq/GetSamane',
                    data: {
                        addEmptyItem: true
                    }
                }
            }
        })
    });
    return vm;
}