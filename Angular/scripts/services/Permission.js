(function () {

    var app = angular.module("school");

    app.directive('permission', function () {
        return {
            restrict: 'A',
            link: function (scope, elem, attr) {
                var perms = attr.permission.split(",");
                var roles = currentUser.roles;
             
                var allow = false;
                console.log(perms);
                console.log(roles);
                for (var i = 0; i < perms.length; i++) {
                    if (roles.indexOf(perms[i]) > -1) {
                        allow = true;
                        break;
                    }
                }
                if (allow)
                    elem.css("display", "block");
                else
                    elem.css("display", "none");
            }
        };
    })
}());