using Library_WebServer.Database;
using Library_WebServer.Models.Database;
using Library_WebServer.Models.Requests.Rental;
using Library_WebServer.Models.Requests.Reservation;
using Library_WebServer.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_WebServer.Controllers;

[ApiController]
[Route("[controller]/")]
public class RentalsController : ControllerBase
{
    private readonly ILogger<RentalsController> _logger;
    private readonly LibraryDbContext _libraryDbContext;

    public RentalsController(ILogger<RentalsController> logger, LibraryDbContext libraryDbContext)
    {
        _logger = logger;
        _libraryDbContext = libraryDbContext;
    }

    [HttpGet]
    [Route("{rentalId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetRental(Guid rentalId)
    {
        //TODO: Add request validation
        var rental = _libraryDbContext.Rentals
            .Include(x => x.LibraryPublication)
            .Include(x => x.LibraryUser)
            .SingleOrDefault(x => x.Id == rentalId);

        if (rental == null)
        {
            return NotFound();
        }

        return Ok(new RentalResponseModel(rental));
    }
    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostReservation([FromBody] RentalRequestBaseModel rental)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        RentalDbModel newRental = new RentalResponseModel()
        {
            Date = rental.Date,
            IsBorrow = rental.IsBorrow,
            LibraryPublication = _libraryDbContext.Publications.Single(x => x.Id == rental.PublicationId),
            LibraryUser = _libraryDbContext.Users.Single(x => x.Id == rental.UserId)
        };

        _libraryDbContext.Rentals.Add(newRental);

        _libraryDbContext.SaveChanges();

        return Ok(new RentalResponseModel(newRental));
    }
}

