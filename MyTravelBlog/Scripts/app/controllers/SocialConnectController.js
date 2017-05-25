
app.controller('SocialConnectController', ['socialConnectService', '$scope', SocialConnectController]).directive("owlCarousel", function () {
    return {
        restrict: 'E',
        transclude: false,
        link: function (scope) {
            scope.initCarousel = function (element) {
                // provide any default options you want
                var defaultOptions = {
                };
                var customOptions = scope.$eval($(element).attr('data-options'));
                // combine the two options objects
                for (var key in customOptions) {
                    defaultOptions[key] = customOptions[key];
                }
                defaultOptions['responsive'] = {
                    0: {
                        items: 1
                    },
                    600: {
                        items: 3
                    },
                    1000: {
                        items: 6
                    }
                };
                // init carousel
                var curOwl = $(element).data('owlCarousel');
                if (!angular.isDefined(curOwl)) {
                    $(element).owlCarousel(defaultOptions);
                }
                scope.cnt++;
            };
        }
    };
})
.directive('owlCarouselItem', [function () {
    return {
        restrict: 'A',
        transclude: false,
        link: function (scope, element) {
            // wait for the last item in the ng-repeat then call init
            if (scope.$last) {
                scope.initCarousel(element.parent());
            }
        }
    };
}]);

function SocialConnectController(socialConnectService, $scope) {
    'use strict';
    $scope.instagramMedia = [];

    socialConnectService.getInstagramRecentMedia().then(function (data) {
        $scope.instagramMedia = data.Data;
    });
}