app.controller('LayoutController', ['$scope', '$location', LayoutController]);

function LayoutController($scope, $location) {
    'use strict';
    $scope.isActive = function (viewLocation) {
        return $location.$$absUrl.endsWith(viewLocation);
    };
}