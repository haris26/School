(function () {

    var app = angular.module("school", ["ngRoute", "ngCookies"]);
    authenticated = false;
    currentUser = {
        id: 0,
        name: "",
        roles: [],
        token: "",
        expiration: null
    };


    app.constant("schConfig",
        {
            source: "http://localhost:61310/api/",
            months: ['jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec'],
            weekdays: ['sun', 'mon', 'tue', 'wed', 'thu', 'fri', 'sat'],
            deadline: 5,
            year: 2016,
            signature: "gC0xdV8gLD2cU0lzeDxFGZoZhxd78iz+6KojPZR5Wh4=",
            apiKey: "R2lnaVNjaG9vbA=="
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/requests", { templateUrl: "views/NewRequests.html", controller: "AllRequestsController" })
            .when("/servicerequests", { templateUrl: "views/ServiceRequests.html", controller: "ServiceRequestsController" })
            .when("/admindashboard", { templateUrl: "views/AdminDashboard.html", controller: "AdminDashboardController" })
            .when("/makenewrequest", { templateUrl: "views/SendNewRequest.html", controller: "NewRequestsController" })
            .when("/assets", { templateUrl: "views/AllAssets.html", controller: "AssetsController" })
            .when("/newservicerequests", { templateUrl: "views/SendServiceRequest.html", controller: "NewServiceRequestController" })
             .when("/login", { templateUrl: "views/login.html", controller: "LoginController" })
            .when("/logout", { template: "", controller: "LogoutController" })
            .when("/people", { templateUrl: "views/people.html", controller: "PeopleController" })
            .when("/teams", { templateUrl: "views/teams.html", controller: "TeamsController" })
            .when("/roles", { templateUrl: "views/roles.html", controller: "RolesController" })
            .when("/engagements", { templateUrl: "views/engagements.html", controller: "EngagementsController" })
            .otherwise({ redirectTo: "/" });
    })
        .run(function ($rootScope, $location) {
        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (!authenticated) {
                if (next.templateUrl != "views/login.html")
                    $location.path("/login");
            }
        })
    });
}());