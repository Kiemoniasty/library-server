using Library_WebServer.Database;
using Library_WebServer.Models.Database;
using Library_WebServer.Models.Requests.Reservation;
using Library_WebServer.Models.Responses;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservationResponseModel))]
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

        return Ok(new ReservationResponseModel(reservation));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservationResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostReservation([FromBody] ReservationRequestBaseModel reservation)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        ReservationDbModel newReservation = new ReservationDbModel()
        {
            Date = reservation.Date,
            LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == reservation.PublicationId),
            LibraryUser = _libraryDbContext.Users.Single(x => x.Id == reservation.UserId)
        };

        _libraryDbContext.Reservations.Add(newReservation);

        _libraryDbContext.SaveChanges();

        return Ok(new ReservationResponseModel(newReservation));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservationResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutReservation([FromBody] ReservationRequestUpdateModel reservation)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        ReservationDbModel newReservation = new ReservationDbModel()
        {
            Id = reservation.Id,
            Date = reservation.Date,
            LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == reservation.PublicationId),
            LibraryUser = _libraryDbContext.Users.Single(x => x.Id == reservation.UserId)
        };

        _libraryDbContext.Reservations.Update(newReservation);

        _libraryDbContext.SaveChanges();

        return Ok(new ReservationResponseModel(newReservation));
    }

    [HttpDelete]
    [Route("{reservationId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReservationResponseModel))]
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

    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseModel<ReservationResponseModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetPublications([FromQuery] int? top, [FromQuery] int? skip)
    {
        //TODO: Add request validation
        List<ReservationResponseModel> reservations = _libraryDbContext.Reservations
            .Include(p => p.LibraryPublication)
            .Include(p => p.LibraryUser)
            .OrderBy(x => x.Date)
            .Take(top ?? 10)
            .Skip(skip ?? 0)
            .Select(x => new ReservationResponseModel(x))
            .ToList();

        int count = _libraryDbContext.Reservations.Count();

        return Ok(new PaginationResponseModel<ReservationResponseModel>(reservations, count));
    }
}
