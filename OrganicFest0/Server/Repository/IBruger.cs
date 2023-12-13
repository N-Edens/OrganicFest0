using OrganicFest.Shared;
using System.Collections.Generic;

namespace OrganicFest.Server.Repository
{
    public interface IBruger
    {
        void AddBruger(Bruger bruger);
        void DeleteBruger(int FID);
        Bruger[] GetAllBruger();
        void UpdateBruger(Bruger bruger);
        Task<Bruger> AuthenticateUser(string email, string password); 


    }
}