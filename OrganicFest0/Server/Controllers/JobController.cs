using System;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Bambus.Server.Repositories;
using Bambus.Shared;

namespace mini.Server.Controllers
{
    [Route("api/jobs")]  // Angiver rutepræfikset for API-endepunkterne i denne controller
    [ApiController]  // Markerer denne klasse som en ApiController, hvilket betyder, at den håndterer HTTP-anmodninger
    public class JobController : ControllerBase
    {

        public readonly IJob _jobRepository;  // Privat felt til at gemme en instans af IShelter

        // Konstruktør, der tager imod en IShelter-implementering gennem dependency injection - Gø
        public JobController(IJob jobRepository)
        {
            _jobRepository = jobRepository; // Gemmer shelterRepository som et felt for brug i metoder
        }

        // Metode til at håndtere HTTP GET-anmodninger til api/shelter
        [HttpGet]
        public List<Job> GetJobs()
        {
            return _jobRepository.GetJobs();  // Kalder GetShelters metoden på _shelterRepository for at hente alle Shelters
        }
    }
}