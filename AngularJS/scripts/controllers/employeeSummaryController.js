(function () {

    var app = angular.module("school");

    app.controller("EmployeeSummaryCtrl", function ($scope, $rootScope, $routeParams, $log, $location, DataService, toaster) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        $scope.permissions = {
            showAdmin: currentUser.roles.indexOf("Admin") > -1,
        }

        getEmployee($scope.employeeId);
        showNotification($scope.employeeId);
        $scope.permissions = {
            showAdmin: currentUser.roles.indexOf("Admin") > -1,
            showUser: currentUser.id == $scope.employeeId
        }
        $scope.newNotificationItem = {
            id: 0,
            employeeId: $scope.employeeId,
            assessedBySupervisor: false
        }

        function getEmployee(id) {
            DataService.read("employeesummaries", id, function (data) {
                $scope.summary = data;
                $scope.message = "";
                var chartData = [];
                $scope.data = [];
                $scope.configChart = [];

                for (var i = 0; i < $scope.summary.skills.length; i++) {
                    chartData[$scope.summary.skills[i].categoryName] = [];
                    for (var j = 0; j < $scope.summary.skills[i].skills.length; j++) {
                        chartData[$scope.summary.skills[i].categoryName].push({
                            x: $scope.summary.skills[i].skills[j].skill,
                            y: [$scope.summary.skills[i].skills[j].level],
                            "tooltip": $scope.summary.skills[i].skills[j].skill +" - level  "+ $scope.summary.skills[i].skills[j].level
                        })
                    }

                    $scope.data[$scope.summary.skills[i].categoryName] = {
                        series: ["Level"],
                        data: chartData[$scope.summary.skills[i].categoryName]
                    };
                    $scope.configChart[$scope.summary.skills[i].categoryName] = {
                            tooltips: true,
                            labels: false,
                            mouseover: function () { },
                            mouseout: function () { },
                            click: function () { },
                            legend: {
                                display: false,
                                position: "right"
                            },
                            colors: ["white"]
                    }
                }
            })
        }

        $scope.goToAssessment = function () {
            $location.path('/employeeAssessments/' + $scope.employeeId);
        }

        $scope.editQualifications = function (employeeId) {
            $location.path('/editEmployeeQualifications/' + employeeId);
        }

        function showNotification(employeeId) {
            DataService.read("employeenotifications", employeeId, function (data) {
                $scope.notification = data;
                if ($scope.notification ==false) {
                    DataService.create("employeenotifications", $scope.newNotificationItem, function (data) {
                    })
                }
            });
        }
        $scope.updateNotification = function () {
            $scope.newNotificationItem = {
                id: $scope.notification.id,
                employeeId: $scope.notification.employeeId,
                assessedBySupervisor: false
            }
                DataService.update("employeenotifications", $scope.notification.id, $scope.newNotificationItem, function (data) {
                })
        }
    });
}());