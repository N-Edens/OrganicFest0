using System;
using Bambus.Shared;

namespace OrganicFest0.Client.Services.VagtService
{
    public interface IVagtService
    {
        Task<IEnumerable<Vagt>> GetAllVagts();
        Task AddVagt(Vagt vagt);
        List<Vagt> GetVagts();
    }
}

