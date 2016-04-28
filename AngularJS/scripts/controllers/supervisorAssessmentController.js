(function () {

    var app = angular.module("school");

    app.controller("SupervisorAssessmentCtrl", function ($scope, $routeParams, $log, $location, DataService) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        getEmployee($scope.employeeId);

        function getEmployee(id) {
            DataService.read("supervisorassessments", id, function (data) {
                $scope.assessments= data;
                $scope.message = "";
                $scope.data = [];
            })
        }

        //function saveAssessment() {
        //    DataService.update("employeeskill", id, )
        //}

    });
}());