(function () {

    var app = angular.module("school", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:50169/api/",
            months: ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec'],
            weekdays: ['sun', 'mon', 'tue', 'wed', 'thu', 'fri', 'sat'],
            deadline: 5,
            year: 2016
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/resources", { templateUrl: "views/resourceList.html", controller: "ResourceController" })
            .when("/teams", { templateUrl: "views/teams.html", controller: "TeamsController" })
            .otherwise({ redirectTo: "/resourceList" });
    });

}());