// Call this to register your module to main application
var moduleName = "virtoCommerce.orderBot.services";

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $stateProvider
                .state('workspace.virtoCommerceOrderBotServicesState', {
                    url: '/virtoCommerce.orderBot.services',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        '$scope', 'platformWebApp.bladeNavigationService', function ($scope, bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: 'virtoCommerce.orderBot.services.helloWorldController',
                                template: 'Modules/$(virtoCommerce.orderBot.services)/Scripts/blades/hello-world.html',
                                isClosingDisabled: true
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['$rootScope', 'platformWebApp.mainMenuService', 'platformWebApp.widgetService', '$state',
        function ($rootScope, mainMenuService, widgetService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/virtoCommerce.orderBot.services',
                icon: 'fa fa-cube',
                title: 'VirtoCommerce.OrderBot.Services',
                priority: 100,
                action: function () { $state.go('workspace.virtoCommerceOrderBotServicesState'); },
                permission: 'virtoCommerce.orderBot.services.WebPermission'
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
