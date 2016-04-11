(function () {

    var app = angular.module("school");

    app.controller("ReservationsController", function ($scope, $rootScope, DataService) {

        var dataSet = "reservationoverview";
        $scope.showme = false;
        $scope.reservationModal = false;
        getCategories();
      
        function getCategories() {
            DataService.list("resourcecategories", function (data) {
                $scope.categories = data
            });
        };

        $scope.sendData = function(item) {
            $scope.searchParameters = {
                categoryName: item.categoryName,
                fromDate: item.fromDate,
                toDate: item.toDate
            };
            console.log($scope.searchParameters);
            DataService.create(dataSet, $scope.searchParameters, function (data) {
                console.log(data);
                $scope.reservations = data;
            });
            $scope.showme = true;
        };

    });
}());
