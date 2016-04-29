(function () {

    var app = angular.module("school", ["ngRoute", "ngCookies", "ui.bootstrap", "ngAnimate", "toaster"]);

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
            .when("/logout", { template: "", controller: "LogoutController" })
            .when("/resources", { templateUrl: "views/resourceList.html", controller: "ResourceController" })
            .when("/home", { templateUrl: "views/userDashboard.html", controller: "UserDashboardController" })
            .when("/profile", { templateUrl: "views/userDashboard.html", controller: "UserDashboardController" })
            .when("/reservations/active", { templateUrl: "views/active.html", controller: "UserDashboardController" })
            .when("/reservations", { templateUrl: "views/resources.html", controller: "ReservationsController" })
            .when("/device/reservation", { templateUrl: "views/deviceReservation.html", controller: "DeviceReservationController" })
            .when("/reservations/recurring", { templateUrl: "views/recurringReservations.html", controller: "RecurringReservationsController" })
            .when("/room/reservation", { templateUrl: "views/roomReservation.html", controller: "RoomReservationController" })

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