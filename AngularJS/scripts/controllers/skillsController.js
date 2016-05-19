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
                    if (data != false) {
                        toaster.pop('note', $scope.category.name + " saved!");
                        fetchCategories();
                    }
                    else {
                        toaster.pop('error', $scope.category.name + " could not be saved!");
                    }
            })
        }

        $scope.addSkill = function () {
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

        $scope.addCategory = function () {
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
            $scope.skillItem.category = 0
            $scope.skillItem = {
                id: 0,
                name: "",
                category: 0,
                numOfEmployees: 0
            };
            $scope.errorEmptySkillName = false;
            $scope.errorExistSkillName = false;
            $scope.errorNoCategory = false;
        }

        $scope.clearCategory = function () {
            $scope.categoryItem = {
                id: 0,
                name: ""
            };
            $scope.errorEmptyCategory = false;
            $scope.errorExistSCategory = false;
        }


        $scope.validateCategory = function (name) {
            DataService.nameCheck("skillscategories", name, function (data) {
                $scope.name = data.length != 0;
                $scope.setParametarCategory(!$scope.name);
            });
        }

        $scope.setParametarCategory = function (parametar) {
            $scope.isValid = parametar;
            if ($scope.isValid && $scope.categoryItem.name) {
                $scope.addCategory();
            }
            else {
                if (!$scope.categoryItem.name) {
                    $scope.errorEmptyCategory = true;
                }
                else if (!$scope.isValid) {
                    $scope.errorExistsCategory = true;
                    $scope.errorEmptyCategory = false;
                }
            }
        }

        $scope.validateCategoryUpdate = function (name) {
            DataService.nameCheck("skillscategories", name, function (data) {
                $scope.name = data.length != 0;
                $scope.setParametarCategoryUpdate(!$scope.name);
            });
        }

        $scope.setParametarCategoryUpdate = function (parametar) {
            $scope.isValid = parametar;
            if ($scope.isValid && $scope.category.name) {
                $scope.updateCategory();
            }
            else {
                if (!$scope.category.name) {
                    $scope.errorEmptyCategory = true;
                }
                else if (!$scope.isValid) {
                    $scope.errorExistsCategory = true;
                    $scope.errorEmptyCategory = false;
                }
            }
        }

        $scope.clearCategoryUpdateError = function () {
            $scope.errorExistsCategory = false;
            $scope.errorEmptyCategory = false;
        }

        $scope.validateSkill = function (name) {
            if (name) {
                DataService.nameCheck("tools", encode(name), function (data) {
                $scope.name = data.length != 0;
                $scope.setParametarSkill(!$scope.name);
            });
            }
            else {
                if (!$scope.skillItem.name && !$scope.skillItem.category) {
                    $scope.errorEmptySkillName = true;
                    $scope.errorNoCategory = true;
                    $scope.errorExistSkillName = false;
                }
                else if (!$scope.skillItem.name) {
                    $scope.errorEmptySkillName = true;
                    $scope.errorNoCategory = false;
                    $scope.errorExistSkillName = false;
                }
            }
        }

        $scope.setParametarSkill = function (parametar) {
            $scope.isValid = parametar;
            if ($scope.isValid && $scope.skillItem.name && $scope.skillItem.category) {
                $scope.addSkill();
            }
            else {
                if (!$scope.skillItem.category) {
                    $scope.errorEmptySkillName = false;
                    $scope.errorNoCategory = true;
                    $scope.errorExistSkillName = false;
                }
                else if (!$scope.isValid) {
                    $scope.errorEmptySkillName = false;
                    $scope.errorExistSkillName = true;
                    $scope.errorNoCategory = false;
                }
            }
        }

        function encode(input) {

            var keyStr = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=';

            var output = "";
            var chr1, chr2, chr3 = "";
            var enc1, enc2, enc3, enc4 = "";
            var i = 0;

            do {
                chr1 = input.charCodeAt(i++);
                chr2 = input.charCodeAt(i++);
                chr3 = input.charCodeAt(i++);

                enc1 = chr1 >> 2;
                enc2 = ((chr1 & 3) << 4) | (chr2 >> 4);
                enc3 = ((chr2 & 15) << 2) | (chr3 >> 6);
                enc4 = chr3 & 63;

                if (isNaN(chr2)) {
                    enc3 = enc4 = 64;
                } else if (isNaN(chr3)) {
                    enc4 = 64;
                }

                output = output +
                    keyStr.charAt(enc1) +
                    keyStr.charAt(enc2) +
                    keyStr.charAt(enc3) +
                    keyStr.charAt(enc4);
                chr1 = chr2 = chr3 = "";
                enc1 = enc2 = enc3 = enc4 = "";
            } while (i < input.length);

            return output;
        }
    });
}());