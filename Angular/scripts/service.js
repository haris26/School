(function() {

    var app = angular.module("school");

    app.factory("DataService", function($http) {

        var source = "http://localhost:61310/api/people/";

        return {
            list: function() {
                return $http.get(source)
            },

            read: function(id) {
                return $http.get(source + id)
            },

            create: function(data) {
                return $http({ method:"post",
                    url:source,
                    data:data })},

            update: function(id, data) {
                return $http({ method:"put",
                    url:source + id,
                    data: data })},

            delete: function(set, id) {
                return $http({ method:"delete",
                    url:source + id,
                    data: null })}
        };
    });
}());
