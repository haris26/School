﻿(function () {

    var app = angular.module("school");

    app.controller("QualificationsCtrl", function ($scope, $log, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.sortOrder = "Name";
        $scope.name = false;

        $scope.qualificationItem = {
            id: 0,
            name: "",
            type: 0,
            numOfEmployees: 0
        };

        $scope.collapse = function (id) {
            $scope.collapsed[id] = !$scope.collapsed[id];
        }

        $scope.collapsed = {};

        $scope.icon = {
            true: "glyphicon glyphicon-chevron-down",
            false: "glyphicon glyphicon-chevron-up"
        }

        fetchQualifications();

        function fetchQualifications() {
            DataService.list("educations", function (data) {
                $scope.qualifications = data;
                $scope.message = "";
                for (i = 0; i < $scope.qualifications.length; i++) {
                    $scope.collapsed[$scope.qualifications[i].id] = true;
                }
            })
        }

        function getQualification(id) {
            DataService.read("educations", id, function (data) {
                $scope.qualification = data;
                $scope.message = "";
                $scope.qualificationItem.type = $scope.qualification.id;
            })
        }

        $scope.addQualification = function () {
            $scope.validate();
            if ($scope.validation) {
                if ($scope.qualificationItem.id == 0) {
                    DataService.create("educations", $scope.qualificationItem, function (data) {
                        if (data != false) {
                            fetchQualifications();
                            getQualification($scope.qualificationItem.type);
                            toaster.pop('note', $scope.qualificationItem.name + " added!");
                            $('.modal').modal('hide');
                            $scope.qualificationItem.name = "";
                            $scope.qualificationItem.category = "";
                        }
                        else {
                            toaster.pop('error', $scope.qualificationItem.name + " could not be added!");
                        }
                    })
                }
                else {
                        DataService.update("educations", $scope.qualificationItem.id, $scope.qualificationItem, function (data) {
                            if (data != false) {
                                getQualification($scope.qualificationItem.type);
                                $('.modal').modal('hide');
                                toaster.pop('note', $scope.qualificationItem.name + " has been updated!")
                                fetchQualifications();
                                $scope.qualificationItem.id = 0;
                                $scope.qualificationItem.name = "";
                                $scope.qualificationItem.category = $scope.qualifications.id;
                            }
                            else {
                                toaster.pop('error', $scope.qualificationItem.name + " could not be updated!");
                            }
                        })
                }
            }
        }

        $scope.editEducation = function (education) {
            $scope.qualificationItem.id = education.id;
            $scope.qualificationItem.name = education.name;
            $scope.qualificationItem.type = education.type;
            $scope.qualificationItem.numOfEmployees = education.numOfEmployees;
        }

        $scope.deleteQualification = function () {
            if ($scope.qualificationItem.numOfEmployees == 0) {
                DataService.remove("educations", $scope.qualificationItem.id, function (data) {
                    if (data != false) {
                        fetchQualifications();
                        $('.modal').modal('hide');
                        toaster.pop('note', $scope.qualificationItem.name + " has been deleted!")
                        $scope.qualificationItem.id = 0;
                        $scope.qualificationItem.name = "";
                        $scope.qualificationItem.category = "";
                    }
                    else {
                        toaster.pop('error', $scope.qualificationItem.name + " could not be deleted!");
                        $scope.qualificationItem.id = 0;
                        $scope.qualificationItem.name = "";
                        $scope.qualificationItem.category = "";
                    }
                })
            }
            else {
                toaster.pop('error', $scope.qualificationItem.name + " could not be deleted", "because it is assigned to some employees!");
                $('.modal').modal('hide');
            }
        }

        $scope.clearQualification = function () {
            $scope.qualificationItem = {
                id: 0,
                name: "",
                type: 0,
                numOfEmployees: 0
            };
        };
        function nameCheck(name) {
            if (name != "") {
                DataService.qualificationCheck("educations", name, function (data) {
                    $scope.name = (data.length!=0);
                })
            }
        };

        $scope.validate = function () {
            $scope.errorEmpty = false;
            nameCheck($scope.qualificationItem.name);
            if (!$scope.qualificationItem.name || $scope.name || !$scope.qualificationItem.type) $scope.validation = false;
            //if (!$scope.qualificationItem.name) { $scope.errorEmpty = true; }
            //if ($scope.name) { $scope.errorExists = true; }
            //if (!$scope.qualificationItem.type) { $scpe, errorTypeEmpty = true; }
            else $scope.validation = true;
            console.log($scope.validation);
        };


    });
}());