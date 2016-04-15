(function () {

    var app = angular.module("school");

    app.controller("LoginCtrl", function ($scope, $rootScope, LoginService, $location) {

        $scope.user = { name: "", pass: "" };
        $scope.wait = false;
        startApp('googleBtn');

        $scope.tokenRequest = function () {

            promise = LoginService.login($scope.user);
            promise.then(
                function (response) {
                    authenticated = true;
                    currentUser = response.data;
                    $rootScope.userName = currentUser.name;
                    $scope.wait = false;
                    $location.path("/overview");
                },
                function (reason) {
                    console.log(reason);
                    $rootScope.message = reason.status;
                }
            )
        }

        function startApp(actionButton) {
            gapi.load('auth2', function () {
                auth2 = gapi.auth2.init({
                    client_id: '990732731863-in59ar3adprbnpuhmgagtsfdmvcfv9q4.apps.googleusercontent.com'
                    //cookiepolicy: 'single_host_origin'
                });
                attachSignin(document.getElementById(actionButton));
            });
        };

        function attachSignin(element) {
            auth2.attachClickHandler(element, {},
                function (googleUser) {
                    $scope.userId = googleUser.getBasicProfile().getId();
                    $scope.userEmail = googleUser.getBasicProfile().getEmail();
                    $scope.userName = googleUser.getBasicProfile().getName();
                    $scope.userImage = googleUser.getBasicProfile().getImageUrl();
                    console.log($scope.userImage);
                    console.log($scope.userEmail);
                   
                    LoginService.google($scope.userEmail).then(
                        function (response) {
                            currentUser = response.data;
                            authenticated = true;
                            $rootScope.userName = currentUser.name;
                            $rootScope.message = "";
                            $location.path("/overview");
                        },
                        function (reason) {
                            currentUser = undefined;
                            authenticated = false;
                            $rootScope.message = "Invalid login, try again!";
                        }
                    );
                },
                function (error) {
                    console.log(error);
                });
        };


    });
}());