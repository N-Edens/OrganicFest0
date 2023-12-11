using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest.Client.Services
{
    public class FrivilligService : IFrivilligService
    {
        private readonly HttpClient http;

        public FrivilligService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<Bruger>> GetAllFrivillige()
        {
            return await http.GetFromJsonAsync<List<Bruger>>("api/frivillig");
        }

        public async Task AddFrivillig(Bruger frivillig)
        {
            await http.PostAsJsonAsync("api/frivillig", frivillig);
        }

        public Task UpdateFrivillig(Bruger frivillig)
        {
            return http.PutAsJsonAsync("api/frivillig/update", frivillig);
        }

        public async Task DeleteFrivillig(int FID)
        {
            await http.DeleteAsync($"api/frivillig/delete/{FID}");
        }
    }
}
