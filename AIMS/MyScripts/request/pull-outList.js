app.controller('myCtrl', function ($scope, $http) {
    $scope.request;
    $scope.initialize = function () {
        $http.post('/Request/PullOutList')
            .then(
            function successCallback(response) {
                $scope.requests = response.data;
            },
            function errorCallback(response) {

            });
    }
});