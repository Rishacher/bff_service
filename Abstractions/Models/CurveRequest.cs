using Clients;

namespace bff_service.Models
{
    public class CurveRequest
    {
        public VlpCalcRequest vlpParams { get; set; }
        public IprCalculationRequest iprParams { get; set; }
    }
}
