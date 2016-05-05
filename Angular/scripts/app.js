(function () {

    var app = angular.module("school", ["ngRoute", "ngCookies",'toaster',"ngAnimate"]);
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
              .when("/test", { templateUrl: "views/AdminRequests.html", controller: "AdminDashboardController" })

            //Dashboards
             .when("/admindashboard", { templateUrl: "views/AdminDashboard.html", controller: "AdminDashboardController", resolve: { factory: userRouting } })
             .when("/officer", { templateUrl: "views/AdminDashboard.html", controller: "AdminOfficeController", resolve: { factory: userRouting } })
             .when("/userdashboard", { templateUrl: "views/UserDashboard.html", controller: "UserDashboardController", resolve: { factory: userRouting } })

            //User-request manipulation
            //send new
            .when("/makenewrequest", { templateUrl: "views/SendNewRequest.html", controller: "NewRequestsController" })
             .when("/assets", { templateUrl: "views/AllAssets.html", controller: "AssetsController" })
             .when("/servicemyassets", { templateUrl: "views/UserAssetsForService.html", controller: "UserDashboardController" })
            .when("/newservicerequests", { templateUrl: "views/SendServiceRequest.html", controller: "NewServiceRequestController" })
  

        //Free assets(admin) 
        .when("/free", { templateUrl: "views/FreeAssets.html", controller: "AssetsController" })

           

            //login and logout controller
            .when("/login", { templateUrl: "views/login.html", controller: "LoginController", resolve: { factory: userRouting } })
            .when("/logout", { template: "", controller: "LogoutController" })


          
           
            
            .when("/people", { templateUrl: "views/people.html", controller: "PeopleController", resolve: { factory: userRouting } })
            .when("/teams", { templateUrl: "views/teams.html", controller: "TeamsController", resolve: { factory: userRouting } })
            .when("/roles", { templateUrl: "views/roles.html", controller: "RolesController", resolve: { factory: userRouting } })
             .when("/engagements", { templateUrl: "views/engagements.html", controller: "EngagementsController", resolve: { factory: userRouting } })

          //All assets owned by a user

              .when("/myassets", { templateUrl: "views/MyAssets.html", controller: "UserDashboardController"})

            //requests that user sent(user dashboard)
            .when("/usernewrequests", { templateUrl: "views/UserRequestsForNew.html", controller: "UserDashboardController"})
             .when("/userservicerequests", { templateUrl: "views/UserRequestsForService.html", controller: "UserDashboardController"})
                     .when("/completedrequests", { templateUrl: "views/CompletedRequestsForUser.html", controller: "AllRequestsController" })
            .otherwise({ redirectTo: "/login" });
    })
        .run(function ($rootScope, $location) {
        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (!authenticated) {
                if (next.templateUrl != "views/login.html")
                    $location.path("/login");
            }
        })
        });


    var userRouting = function ($location) {
        if (currentUser.roles.indexOf("ITOfficer") > -1) {
            return    $location.path("/admindashboard");
            //} else if (currentUser.roles.indexOf("OfficeManager") > -1) {
            //    return $location.path("/officer");

            //}
        }
        else {
            return $location.path("/userdashboard");
        }
    };
}());