(function () {

    var app = angular.module("school");

    app.controller("SkillsCtrl", function ($scope, $rootScope, $log, $location, $routeParams, DataService) {

        $scope.selCategory = "";
        $scope.sortOrder = "Name";
        fetchCategories();
        $scope.categoryId = $routeParams.categoryId;

        if ($scope.categoryId != undefined) {
            getCategory($scope.categoryId);
            $scope.newSkill = {
                "id": 0,
                "name": "",
                "category": $scope.categoryId
            };
        }

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
            })
        }

        function getCategory(id) {
            DataService.read("skillscategories", id, function (data) {
                $scope.category = data;
            })
        }

        $scope.editCategory = function (categoryId) {
            $location.path('/editCategory/'+categoryId)
        }

        $scope.saveCategory = function () {

            var skillCategory = {
                "id": categoryId,
                "name": $scope.category.name
            };

            DataService.update("skillscategories", $scope.category.id, skillCategory, function (data) {
                if (data != false) {
                    window.alert($scope.category.name + " saved!");
                }
                else {
                    window.alert($scope.category.name + " could not be saved!");
                }
            })
        }

        $scope.addSkill = function () {
            $log.info($scope.newSkill);

            DataService.create("tools", $scope.newSkill, function (data) {
                if (data != false) {
                    getCategory($scope.newSkill.category);
                    $('#addNewSkillModal').modal('hide');
                    window.alert($scope.newSkill.name + " added!");
                }
                else {
                    window.alert($scope.newSkill.name + " could not be added!");
                }
            })
        }
    });

}());