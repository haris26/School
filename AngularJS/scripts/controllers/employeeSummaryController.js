(function () {

    var app = angular.module("school");

    app.controller("EmployeeSummaryCtrl", function ($scope, $routeParams, $log, $location, DataService) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        getEmployee($scope.employeeId);

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
    });
}());