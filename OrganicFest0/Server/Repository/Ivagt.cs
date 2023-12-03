using System;
using OrganicFest.Shared;

namespace OrganicFest.Server.Repository
{
    public interface IVagt
    {
        void AddVagt(Vagt vagt);
        void DeleteVagt(int VID);
        Vagt[] GetAllVagts();
        void UpdateVagt(Vagt vagt);
    }
}
