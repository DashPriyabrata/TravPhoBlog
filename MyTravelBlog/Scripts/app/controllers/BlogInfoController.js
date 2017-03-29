app.controller('BlogInfoController', ['blogInfoService', 'categoryService', '$scope', BlogInfoController]);

function BlogInfoController(blogInfoService, categoryService, $scope) {
    'use strict';
    $scope.blogData = [];
    $scope.postContent = [];
    $scope.categoryData = [];
    
    blogInfoService.getBlogInfo(1).then(function (data) {
        $scope.blogData = data;

        blogInfoService.getPostContent($scope.blogData.ContentId).then(function (data) {
            $scope.postContent = data;
        });

        categoryService.getCategory($scope.blogData.CategoryId).then(function (data) {
            $scope.categoryData = data;
        });
    });
}