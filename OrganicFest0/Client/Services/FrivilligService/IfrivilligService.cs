using System.Threading.Tasks;
using OrganicFest.Shared;

namespace OrganicFest0.Client.Services
{
    public interface IFrivilligService
    {
        Task<IEnumerable<Frivillig>> GetAllFrivillige();
        Task AddFrivillig(Frivillig frivillig);
        Task UpdateFrivillig(Frivillig frivillig);
    }
}
