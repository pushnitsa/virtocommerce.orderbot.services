angular.module('virtoCommerce.orderBot.services')
    .controller('virtoCommerce.orderBot.services.helloWorldController', ['$scope', 'virtoCommerce.orderBot.services.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'VirtoCommerce.OrderBot.Services';

        blade.refresh = function () {
            api.get(function (data) {
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);