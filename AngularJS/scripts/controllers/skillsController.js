(function () {

    var app = angular.module("school");

    app.controller("SkillsCtrl", function ($scope, $rootScope, $log, $location, $routeParams, DataService, toaster) {

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
                $scope.validateCategory();
                if ($scope.categoryValidation) {
                    if (data != false) {
                        toaster.pop('note', $scope.category.name + " saved!");
                        fetchCategories();
                    }
                    else {
                        toaster.pop('error', $scope.category.name + " could not be saved!");
                    }
                }
            })
        }

        $scope.addSkill = function () {
            $scope.validateSkill();
            if ($scope.skillValidation) {
                if ($scope.skillItem.id == 0) {
                    DataService.create("tools", $scope.skillItem, function (data) {
                        if (data != false) {
                            fetchCategories();
                            getCategory($scope.skillItem.category);
                            toaster.pop('note', $scope.skillItem.name + " added!");
                            $('.modal').modal('hide');
                            $scope.skillItem.name = "";
                        }
                        else {
                            toaster.pop('error', $scope.skillItem.name + " could not be added!");
                        }
                    })
                }
                else {
                    DataService.update("tools", $scope.skillItem.id, $scope.skillItem, function (data) {
                        if (data != false) {
                            getCategory($scope.skillItem.category);
                            $('#addSkillModal').modal('hide');
                            toaster.pop('note', $scope.skillItem.name + " has been updated!")
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
        }

        $scope.addCategory = function () {
            $scope.validateCategory();
            if ($scope.categoryValidation) {
                DataService.create("skillscategories", $scope.categoryItem, function (data) {
                    if (data != false) {
                        fetchCategories();
                        $('#addNewCategoryModal').modal('hide');
                        toaster.pop('note', $scope.categoryItem.name + " added!");
                        $scope.categoryItem.name = "";
                    }
                    else {
                        toaster.pop('error', $scope.categoryItem.name + " could not be added!");
                    }
                })
            }
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
                        toaster.pop('note', $scope.skillItem.name + " has been deleted!")
                    }
                    else {
                        toaster.pop('error', $scope.skillItem.name + " could not be deleted!");
                    }
                })
            }
            else {
                toaster.pop('error', $scope.skillItem.name + " could not be deleted", "because it is assigned to some employees!");
                $('.modal').modal('hide');
            }
        }

        $scope.deleteCategory = function () {
            if($scope.category.tools.length == 0 ) {

                DataService.remove("skillscategories", $scope.category.id,  function (data) {
                    if (data != false) {
                        toaster.pop('note', $scope.category.name + " has been deleted!");
                        $('#deleteCategoryModal').modal('hide');
                        $('.modal-backdrop').remove();
                        $('body').removeClass('modal-open');
                        $location.path("/skills");
                    }
                    else {
                        toaster.pop('error', $scope.category.name + " could not be deleted!");
                    }
                })

            }
            else {
                toaster.pop('error', $scope.category.name + " could not be deleted because it is not empty!");
                $('.modal').modal('hide');
            }
        }

        $scope.clearSkill = function () {
            $scope.skillItem = {
                id: 0,
                name: "",
                category: 0,
                numOfEmployees: 0
            };

            $scope.skillItem.category = $scope.category.id;
        }

        function nameCheckCategory(name) {
            if (name != "") {
                DataService.nameCheck("skillscategories", name, function (data) {
                    $scope.name = data.length != 0;
                })
            }
        };

        function nameCheckTool(name) {
            if (name != "") {
                DataService.nameCheck("tools", name, function (data) {
                    $scope.name = data.length != 0;
                })
            }
        };


        $scope.validateCategory = function () {
            if (!$scope.categoryItem.name || !scope.skillItem.category.name) {
                $scope.categoryValidation = false;
                $scope.errorEmptyCategory = true;
            }
            else $scope.categoryValidation = true;
        };

        $scope.validateSkill = function () {

            if (!$scope.skillItem.name && !$scope.skillItem.category) {
                $scope.skillValidation = false;
                $scope.errorNoCategory = true;
                $scope.errorEmptySkillName = true;
            }
            else if (!$scope.skillItem.category) {
                $scope.skillValidation = false;
                $scope.errorNoCategory = true;
                $scope.errorEmptySkillName = false;
            }
            else if (!$scope.skillItem.name) {
                $scope.skillValidation = false;
                $scope.errorEmptySkillName = true;
                $scope.errorNoCategory = false;
            }
            else $scope.skillValidation = true;
        };

    });
}());