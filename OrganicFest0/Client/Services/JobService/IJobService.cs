using System;
using OrganicFest.Shared;

namespace OrganicFest.Client.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobs();
    }
}


