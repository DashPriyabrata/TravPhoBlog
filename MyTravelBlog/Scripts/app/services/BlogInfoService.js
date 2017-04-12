
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
                }
            };
        }
]);
