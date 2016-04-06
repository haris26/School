(function () {

    var app = angular.module("school", []);

    app.controller("SkillsCtrl", function ($scope, SkillsService) {

        $scope.selCategory = "";
        $scope.sortOrder = "Name";
        fetchCategories();

        function fetchCategories() {
            $scope.message = "Wait...";
            SkillsService.getCategories().then(
                function (response) {
                    $scope.categories = response.data;
                    $scope.message = "";
                },
                function (reason) {
                    $scope.message = "No data for that request";
                }
            );
        }
    });

}());