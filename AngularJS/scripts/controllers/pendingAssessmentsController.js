(function () {

    var app = angular.module("school");

    app.controller("PendingAssessmentsCtrl", function ($scope, $rootScope, $log, $location, DataService) {
    
        $scope.message = "Loading data...";
        $scope.pageSizes = [10, 20, 30];
        $scope.pageSize = 10;
        $scope.currentPage = 0;

        $scope.changePage = function (page) {
            $scope.currentPage = page - 1;
            $scope.fetchPeople();
        }

        $scope.fetchPeople = function () {
            $scope.pages = [];
            DataService.getPendingAssessments($scope.currentPage, $scope.pageSize).then(function (response) {
                $scope.people = response.data;
                $scope.pagination = JSON.parse(response.headers("Pagination"));
                for (var i = 1; i <= $scope.pagination.pageCount ; i++) {
                    $scope.pages.push(i);
                }

                if ($scope.currentPage > $scope.pagination.pageCount - 1) {
                    $scope.currentPage = $scope.pagination.pageCount - 1;
                    $scope.fetchPeople();
                }

                $scope.message = "";
            }, function (reason) {
                $scope.message = reason;
            })
        }

        $scope.fetchPeople();

    });

}());