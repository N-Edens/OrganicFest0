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
        public IEnumerable<Bruger> GetAllFrivillige()
        {
            return fRepo.GetAllFrivillige();
        }

        [HttpPost]
        public void AddFrivillig(Bruger frivillig)
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
        public void UpdateFrivillig(Bruger frivillig)
        {
            fRepo.UpdateFrivillig(frivillig);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Bruger loginFrivillig)
        {

                var existingFrivillig = await fRepo.GetFrivilligByEmail(loginFrivillig.Email);

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