using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest.Client.Services
{
    public interface IFrivilligService
    {
        Task<IEnumerable<Bruger>> GetAllFrivillige();
        Task AddFrivillig(Bruger frivillig);
        Task UpdateFrivillig(Bruger frivillig);
        Task DeleteFrivillig(int FID);
    }
}
