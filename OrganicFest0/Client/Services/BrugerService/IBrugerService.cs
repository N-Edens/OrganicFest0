using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest.Client.Services
{
    public interface IBrugerService
    {
        Task<IEnumerable<Bruger>> GetAllBruger();
        Task AddBruger(Bruger bruger);
        Task UpdateBruger(Bruger bruger);
        Task DeleteBruger(int FID);
    }
}