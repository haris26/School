(function () {

    var app = angular.module("school");

    app.controller("FindPeopleCtrl", function ($scope, $log, DataService) {
        $scope.message = "Loading data...";
        $scope.searchCriteria = [];
        
        fetchCategories();

        function fetchCategories() {
            DataService.list("tools", function (data) {
                $scope.categories = data.categories;
                $scope.searchCriteria.push(criteriaItem());
                $scope.message = "";
            })
        }

        function criteriaItem() {
            return {
                category: $scope.categories[0],
                skills: $scope.categories[0].skills,
                skill: $scope.categories[0].skills[0].id,
                level: "1",
                experience: 0
            };
        }

        $scope.selectCategory = function(index)
        {
            $scope.searchCriteria[index].skills = $scope.searchCriteria[index].category.skills;
            $scope.searchCriteria[index].skill = $scope.searchCriteria[index].category.skills[0].id;
        }

        $scope.addCriteria = function () {
            $scope.searchCriteria.push(criteriaItem());
        }

        $scope.removeCriteria = function (index) {
            $scope.searchCriteria.splice(index, 1);
        }

        $scope.resetCriteria = function () {
            $scope.searchCriteria = [];
            $scope.addCriteria();
        }

        $scope.findPeople = function () {
            var searchModel = {
                queriedSkills: [],
                queriedEducations: []
            }

            for (i = 0; i < $scope.searchCriteria.length; i++) {
                if ($scope.searchCriteria[i].category.categoryType == 0) {
                    searchModel.queriedSkills.push({
                        id: $scope.searchCriteria[i].skill,
                        level: parseInt($scope.searchCriteria[i].level),
                        experience: $scope.searchCriteria[i].experience
                    });
                }
                else {
                    searchModel.queriedEducations.push($scope.searchCriteria[i].skill);
                }
            }

            DataService.findPeople(searchModel, function (data) {
                $scope.exactMatches = data.exactMatches;
                $scope.closeMatches = data.closeMatches;
                for (var i = 0; i < $scope.closeMatches.length; i++) {
                    console.log("educations", $scope.closeMatches[i].fullName);
                    console.log("educations", $scope.closeMatches[i].educations);
                }              
            });
        }
    });
}());