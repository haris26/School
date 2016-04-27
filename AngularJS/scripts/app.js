(function () {

    var app = angular.module("school", ["ngRoute", "ngCookies", "angularCharts", "ui.bootstrap", "toaster", "ngAnimate"]);

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
            source: "http://localhost:55013/api/",
            signature: "gC0xdV8gLD2cU0lzeDxFGZoZhxd78iz+6KojPZR5Wh4=",
            apiKey: "R2lnaVNjaG9vbA=="
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/login", { templateUrl: "views/login.html", controller: "LoginCtrl" })
		    .when("/overview", { templateUrl: "views/overview.html", controller: "OverviewCtrl" })
            .when("/skills", { templateUrl: "views/skills.html", controller: "SkillsCtrl" })
            .when("/editCategory/:categoryId", { templateUrl: "views/editCategory.html", controller: "SkillsCtrl" })
            .when("/qualifications", { templateUrl: "views/qualifications.html", controller: "QualificationsCtrl" })
            .when("/employeeSummary/:employeeId", { templateUrl: "views/employeeSummary.html", controller: "EmployeeSummaryCtrl" })
            .when("/employeeAssessments/:employeeId", { templateUrl: "views/employeeAssessments.html", controller: "EmployeeAssessmentsCtrl" })
            .when("/supervisorAssessment/:employeeId", { templateUrl: "views/supervisorAssessment.html", controller: "SupervisorAssessmentCtrl" })
            .when("/people", { templateUrl: "views/people.html", controller: "PeopleCtrl" })
            .when("/editEmployeeQualifications/:employeeId", { templateUrl: "views/editEmployeeQualifications.html", controller: "EditEmployeeQualificationsCtrl" })
            .when("/logout", { template: "", controller: "LogoutCtrl" })
            .otherwise({ redirectTo: "/overview" });
    }).run(function ($rootScope, $location) {
        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            if (!authenticated) {
                if (next.templateUrl != "views/login.html")
                    $location.path("/login");
            }
        })
    });
}());