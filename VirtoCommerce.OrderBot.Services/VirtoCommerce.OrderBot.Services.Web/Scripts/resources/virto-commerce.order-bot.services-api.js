angular.module('virtoCommerce.orderBot.services')
    .factory('virtoCommerce.orderBot.services.webApi', ['$resource', function ($resource) {
        return $resource('api/VirtoCommerceOrderBotServices');
}]);
