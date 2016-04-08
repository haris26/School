(function () {

    var app = angular.module("school");

    app.controller("SkillsCtrl", function ($scope, $rootScope, $log, $location, $routeParams, DataService) {

        $scope.message = "Loading data...";
        $scope.categoryId = $routeParams.categoryId;
        $scope.selCategory = "";
        $scope.sortOrder = "Name";

        $scope.newCategory = {
            "id": 0,
            "name": ""
        }
        $scope.newSkill = {
            "id": 0,
            "name": "",
            "category": 0,
            "numOfEmployees": 0
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
                $scope.newSkill.category = $scope.category.id;
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
                        window.alert($scope.newSkill.name + " added!");
                        $('.modal').modal('hide');
                    }
                    else {
                        window.alert($scope.newSkill.name + " could not be added!");
                    }
                })
            }
            else {
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
            $scope.newSkill.numOfEmployees = tool.numOfEmployees;
        }

        $scope.deleteSkill = function () {
            if ($scope.newSkill.numOfEmployees == 0) {
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
            else {
                window.alert($scope.newSkill.name + " could not be deleted because it is assigned to some employees!");
                $('.modal').modal('hide');
            }


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