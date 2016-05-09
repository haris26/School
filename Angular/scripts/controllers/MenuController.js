(function () {

    var app = angular.module("school");

    app.controller("MenuController", function ($rootScope) {

        buildMenu();

        function buildMenu() {
            $rootScope.menuItems = [];
            


            if (currentUser.roles.indexOf("admin") > -1) {
                $rootScope.menuItems.push({ link: "months", class: "glyphicon glyphicon-home", text: "Dashboard" });
                $rootScope.menuItems.push({ link: "calendar", class: "glyphicon glyphicon-calendar", text: "Log Time" });
                $rootScope.menuItems.push({ link: "details", class: "glyphicon glyphicon-dashboard", text: "Entries" });
                $rootScope.menuItems.push({ link: "logout", class: "glyphicon glyphicon-log-out", text: "Log Out" });
              
            };
            if (currentUser.roles.indexOf("developer") > -1) {
                $rootScope.menuItems.push({ link: "calendar", class: "glyphicon glyphicon-calendar", text: "Log Time" });
                $rootScope.menuItems.push({ link: "details", class: "glyphicon glyphicon-dashboard", text: "Entries" });
                $rootScope.menuItems.push({ link: "logout", class: "glyphicon glyphicon-log-out", text: "Log Out" });
            };

        };

        $rootScope.$on('userLoggedIn', function () {
            buildMenu();
        });

    });
}());