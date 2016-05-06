(function () {

    var app = angular.module("school");

    app.controller("SelfAssessmentCtrl", function ($scope, $routeParams, $location, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        $scope.assessed = {};
        $scope.selectedCategory = {};
        $scope.newSkills={};

        $scope.assessmentClass = {
            true: "btn btn-success btn-sm",
            false: "btn btn-primary btn-sm"
        }

        fetchCategories();

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
                $scope.selectedCategory = $scope.categories[0];
                $scope.message = "";
            })
        }

        getEmployee($scope.employeeId);

        function getEmployee(id) {
            DataService.read("selfassessments", id, function (data) {
                $scope.assessments = data;
                for (i = 0; i < $scope.assessments.skills.length; i++) {
                    for (j = 0; j < $scope.assessments.skills[i].skills.length; j++) {
                        $scope.assessed[$scope.assessments.skills[i].skills[j].skillId] = false;
                    }
                }
                $scope.message = "";
                $scope.data = [];
            })
        }

        $scope.createEmployeeSkill = function (skill) {

            console.log(skill);

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

        $scope.addEmployeeSkill = function () {
            
            var newCategory = {
                categoryName: "New Skills",
                skills: []
            };
          
            angular.forEach($scope.newSkills, function (tool) {
                var newEmployeeSkill = {
                    employee: $scope.employeeId,
                    skillId: tool.id,
                    level: 1,
                    experience: 0,
                    skill: tool.name,
                    dateOfSelfAssessment: new Date(),
                    assessedBy: 0,
                }
               newCategory.skills.push(newEmployeeSkill);
            });

            $scope.assessments.skills.push(newCategory);
            for (j = 0; j < $scope.assessments.skills[$scope.assessments.skills.length - 1].skills.length; j++) {
                $scope.assessed[$scope.assessments.skills[$scope.assessments.skills.length - 1].skills[j].skillId] = false;
            }
            }
    });
}());