using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace catalog.API.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
