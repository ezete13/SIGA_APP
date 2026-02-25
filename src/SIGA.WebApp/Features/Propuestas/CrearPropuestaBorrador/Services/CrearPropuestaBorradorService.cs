using SIGA.WebApp.Features.Propuestas.CrearPropuestaBorrador.Models;

namespace SIGA.WebApp.Features.Propuestas.CrearPropuestaBorrador.Service;

public class CrearPropuestaBorradorService
{
    private readonly HttpClient _http;

    public CrearPropuestaBorradorService(HttpClient http)
    {
        _http = http;
    }

    public async Task<int?> CrearPropuestaBorradorAsync(CrearPropuestaBorradorRequest request)
    {
        var response = await _http.PostAsJsonAsync("api/propuestas/crear-borrador", request);

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<CrearPropuestaResponse>();

        return result?.PropuestaId;
    }
}
