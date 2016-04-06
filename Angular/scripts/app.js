(function () {

    var app = angular.module("school", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:61310/api/",
            months: ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec'],
            weekdays: ['sun', 'mon', 'tue', 'wed', 'thu', 'fri', 'sat'],
            deadline: 5,
            year: 2016
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/requests", { templateUrl: "views/NewRequests.html", controller: "AllRequestsController" })
            .when("/servicerequests", { templateUrl: "views/ServiceRequests.html", controller: "ServiceRequestsController" })
            //.when("/roles", { templateUrl: "views/roles.html", controller: "RolesController" })
            //.when("/engagements", { templateUrl: "views/engagements.html", controller: "EngagementsController" })
            .otherwise({ redirectTo: "/" });
    });

}());