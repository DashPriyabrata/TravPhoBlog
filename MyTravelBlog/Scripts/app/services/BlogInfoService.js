
app.factory('blogInfoService', [
        'blogInfoApiRoot', '$http', '$q', function (apiRoot, $http, $q) {
            'use strict';
            return {
                apiRoot: apiRoot,
                getBlogInfo: function (blogId) {
                    var def = $q.defer();

                    $http.get(apiRoot + blogId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getPostContent: function (contentId) {
                    var def = $q.defer();

                    $http.get(apiRoot + "PostContent/" + contentId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getTags: function (blogTagId) {
                    var def = $q.defer();

                    $http.get(apiRoot + "Tags/" + blogTagId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getComments: function (blogId) {
                    var def = $q.defer();

                    $http.get(apiRoot + "Comments/" + blogId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                addComment: function (commentData) {
                    var def = $q.defer();

                    $http.post(apiRoot + "AddComment/", commentData)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getPrevPost: function (postId) {
                    var def = $q.defer();

                    $http.get(apiRoot + "PrevPost/" + postId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getNextPost: function (postId) {
                    var def = $q.defer();

                    $http.get(apiRoot + "NextPost/" + postId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                },
                getRelatedPosts: function (blogTagId) {
                    var def = $q.defer();

                    $http.get(apiRoot + "RelatedPosts/" + blogTagId)
                        .then(function (response) {
                            def.resolve(response.data);
                        }, def.reject);

                    return def.promise;
                }
            };
        }
]);
