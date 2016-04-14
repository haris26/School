(function () {

    var app = angular.module("school", ["ngRoute", "angularCharts"]);

    app.constant("schConfig",
        {
            source: "http://localhost:55013/api/",
        });

    app.config(function ($routeProvider) {

        $routeProvider
		    .when("/overview", { templateUrl: "overview.html", controller: "OverviewCtrl" })
            .when("/skills", { templateUrl: "skills.html", controller: "SkillsCtrl" })
            .when("/editCategory/:categoryId", { templateUrl: "editCategory.html", controller: "SkillsCtrl" })
            .when("/qualifications", { templateUrl: "qualifications.html", controller: "QualificationsCtrl" })
            .when("/employeeSummary/:employeeId", { templateUrl: "employeeSummary.html", controller: "EmployeeSummaryCtrl" })
            .when("/qualifications", { templateUrl: "qualifications.html", controller: "SkillsCtrl" })
            .when("/people", { templateUrl: "people.html", controller: "PeopleCtrl" })
            .when("/employeeAssessments/:employeeId", {templateUrl: "employeeAssessments.html", controller: "EmployeeAssessmentsCtrl"})
            .otherwise({ redirectTo: "overview" });
    });

}());