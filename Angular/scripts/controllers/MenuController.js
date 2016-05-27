(function () {

    var app = angular.module("school");

    app.controller("MenuController", function ($rootScope) {

        buildMenu();

        function buildMenu() {
            $rootScope.menuItems = [];

            if (currentUser.roles.indexOf("admin") > -1) {
                $rootScope.menuItems.push({ link: "months", class: "fa fa-home fa-lg", text: "Dashboard" });
                $rootScope.menuItems.push({ link: "calendar", class: "fa fa-calendar-o fa-lg", text: "Log Time" });
                $rootScope.menuItems.push({ link: "details", class: "fa fa-tasks fa-lg", text: "Entries" });
                $rootScope.menuItems.push({ link: "logout", class: "fa fa-sign-out fa-lg", text: "Log Out" });
              
            };
            if (currentUser.roles.indexOf("user") > -1) {
                $rootScope.menuItems.push({ link: "calendar", class: "fa fa-calendar-o fa-lg", text: "Log Time" });
                $rootScope.menuItems.push({ link: "details", class: "fa fa-tasks fa-lg", text: "Entries" });
                $rootScope.menuItems.push({ link: "logout", class: "fa fa-sign-out fa-lg", text: "Log Out" });
            };
        };

        $rootScope.$on('userLoggedIn', function () {
            buildMenu();
        });

    });
}());