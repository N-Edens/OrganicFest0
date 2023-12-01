using Bambus.Shared;
using System.Collections.Generic;

namespace Bambus.Server.Repositories
{
    public interface Ifrivillig
    {
        Task<IEnumerable<Frivillig>> GetAllFrivillige();
        Task AddFrivillig(Frivillig frivillig);
        List<Frivillig> GetFrivilligs();
    }
}
