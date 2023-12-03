using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest0.Client.Services
{
    public class JobService : IJobService
    {
        private readonly HttpClient http;

        public JobService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await http.GetFromJsonAsync<List<Job>>("api/job");
        }
    }
}
