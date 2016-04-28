(function () {

    var app = angular.module("school");

    app.controller("SupervisorAssessmentCtrl", function ($scope, $routeParams, $log, $location, DataService) {

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

        $scope.updateEmployeeSkill = function (skill,dateOfSelfAssessment ) {

            var employeeSkill = {
                id: skill.employeeSkillId,
                employee: $scope.employeeId,
                skillId: skill.skillId,
                level: skill.level,
                experience: skill.experience,
                dateOfSelfAssessment: dateOfSelfAssessment,
                dateOfSupervisorAssessment: new Date(),
                assessedBy: 1
            }

            DataService.update("employeeskills", skill.employeeSkillId, employeeSkill, function (data) {
               // getEmployee($scope.employeeId);
            });
        }
    });
}());