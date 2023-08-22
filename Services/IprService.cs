using bff_service.Models;
using Clients;
public class IprService 
{
    private readonly IprClient _iprClient;

    public IprService(HttpClient client)
    {
        _iprClient = new IprClient(client);
    }

    public async Task<CurvePoint[]> GetCurveAsync(IprCalculationRequest request, CancellationToken ct = default)
    {
        var response = await _iprClient.CalculateCurveAsync(request);
        var debit = response.Q_liq;
        var pressure = response.P_wf;

        var curvePoints = debit.Zip(pressure).Select((point) => new CurvePoint() { Debit = point.First, Pressure = point.Second }).ToArray();

        return curvePoints;
    }
}