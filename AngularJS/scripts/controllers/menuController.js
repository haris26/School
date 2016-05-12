(function () {

    var app = angular.module("school");

    app.controller("MenuController", function ($rootScope) {

        buildMenu();

        function buildMenu() {
            $rootScope.menuItems = [];
            if (currentUser.roles.indexOf("Admin") > -1) {
                $rootScope.menuItems.push({ link: "overview", class: "glyphicon glyphicon-home", text: "Overview" });
                $rootScope.menuItems.push({ link: "teams", class: "glyphicon glyphicon-user", text: "Teams" });
                $rootScope.menuItems.push({ link: "people", class: "glyphicon glyphicon-user", text: "People" });
                $rootScope.menuItems.push({ link: "qualifications", class: "glyphicon glyphicon-bookmark", text: "Qualifications" });
                $rootScope.menuItems.push({ link: "skills", class: "glyphicon glyphicon-cog", text: "Skills" });
                $rootScope.menuItems.push({ link: "findPeople", class: "glyphicon glyphicon-search", text: "Find People" });
            };
            if (currentUser.roles.indexOf("User") > -1) {
                $rootScope.menuItems.push({ link: "employeeSummary", class: "glyphicon glyphicon-user", text: "User Profile" });
            };
        };

        $rootScope.$on('userLoggedIn', function () {
            buildMenu();
        });

    });
}());