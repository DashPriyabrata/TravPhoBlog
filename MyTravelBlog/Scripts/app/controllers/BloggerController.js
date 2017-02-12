app.controller('BloggerController', ['bloggerService', '$scope', BloggerController]);

function BloggerController(bloggerService, $scope) {
    'use strict';
    $scope.blogger = [];
    $scope.testData = [];

    bloggerService.getBlogger().then(function (data) {
        $scope.blogger = data;
    });

    bloggerService.getTestData().then(function (data) {
        $scope.testData = data;
    });
}