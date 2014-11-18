applicationModule.controller('controller',['$scope','chatHub','$timeout','productsService','$rootScope',
    function ($scope, chatHub, $timeout, productsService, $rootScope) {
        $scope.products = [];
        $scope.message = '';
        $scope.messages = [];
        var room = "bar"; //Hardcode

        productsService.get().then(function (product) {
            console.log(product);
            $scope.products = product;
        });




        $timeout(function () {
            chatHub.joinRoom(room);
        }, 500);



        $scope.send = function() {
            if ($scope.message == '') return;
            chatHub.send($scope.message, room);
            $scope.message = '';
        };



        $rootScope.$on('NewMessage', function (meta, obj) {
            if (room === obj.room) {
                $timeout(function() {
                    $scope.messages.push(obj.message);
                });
            }
        });
   


  

  
   
}]);