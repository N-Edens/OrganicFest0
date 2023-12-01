using System;
using Bambus.Shared;

namespace OrganicFest0.Client.Services.JobService;

    public interface IJobService
    {
        List<Job> GetJobs(); // Method to retrieve a list of jobs
    }

