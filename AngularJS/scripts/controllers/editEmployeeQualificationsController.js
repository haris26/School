(function () {

    var app = angular.module("school");

    app.controller("EditEmployeeQualificationsCtrl", function ($scope, $routeParams, $log, $location, DataService) {

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
                    window.alert($scope.newCertificate.name + " added!");
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
                    window.alert("New qualification has been added!");
                }
                else {
                    window.alert("New qualification could not be added!");
                }
            })
        };

        $scope.chooseType();

    });
}());