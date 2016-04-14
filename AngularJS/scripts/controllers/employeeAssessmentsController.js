(function () {

    var app = angular.module("school");

    app.controller("EmployeeAssessmentsCtrl", function ($scope, $routeParams, $log, DataService) {
        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        getEmployeeAssessments($scope.employeeId);

        function getEmployeeAssessments(id) {
            DataService.read("employeeassessments", id, function (data) {
                $scope.assessments = data;
                $scope.message = "";
            })
        }

    });
}());