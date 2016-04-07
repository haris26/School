﻿(function () {

    var app = angular.module("school");

    app.controller("SkillsCtrl", function ($scope, $rootScope, $log, $location, $routeParams, DataService) {

        $scope.selCategory = "";
        $scope.sortOrder = "Name";
        $scope.mode = true;
        fetchCategories();
        $scope.categoryId = $routeParams.categoryId;

        $scope.newCategory = {
            "id": 0,
            "name": ""
        }

        $scope.newSkill = {
            "id": 0,
            "name": "",
            "category": 0
        };

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
                $scope.newSkill.category = $scope.category.id;
            })
        }

        $scope.editCategory = function (categoryId) {
            $location.path('/editCategory/'+categoryId)
        }

        $scope.updateCategory = function () {

            var skillCategory = {
                "id": $scope.category.id,
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

            if ($scope.newSkill.id == 0) {
                DataService.create("tools", $scope.newSkill, function (data) {
                    if (data != false) {
                        fetchCategories();
                        getCategory($scope.newSkill.category);
                        $('#addSkillModal').modal('hide');
                        window.alert($scope.newSkill.name + " added!");
                    }
                    else {
                        window.alert($scope.newSkill.name + " could not be added!");
                    }
                })
            }
            else {
                $log.info("new category: " + $scope.newSkill.category);
                DataService.update("tools", $scope.newSkill.id, $scope.newSkill, function (data) {
                    if (data != false) {
                        getCategory($scope.newSkill.category);
                        $('#addSkillModal').modal('hide');
                        window.alert($scope.newSkill.name + " has been updated!")
                        $scope.newSkill.id = 0;
                        $scope.newSkill.name = "";
                        $scope.newSkill.category = $scope.category.id;
                    }
                    else {
                        window.alert($scope.newSkill.name + " could not be updated!");
                    }
                })
            }
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

        $scope.editSkill = function (tool) {
            $scope.newSkill.id = tool.id;
            $scope.newSkill.name = tool.name;
            $scope.newSkill.category = tool.category;
        }

        $scope.deleteSkill = function () {
            DataService.remove("tools", $scope.newSkill.id, function (data) {
                if (data != false) {
                    getCategory($scope.newSkill.category);
                    $('#deleteSkillModal').modal('hide');
                    window.alert($scope.newSkill.name + " has been deleted!")
                }
                else {
                    window.alert($scope.newSkill.name + " could not be deleted!");
                }
            })
        }

        $scope.deleteCategory = function () {
            if($scope.category.tools.length == 0 ) {

            DataService.remove("skillscategories", $scope.category.id,  function (data) {
                if (data != false) {
                    window.alert($scope.category.name + " has been deleted!");
                    $('.modal').modal('hide');
                    $('.modal-backdrop').remove();
                    $location.path("/skills");
                }
                else {
                    window.alert($scope.category.name + " could not be deleted!");
                }
            })

            }
            else {
                window.alert($scope.category.name + " could not be deleted because it is not empty!");
                $('.modal').modal('hide');
            }
        }
    });

}());