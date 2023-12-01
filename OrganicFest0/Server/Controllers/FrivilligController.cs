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
    public class FrivilligController : ControllerBase
    {
        private readonly Ifrivillig _repository; // Privat felt til at gemme en instans af IBookingRepository

        // Konstruktør, der tager imod en IBookingRepository-implementering gennem dependency injection - Altså giver ansvaret videre
        public FrivilligController(Ifrivillig repository)
        {
            _repository = repository;   // Gemmer repository som et felt for brug i metoder
        }

        // Metode til at håndtere HTTP GET-anmodninger til api/bookings
        [HttpGet]
        public IEnumerable<Frivillig> GetFrivilligs()
        {
            return _repository.GetFrivilligs();  // Kalder GetBookings metoden på _repository for at hente alle bookinger
        }


        // Metode til at håndtere HTTP POST-anmodninger til api/bookings med en Booking som krop (FromBody)
        [HttpPost]
        public async Task<IActionResult> OpretFrivillig([FromBody] Frivillig frivillig)
        {
            try
            {
                await _repository.AddFrivillig(frivillig);  // Kalder AddBooking-metoden på _repository for at oprette en ny booking
                return Ok();  // Returnerer et HTTP 200 OK-svar ved succes
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"En fejl opstod ved oprettelse af booking. Fejl: {ex.Message}");  // Returnerer en fejlmeddelelse og HTTP 500-statuskode ved fejl
            }
        }

        // Her kan du tilføje yderligere metoder til at opdatere, slette osv., baseret på din repository implementering
    }
}