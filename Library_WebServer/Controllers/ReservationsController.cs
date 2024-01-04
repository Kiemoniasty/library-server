using Library_WebServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<ReservationsController> _logger;

        public ReservationsController(ILogger<ReservationsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{reservationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryReservation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetReservation([FromRoute] Guid reservationId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryReservation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostReservation([FromBody] LibraryReservation reservation)
        {
            return Ok();
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryReservation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutReservation([FromBody] LibraryReservation reservation)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{reservationId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryReservation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteReservation([FromRoute] Guid reservationId)
        {
            return Ok();
        }
    }
}
