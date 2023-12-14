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

        [HttpPost]
        public void GetBruger(Bruger bruger)
        {
            bRepo.AddBruger(bruger);
        }

        [HttpDelete]
        [Route("delete/{FID:int}")]
        public void DeleteBruger(int FID)
        {
            bRepo.DeleteBruger(FID);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateBruger(Bruger bruger)
        {
            bRepo.UpdateBruger(bruger);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Bruger loginFrivillig)
        {
            var authenticatedUser = await bRepo.AuthenticateUser(loginFrivillig.Email, loginFrivillig.Password);

            if (authenticatedUser != null)
            {
                // Login successful
                return Ok(authenticatedUser);
            }
            else
            {
                // Login failed
                return BadRequest("Incorrect email or password.");
            }
        }

    }
}