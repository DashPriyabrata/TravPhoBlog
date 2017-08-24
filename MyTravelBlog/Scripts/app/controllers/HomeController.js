
app.controller('HomeController', ['blogHomeService', '$scope', HomeController]);

function HomeController(blogHomeService, $scope) {
    'use strict';
    $scope.featuredPosts = [];
    $scope.allPosts = [];
    $scope.trendingPosts = [];

    blogInfoService.getAllPosts().then(function (data) {
        $scope.allPosts = data;
    });
    blogInfoService.getFeaturedPosts().then(function (data) {
        $scope.featuredPosts = data;
    });
    blogInfoService.getTrendingPosts().then(function (data) {
        $scope.trendingPosts = data;
    });
}