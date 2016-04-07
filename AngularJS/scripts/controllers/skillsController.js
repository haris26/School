(function () {

    var app = angular.module("school");

    app.controller("SkillsCtrl", function ($scope, $rootScope, $log, $location, $routeParams, DataService) {

        $scope.selCategory = "";
        $scope.sortOrder = "Name";
        fetchCategories();
        $scope.categoryId = $routeParams.categoryId;

        $scope.newCategory = {
            "id": 0,
            "name": ""
        }

        if ($scope.categoryId != undefined) {
            getCategory($scope.categoryId);
        }

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
            })
        }

        function getCategory(id) {
            DataService.read("skillscategories", id, function (data) {
                $scope.category = data;
                $scope.newSkill = {
                    "id": 0,
                    "name": "",
                    "category": $scope.category.id
                };
            })
        }

        $scope.editCategory = function (categoryId) {
            $location.path('/editCategory/'+categoryId)
        }

        $scope.saveCategory = function () {

            var skillCategory = {
                "id": categoryId,
                "name": $scope.category.name,
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

        $scope.addCategory = function () {
            DataService.create("skillscategories", $scope.newCategory, function (data) {
                if (data != false) {
                    fetchCategories();
                    $('#addNewCategoryModal').modal('hide');
                    window.alert($scope.newCategory.name + " added!");
                }
                else {
                    window.alert($scope.newCategory.name + " could not be added!");
                }
            })
        }
    });

}());