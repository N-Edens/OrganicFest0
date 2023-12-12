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
        private IBruger fRepo;

        public FrivilligController(IBruger repo)
        {
            fRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Bruger> GetAllFrivillige()
        {
            return fRepo.GetAllBruger();
        }

        [HttpPost]
        public void AddFrivillig(Bruger bruger)
        {
            fRepo.AddBruger(bruger);
        }

        [HttpDelete]
        [Route("delete/{FID:int}")]
        public void DeleteFrivillig(int FID)
        {
            fRepo.DeleteBruger(FID);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateFrivillig(Bruger bruger)
        {
            fRepo.UpdateBruger(bruger);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Bruger loginFrivillig)
        {

            var existingFrivillig = await fRepo.GetBrugerByEmail(loginFrivillig.Email);

            if (existingFrivillig != null && existingFrivillig.Password == loginFrivillig.Password)
            {
                // Login successful
                return Ok(existingFrivillig);
            }
            else
            {
                // Login failed
                return BadRequest("Incorrect email or password.");
            }
        }

    }
}