(function () {

    var app = angular.module("school");

    app.controller("FindPeopleCtrl", function ($scope, $routeParams, $log, $location, DataService) {
        $scope.message = "Loading data...";

        $scope.categoryItem = {
            id: 0,
            name: ""
        };

        $scope.skillItem = {
            id: 0,
            name: "",
            category: 0,
            numOfEmployees: 0
        };

        fetchCategories();

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
                $scope.message = "";
            })
        }
        
    });
}());