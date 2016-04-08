(function () {

    var app = angular.module("school", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:50169/api/",
            months: ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec'],
            weekdays: ['sun', 'mon', 'tue', 'wed', 'thu', 'fri', 'sat'],
            deadline: 5,
            year: 2016,
            repeatingType: ['Undefined','Daily', 'Weekly', 'Monthly']
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/resources", { templateUrl: "views/resourceList.html", controller: "ResourceController" })
            .when("/home", { templateUrl: "views/userDashboard.html", controller: "UserDashboardController" })
            .when("/dashboard", { templateUrl: "views/userDashboard.html", controller: "UserDashboardController" })
            .when("/active", { templateUrl: "views/active.html", controller: "UserDashboardController" })
            .when("/reservations", { templateUrl: "views/resources.html", controller: "ReservationsController" })
            .otherwise({ redirectTo: "/home" });
    });

}());