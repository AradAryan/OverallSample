
function initView(vm) {
    $("#Gender").kendoDropDownList({
    });
    $("#Nationality").kendoDropDownList({
    });
    $("#Status").kendoDropDownList({
    });
    $("#Province").kendoDropDownList({
    });
    $("#City").kendoDropDownList({
    });

    var container = $("#UserForm");
    kendo.init(container);

    $(function () {
        container.kendoValidator({
            rules: {
                minimum: function (input) {
                    if (input.is("[name=PhoneNumber]") || input.is("[name=StableNumber]")) {
                        return input[0].value.length == 0 || input[0].value.length == 12;
                    }
                    return true;
                }
            }
        });
    });
}
