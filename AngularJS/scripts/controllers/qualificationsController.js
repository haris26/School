(function () {

    var app = angular.module("school");

    app.controller("QualificationsCtrl", function ($scope, $log, DataService) {

        $scope.message = "Loading data...";
        $scope.sortOrder = "Name";
        $scope.school = "School";
        $scope.

        fetchEducations();

        function fetchEducations() {
            DataService.list("educations", function (data) {
                $scope.educations = data;
                $scope.message = "";
            })
        }
    });
}());