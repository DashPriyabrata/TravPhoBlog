app.controller('BlogInfoController', ['blogInfoService', 'categoryService', 'userService', '$scope', BlogInfoController]);

function BlogInfoController(blogInfoService, categoryService, userService, $scope) {
    'use strict';
    $scope.blogData = [];
    $scope.postContent = [];
    $scope.categoryData = [];
    $scope.comments = [];
    $scope.comment = [];
    $scope.addCommentStatus = [];
    $scope.user = {};
    $scope.parentId = 0;
    var _self = this;
    _self.comment = "";

    _self.saveComment = function (commentsData) {
        //save logic here - can me form post or ajax post
    }

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

    $scope.addUser = function () {
        userService.addUser($scope.user).then(function (data) {
            var userData = data;
            var commentData = {
                PostId: $scope.blogData.BlogId,
                ParentId: $scope.parentId,
                UserId: userData.Id,
                Comment: $scope.comment
            };

            return blogInfoService.addComment(commentData);
        }).then(function (isSuccess) {
            $scope.addCommentStatus = isSuccess;
        });
    }
}