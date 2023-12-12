using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest.Client.Services
{
    public class AfdelingService : IAfdelingService
    {
        private readonly HttpClient http;

        public AfdelingService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<Afdeling>> GetAllAfdelinger()
        {
            return await http.GetFromJsonAsync<List<Afdeling>>("api/afdeling");
        }
    }
}
