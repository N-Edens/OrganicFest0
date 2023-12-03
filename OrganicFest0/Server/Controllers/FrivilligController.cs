using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrganicFest.Server.Repository;
using OrganicFest.Shared;

namespace OrganicFest.Server.Controllers
{
    [ApiController]
    [Route("api/frivillig")]
    public class FrivilligController : ControllerBase
    {
        private Ifrivillig fRepo;

        public FrivilligController(Ifrivillig repo)
        {
            fRepo = repo;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Frivillig> GetAllFrivillige()
        {
            return fRepo.GetAllFrivillige();
        }

        [HttpPost]
        [Route("add")]
        public void AddFrivillig(Frivillig frivillig)
        {
            fRepo.AddFrivillig(frivillig);
        }

        [HttpDelete]
        [Route("delete/{FID:int}")]
        public void DeleteFrivillig(int FID)
        {
            fRepo.DeleteFrivillig(FID);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateFrivillig(Frivillig frivillig)
        {
            fRepo.UpdateFrivillig(frivillig);
        }

        // Metode til at håndtere login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Frivillig frivillig)
        {
            // Hent frivillig baseret på e-mail
            var existingFrivillig = await fRepo.GetFrivilligByEmail(frivillig.Email);

            // Check om frivillig eksisterer og adgangskoden matcher
            if (existingFrivillig != null && existingFrivillig.Password == frivillig.Password)
            {
                // Login er vellykket
                return Ok(existingFrivillig);
            }
            else
            {
                // Login mislykkedes
                return BadRequest("Forkert e-mail eller adgangskode.");
            }
        }
        // Her kan du tilføje yderligere metoder til at opdatere, slette osv., baseret på din repository implementering
    }
}