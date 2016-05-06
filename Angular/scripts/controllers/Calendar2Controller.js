﻿(function () {
    var app = angular.module("school");
    app.controller("Calendar2Controller", function ($scope, $rootScope, DataService, toaster, $window, $timeout) {

        var dataSet = "details";
        var dataSet2 = "days"
        $scope.selDetail = "";
        $scope.sortOrder = '-date';
        var month = new Date();
        month.setDate(month.getMonth() + 1);
        console.log(month);
        var day = new Date();
        day.setDate(day.getDate());
        var year = new Date();
        year.setDate(year.getFullYear());
        fetchDataByDay();
        function fetchDataByDay() {
            DataService.readD(dataSet2, currentUser.id, month.getMonth(), year.getFullYear(), day.getDate(), function (data) {
                $scope.details = data;
            });
        }

        getTeams();

        getPeople();
        getDays();

        $scope.$watch('$viewContentLoaded', function () {
            $timeout(function () {
                var nDay = new Date();
                var day = nDay.getDate();

                if (day <= 5 && day > 1) {
                    $scope.dayL = 5 - day;
                    $scope.pop($scope.dayL);
                    console.log($scope.dayL);
                }
                else if (day = 5) {
                    $scope.pop();
                }

            }, 0);
        });
        $scope.pop = function () {
            toaster.pop('info', "Please complete your time log", "myTemplate.html", null, 'template');
        };
        $scope.goToLink = function (toaster) {
            var match = toaster.body.match(/http[s]?:\/\/[^\s]+/);
            if (match) $window.open(match[0]);
            return true;
        };
       

        function getDays() {
            DataService.read("days", currentUser.id, function (data) {
                $scope.days = data;
            });
        };

        function getTeams() {
            DataService.list("teams", function (data) {
                $scope.teams = data;
            });
        };
        function getPeople() {
            DataService.read("people", currentUser.id, function (data) {
                $scope.people = data;
            });
        };
        //function fetchData() {
        //    DataService.read(dataSet, currentUser.id, function (data) {
        //        $scope.details = data;

        //    });
        //}

        $scope.transfer = function (item) {
            $scope.detail = item;
        };
        $scope.reloadRoute = function () {
            $window.location.reload();
        }

        $scope.newDetail = function ()
        {
            $scope.detail = {
                id: 0,
                day: 0,
                date: $scope.dt,
                person: currentUser.id,
                personName: currentUser.personName,
                workTime: "",
                description: "",
                team: 0,
                teamName: ""
            }
            
        };
        $scope.deleteData = function () {
            DataService.delete(dataSet, $scope.detail.id, function (data) { fetchData() });
            // fetchData();
        }

        $scope.saveData = function (selectedDate) {
            $scope.detail.date = new Date(selectedDate).toISOString();
            var promise;
            if ($scope.detail.id == 0) {
                DataService.create(dataSet, $scope.detail, function (data) { fetchData() });
                console.log(selectedDate.getFullYear() + '-' + ('0' + (selectedDate.getMonth() + 1)).slice(-2) + '-' + ('0' + selectedDate.getDate()).slice(-2));
            }
            else {
                DataService.update(dataSet, $scope.detail.id, $scope.detail, function (data) { fetchData() });
            }

            //fetchData();
        }
        

        $scope.today = function () {
            $scope.dt = new Date();
            //console.log($scope.dt);
        };
        $scope.today();

        $scope.clear = function () {
            $scope.dt = null;
        };

        $scope.options = {
            customClass: getDayClass,
            minDate: new Date(),
            showWeeks: true
        };

        // Disable weekend selection
        function disabled(data) {
            var date = data.date,
              mode = data.mode;
            return mode === 'day' && (date.getDay() === 0 || date.getDay() === 6);
        }

        $scope.toggleMin = function () {
            $scope.options.minDate = $scope.options.minDate ? null : new Date();
        };

        $scope.toggleMin();

        $scope.setDate = function (year, month, day) {
            $scope.dt = new Date(year, month, day);
            $scope.dt.setHours(2, 0, 0);
        };
       

        var tomorrow = new Date();
        tomorrow.setDate(tomorrow.getDate() + 1);
        var afterTomorrow = new Date(tomorrow);
        afterTomorrow.setDate(tomorrow.getDate() + 1);
        

        $scope.events = [
          {
              date: tomorrow,
              status: 'full'
          },
          {
              date: afterTomorrow,
              status: 'partially'
          }
        ];

        function getDayClass(data) {
            var date = data.date,
              mode = data.mode;
            if (mode === 'day') {
                var dayToCheck = new Date(date).setHours(0, 0, 0, 0);

                for (var i = 0; i < $scope.events.length; i++) {
                    var currentDay = new Date($scope.events[i].date).setHours(0, 0, 0, 0);

                    if (dayToCheck === currentDay) {
                        return $scope.events[i].status;
                    }
                }
            }
            return '';
        };
        $scope.test = function () {
            console.log('calendar clicked');
        }

    });
    //app.filter('dateRange', function () {
    //    return function (input, startDate, endDate) {

    //        var retArray = [];

    //        angular.forEach(input, function (obj) {

    //            var receivedDate = new Date(obj.date).getTime();
    //            console.log(receivedDate);

    //            if (receivedDate >= startDate && receivedDate < endDate) {
    //                console.log("poredjenje");
    //                retArray.push(obj);
    //            }
    //        });
    //        return retArray;
    //    };
    //});
}());