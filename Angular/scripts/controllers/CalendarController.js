(function () {

    var app = angular.module("school");

    app.controller("CalendarController", function ($scope, $rootScope, DataService, schConfig, toaster) {

        var p = new Date();
        var d = p.getDate();
        var n = p.getMonth() + 1;
        var y = p.getFullYear();
        $scope.mont = new Date().getMonth() + 1;
        $scope.year = new Date().getFullYear();
        $scope.day = new Date().getDate();
        var dataSet = "calendar";
        var dataSet1 = "days";
        var dataSet2 = "details"
        $scope.selDay = "";
        $scope.sortOrder = "team";
        fetchData();
        getTeams();
        
        function getTeams() {
            DataService.list("teams", function (data) {
                $scope.teams = data;
            });
        };

        function fetchDataByDay(d) {
            DataService.getDetailsD(dataSet1, currentUser.id, n, y, d).then(function (response) {
                $scope.dayDetails = response.data;
            });
        }

        //function fetchDataByDay(d) {
        //    DataService.readD(dataSet1, currentUser.id, n, y, d, function (data) {
        //        $scope.dayDetails = data;
        //        //console.log(d, n, y);
        //        console.log($scope.dayDetails);
        //    });
        //}
        //fetchDataByDay(d);

        function fetchData() {
            DataService.readDd(dataSet, currentUser.id, n, y, function (data) {
                $scope.mjesec = data;
                $scope.days = $scope.mjesec.lista[0].days;
                var month = new Date().getMonth() + 1;
                var year = new Date().getFullYear();
                for (i = 0; i < $scope.days.length; i++) {
                    if ($scope.days[i].day == $scope.day && $scope.mjesec.month == month && $scope.mjesec.year == year) {
                        $scope.days[i].class = 'today'
                    }
                    if ($scope.days[i].class == 'weekend') {
                        $scope.days[i].class = 'weekends'
                    }
                    if ($scope.days[i].class != 'today') {
                        if ($scope.days[i].details.length != 0) {
                            $scope.days[i].class = 'hasData'
                        }
                    }

                    if (n == month && d > schConfig.deadline && y == year) {
                        $scope.previous = function () { $scope.warning() }
                        $scope.class = 'colored'
                    }
                    else if (n < month) {
                        $scope.previous = function () { $scope.warning() }
                        $scope.class = 'colored'
                    }
                    else {
                        $scope.previous = function () {
                            n = n - 1;
                            $scope.mont--;
                            if ($scope.mont == 0) {
                                n = 12;
                                y -= 1;
                                $scope.mont = 12;
                                $scope.year -= 1;
                            }
                            fetchData(n, y);
                        }
                        $scope.class = '';
                    }
                }
            });
        }

        $scope.$on('$viewContentLoaded', function ($evt, data) {
            if (currentUser.roles.indexOf("user") > -1) {
                if (d >= 1 && d < 5) {
                    $scope.pop();
                    $scope.left = 5 - d;                    
                }
                if (d == 5) {
                    $scope.lastDay();
                }
            }
        });

        $scope.pop = function () {
            toaster.pop('info', "Please complete your time log", "myTemplate.html", null, 'template');
        };

        $scope.lastDay = function () {
            toaster.pop('info', "Please complete your time log", "upozorenje.html", null, 'template');
        };

        $scope.warning = function () {
            toaster.pop('error', "Notice!", "scroll.html", null, 'template')
        }

        $scope.nextD = function () {
            d = $scope.datum.getDate();
            $scope.d = $scope.datum.getDate();
            d = d + 1;
            $scope.transfer(d, n, y);
            if (d == new Date(y, n, 0).getDate() + 1) {
                d = 1;
                $scope.transfer(d);
            }
        }

        $scope.previousD = function () {
            d = $scope.datum.getDate();
            d = d - 1;
            $scope.transfer(d, n, y);
            if (d == 0) {
                d = new Date(y, n, 0).getDate();
                $scope.transfer(d);
            }
        }

        $scope.next = function () {
            n = n + 1;
            $scope.mont++;
            if ($scope.mont == 13) {
                n = 1;
                y += 1;
                $scope.year += 1;
                $scope.mont = 1;
            }
            fetchData(n, y);
        }

        $scope.today = function () {
            d = new Date().getDate();
            n = new Date().getMonth() + 1;
            y = new Date().getFullYear();
            //console.log(d);
            $scope.transfer(d);
        }

        $scope.thisMonth = function () {
            n = new Date().getMonth() + 1;
            y = new Date().getFullYear();
            fetchData(n, y);
            $scope.mont = new Date().getMonth() + 1;
            $scope.year = new Date().getFullYear();
        }

        $scope.previous = function () {
            n = n - 1;
            $scope.mont--;
            if ($scope.mont == 0) {
                n = 12;
                y -= 1;
                $scope.mont = 12;
                $scope.year -= 1;
            }
            fetchData(n, y);
        }

        $scope.datum = new Date();

        $scope.transfer = function (d) {
            fetchDataByDay(d);
            $scope.datum.setMonth(n - 1, d, y);
        };

        $scope.transfer1 = function (item) {
            $scope.detail = item;
        }

        $scope.newDetail = function () {
            $scope.detail = {
                id: 0,
                day: 0,
                date: $scope.datum,
                person: currentUser.id,
                personName: currentUser.personName,
                workTime: "",
                description: "",
                team: 0,
                teamName: ""
            }
        };

        $scope.deleteData = function () {
            DataService.delete(dataSet2, $scope.detail.id, function (data) { fetchData(); });
        }
        $scope.saveData = function () {
            //$scope.detail.date = new Date($scope.datum).toISOString();
            if ($scope.detail.id == 0) {
                DataService.create(dataSet2, $scope.detail, function (data) { fetchData(); });
            }
            else {
                DataService.update(dataSet2, $scope.detail.id, $scope.detail, function (data) { fetchData(); });
            }
        }
    });
    app.filter('monthName', [function () {
        return function (monthNumber) { //1 = January
            var monthNames = ['January', 'February', 'March', 'April', 'May', 'June',
                'July', 'August', 'September', 'October', 'November', 'December'];
            return monthNames[monthNumber - 1];
        }
    }]);
}());
