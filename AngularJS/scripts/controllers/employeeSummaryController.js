(function () {

    var app = angular.module("school");

    app.controller("EmployeeSummaryCtrl", function ($scope, $routeParams, DataService) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        getEmployee($scope.employeeId);

        function getEmployee(id) {
            DataService.read("employeesummaries", id, function (data) {
                $scope.summary = data;
                $scope.message = "";
            })
        }
    });
}());