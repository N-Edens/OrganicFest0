using OrganicFest.Shared;
using System.Collections.Generic;

namespace OrganicFest.Server.Repository
{
    public interface Ifrivillig
    {
        void AddFrivillig(Frivillig frivillig);
        void DeleteFrivillig(int FID);
        Frivillig[] GetAllFrivillige();
        void UpdateFrivillig(Frivillig frivillig);
        Task<Frivillig> GetFrivilligByEmail(string email);

    }
}
