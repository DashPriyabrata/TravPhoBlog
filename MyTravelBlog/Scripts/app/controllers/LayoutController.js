app.controller('LayoutController', ['newsletterService', '$scope', '$location', LayoutController]);

function LayoutController(newsletterService, $scope, $location) {
    'use strict';
    $scope.subscriber = {};
    $scope.addSubscriberStatus = [];

    $scope.addSubscriber = function () {
        newsletterService.addSubscriber($scope.subscriber).then(function (isSuccess) {
            $scope.addSubscriberStatus = isSuccess;
        });
    }

    $scope.isActive = function (viewLocation) {
        return $location.$$absUrl.endsWith(viewLocation);
    };
}