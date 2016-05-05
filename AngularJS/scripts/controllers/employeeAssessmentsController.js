(function () {

    var app = angular.module("school");

    app.controller("EmployeeAssessmentsCtrl", function ($scope, $routeParams, $log, $location, DataService) {
        $scope.message = "Loading data...";
        $scope.employeeId = $routeParams.employeeId;

        var chartData = [];
        $scope.data = {};
        $scope.configChart = {};
        $scope.visibilityClass = "invisibleChart";

        $scope.goToSumarry = function () {
            $location.path('/employeeSummary/' + $scope.employeeId);
        }

        $scope.goToSelfAssessment = function () {
            $location.path('/selfAssessment/' + $scope.employeeId);
        }

        $scope.goToSupervisorAssessment = function () {
            $location.path('/supervisorAssessment/' + $scope.employeeId);
        }

        getEmployeeAssessments($scope.employeeId);

        function getEmployeeAssessments(id) {
            DataService.read("employeeassessments", id, function (data) {
                $scope.assessments = data;
                if ($scope.assessments.availableSkills.length > 0) {
                    $scope.selectedSkill = $scope.assessments.availableSkills[0].id;
                }
                $scope.message = "";
            })
        }

        //date pickers
        $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
        $scope.format = $scope.formats[0];
        $scope.altInputFormats = ['M!/d!/yyyy'];

        $scope.startDate = new Date();
        $scope.endDate = new Date();

        $scope.clearStart = function () {
            $scope.startDate = null;
        };

        $scope.dateOptions = {
            formatYear: 'yy',
            maxDate: null,
            minDate: new Date('01/01/2008'),
            startingDay: 1
        };

        $scope.openStart = function () {
            $scope.popupStart.opened = true;
        };

        $scope.openEnd = function () {
            $scope.popupEnd.opened = true;
        };

        $scope.popupStart = {
            opened: false
        };

        $scope.popupEnd = {
            opened: false
        };


        //chart
        $scope.getHistory = function () {

            $scope.visibilityClass = "invisibleChart";

            var searchModel = {
                EmpId: $scope.employeeId,
                Skill: $scope.selectedSkill,
                StartDate: $scope.startDate,
                EndDate: $scope.endDate
            };

            DataService.getAssessmentHistory(searchModel, function (data) {
                $scope.history = data;
                getChartData();
            })
        }

        function getChartData() {
            chartData = [];
            for (var i = 0; i < $scope.history.length; i++) {
                chartData.push({
                    x: $scope.history[i].date,
                    y: [$scope.history[i].level]
                })
            }

            $scope.data = {
                series: ["Level"],
                data: chartData
            };

            $scope.configChart = {
                title: $scope.history[0].name,
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

            $scope.visibilityClass = "div-darkblue";
        }
    });
}());