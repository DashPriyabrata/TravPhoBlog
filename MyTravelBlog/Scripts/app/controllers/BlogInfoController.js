app.controller('BlogInfoController', ['blogInfoService', '$scope', BlogInfoController]);

function BlogInfoController(blogInfoService, $scope) {
    'use strict';
    $scope.blogData = [];
    $scope.postContent = [];

    blogInfoService.getBlogInfo(1).then(function (data) {
        $scope.blogData = data;
    });

    blogInfoService.getPostContent(1).then(function (data) {
        $scope.postContent = data;
    });
    
}