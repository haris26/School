(function () {

    var app = angular.module("school");

    app.directive("popoverRoom", function () {
        return {
            restrict: 'A',
            template: '<span>{{images}}</span>',
            link: function (scope, el, attrs) {
                scope.images = attrs.popoverImage;
                $(el).popover({
                    trigger: 'mouseenter',
                    html: true,
                    content: attrs.popoverHtml,
                    placement: attrs.popoverPlacement
                });
            }
        };
    });
}());