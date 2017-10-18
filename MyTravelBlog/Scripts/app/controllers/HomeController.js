app.config(['$locationProvider', function ($locationProvider) {
    //Disabling displayig the re-written url on browser but do the job.
    $locationProvider.html5Mode({
        enabled: true,
        rewriteLinks: false,
        requireBase: false
    });
}]);
app.controller('HomeController', ['blogHomeService', 'pagerService', '$scope', HomeController]);

function HomeController(blogHomeService, pagerService, $scope) {
    'use strict';
    $scope.featuredPosts = [];
    //$scope.allPosts = [];
    $scope.precisePosts = [];
    $scope.trendingPosts = [];
    $scope.recentPosts = [];
    $scope.pageNumber = 1;
    $scope.totalBlogCount = 0;
    var startIndex = 0;
    var numOfPosts = 7;

    //blogHomeService.getAllPosts().then(function (data) {
    //    $scope.allPosts = data;
    //});
    blogHomeService.getPrecisePosts(startIndex, numOfPosts).then(function (data) {
        $scope.precisePosts = data;
        $scope.recentPosts = data;
    });
    blogHomeService.getTotalBlogCount().then(function (data) {
        $scope.totalBlogCount = data;
        $scope.pager = pagerService.getPager($scope.totalBlogCount, 1);
    });
    blogHomeService.getFeaturedPosts().then(function (data) {
        $scope.featuredPosts = data;
    });
    blogHomeService.getTrendingPosts().then(function (data) {
        $scope.trendingPosts = data;
    });

    $scope.gotoPage = function (pageNumber) {
        $scope.pager = pagerService.getPager($scope.totalBlogCount, pageNumber);
        blogHomeService.getPrecisePosts(numOfPosts * (pageNumber - 1), numOfPosts).then(function (data) {
            $scope.precisePosts = data;
        });

        $scope.pageNumber = pageNumber;
    }
}