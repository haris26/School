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
		    .when("/overview", { templateUrl: "views/overview.html", controller: "OverviewCtrl", resolve: { factory: userRouting } })
            .when("/skills", { templateUrl: "views/skills.html", controller: "SkillsCtrl", resolve: { factory: userRouting } })
            .when("/editCategory/:categoryId", { templateUrl: "views/editCategory.html", controller: "SkillsCtrl", resolve: { factory: userRouting } })
            .when("/qualifications", { templateUrl: "views/qualifications.html", controller: "QualificationsCtrl", resolve: { factory: userRouting } })
            .when("/people", { templateUrl: "views/people.html", controller: "PeopleCtrl", resolve: { factory: userRouting } })
            .when("/supervisorAssessment/:employeeId", { templateUrl: "views/supervisorAssessment.html", controller: "SupervisorAssessmentCtrl", resolve: { factory: userRouting } })
            .when("/findPeople", { templateUrl: "views/findPeople.html", controller: "FindPeopleCtrl", resolve: { factory: userRouting } })
            .when("/teams", { templateUrl: "views/teams.html", controller: "TeamsSummaryCtrl", resolve: { factory: userRouting } })
            .when("/pendingAssessments", { templateUrl: "views/pendingAssessments.html", controller: "PendingAssessmentsCtrl", resolve: { factory: userRouting } })

            //employeeId
            .when("/employeeSummary/:employeeId", { templateUrl: "views/employeeSummary.html", controller: "EmployeeSummaryCtrl", resolve: { factory: userRouting } })
            .when("/employeeAssessments/:employeeId", { templateUrl: "views/employeeAssessments.html", controller: "EmployeeAssessmentsCtrl", resolve: { factory: userRoutingEmployeeAssessment } })
            .when("/selfAssessment/:employeeId", { templateUrl: "views/selfAssessment.html", controller: "SelfAssessmentCtrl", resolve: { factory: userRoutingSelfAssessment } })
            .when("/editEmployeeQualifications/:employeeId", { templateUrl: "views/editEmployeeQualifications.html", controller: "EditEmployeeQualificationsCtrl", resolve: { factory: userRoutingQualification } })
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

    var userRouting = function ($location) {
        if (currentUser.roles.indexOf("Admin") > -1) {
            return true;
        } else {
            return $location.path("/employeeSummary/" + currentUser.id);
        }
    };

    var userRoutingSelfAssessment = function ($location) {
            return $location.path("/selfAssessment/" + currentUser.id);
    };

    var userRoutingEmployeeAssessment = function ($location) {
        if (currentUser.roles.indexOf("Admin") > -1) {
            return true;
        } else {
            return $location.path("/employeeAssessments/" + currentUser.id);
        }
    };

    var userRoutingQualification = function ($location) {
        if (currentUser.roles.indexOf("Admin") > -1) {
            return true;
        } else {
            return $location.path("/editEmployeeQualifications/" + currentUser.id);
        }
    };



}());