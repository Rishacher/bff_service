using bff_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace bff_service.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BffController : ControllerBase
    {
        public BffController(IntersectionService intersectionService)
        {
        }

        [HttpPost]
        public CurveResponse GetIntersections([FromBody] CurveRequest curveRequest)
        {
            return null;
        }
    }
}