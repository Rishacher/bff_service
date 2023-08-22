namespace bff_service.Models
{
    public class CurveResponse
    {
        public CurvePoint[] VlpCurve { get; set; }
        public CurvePoint[] IprCurve { get; set; }
        public CurvePoint[] Intersection { get; set; }
    }    
}
