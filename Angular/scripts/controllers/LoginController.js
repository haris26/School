﻿(function () {

    var app = angular.module("school");

    app.controller("LoginController", function ($scope, $rootScope, $location, LoginService) {

        $scope.user = { name: "", pass: "" };

        $scope.tokenRequest = function () {

            promise = LoginService.login($scope.user);
            promise.then(
                function (response) {
                    authenticated = true;
                    currentUser = response.data;
                    $location.path("/home");
                    //$rootScope.userName = currentUser.name;

                },
                function (reason) {
                    console.log(reason);
                    //$rootScope.message = reason.status;
                }
            )
        }
    });
}());