app.controller('CategoryController', ['categoryService', '$scope', CategoryController]);

function CategoryController(categoryService, $scope) {
    'use strict';
    $scope.categoryData = [];
    $scope.allCategories = [];

    categoryService.getCategory(1).then(function (data) {
        $scope.categoryData = data;
    });

    categoryService.getAll().then(function (data) {
        $scope.allCategories = data;
    });
}