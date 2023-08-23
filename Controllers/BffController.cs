using bff_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace bff_service.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BffController : ControllerBase
    {
        private IntersectionService _intersectionService;
        
        public BffController(IntersectionService intersectionService)
        {
            _intersectionService = intersectionService;
        }

        [HttpPost]
        public async Task<CurveResponse> GetIntersections([FromBody] CurveRequest curveRequest) => 
            await _intersectionService.GetIntersectionAsync(curveRequest);
    }
}