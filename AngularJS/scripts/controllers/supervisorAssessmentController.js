(function () {

    var app = angular.module("school");

    app.controller("SupervisorAssessmentCtrl", function ($scope, $routeParams, $log, $location, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        getEmployee($scope.employeeId);


        function getEmployee(id) {
            DataService.read("supervisorassessments", id, function (data) {
                $scope.assessments = data;
                $scope.message = "";
                $scope.data = [];
            })
        }

        $scope.updateEmployeeSkill = function (skill, dateOfSelfAssessment ) {
            //$log.info(skill);
            var employeeSkill = {
                id: skill.employeeSkillId,
                employee: $scope.employeeId,
                tool: skill.skillId,
                level: skill.level,
                experience: skill.experience,
                skill:skill.skill,
                dateOfSelfAssessment: dateOfSelfAssessment,
                dateOfSupervisorAssessment: new Date(),
                assessedBy: 1,
            }

            //$log.info(employeeSkill);

            DataService.update("employeeskills", skill.employeeSkillId, employeeSkill, function (data) {
                if (data != false) {
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