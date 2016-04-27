(function () {

    var app = angular.module("school");

    app.controller("MenuController", function ($rootScope) {

        buildMenu();

        function buildMenu() {
            $rootScope.menuItems = [];
            $rootScope.menuItems.push({ link: "overview", class: "glyphicon glyphicon-home", text: "Overview" });
            if (currentUser.roles.indexOf("Admin") > -1) {
                $rootScope.menuItems.push({ link: "teams", class: "glyphicon glyphicon-user", text: "Teams" });
            };
            $rootScope.menuItems.push({ link: "people", class: "glyphicon glyphicon-user", text: "People" });
            $rootScope.menuItems.push({ link: "qualifications", class: "glyphicon glyphicon-bookmark", text: "Qualifications" });
            $rootScope.menuItems.push({ link: "skills", class: "glyphicon glyphicon-cog", text: "Skills" });
            $rootScope.menuItems.push({ link: "findPeople", class: "glyphicon glyphicon-search", text: "Find People" });
        };

        $rootScope.$on('userLoggedIn', function () {
            buildMenu();
        });

    });
}());