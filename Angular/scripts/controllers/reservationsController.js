(function () {

    var app = angular.module("school");

    app.controller("ReservationsController", function ($scope, $rootScope, DataService) {

        var dataSet = "reservationoverviews";
        $scope.showme = false;
        getCategories();
        //fetchData();

        //function fetchData() {
        //    DataService.list(dataSet, function (data) {
        //        $scope.resources = data;
        //    });
        //}

        function getCategories() {
            DataService.list("resourcecategories", function (data) {
                $scope.categories = data;
            });
        };

        $scope.sendData = function(item) {
            $scope.searchParameters = {
                categoryName: item.categoryName,
                fromDate: item.fromDate.Date,
                toDate: item.toDate.Date
            };
            DataService.create(dataSet, $scope.searchParameters, function (data) {
                $scope.resources = data;
            });
        };

    });
}());
