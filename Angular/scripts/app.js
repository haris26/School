﻿(function () {

    var app = angular.module("school", ["ngRoute"]);

    authenticated = false;
    currentUser = {};

    app.constant("schConfig",
        {
            source: "http://localhost:50169/api/",
            months: ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec'],
            weekdays: ['sun', 'mon', 'tue', 'wed', 'thu', 'fri', 'sat'],
            deadline: 5,
            year: 2016,
            signature: "gC0xdV8gLD2cU0lzeDxFGZoZhxd78iz+6KojPZR5Wh4=",
            apiKey: "R2lnaVNjaG9vbA==",
            repeatingType: ['Undefined','Daily', 'Weekly', 'Monthly']
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/login", { templateUrl: "views/login.html", controller: "LoginController" })
            .when("/resources", { templateUrl: "views/resourceList.html", controller: "ResourceController" })
            .when("/home", { templateUrl: "views/userDashboard.html", controller: "UserDashboardController" })
            .when("/dashboard", { templateUrl: "views/userDashboard.html", controller: "UserDashboardController" })
            .when("/active", { templateUrl: "views/active.html", controller: "UserDashboardController" })
            .when("/reservations", { templateUrl: "views/resources.html", controller: "ReservationsController" })
            .otherwise({ redirectTo: "/home" });

    }).run(function ($rootScope, $location) {
        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (!authenticated) {
                if (next.templateUrl != "views/login.html")
                    $location.path("/login");
            }
        })
    });
    
}());