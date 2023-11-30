using System;
using Bambus.Shared;

namespace Bambus.Server.Repositories
{
    public interface IVagt
    {
        Task<IEnumerable<Vagt>> GetAllVagts();
        Task AddVagt(Vagt vagt);
        List<Vagt> GetVagts();
    }
}
