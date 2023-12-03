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
        public IEnumerable<Frivillig> GetAllFrivillige()
        {
            return fRepo.GetAllFrivillige();
        }

        [HttpPost]
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
        public void UpdateFrivillig(Frivillig frivillig)
        {
            fRepo.UpdateFrivillig(frivillig);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Frivillig loginFrivillig)
        {
            try
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
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}