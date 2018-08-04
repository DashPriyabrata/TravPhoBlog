app.controller('LayoutController', ['newsletterService', '$scope', '$location', LayoutController]);

function LayoutController(newsletterService, $scope, $location) {
    'use strict';
    $scope.subscriber = {};
    $scope.subscriptionMsg = [];

    $scope.addSubscriber = function () {
        newsletterService.addSubscriber($scope.subscriber).then(function (successMsg) {
            $scope.subscriptionMsg = successMsg;
        })
        .catch(function (data, status) {
            $scope.subscriptionMsg = 'Sorry! We faced technical difficulty travelling to the server. Please refresh the page and try again.';
            console.error('Error', response.status, response.data);
        });
    }

    $scope.isActive = function (viewLocation) {
        return $location.$$absUrl.endsWith(viewLocation);
    };
}