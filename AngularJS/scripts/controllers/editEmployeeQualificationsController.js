(function () {

    var app = angular.module("school");

    app.controller("EditEmployeeQualificationsCtrl", function ($scope, $routeParams, $log, $location, DataService) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        fetchEducations($scope.employeeId);

        function fetchEducations(id) {
            DataService.read("editeducations", id, function (data) {
                $scope.educations = data;
                $scope.message = "";
            })
        }

    });
}());