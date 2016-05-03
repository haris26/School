(function () {

    var app = angular.module("school");

    app.controller("SelfAssessmentCtrl", function ($scope, $routeParams, $log, $location, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        getEmployee($scope.employeeId);


        function getEmployee(id) {
            DataService.read("selfassessments", id, function (data) {
                $scope.assessments = data;
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
                toaster.pop('note', skill.skill + " assessed");
            });
        }
      
    });
}());