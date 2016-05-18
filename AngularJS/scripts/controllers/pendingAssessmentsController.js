(function () {

    var app = angular.module("school");

    app.controller("PendingAssessmentsCtrl", function ($scope, DataService) {
    
        $scope.message = "Loading data...";

        fetchPendingAssessments();

        function fetchPendingAssessments() {
            DataService.list("employeeskills", function (data) {
                $scope.pendingAssessment = data;
                $scope.message = "";
                $scope.numPendingAssessments = data.length;
            })
        }
    });

}());