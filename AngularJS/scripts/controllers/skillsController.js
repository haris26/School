(function () {

    var app = angular.module("school");

    app.controller("SkillsCtrl", function ($scope, $rootScope, DataService) {

        $scope.selCategory = "";
        $scope.sortOrder = "Name";
        fetchCategories();

        var categoryId = 13;
        getCategory(categoryId);

        function getCategory(Id) {
            DataService.read("skillscategories", categoryId, function (data) {
                $scope.category = data;
            })
        }

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
            })
        }
    });

}());