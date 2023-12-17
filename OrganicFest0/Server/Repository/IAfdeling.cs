using OrganicFest.Shared;
using System.Collections.Generic;

namespace OrganicFest.Server.Repository
{
    public interface IAfdeling
    {
        Afdeling[] GetAllAfdelinger();
    }
}
