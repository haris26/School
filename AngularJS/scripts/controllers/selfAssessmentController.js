(function () {

    var app = angular.module("school");

    app.controller("SelfAssessmentCtrl", function ($scope, $routeParams, $log, $location, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        $scope.assessed = {};

        $scope.assessmentClass = {
            true: "btn btn-success btn-sm",
            false: "btn btn-primary btn-sm"

        $scope.categoryItem = {
            id: 0,
            name: ""
        };

        $scope.skillItem = {
            id: 0,
            name: "",
            category: 0,
            numOfEmployees: 0
        };

        fetchCategories();

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
                $scope.message = "";
            })
        }

        getEmployee($scope.employeeId);

        function getEmployee(id) {
            DataService.read("selfassessments", id, function (data) {
                $scope.assessments = data;
                for (i = 0; i < $scope.assessments.skills.length; i++) {
                    $scope.assessed[$scope.assessments.skills[i].categoryName] = {};
                    for (j = 0; j < $scope.assessments.skills[i].skills.length; j++) {
                        $scope.assessed[$scope.assessments.skills[i].categoryName][$scope.assessments.skills[i].skills[j].skillId] = false;
                    }
                }
                $scope.message = "";
                $scope.data = [];
            })
        }

        $scope.createEmployeeSkill = function (skill, categoryName) {
                var employeeSkill = {
                    employee: $scope.employeeId,
                    tool: skill.skillId,
                    level: skill.level,
                    experience: skill.experience,
                    skill: skill.skill,
                    dateOfSelfAssessment: new Date(),
                    assessedBy: 0,
                }

                DataService.create("employeeskills", employeeSkill, function (data) {
                    $scope.assessed[categoryName][skill.skillId] = true;
                    toaster.pop('note', skill.skill + " assessed");
                });
            
        }
    });
}());