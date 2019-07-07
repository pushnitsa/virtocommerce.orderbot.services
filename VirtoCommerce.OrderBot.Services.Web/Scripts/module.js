// Call this to register your module to main application
var moduleName = "virtoCommerce.orderBot.services";

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .run(['$rootScope', 'virtoCommerce.customerModule.memberTypesResolverService',
        function ($rootScope, memberTypesResolverService) {

            var contactInfo = memberTypesResolverService.resolve("Contact");
            contactInfo.detailBlade.metaFields.unshift({
                name: 'botUserName',
                title: "Bot User Name",
                valueType: "ShortText"
            });
        }
    ]);
