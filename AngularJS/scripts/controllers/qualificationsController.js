(function () {

    var app = angular.module("school");

    app.controller("QualificationsCtrl", function ($scope, $log, DataService) {

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
                for (i = 0; i < $scope.educations.length; i++) {
                    $scope.collapsed[$scope.educations[i].type] = true;
                }
            })
        }
    });
}());