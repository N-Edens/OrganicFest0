using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrganicFest.Server.Repository;
using OrganicFest.Shared;
using static System.Net.Mime.MediaTypeNames;

namespace OrganicFest.Server.Controllers
{
    [ApiController]
    [Route("api/vagt")]
    public class VagtController : ControllerBase
    {
        private IVagt vRepo;

        public VagtController(IVagt repo)
        {
            vRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Vagt> GetAllVagt()
        {
            return vRepo.GetAllVagts();
        }

        [HttpPost]
        public void AddVagt(Vagt vagt)
        {
            vRepo.AddVagt(vagt);
        }

        [HttpDelete]
        [Route("delete/{VID:int}")]
        public void DeleteVagt(int VID)
        {
            vRepo.DeleteVagt(VID);
        }

        [HttpPut]
        [Route("update")]
        public void UpdateVagt(Vagt vagt)
        {
            vRepo.UpdateVagt(vagt);
        }

    }
}