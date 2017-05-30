
app.controller('HomeController', ['blogInfoService', '$scope', HomeController]);

function HomeController(blogInfoService, $scope) {
    'use strict';
    $scope.featuredPosts = [];

    blogInfoService.getFeaturedPosts().then(function (data) {
        $scope.featuredPosts = data;
    });
}