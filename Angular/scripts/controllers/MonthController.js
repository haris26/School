(function () {

    var app = angular.module("school");

    app.controller("MonthController", function ($scope, $rootScope, DataService, $window, $timeout, toaster) {

        var p = new Date();
        var d = p.getDate();
        var n = p.getMonth() + 1;
        var y = p.getFullYear();
        var current = "month";
        var dataSet = "month";
        $scope.dataSetD = "details";
        var n1 = 0;
        var mailSet = "sendmail/sendmailnotification";

        $scope.mont = new Date().getMonth() + 1;
        $scope.year = new Date().getFullYear();
        $scope.day = new Date();
        $scope.selMonth = "";
        $scope.sortOrder = "name";
        fetchData();
        var recepient = "";
        function newEmail() {
            $scope.email = {
                emailId: recepient
            }
        };

        $scope.message = "Fetching Details...";
        $scope.pageSizes = [5, 10, 15];
        $scope.pageSize = 5;
        $scope.currentPage = 0;

        $scope.changePage = function (page) {
            $scope.currentPage = page - 1;
            $scope.fetchDetails();
        }

        $scope.fetchDetails = function () {
            $scope.pages = [];
            DataService.getDet($rootScope.n1, n, $scope.currentPage, $scope.pageSize).then(function (response) {
                $scope.detailsP = response.data;
                $scope.warning = "";
                if ($scope.detailsP.length == 0) {
                    $scope.warning = "There are no entries in this month for " + $rootScope.month.name;
                };
                console.log($scope.detailsP.length);
                $scope.pagination = JSON.parse(response.headers("pagination"));
                for (var i = 1; i <= $scope.pagination.pageCount ; i++) {
                    $scope.pages.push(i);
                }

                if ($scope.currentPage > $scope.pagination.pageCount - 1) {
                    $scope.currentPage = $scope.pagination.pageCount - 1;
                    $scope.fetchDetails();
                }

                $scope.message = "";
            }, function (reason) {
                $scope.message = reason;
            })
        }
        $scope.fetchDetails();

        $scope.sendEmail = function () {
            DataService.create(mailSet, $scope.email, function (data) { });
            //console.log($scope.email.emailId);
        };

        $scope.$on('$viewContentLoaded', function ($evt, data) {
            if (currentUser.roles.indexOf("admin") > -1) {
                if (d >= 26 && d < 31) {
                    $scope.pop();
                    $scope.left = 31 - d;
                    console.log($scope.left);                   
                }
                if (d == 31) {
                    $scope.lastDay();
                }
            }
        });

        $scope.info = function () {
            toaster.pop('info', "Success!", "email.html", null, 'template')
        }

        $scope.pop = function () {
            toaster.pop('info', "Please complete your time log", "myTemplate.html", null, 'template');
        };

        $scope.lastDay = function () {
            toaster.pop('info', "Please complete your time log", "lastday.html", null, 'template');
        };

        $scope.transfer = function (item) {
            $rootScope.month = item;
            $scope.colection = item.details;
            recepient = item.email;
            $scope.mail = item.email;
            newEmail();
            console.log($scope.month.details);
            console.log(recepient);
            $scope.warning = "";
        };

        $scope.transfer1 = function (item1) {
            $rootScope.n1 = item1.id;
            //console.log(n1,n);
            //fetchDataByUser(n1);
            $scope.fetchDetails(n1);
        };

        function fetchDataByUser(n1) {
            DataService.read1(dataSetD, n1, n, function (data) {
                $scope.detailsBy = data;
                if ($scope.detailsBy == null) {
                    $scope.warning = "There are no entries in this month";
                    console.log($scope.warning);
                };
            });
        }

        function fetchMonth(n) {
            DataService.read(dataSet, n, function (data) {
                $scope.months = data;
            });
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
                $scope.mont = 12;
                $scope.year -= 1;
            }
            fetchMonth(n);
            console.log(n);
        }

        $scope.next = function () {
            n = n + 1;
            $scope.mont++;
            if ($scope.mont == 13) {
                n = 1;
                $scope.year += 1;
                $scope.mont = 1;
            }
            fetchMonth(n);
            console.log(n);
        }

        $scope.details = [];

        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.months = data;
                // console.log(data);
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
