(function () {

    var app = angular.module("school");

    app.factory("SkillsService", function ($http) {

        var source = "http://localhost:55013/api/";

        return {

            getCategories : function () {
                return $http.get(source + "skillscategories")
            },

            getCategory: function (id) {
                return $http.get(source + "skillscategories/" + id)
            },

            create: function (data, controllerName) {
                source += controllerName;
                return $http({
                    method: "post",
                    url: source,
                    data: data
                })
            },

            update: function (id, data, controllerName) {
                source += controllerName +"/";
                return $http({
                    method: "put",
                    url: source + id,
                    data: data
                })
            },

            remove: function (id, controllerName) {
                source += controllerName + "/";
                return $http({
                    method: "delete",
                    url: source + id,
                    data: null
                })
            }

        };
    });
}());