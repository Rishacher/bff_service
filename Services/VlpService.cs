using bff_service.Models;
using Clients;

public class VlpService
{
    private readonly VlpClient _vlpClient;
    public VlpService(HttpClient client)
    {
        _vlpClient = new VlpClient("http://localhost:8002", client);
    }

    public async Task<CurvePoint[]> GetCurveAsync(VlpCalcRequest request, CancellationToken ct = default)
    {
        var response = await _vlpClient.PostAsync(request);
        var debit = response.Q_liq;
        var pressure = response.P_wf;

        var curvePoints = debit.Zip(pressure).Select((point) => new CurvePoint() { Debit = point.First, Pressure = point.Second }).ToArray();

        return curvePoints;
    }
}