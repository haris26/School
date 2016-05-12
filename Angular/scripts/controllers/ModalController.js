(function () {

    var app = angular.module("school");

    app.controller("CancelReqCtrl", function ($scope, $modalInstance, confirmed) {
        $scope.confirmed = confirmed;

        $scope.yes = function () {
            $scope.isConfirmed = true;
            $modalInstance.close($scope.isConfirmed);
        };
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        }
    })

}());