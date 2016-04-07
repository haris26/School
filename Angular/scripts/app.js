(function(){

    var app = angular.module("school", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:52571/api/",
            months: [ 'jan', 'feb', 'mar', 'apr', 'may', 'jun', 'jul', 'aug', 'sep', 'oct', 'nov', 'dec' ],
            weekdays: [ 'sun', 'mon', 'tue', 'wed', 'thu', 'fri', 'sat' ],
            deadline: 5,
            year: 2016
        });

    app.config(function($routeProvider) {

        $routeProvider
            .when("/details", { templateUrl: "views/details.html", controller: "DetailsController" })
            .when("/people", {templateUrl: "views/people.html", controller: "PeopleController"})
            .when("/teams", {templateUrl: "views/teams.html", controller: "TeamsController"})
            .when("/roles", {templateUrl: "views/roles.html", controller: "RolesController"})
            .when("/engagements", {templateUrl: "views/engagements.html", controller: "EngagementsController"})
            .otherwise({redirectTo: "/people"});
    });

}());
