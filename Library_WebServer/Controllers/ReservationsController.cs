using Library_WebServer.Database;
using Library_WebServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebServer.Controllers
{
    [ApiController]
    [Route("[controller]/")]
    public class ReservationsController : ControllerBase
    {
        private readonly ILogger<ReservationsController> _logger;
        private readonly LibraryDbContext _libraryDbContext;

        public ReservationsController(ILogger<ReservationsController> logger, LibraryDbContext libraryDbContext)
        {
            _logger = logger;
            _libraryDbContext = libraryDbContext;
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
            LibraryReservation newReservation = new LibraryReservation()
            {
                Date = reservation.Date,
                LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == reservation.LibraryPublication).Id,
                User = _libraryDbContext.Users.Single(x => x.Id == reservation.User).Id
            };

            _libraryDbContext.Reservations.Add(newReservation);

            _libraryDbContext.SaveChanges();

            return Ok(newReservation);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LibraryReservation))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutReservation([FromBody] LibraryReservation reservation)
        {
            LibraryReservation newReservation = new LibraryReservation()
            {
                Id = reservation.Id,
                Date = reservation.Date,
                LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == reservation.LibraryPublication).Id,
                User = _libraryDbContext.Users.Single(x => x.Id == reservation.User).Id
            };

            _libraryDbContext.Reservations.Update(newReservation);

            _libraryDbContext.SaveChanges();

            return Ok(newReservation);
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
