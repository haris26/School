(function () {

    var app = angular.module("school");

    app.controller("LoginController", function ($scope, $rootScope, LoginService, $location) {

        $scope.user = { name: "", pass: "" };

        $scope.tokenRequest = function () {

            promise = LoginService.login($scope.user);
            promise.then(
                function (response) {
                    authenticated = true;
                    currentUser = response.data;
                    console.log(currentUser.name);
                    $rootScope.userName = currentUser.name;
                    $location.path("/");
                },
                function (reason) {
                    console.log(reason);
                    $rootScope.message = reason.status;
                }
            )
        }
    });
}());
