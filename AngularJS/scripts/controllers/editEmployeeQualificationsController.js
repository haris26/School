(function () {

    var app = angular.module("school");

    app.controller("EditEmployeeQualificationsCtrl", function ($scope, $routeParams, $log, $location, DataService) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        $scope.educationTypes = {
            "1": "Formal Education",
            "2": "Course",
            "3": "Certificate"
        };

        fetchEducations($scope.employeeId);

        function fetchEducations(id) {
            DataService.read("editeducations", id, function (data) {
                $scope.educations = data;
                $scope.message = "";
            })
        }

    });
}());