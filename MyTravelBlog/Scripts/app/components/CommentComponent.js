
app.controller('commentsComponentController', function () {
    var _self = this;

    _self.saveComment = function () {
        //data -> form data or form id to post it externally
        _self.onSubmit(data);
    }
}).component('commentComponent', {
    templateUrl: '/app/templates/addcomment.html',
    controller: 'commentsComponentController',
    controllerAs: "$commentsCtrl",
    bindings: {
        input: '=',
        onSubmit: '&'
    }
});