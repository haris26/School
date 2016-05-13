(function () {

    var app = angular.module("school");

    app.controller("CalendarController", function ($scope, $rootScope, DataService) {

        var d = new Date();
        var n = d.getMonth() + 1;
        var y = d.getFullYear();
        $scope.mont = new Date().getMonth() + 1;
        var dataSet = "days";
        $scope.selDay = "";
        $scope.sortOrder = "date";
        fetchData();
        getTeams();
        function getTeams() {
            DataService.list("teams", function (data) {
                $scope.teams = data;
            });
        };
        $scope.transfer = function (item) {
            $scope.dayD = item.date;
            $scope.colection = item.details;

        };

        function fetchData() {
            console.log(n, y);
            DataService.readDd(dataSet, currentUser.id, n, y, function (data) {
                $scope.days = data;
            });
        }
        $scope.saveData = function () {
            $scope.detail.date = new Date($scope.dayD).toISOString();
            var promise;
            if ($scope.detail.id == 0) {
                DataService.create(dataSet, $scope.detail, function (data) { fetchData() });
            }
            else {
                DataService.update(dataSet, $scope.detail.id, $scope.detail, function (data) { fetchData() });
            }

            //fetchData();
        }
        $scope.next = function () {
            n = n + 1;
            $scope.mont++;
            //if (n == 12)
            //{
            //    y = y + 1;
            //}
            fetchData(n,y);
            console.log(n);
        }
        $scope.previous = function () {
            n = n - 1;
            $scope.mont--;
            //if (n == 1)
            //{
            //    y = y - 1;
            //}
            fetchData(n,y);
            console.log(n);
        }
        $scope.details = [];

        $scope.newDetail = function () {
            $scope.detail = {
                id: 0,
                day: 0,
                date: $scope.dayD,
                person: currentUser.id,
                personName: currentUser.personName,
                workTime: "",
                description: "",
                team: 0,
                teamName: ""
            }

        };
    });
    app.filter('monthName', [function () {
        return function (monthNumber) { //1 = January
            var monthNames = ['January', 'February', 'March', 'April', 'May', 'June',
                'July', 'August', 'September', 'October', 'November', 'December'];
            return monthNames[monthNumber - 1];
        }
    }]);
}());
