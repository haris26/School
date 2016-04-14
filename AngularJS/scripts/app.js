(function () {

    var app = angular.module("school", ["ngRoute", "angularCharts"]);

    app.constant("schConfig",
        {
            source: "http://localhost:55013/api/",
            signature: "gC0xdV8gLD2cU0lzeDxFGZoZhxd78iz+6KojPZR5Wh4=",
            apiKey: "R2lnaVNjaG9vbA=="
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/login", { templateUrl: "login.html", controller: "LoginCtrl" })
		    .when("/overview", { templateUrl: "overview.html", controller: "OverviewCtrl" })
            .when("/skills", { templateUrl: "skills.html", controller: "SkillsCtrl" })
            .when("/editCategory/:categoryId", { templateUrl: "editCategory.html", controller: "SkillsCtrl" })
            .when("/qualifications", { templateUrl: "qualifications.html", controller: "QualificationsCtrl" })
            .when("/employeeSummary/:employeeId", { templateUrl: "employeeSummary.html", controller: "EmployeeSummaryCtrl" })
            .when("/qualifications", { templateUrl: "qualifications.html", controller: "SkillsCtrl" })
            .when("/people", {templateUrl: "people.html", controller:"PeopleCtrl"})
            .otherwise({ redirectTo: "/login" });
    }).run(function ($rootScope, $location) {
        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (!authenticated) {
                if (next.templateUrl != "login.html")
                    $location.path("/login");
            }
        })
    });
}());