using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bambus.Server.Repositories;
using Bambus.Shared;

namespace Bambus.Server.Controller
{
    [ApiController]
    [Route("api/Frivillig")]

    //Dependency injection
    public class FrivilligController : ControllerBase

    {

        private Ifrivillig fRepo;

        public FrivilligController(Ifrivillig repo)
        {
            fRepo = repo;
        }

        [HttpGet]
        public IEnumerable<Frivillig> GetFrivillig()
        {
            return fRepo.GetFrivillig();
        }

    }

}