using OrganicFest.Shared;
using System.Collections.Generic;

namespace OrganicFest.Server.Repository
{
    // The IJob interface defines a contract for classes that will handle jobs
    public interface IJob
    {
        Job[] GetallJobs();
    }
}
