(function () {

    var app = angular.module("school");

    app.controller("SkillsCtrl", function ($scope, $rootScope, $log, $location, $routeParams, DataService) {

        $scope.message = "Loading data...";
        $scope.categoryId = $routeParams.categoryId;
        $scope.selCategory = "";
        $scope.sortOrder = "Name";

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

        $scope.collapsed = {};

        $scope.icon = {
            true: "glyphicon glyphicon-chevron-down",
            false: "glyphicon glyphicon-chevron-up"
        }

        fetchCategories();

        if ($scope.categoryId != undefined) {
            getCategory($scope.categoryId);
        }

        function fetchCategories() {
            DataService.list("skillscategories", function (data) {
                $scope.categories = data;
                $scope.message = "";
                for (i = 0; i < $scope.categories.length; i++) {
                    $scope.collapsed[$scope.categories[i].id] = true;
                }
            })
        }

        function getCategory(id) {
            DataService.read("skillscategories", id, function (data) {
                $scope.category = data;
                $scope.message = "";
                $scope.skillItem.category = $scope.category.id;
            })
        }

        $scope.collapse = function (id) {
            $scope.collapsed[id] = !$scope.collapsed[id];
        }

        $scope.editCategory = function (categoryId) {
            $location.path('/editCategory/'+categoryId)
        }

        $scope.updateCategory = function () {

            var skillCategory = {
                id: $scope.category.id,
                name : $scope.category.name,
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
            if ($scope.skillItem.id == 0) {
                DataService.create("tools", $scope.skillItem, function (data) {
                    if (data != false) {
                        fetchCategories();
                        getCategory($scope.skillItem.category);
                        window.alert($scope.skillItem.name + " added!");
                        $('.modal').modal('hide');
                        $scope.skillItem.name = "";
                    }
                    else {
                        window.alert($scope.skillItem.name + " could not be added!");
                    }
                })
            }
            else {
                DataService.update("tools", $scope.skillItem.id, $scope.skillItem, function (data) {
                    if (data != false) {
                        getCategory($scope.skillItem.category);
                        $('#addSkillModal').modal('hide');
                        window.alert($scope.skillItem.name + " has been updated!")
                        $scope.skillItem.id = 0;
                        $scope.skillItem.name = "";
                        $scope.skillItem.category = $scope.category.id;
                    }
                    else {
                        window.alert($scope.skillItem.name + " could not be updated!");
                    }
                })
            }
        }

        $scope.addCategory = function () {
            DataService.create("skillscategories", $scope.categoryItem, function (data) {
                if (data != false) {
                    fetchCategories();
                    $('#addNewCategoryModal').modal('hide');
                    window.alert($scope.categoryItem.name + " added!");
                    $scope.categoryItem.name = "";
                }
                else {
                    window.alert($scope.categoryItem.name + " could not be added!");
                }
            })
        }

        $scope.editSkill = function (tool) {
            $scope.skillItem.id = tool.id;
            $scope.skillItem.name = tool.name;
            $scope.skillItem.category = tool.category;
            $scope.skillItem.numOfEmployees = tool.numOfEmployees;
        }

        $scope.deleteSkill = function () {
            if ($scope.skillItem.numOfEmployees == 0) {
                DataService.remove("tools", $scope.skillItem.id, function (data) {
                    if (data != false) {
                        getCategory($scope.skillItem.category);
                        $('#deleteSkillModal').modal('hide');
                        window.alert($scope.skillItem.name + " has been deleted!")
                    }
                    else {
                        window.alert($scope.skillItem.name + " could not be deleted!");
                    }
                })
            }
            else {
                window.alert($scope.skillItem.name + " could not be deleted because it is assigned to some employees!");
                $('.modal').modal('hide');
            }


        }

        $scope.deleteCategory = function () {
            if($scope.category.tools.length == 0 ) {

                DataService.remove("skillscategories", $scope.category.id,  function (data) {
                    if (data != false) {
                        window.alert($scope.category.name + " has been deleted!");
                        $('#deleteCategoryModal').modal('hide');
                        $('.modal-backdrop').remove();
                        $('body').removeClass('modal-open');
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