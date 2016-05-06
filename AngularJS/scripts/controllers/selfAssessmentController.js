(function () {

    var app = angular.module("school");

    app.controller("SelfAssessmentCtrl", function ($scope, $routeParams, $log, $location, DataService, toaster) {

        var categories = {};

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        $scope.assessed = {};
        $scope.selectedCategory = {};

        $scope.assessmentClass = {
            true: "btn btn-success btn-sm",
            false: "btn btn-primary btn-sm"
        }

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
                $scope.selectedCategory = $scope.categories[0];
                $scope.message = "";
                for (i = 0; i < $scope.categories.length; i++) {
                    var ids = categories[$scope.categories[i].name];
                    var filteredTools = $scope.categories[i].tools.filter(function (obj) {
                                                                            return !(obj.id in ids);
                    });
                    $scope.categories[i].tools = filteredTools;
                }
            })
        }

        getEmployee($scope.employeeId);

        function getEmployee(id) {
            DataService.read("selfassessments", id, function (data) {
                $scope.assessments = data;
                for (i = 0; i < $scope.assessments.skills.length; i++) {
					categories[$scope.assessments.skills[i].categoryName] = {};
                    for (j = 0; j < $scope.assessments.skills[i].skills.length; j++) {
                        $scope.assessed[$scope.assessments.skills[i].skills[j].skillId] = false;
                        categories[$scope.assessments.skills[i].categoryName][$scope.assessments.skills[i].skills[j].skillId] = $scope.assessments.skills[i].skills[j];
                    }
                }
                fetchCategories();
                $scope.message = "";
                $scope.data = [];
            })
        }

        $scope.createEmployeeSkill = function (skill) {
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
                    if (data != false) {
                        $scope.assessed[skill.skillId] = true;
                        toaster.pop('note', skill.skill + " assessed");
                    }
                    else {
                        toaster.pop('error', skill.skill + " could not be assessed!");
                    }
                });
        }

        $scope.goToAssessment = function () {
            $location.path('/employeeAssessments/' + $scope.employeeId);
        }

    });
}());