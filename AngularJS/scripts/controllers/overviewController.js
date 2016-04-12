(function () {

    var app = angular.module("school");

    app.controller("OverviewCtrl", function ($scope, DataService) {

        $scope.message = "Loading data...";

        fetchOverview();

        function fetchOverview() {
            DataService.list("overview", function (data) {
                $scope.overview = data;
                $scope.message = "";
            })
        }
    });

}());