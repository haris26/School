(function () {

    var app = angular.module("school");

    app.factory("DataService", function ($http) {

        var source = "http://localhost:50169/api/";

        return {
            resourceList: function () {
                return $http.get(source + "resources/")
            },

            resourceRead: function (id) {
                return $http.get(source + "resources/" + id)
            },

            resourceCreate: function (data) {
                return $http({
                    method: "post",
                    url: source,
                    data: data
                })
            },

            update: function (id, data) {
                return $http({
                    method: "put",
                    url: source + id,
                    data: data
                })
            },

            delete: function (set, id) {
                return $http({
                    method: "delete",
                    url: source + id,
                    data: null
                })
            }
        };
    });
}());