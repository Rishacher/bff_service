using bff_service.Models;
using Clients;

public class IntersectionService
{
    private readonly IntersectionClient intersectionClient;
    private readonly IprService iprService;
    private readonly VlpService vlpService;

    public IntersectionService(HttpClient client, IprService iprService, VlpService vlpService)
    {
        intersectionClient = new IntersectionClient("http://localhost:8004", client);
        this.iprService = iprService;
        this.vlpService = vlpService;
    }

    public async Task<CurveResponse> GetIntersectionAsync(CurveRequest req, CancellationToken ct = default)
    {
        var ipr = await iprService.GetCurveAsync(req.iprParams);
        var vlp = await vlpService.GetCurveAsync(req.vlpParams);

        var intersection = await intersectionClient.PostAsync(
            new NodalCalcRequest
            {
                Ipr = new VlpIprCalcResponse
                {
                    P_wf = ipr.Select(e => e.Pressure).ToArray(),
                    Q_liq = ipr.Select(e => e.Debit).ToArray()
                },
                Vlp = new VlpIprCalcResponse
                {
                    P_wf = vlp.Select(e => e.Pressure).ToArray(),
                    Q_liq = vlp.Select(e => e.Debit).ToArray()
                }
            });

        return new CurveResponse
        {
            Intersection = intersection.Select(e => new CurvePoint { Pressure = e.P_wf, Debit = e.Q_liq }).ToArray(), 
            IprCurve = ipr, 
            VlpCurve = vlp
        };
    }

    private CurvePoint ConvertPoint(CurvePoint curvePoints)
    {
        return new CurvePoint { Debit = curvePoints.Debit, Pressure = curvePoints.Pressure };
    }

    private CurvePoint ConvertPointBack(CurvePoint curvePoints)
    {
        return new CurvePoint { Debit = curvePoints.Debit, Pressure = curvePoints.Pressure };
    }
}