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
        [Route("vagt")]
        public IEnumerable<Vagt> GetAllVagt()
        {
            return vRepo.GetAllVagts();
        }

        // Gør at en vagt kan tilføjes på beskrivelse, afdeling osv.
        [HttpPost]
        public void AddVagt(Vagt vagt)
        {
            vRepo.AddVagt(vagt);
        }
        // Henter kaldeet til at slette en Bruger ud fra VID (Vagt ID).

        [HttpDelete]
        [Route("delete/{VID:int}")]
        public void DeleteVagt(int VID)
        {
            vRepo.DeleteVagt(VID);
        }

        // Henter kaldet for at gøre det muligt at kunne opdatere i vagt
        [HttpPut]
        [Route("update")]
        public void UpdateVagt(Vagt vagt)
        {
            vRepo.UpdateVagt(vagt);
        }
    }
}