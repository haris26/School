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
            .when("/admindashboard", { templateUrl: "views/AdminDashboard.html", controller: "AdminDashboardController" })

            .when("/makenewrequest", { templateUrl: "views/SendNewRequest.html", controller: "NewRequestsController" })

            .when("/assets", { templateUrl: "views/AllAssets.html", controller: "AssetsController" })
            .when("/newservicerequests", { templateUrl: "views/SendServiceRequest.html", controller: "NewServiceRequestController" })
            .otherwise({ redirectTo: "/" });
    });

}());