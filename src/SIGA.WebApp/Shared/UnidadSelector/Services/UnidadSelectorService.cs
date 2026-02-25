using SIGA.WebApp.Shared.UnidadSelector.Models;

namespace SIGA.WebApp.Shared.UnidadSelector.Services;

public class UnidadSelectorService
{
    private readonly HttpClient _http;

    public UnidadSelectorService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<UnidadSelectorResponse>> GetUnidadesAsync()
    {
        return await _http.GetFromJsonAsync<List<UnidadSelectorResponse>>(
                "api/unidades/obtener-unidades"
            ) ?? new List<UnidadSelectorResponse>();
    }
}
