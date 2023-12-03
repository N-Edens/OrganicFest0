using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OrganicFest.Server.Repository;
using OrganicFest.Shared;

namespace OrganicFest.Server.Controllers
{
    [ApiController]
    [Route("api/job")]
    public class JobController : ControllerBase
    {
        private IJob jRepo;

        public JobController(IJob repo)
        {
            jRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Job> GetAllJobs()
        {
            return jRepo.GetallJobs();
        }

    }
}