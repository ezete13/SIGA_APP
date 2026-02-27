using SIGA.WebApp.Features.Unidades.Models;

namespace SIGA.WebApp.Features.Unidades;

public class UnidadService
{
    private readonly HttpClient _http;

    public UnidadService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<UnidadResponse>> GetUnidadesAsync()
    {
        return await _http.GetFromJsonAsync<List<UnidadResponse>>("api/unidades/obtener-unidades")
            ?? new List<UnidadResponse>();
    }

    public async Task<List<UnidadDetalleResponse>> GetUnidadesDetalleAsync()
    {
        return await _http.GetFromJsonAsync<List<UnidadDetalleResponse>>(
                "api/unidades/obtener-unidades"
            ) ?? new List<UnidadDetalleResponse>();
    }
}
