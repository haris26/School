(function () {

    var app = angular.module("school");

    app.controller("EmployeeSummaryCtrl", function ($scope, $routeParams, $log, DataService) {

        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        getEmployee($scope.employeeId);

        function getEmployee(id) {
            DataService.read("employeesummaries", id, function (data) {
                $scope.summary = data;
                $scope.message = "";

                var charProgrammingSkills = [];
                for (var i = 0; i < $scope.summary.length; i++) {
                    charProgrammingSkills.push({
                        x: summary[i].skill,
                        y: summary[i].level
                    });
                }

                $scope.programmingSkills = {
                    series: ["Level"],
                    data: charProgrammingSkills
                };

                $scope.configProgrammingSkills = {
                    title: "Programming Skills",
                    tooltips: true,
                    labels: false,
                    mouseover: function () { },
                    mouseout: function () { },
                    click: function () { },
                    legend: {
                        display: false,
                        position: "right"
                    }
                };


            })
        }

        

    });
}());