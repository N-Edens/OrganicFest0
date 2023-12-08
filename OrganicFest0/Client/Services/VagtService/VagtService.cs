// VagtService.cs
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest0.Client.Services
{
    public class VagtService : IVagtService
    {
        private readonly HttpClient http;

        public VagtService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<Vagt>> GetAllVagts()
        {
            return await http.GetFromJsonAsync<List<Vagt>>("api/vagt");
        }

        public async Task AddVagt(Vagt vagt)
        {
            await http.PostAsJsonAsync("api/vagt", vagt);
        }

        public Task UpdateVagt(Vagt vagt)
        {
            return http.PutAsJsonAsync("api/vagt/update", vagt);
        }

        public async Task DeleteVagt(int vagtId)
        {
            await http.DeleteAsync($"api/vagt/delete/{vagtId}");
        }

        public Task ChangeVagt(Vagt vagt)
        {
            return http.PutAsJsonAsync("api/vagt/change", vagt);
        }

    }
}
