(function () {

    var app = angular.module("school");

    app.controller("MenuController", function ($rootScope) {

        buildMenu();

        function buildMenu() {
            $rootScope.menuItems = [];
            $rootScope.menuItems.push({ link: "people", text: "People" });
            //if (currentUser.roles.indexOf("admin") > -1) {
            //    $rootScope.menuItems.push({ link: "roles", text: "Roles" });
            //    $rootScope.menuItems.push({ link: "teams", text: "Teams" });
            //};
            //$rootScope.menuItems.push({ link: "engagements", text: "Engagements" });
        };

        $rootScope.$on('userLoggedIn', function () {
            buildMenu();
        });

    });
}());