(function () {

    var app = angular.module("school");

    app.controller("SelfAssessmentCtrl", function ($scope, $routeParams, $location, DataService, toaster) {

        var categories = {};

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        $scope.assessed = {};
        $scope.selectedCategory = {};
        $scope.newSkills = {};
        $scope.showAdd = true;
        $scope.showUpdate = false;
        $scope.leftToAssessEmployee = 0;
        $scope.leftToAssessOriginal = 0;

        $scope.assessmentClass = {
            true: "btn btn-success btn-sm",
            false: "btn btn-primary btn-sm"
        }
        $scope.permissions = {
            showAdmin: currentUser.roles.indexOf("Admin") > -1,
            showUser: currentUser.id == $scope.employeeId
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
                        $scope.leftToAssessEmployee++;
                        $scope.leftToAssessOriginal++;
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
                        if ($scope.assessed[skill.skillId] == false) {
                            $scope.leftToAssessEmployee--;
                            $scope.leftToAssessOriginal--;
                            $scope.assessed[skill.skillId] = true;
                            toaster.pop('note', skill.skill + " assessed");
                        }
                        else {
                            $scope.assessed[skill.skillId] = true;
                            toaster.pop('note', skill.skill + " assessed");
                        }
                    }
                    else {
                        toaster.pop('error', skill.skill + " could not be assessed!");
                    }
                });
        }

        $scope.goToAssessment = function () {
            $location.path('/employeeAssessments/' + $scope.employeeId);
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
                $scope.currentLength = newCategory.skills.length;
            });

            if ($scope.currentLength != null) {
                $scope.assessments.skills.push(newCategory);
                for (j = 0; j < $scope.assessments.skills[$scope.assessments.skills.length - 1].skills.length; j++) {
                    $scope.assessed[$scope.assessments.skills[$scope.assessments.skills.length - 1].skills[j].skillId] = false;
                }
                $scope.showAdd = false;
                $scope.showUpdate = true;
            }
            $scope.leftToAssessEmployee += $scope.currentLength;
        }

        $scope.updateEmployeeSkill = function () {

            var newCategory = {
                categoryName: "New Skills",
                skills: []
            };

            angular.forEach($scope.newSkills, function (tool) {
                    if (tool) {
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
                        $scope.currentLength = newCategory.skills.length;
                        $scope.leftToAssessEmployee = $scope.leftToAssessOriginal + $scope.currentLength;
                    }
                    else if (!tool) {
                        $scope.leftToAssessEmployee = $scope.leftToAssessOriginal + newCategory.skills.length;
                    }
            });

            if ($scope.currentLength != null) {
                console.log($scope.currentLength);
                $scope.assessments.skills.pop(newCategory);
                $scope.assessments.skills.push(newCategory);
                for (j = 0; j < $scope.assessments.skills[$scope.assessments.skills.length - 1].skills.length; j++) {
                    $scope.assessed[$scope.assessments.skills[$scope.assessments.skills.length - 1].skills[j].skillId] = false;
                }
            }
            console.log("KONACNO:", $scope.leftToAssessEmployee);
        }

        $scope.goToAssessment = function () {
            $location.path('/employeeAssessments/' + $scope.employeeId);
            $('#finishAssessmentModal').modal('hide');
            $('.modal-backdrop').remove();
            $('body').removeClass('modal-open');
        }
    });
}());