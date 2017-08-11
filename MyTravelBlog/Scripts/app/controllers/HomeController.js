
app.controller('HomeController', ['blogInfoService', '$scope', HomeController]);

function HomeController(blogInfoService, $scope) {
    'use strict';
    $scope.featuredPosts = [];
    $scope.allPosts = [];

    blogInfoService.getAllPosts().then(function (data) {
        $scope.allPosts = data;
    });
    blogInfoService.getFeaturedPosts().then(function (data) {
        $scope.featuredPosts = data;
    });
}