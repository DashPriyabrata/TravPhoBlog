app.controller('BlogInfoController', ['blogInfoService', '$scope', BlogInfoController]);

function BlogInfoController(blogInfoService, $scope) {
    'use strict';
    $scope.blogData = [];

    blogInfoService.getBlogInfo().then(function (data) {
        $scope.blogData = data;
    });
}