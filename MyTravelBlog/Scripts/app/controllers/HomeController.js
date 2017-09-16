app.config(['$locationProvider', function ($locationProvider) {
    //Disabling displayig the re-written url on browser but do the job.
    $locationProvider.html5Mode({
        enabled: true,
        rewriteLinks: false,
        requireBase: false
    });
}]);
app.controller('HomeController', ['blogHomeService', '$scope', HomeController]);

function HomeController(blogHomeService, $scope) {
    'use strict';
    $scope.featuredPosts = [];
    //$scope.allPosts = [];
    $scope.precisePosts = [];
    $scope.trendingPosts = [];
    //$scope.startIndex = 0;
    //$scope.numOfPosts = 7;
    var startIndex = 0;
    var numOfPosts = 7;

    //blogHomeService.getAllPosts().then(function (data) {
    //    $scope.allPosts = data;
    //});
    blogHomeService.getPrecisePosts(startIndex, numOfPosts).then(function (data) {
        $scope.precisePosts = data;
    });
    blogHomeService.getFeaturedPosts().then(function (data) {
        $scope.featuredPosts = data;
    });
    blogHomeService.getTrendingPosts().then(function (data) {
        $scope.trendingPosts = data;
    });
}