(function () {

    var app = angular.module("school", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:55013/api/",
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/skills", { templateUrl: "skills.html", controller: "SkillsCtrl" })
            .when("/editCategory/:categoryId", { templateUrl: "editCategory.html", controller: "SkillsCtrl" })
            .when("/addNewCategory", { templateUrl: "addNewCategory.html", controller: "SkillsCtrl" })
            .otherwise({ redirectTo: "skills" });
    });

}());