(function () {

    var app = angular.module("school");

    app.factory("SkillsService", function ($http) {

        var source = "http://localhost:55013/api/";

        return {

            getCategories: function () {
                return $http.get(source + "skillscategories")
            },


        };
    });
}());