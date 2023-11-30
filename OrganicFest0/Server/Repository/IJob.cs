using Bambus.Shared;
using System.Collections.Generic;

namespace Bambus.Server.Repositories
{
    // The IJob interface defines a contract for classes that will handle jobs
    public interface IJob
    {
        List<Job> GetJobs(); // Method to retrieve a list of jobs
    }
}
