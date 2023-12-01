using System;
using Bambus.Shared;

namespace OrganicFest0.Client.Services.FrivilligService
{
    public interface IJobService
    {
        List<Frivillig> GetFrivillig();
    }
}
