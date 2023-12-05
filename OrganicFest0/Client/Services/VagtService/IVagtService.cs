using System.Collections.Generic;
using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest0.Client.Services
{
    public interface IVagtService
    {
        Task<IEnumerable<Vagt>> GetAllVagts();
        Task AddVagt(Vagt vagt);
        Task UpdateVagt(Vagt vagt);
    }
}



