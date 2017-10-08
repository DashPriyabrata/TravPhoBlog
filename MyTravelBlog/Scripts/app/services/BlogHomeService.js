
app.factory('blogHomeService', [
        'blogHomeApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
            'use strict';
            return {
                apiRoot: apiRoot,
                getAllPosts: function () {
                    var def = $q.defer();

                    $http.get(apiRoot + "All")
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getPrecisePosts: function (startIndex, numOfPosts) {
                    var def = $q.defer();

                    $http.get(apiRoot + "Precise/" + startIndex + "/" + numOfPosts)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getTotalBlogCount: function () {
                    var def = $q.defer();

                    $http.get(apiRoot + "TotalBlogCount")
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getFeaturedPosts: function(){
                    var def = $q.defer();

                    $http.get(apiRoot + "Featured")
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getTrendingPosts: function () {
                    var def = $q.defer();

                    $http.get(apiRoot + "Trending")
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                }
            };
        }
]);
