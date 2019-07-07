using System.Web.Http;
using VirtoCommerce.OrderBot.Services.Core;
using VirtoCommerce.Platform.Core.Web.Security;

namespace VirtoCommerce.OrderBot.Services.Web.Controllers.Api
{
    [RoutePrefix("api/VirtoCommerceOrderBotServices")]
    public class VirtoCommerceOrderBotServicesController : ApiController
    {
        // GET: api/VirtoCommerceOrderBotServices
        [HttpGet]
        [Route("")]
        [CheckPermission(Permission = ModuleConstants.Security.Permissions.Read)]
        public IHttpActionResult Get()
        {
            return Ok(new { result = "Hello world!" });
        }
    }
}
