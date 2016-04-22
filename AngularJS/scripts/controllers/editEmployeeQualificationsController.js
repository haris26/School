(function () {

    var app = angular.module("school");

    app.controller("EditEmployeeQualificationsCtrl", function ($scope, $routeParams, $log, $location, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;
        $scope.eduItem = {
            id: 0,
            employee: $scope.employeeId,
            education: 0,
            reference: "",
            type : "1"
        };
        $scope.newCertificate = {
            name: "",
            type : 3
        }

        $scope.educationTypes = {
            "1": "Formal Education",
            "2": "Course",
            "3": "Certificate"
        };
        
        fetchEducations($scope.employeeId);

        function fetchEducations(id) {
            DataService.read("editeducations", id, function (data) {
                $scope.educations = data;
                $scope.message = "";
            })
        }

        $scope.chooseType = function () {
            var eduType = parseInt($scope.eduItem.type);
            if (eduType == 3) {
                $scope.showReference = true;
            }
            else {
                $scope.showReference = false;
                $scope.showNewCertificate = false;
            }
            DataService.read("educations", eduType, function (data) {
                $scope.eduOptions = data;
            })
        }

        $scope.addNewCertificate = function () {
            $scope.showNewCertificate = true;
        };

        $scope.saveNewCertificate = function () {
            DataService.create("educations", $scope.newCertificate, function (data) {
                if (data != false) {
                    $scope.showNewCertificate = false;
                    $scope.chooseType();
                    toaster.pop('note', $scope.newCertificate.name + " added!");
                    $scope.newCertificate.name = "";
                }
                else {
                    window.alert($scope.newCertificate.name + " could not be added!");
                }
            })
        };

        $scope.saveNewQualification = function () {
            DataService.create("employeeEducations", $scope.eduItem, function (data) {
                if (data != false) {
                    fetchEducations($scope.employeeId);
                    $scope.eduItem.education = 0;
                    $scope.eduItem.reference = "";
                    $('.modal').modal('hide');
                    toaster.pop('note',"New qualification has been added!");
                }
                else {
                    toaster.pop('error', "New qualification could not be added!");
                }
            })
        };

        $scope.selectQualification = function (education) {
            $scope.selectedQualification = education;
        }

        $scope.deleteQualification = function (id) {

            DataService.remove("employeeeducations", $scope.selectedQualification.id, function (data) {
                if (data != false) {
                    fetchEducations($scope.employeeId);
                    $('#deleteEmpQualModal').modal('hide');
                    toaster.pop('note', $scope.selectedQualification.educationName + " has been deleted!")
                }
                else {
                    toaster.pop('error', $scope.selectedQualification.educationName + " could not be deleted!");
                }
            })
        }

        $scope.updateQualification = function (education) {

            var chosenEdu = {
                id: education.id,
                employee: $scope.employeeId,
                education: education.education,
                reference: education.reference
            };

            DataService.update("employeeeducations", education.id, chosenEdu, function (data) {
                if (data != false) {
                    toaster.pop('note', "The changes have been saved!");
                }
                else {
                    toaster.pop('error', "The changes could not be saved!");
                }
            })
        }

        $scope.chooseType();

    });
}());