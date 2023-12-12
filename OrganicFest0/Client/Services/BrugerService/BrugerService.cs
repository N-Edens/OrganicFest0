using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest.Client.Services
{
    public class BrugerService : IBrugerService
    {
        private readonly HttpClient http;

        public BrugerService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<Bruger>> GetAllBruger()
        {
            return await http.GetFromJsonAsync<List<Bruger>>("api/frivillig");
        }

        public async Task AddBruger(Bruger bruger)
        {
            await http.PostAsJsonAsync("api/frivillig", bruger);
        }

        public Task UpdateBruger(Bruger bruger)
        {
            return http.PutAsJsonAsync("api/frivillig/update", bruger);
        }

        public async Task DeleteBruger(int FID)
        {
            await http.DeleteAsync($"api/frivillig/delete/{FID}");
        }
    }
}