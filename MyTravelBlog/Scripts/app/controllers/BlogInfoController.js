app.config(['$locationProvider', function ($locationProvider) {
    // In order to get the query string from the
    // $location object, it must be in HTML5 mode.
    $locationProvider.html5Mode(true);
}]);
app.controller('BlogInfoController', ['blogInfoService', 'categoryService', 'userService', '$scope', '$location', BlogInfoController]);

function BlogInfoController(blogInfoService, categoryService, userService, $scope, $location) {
    'use strict';
    $scope.blogData = [];
    $scope.postContent = [];
    $scope.categoryData = [];
    $scope.tags = [];
    $scope.comments = [];
    $scope.comment = [];
    $scope.addCommentStatus = [];
    $scope.prevPost = [];
    $scope.nextPost = [];
    $scope.user = {};
    $scope.parentId = 0;
    var _self = this;
    _self.comment = "";

    _self.saveComment = function (commentsData) {
        //save logic here - can me form post or ajax post
    }

    var blogId = $location.search().blogId;

    blogInfoService.getBlogInfo(blogId).then(function (data) {
        $scope.blogData = data;

        blogInfoService.getPostContent($scope.blogData.ContentId).then(function (data) {
            $scope.postContent = data;
        });

        categoryService.getCategory($scope.blogData.CategoryId).then(function (data) {
            $scope.categoryData = data;
        });

        blogInfoService.getTags($scope.blogData.BlogTagId).then(function (data) {
            $scope.tags = data;
        });

        blogInfoService.getComments(1).then(function (data) {
            $scope.comments = data;
        });
    });

    blogInfoService.getPrevPost(blogId).then(function (data) {
        $scope.prevPost = data;
    });

    blogInfoService.getNextPost(blogId).then(function (data) {
        $scope.nextPost = data;
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