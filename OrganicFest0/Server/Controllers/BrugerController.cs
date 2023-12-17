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
        private IBruger bRepo;

        public FrivilligController(IBruger repo)
        {
            bRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Bruger> GetAllBruger()
        {
            return bRepo.GetAllBruger();
        }

        // Gør at en bruger kan tilføjes på navn, email osv.
        [HttpPost]
        public void AddBruger(Bruger bruger)
        {
            bRepo.AddBruger(bruger);
        }

        // Henter kaldeet til at slette en Bruger ud fra FID (Frivillig ID).
        [HttpDelete]
        [Route("delete/{FID:int}")]
        public void DeleteBruger(int FID)
        {
            bRepo.DeleteBruger(FID);
        }

        // Henter kaldet for at gøre det muligt at kunne opdatere i bruger
        [HttpPut]
        [Route("update")]
        public void UpdateBruger(Bruger bruger)
        {
            bRepo.UpdateBruger(bruger);
        }

        // Kald AuthenticateUser-metoden for at se om bruger findes. 
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Bruger loginFrivillig)
        {
            var authenticatedUser = await bRepo.AuthenticateUser(loginFrivillig.Email, loginFrivillig.Password);

            if (authenticatedUser != null)
            {
                return Ok(authenticatedUser);
            }
            else
            {
                return BadRequest("Incorrect email or password.");
            }
        }

    }
}