using System;
using OrganicFest.Shared;

namespace OrganicFest0.Client.Services
{
    public interface IJobService
    {
        Task<IEnumerable<Job>> GetAllJobs();
    }
}


