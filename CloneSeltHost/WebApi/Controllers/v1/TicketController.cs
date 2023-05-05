using ICA.Ng.Carpark.WebApi.Domains;
using ICA.Ng.Carpark.WebApi.Services.v1.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ICA.Ng.Carpark.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TicketController : Controller
    {
        //just add line

        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("GetTickets")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ticket))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public List<Ticket> GetTickets()
        {
            return _ticketService.GetAllTickets();
        }

        [HttpGet("GetTicketById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        public IActionResult GetTicketById(int id)
        {
            var ticket = _ticketService.GetById(id);
            return ticket == null ? NotFound() : Ok(ticket);
        }
    }
}
