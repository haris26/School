(function () {

    var app = angular.module("school");

    app.controller("AdminOfficeController", function ($scope, $rootScope, DataService, schConfig) {
        var dataSet = "admindashboard";
        var num = "2";
        fetchData();

        function fetchData() {

            DataService.read(dataSet, num, function (data) {
                $scope.dashboard = data;
            });
        }



    });
}());
