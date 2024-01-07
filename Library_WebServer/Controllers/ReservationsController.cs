using Library_WebServer.Database;
using Library_WebServer.Models.Database;
using Library_WebServer.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_WebServer.Controllers;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetReservation(Guid reservationId)
    {
        //TODO: Add request validation
        var reservation = _libraryDbContext.Reservations
            .Include(x => x.LibraryPublication)
            .Include(x => x.LibraryUser)
            .SingleOrDefault(x => x.Id == reservationId);

        if (reservation == null)
        {
            return NotFound();
        }

        return Ok(new Reservation(reservation));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostReservation([FromBody] Reservation reservation)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        LibraryReservation newReservation = new LibraryReservation()
        {
            Date = reservation.Date,
            LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == reservation.PublicationId),
            LibraryUser = _libraryDbContext.Users.Single(x => x.Id == reservation.UserId)
        };

        _libraryDbContext.Reservations.Add(newReservation);

        _libraryDbContext.SaveChanges();

        return Ok(new Reservation(newReservation));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutReservation([FromBody] Reservation reservation)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        LibraryReservation newReservation = new LibraryReservation()
        {
            Id = reservation.Id,
            Date = reservation.Date,
            LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == reservation.PublicationId),
            LibraryUser = _libraryDbContext.Users.Single(x => x.Id == reservation.UserId)
        };

        _libraryDbContext.Reservations.Update(newReservation);

        _libraryDbContext.SaveChanges();

        return Ok(new Reservation(newReservation));
    }

    [HttpDelete]
    [Route("{reservationId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Reservation))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteReservation(Guid reservationId)
    {
        var reservation = _libraryDbContext.Reservations.SingleOrDefault(x => x.Id == reservationId);

        if (reservation == null)
        {
            return NotFound();
        }

        _libraryDbContext.Reservations.Remove(reservation);
        _libraryDbContext.SaveChanges();

        return Ok();
    }
}
