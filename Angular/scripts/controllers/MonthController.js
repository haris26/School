(function () {

    var app = angular.module("school");
    
    app.controller("MonthController", function ($scope, $rootScope, DataService) {

        var d = new Date();
        var n = d.getMonth() + 1;
        var current = "month";
        var dataSet = "month";  
        var dataSetD = "details";
        var n1 = 0;
        $scope.mont = new Date().getMonth() + 1;
        $scope.selMonth = "";
        $scope.sortOrder = "name";
        fetchData();

       $scope.transfer = function (item) {
            $scope.month = item;
            $scope.recepient = item.email;
            $scope.colection = item.details;
            console.log($scope.month.details);
            console.log($scope.recepient);
        };
        $scope.transfer1 = function (item1) {
            n1 = item1.id;
            console.log(n1,n);
            fetchDataByUser(n1);
        };
        function fetchDataByUser(n1) {
            DataService.read1(dataSetD, n1, n, function (data) {
                $scope.detailsBy = data;
            });
        }
        function fetchMonth(n) {
            DataService.read(dataSet, n, function (data) {
                $scope.months = data;
            });
        }

        $scope.next = function () {
            n = n + 1;
            $scope.mont++;
            fetchMonth(n);
            console.log(n);
        }
        $scope.previous = function () {
            n = n - 1;
            $scope.mont--;
            fetchMonth(n);
            console.log(n);
        }
        $scope.details = [];

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.months = data;
                console.log(data);
            });
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
