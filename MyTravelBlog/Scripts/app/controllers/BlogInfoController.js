app.config(['$locationProvider', function ($locationProvider) {
    // In order to get the query string from the
    // $location object, it must be in HTML5 mode.
    $locationProvider.html5Mode({
        enabled: true,
        rewriteLinks: false,
        requireBase: true
    });
}]);
app.controller('BlogInfoController', ['blogInfoService', 'userService', '$scope', '$location', '$filter', BlogInfoController]);


function BlogInfoController(blogInfoService, userService, $scope, $location, $filter) {
    'use strict';
    $scope.blogData = [];
    $scope.postContent = [];
    $scope.tags = [];
    $scope.comments = [];
    $scope.comment = [];
    $scope.addCommentStatus = [];
    $scope.prevPost = [];
    $scope.nextPost = [];
    $scope.relatedPosts = [];
    $scope.user = {};
    $scope.parentId = 0;
    $scope.jsonLD = {};
    var _self = this;
    _self.comment = "";

    _self.saveComment = function (commentsData) {
        //save logic here - can me form post or ajax post
    }
    var splitUrl = $location.$$path.split('/');
    var blogId = splitUrl[splitUrl.length - 1];
    //var blogId = $location.search().blogId;

    blogInfoService.getBlogInfo(blogId).then(function (data) {
        $scope.blogData = data;

        blogInfoService.getPostContent($scope.blogData.ContentId).then(function (data) {
            $scope.postContent = data;
        });

        blogInfoService.getTags($scope.blogData.BlogTagId).then(function (data) {
            $scope.tags = data;
        });

        blogInfoService.getRelatedPosts($scope.blogData.BlogTagId).then(function (data) {
            $scope.relatedPosts = data;
        });

        blogInfoService.getComments(blogId).then(function (data) {
            $scope.comments = data;
        });

        $scope.jsonLD = {
            "@context": "http://schema.org",
            "@type": "BlogPosting",
            "headline": $scope.blogData.Title,
            "description": $scope.blogData.NavUrlString.replace(/\-/g, ' '),
            "datePublished": $filter('date')($scope.blogData.PostDate, "MMMM d, yyyy"),
            "image": {
                "@type": "imageObject",
                "url": $location.protocol() + "://" + $location.host() + "/Images/Post/" + $scope.blogData.TitleImage,
                "height": "1000",
                "width": "360"
            },
            "genre": "search engine optimization",
            "keywords": $scope.blogData.Category + " " + $scope.blogData.City + " " + $scope.blogData.Country,
            "url": $location.absUrl(),
            "articleBody": $scope.postContent.Introduction,
            "author": {
                "@type": "Person",
                "name": $scope.blogData.blogger.FirstName + " " + $scope.blogData.blogger.LastName,
                "photo": {
                    "@type": "imageObject",
                    "url": $location.protocol() + "://" + $location.host() + "/Images/Blogger/" + $scope.blogData.blogger.Photo
                }
            }
        };
    });

    blogInfoService.getPrevPost(blogId).then(function (data) {
        $scope.prevPost = data;
    });

    blogInfoService.getNextPost(blogId).then(function (data) {
        $scope.nextPost = data;
    });

    $scope.setCommentParent = function (id) {
        $scope.parentId = id;
    }

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

            //To refresh the comments to show the newly added comment.
            blogInfoService.getComments(blogId).then(function (data) {
                $scope.comments = data;
            });
        });
    }
}

app.directive('jsonld', ['$filter', '$sce', function ($filter, $sce) {
    return {
        restrict: 'E',
        template: function () {
            return '<' + 'script type="application/ld+json" ng-bind-html="onGetJson()">' + '<' + '/script>';
        },
        scope: {
            json: '=json'
        },
        link: function (scope, element, attrs) {
            scope.onGetJson = function () {
                return $sce.trustAsHtml($filter('json')(scope.json));
            }
        },
        replace: true
    };
}]);