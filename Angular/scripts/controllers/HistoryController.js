(function () {

    var app = angular.module("school");

    app.controller("HistoryController", function ($scope, $rootScope, DataService) {

        var dataSet = "history";
        
        getHistory();
        fetchData();

        function getHistory() {
            DataService.list("history", function (data) {
                $scope.history = data.allhistory;
            });
        };

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.history = data.allhistory;
            });
        };

        
    });
}());