app.controller('BlogInfoController', ['blogInfoService', 'categoryService', '$scope', BlogInfoController]);

function BlogInfoController(blogInfoService, categoryService, $scope) {
    'use strict';
    $scope.blogData = [];
    $scope.postContent = [];
    $scope.categoryData = [];
    $scope.comments = [];
    
    blogInfoService.getBlogInfo(3).then(function (data) {
        $scope.blogData = data;

        blogInfoService.getPostContent($scope.blogData.ContentId).then(function (data) {
            $scope.postContent = data;
        });

        categoryService.getCategory($scope.blogData.CategoryId).then(function (data) {
            $scope.categoryData = data;
        });

        blogInfoService.getComments(1).then(function (data) {
            $scope.comments = data;
        });
    });
}