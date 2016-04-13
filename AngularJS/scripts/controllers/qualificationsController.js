(function () {

    var app = angular.module("school");

    app.controller("QualificationsCtrl", function ($scope, DataService) {

        $scope.message = "Loading data...";
        $scope.sortOrder = "Name";

        $scope.collapsed = {};

        $scope.icon = {
            true: "glyphicon glyphicon-chevron-down",
            false: "glyphicon glyphicon-chevron-up"
        }

        fetchEducations();

        function fetchEducations() {
            DataService.list("educations", function (data) {
                $scope.educations = data;
                $scope.message = "";
            })
        }

    });

}());