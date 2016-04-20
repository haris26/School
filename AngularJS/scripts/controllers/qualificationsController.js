(function () {

    var app = angular.module("school");

    app.controller("QualificationsCtrl", function ($scope, $log, DataService) {

        $scope.message = "Loading data...";
        $scope.sortOrder = "Name";

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
            if ($scope.qualificationItem.id == 0) {
                DataService.create("educations", $scope.qualificationItem, function (data) {
                    if (data != false) {
                        fetchQualifications();
                        getQualification($scope.qualificationItem.type);
                        window.alert($scope.qualificationItem.name + " added!");
                        $('.modal').modal('hide');
                        $scope.qualificationItem.name = "";
                    }
                    else {
                        window.alert($scope.qualificationItem.name + " could not be added!");
                    }
                })
            }
            else {
                DataService.update("educations", $scope.qualificationItem.id, $scope.qualificationItem, function (data) {
                    if (data != false) {
                        getQualification($scope.qualificationItem.type);
                        $('.modal').modal('hide');
                        window.alert($scope.qualificationItem.name + " has been updated!")
                        fetchQualifications();
                        $scope.qualificationItem.id = 0;
                        $scope.qualificationItem.name = "";
                        $scope.qualificationItem.category = $scope.qualifications.id;
                    }
                    else {
                        window.alert($scope.qualificationItem.name + " could not be updated!");
                    }
                })
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
                        window.alert($scope.qualificationItem.name + " has been deleted!")
                    }
                    else {
                        window.alert($scope.qualificationItem.name + " could not be deleted!");
                    }
                })
            }
            else {
                window.alert($scope.qualificationItem.name + " could not be deleted because it is assigned to some employees!");
                $('.modal').modal('hide');
            }
        }


    });
}());