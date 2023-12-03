using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest0.Client.Services
{
    public class FrivilligService : IFrivilligService
    {
        private readonly HttpClient http;

        public FrivilligService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<Frivillig>> GetAllFrivillige()
        {
            return await http.GetFromJsonAsync<List<Frivillig>>("api/frivillig");
        }

        public async Task AddFrivillig(Frivillig frivillig)
        {
            await http.PostAsJsonAsync("api/frivillig", frivillig);
        }
    }
}
