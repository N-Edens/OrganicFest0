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
    [Route("api/afdeling")]
    public class JobController : ControllerBase
    {
        private IAfdeling jRepo;

        public JobController(IAfdeling repo)
        {
            jRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Afdeling> GetAllAfdelinger()
        {
            return jRepo.GetAllAfdelinger();
        }

    }
}