function initVM(arg)
{
    var vm = kendo.observable
    ({
        firstname : 'milad',
        lastname : 'karami',
        mobile: '09187559855',
        tellTypeId: '0',
        onSearch: function(e)
        {
            vm.searchDs.page(0);
        },
        tellTypeDs:new kendo.data.DataSource
        ({
            transport:
            {
                read:
                {
                    //id:function(){returnn vm}
                }
            }
        }),
        searchDs: new kendo.data.DataSource
        ({

            transport:
            {
                read:
                {
                    dataType:'json',
                    url: arg.searchUrl,
                    type: 'POST',

                    data:
                    {

                        firstname: function () { return vm.firstname; },
                        lastname: function () { return vm.lastname; },
                        mobile:function(){return vm.lastname}
                    }
                }
            },
            schema: {
                total: "Total",
                data: "Data",
                // parse: function (result) {
                //     console.log('data received');
                //     console.log(result);
                //     return result;
                // }
            },
            pageSize: 10,
            serverPagin:true
        })
    });
    return vm;
}