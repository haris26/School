//(function () {

//    var app = angular.module("school");

//    app.controller("LoginController", function ($scope, $rootScope, $location, LoginService) {

//        $scope.wait = true;
//        promise = LoginService.getCredentials();
//        if (promise) {
//            promise.then(
//                function (response) {
//                    authenticated = true;
//                    currentUser = response.data;
//                    $rootScope.userName = currentUser.name;
//                    $location.path("/details");
//                },
//                function (reason) {
//                    $rootScope.message = reason.status;
//                    $location.path("/login");
//                })
//        };
//        $scope.wait = false;
//        $scope.user = { name: "", pass: "", remember: false };
//        startApp('googleBtn');

//        $scope.login = function () {

//            $scope.wait = true;
//            promise = LoginService.login($scope.user);
//            promise.then(
//                function (response) {
//                    authenticated = true;
//                    currentUser = response.data;
//                    $rootScope.userName = currentUser.name;
//                    console.log($scope.user.remember);
//                    if ($scope.user.remember) LoginService.setCredentials("local", $scope.user.name + ":" + $scope.user.pass);
//                    $scope.wait = false;
//                    $rootScope.$broadcast('userLoggedIn');
//                    $location.path("/details");
//                },
//                function (reason) {
//                    console.log(reason);
//                    $rootScope.message = reason.status;
//                    $scope.wait = false;
//                }
//            )
//        };

//        function startApp(actionButton) {
//            gapi.load('auth2', function () {
//                auth2 = gapi.auth2.init({
//                    client_id: '990732731863-in59ar3adprbnpuhmgagtsfdmvcfv9q4.apps.googleusercontent.com',
//                    cookiepolicy: 'single_host_origin'
//                });
//                attachSignin(document.getElementById(actionButton));
//            });
//        };

//        function attachSignin(element) {
//            auth2.attachClickHandler(element, {},
//                function (googleUser) {
//                    $scope.wait = true;
//                    var userEmail = googleUser.getBasicProfile().getEmail();
//                    $scope.userName = googleUser.getBasicProfile().getName();
//                    $rootScope.userImage = googleUser.getBasicProfile().getImageUrl();

//                    LoginService.google(userEmail).then(
//                        function (response) {
//                            currentUser = response.data;
//                            authenticated = true;
//                            $rootScope.userName = currentUser.name;
//                            $rootScope.message = "";
//                            if ($scope.user.remember) LoginService.setCredentials("google", userEmail);
//                            $scope.wait = false;
//                            $rootScope.$broadcast('userLoggedIn');
//                            $location.path("/details");
//                        },
//                        function (reason) {
//                            currentUser = undefined;
//                            authenticated = false;
//                            $rootScope.message = "Invalid login, try again!";
//                            $scope.wait = false;
//                        }
//                    );
//                },
//                function (error) {
//                    console.log(error);
//                });
//        };
//    });

//    app.controller("LogoutController", function ($cookies, $location, $rootScope) {
//        currentUser = {};
//        authenticated = false;
//        $cookies.remove('gigiSchool');

//        //$rootScope.userName = "";
//        //$rootScope.userImage = null;
//        //$location.path("/login");

//        window.location.reload();
//    });

//}());

(function () {

    var app = angular.module("school");

    app.controller("LoginController", function ($scope, $rootScope, $location, LoginService) {

        $scope.wait = true;
        promise = LoginService.getCredentials();
        if (promise) {
            promise.then(
                function (response) {
                    authenticated = true;
                    currentUser = response.data;
                    $rootScope.userName = currentUser.name;
                    $location.path("/overview");
                },
                function (reason) {
                    $rootScope.message = reason.status;
                    $location.path("/login");
                })
        };
        $scope.wait = false;
        $scope.user = { name: "", pass: "", remember: false };
        startApp("googleBtn");

        $scope.login = function () {

            $scope.wait = true;
            promise = LoginService.login($scope.user);
            promise.then(
                function (response) {
                    authenticated = true;
                    currentUser = response.data;
                    $rootScope.userName = currentUser.name;
                    console.log($scope.userName);
                    if ($scope.user.remember) LoginService.setCredentials("local", $scope.user.name + ":" + $scope.user.pass);
                    $location.path("/overview");
                    $('.modal').modal('hide');
                    $('.modal-backdrop').remove();
                    $('body').removeClass('modal-open');
                    $scope.wait = false;
                },
                function (reason) {
                    console.log(reason);
                    $rootScope.message = reason.status;
                    $scope.wait = false;
                }
            )
        };

        function startApp(actionButton) {
            gapi.load("auth2", function () {
                auth2 = gapi.auth2.init({
                    client_id: "990732731863-in59ar3adprbnpuhmgagtsfdmvcfv9q4.apps.googleusercontent.com",
                    cookiepolicy: "single_host_origin"
                });
                attachSignin(document.getElementById(actionButton));
            });
        };

        function attachSignin(element) {
            auth2.attachClickHandler(element, {},
                function (googleUser) {
                    $scope.wait = true;
                    var userEmail = googleUser.getBasicProfile().getEmail();
                    $rootScope.userName = googleUser.getBasicProfile().getName();
                    $rootScope.userImage = googleUser.getBasicProfile().getImageUrl();

                    LoginService.google(userEmail).then(
                        function (response) {
                            currentUser = response.data;
                            authenticated = true;
                            $rootScope.userName = currentUser.name;
                            $rootScope.message = "";
                            $location.path("/overview");
                            if ($scope.user.remember) LoginService.setCredentials("google", userEmail);
                            $('.modal').modal('hide');
                            $('.modal-backdrop').remove();
                            $('body').removeClass('modal-open');
                            $scope.wait = false;
                        },
                        function (reason) {
                            currentUser = undefined;
                            authenticated = false;
                            $rootScope.message = "Invalid login, try again!";
                            $scope.wait = false;
                        }
                    );
                },
                function (error) {
                    console.log(error);
                });
        };
    });

    app.controller("LogoutController", function ($cookies, $location, $rootScope) {
        authenticated = false;
        $cookies.remove("gigiSchool");

        window.location.reload();
    });

}());