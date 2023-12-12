using System;
using OrganicFest.Shared;

namespace OrganicFest.Client.Services
{
    public interface IAfdelingService
    {
        Task<IEnumerable<Afdeling>> GetAllAfdelinger();
    }
}


