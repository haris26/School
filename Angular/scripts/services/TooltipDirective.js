(function () {

    var app = angular.module("school");

    app.directive("tooltipDirective", function ($rootScope) {
        return {
            restrict: "AE",
            replace: true,
                link: function (scope,elem, attrs) {
                    elem.bind('mouseenter', function () {
                        $rootScope.chair = "images/chairYes.png";
                        if (scope.room.room.characteristics[0].name == "NumberOfChairs") {
                            $rootScope.chairsNum = scope.room.room.characteristics[0].value;
                        }
                        if (scope.room.room.characteristics[1].name =="Speaker" && scope.room.room.characteristics[1].value == "Yes") {
                            $rootScope.speaker = "images/speakerYes.png";
                        }
                        else {
                            $rootScope.speaker = "images/speakerNo.png";
                        }
                        if (scope.room.room.characteristics[2].name == "TV" && scope.room.room.characteristics[2].value == "Yes") {
                            $rootScope.tv = "images/tvYes.png";
                        }
                        else {
                            $rootScope.tv = "images/tvNo.png";
                        }
                        if (scope.room.room.characteristics[3].name == "WhiteBoard" && scope.room.room.characteristics[3].value == "Yes"){
                            $rootScope.board = "images/whiteboardYes.png";
                        }
                        else {
                            $rootScope.board = "images/whiteboardNo.png";
                        }
                        $rootScope.tooltipContent = '<span><img src="' + $rootScope.chair + '"/></span><span>' + $rootScope.chairsNum + '</span>' +
                                '<span style="padding-left:8px"><img src="' + $rootScope.speaker + '"/></span>' +
                                '<span style="padding-left:8px"><img src="' + $rootScope.tv + '"/></span>' +
                                '<span style="padding-left:8px"><img src="' + $rootScope.board + '"/></span>';
                    });
                }
            }
    });

}());