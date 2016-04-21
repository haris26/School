(function () {

    var app = angular.module("school");

    app.controller("RecurringReservationsController", function ($scope, $rootScope, DataService) {

        var dataSet = "extendedoverview";
        fetchData();

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.extendedEvents = data;
            });
        }

    });
}());
