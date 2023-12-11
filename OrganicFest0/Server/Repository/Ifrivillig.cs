using OrganicFest.Shared;
using System.Collections.Generic;

namespace OrganicFest.Server.Repository
{
    public interface Ifrivillig
    {
        void AddFrivillig(Bruger frivillig);
        void DeleteFrivillig(int FID);
        Bruger[] GetAllFrivillige();
        void UpdateFrivillig(Bruger frivillig);
        Task<Bruger> GetFrivilligByEmail(string email);


    }
}
