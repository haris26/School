(function () {

    var app = angular.module("school");

    app.controller("CalendarController", function ($scope, $rootScope, DataService) {

        var d = new Date();
        var n = d.getMonth() + 1;
        var y = d.getFullYear();
        $scope.mont = new Date().getMonth() + 1;
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
        //$scope.transfer = function (item) {
        //    $scope.dayD = item.date;
        //    $scope.colection = item.details;
        //};
        function fetchDataByDay(d) {
            DataService.readD(dataSet1, currentUser.id, n, y, d, function (data) {
                $scope.dayDetails = data;
                console.log($scope.dayDetails);
            });
        }
        fetchDataByDay(d);
        function fetchData() {
            console.log(n, y);
            DataService.readDd(dataSet, currentUser.id, n, y, function (data) {
                $scope.mjesec = data;
                console.log($scope.mjesec);
            });
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
        //$scope.details = [];
       $scope.datum = new Date();
        
       $scope.transfer = function (d) {
            fetchDataByDay(d);
            $scope.datum.setMonth(n-1,d);
            console.log($scope.datum);
        };

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
        $scope.nextDay = function()
        {
            //day = day.getDate() + 1;
            var mj = new Date(y, n, 0).getDate();
            var dand = $scope.datum.getDate();
            for (var i = dand; i <= mj; i++) {
                dand++;
            }
          //  console.log(day);
            console.log(dand);
            
        }
        $scope.previousDay = function()
        {

        }

        $scope.transfer1 = function(detail)
        {
            $scope.detail = detail;
        }
        $scope.deleteData = function () {
            DataService.delete(dataSet2, $scope.detail.id, function (data) { fetchDataByDay(d); });
            // fetchData();
        }
        $scope.saveData = function () {
            $scope.detail.date = new Date($scope.datum).toISOString();
            var promise;
            if ($scope.detail.id == 0) {
                DataService.create(dataSet2, $scope.detail, function (data) { fetchDataByDay(d); });
            }
            else {
                DataService.update(dataSet2, $scope.detail.id, $scope.detail, function (data) { fetchDataByDay(d); });
            }

            //fetchData();
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
