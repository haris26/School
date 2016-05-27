(function () {
    var app = angular.module("school");
    app.controller("ReportController", function ($scope, $rootScope, DataService, $http) {

        var dataSet = "report";
        getTeams();
        //fetchData();

        getYears();
        function getYears() {
            DataService.list("year", function (data) {
                $scope.years = data;
            });
        };

        function getTeams() {
            DataService.list("teams", function (data) {
                $scope.teams = data;
            });
        };
       // var y = 2016;
        var n = 5;
        $scope.fetchData = function() {
            DataService.readDd(dataSet, $scope.teamId, $scope.monthD, $scope.yearD, function (data) {
                $scope.reports = data;
            });
        }
        $scope.updateYear = function()
        {
            $scope.yearD = $scope.item1;
            console.log($scope.yearD);
        }
        $scope.updateMonth = function () {
            $scope.monthD = $scope.month;
            console.log($scope.monthD);
        }
        $scope.update = function () {  
            $scope.teamId = $scope.item.id;
            console.log($scope.teamId);
        }
        $scope.printDiv = function(elementId) {
            var a = document.getElementById('printing-css').value;
            var b = document.getElementById(elementId).innerHTML;
            window.frames["print_frame"].document.title = document.title;
            window.frames["print_frame"].document.body.innerHTML = '<style>' + a + '</style>' + b;
            window.frames["print_frame"].window.focus();
            window.frames["print_frame"].window.print();
        }
        $scope.months = [
      {
          "key": "0",
          "value": "All"
      },
      {
          "key": "1",
          "value": "Jan"
      },
      {
          "key": "2",
          "value": "Feb"
      },
      {
          "key": "3",
          "value": "Mar"
      },
      {
          "key": "4",
          "value": "Apr"
      },
      {
          "key": "5",
          "value": "May"
      },
      {
          "key": "6",
          "value": "Jun"
      },
      {
          "key": "7",
          "value": "Jul"
      },
      {
          "key": "8",
          "value": "Aug"
      },
      {
          "key": "9",
          "value": "Sep"
      },
      {
          "key": "10",
          "value": "Oct"
      },
      {
          "key": "11",
          "value": "Nov"
      },
      {
          "key": "12",
          "value": "Dec"
      }
        ];
        $scope.month = 'null';
    });
}());
