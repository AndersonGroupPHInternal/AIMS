app.controller("myCtrl", function ($scope, $http) {
   
    $scope.initialize = function () {
        $http.post('/Request/Viewreq')
            .then(
        function successCallback(response) {
            $scope.ViewReqs = response.data;
        },
        function errorCallback(response) {

        });
    }
   
});
