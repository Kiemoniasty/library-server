using Library_WebServer.Database;
using Library_WebServer.Models.Database;
using Library_WebServer.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_WebServer.Controllers;

[ApiController]
[Route("[controller]/")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;
    private readonly LibraryDbContext _libraryDbContext;

    public UsersController(ILogger<UsersController> logger, LibraryDbContext libraryDbContext)
    {
        _logger = logger;
        _libraryDbContext = libraryDbContext;
    }

    [HttpGet]
    [Route("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetUser([FromRoute] Guid userId)
    {
        //TODO: Add request validation
        LibraryUser? user = _libraryDbContext.Users
            .Include(x => x.UserAccountType)
            .SingleOrDefault(x => x.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new User(user));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostUser([FromBody] User user)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        LibraryUser newUser = new LibraryUser()
        {
            Address = user.Address,
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            UserAccountType = _libraryDbContext.AccountTypes.Single(x => x.Id == user.AccountType)
        };

        _libraryDbContext.Users.Add(newUser);

        _libraryDbContext.SaveChanges();

        return Ok(new User(newUser));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutUser([FromBody] User user)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        LibraryUser? newUser = _libraryDbContext.Users
            .SingleOrDefault(p => p.Id == user.Id);

        if (newUser == null)
        {
            return BadRequest();
        }

        newUser.Name = user.Name;
        newUser.Password = user.Password;
        newUser.Email = user.Email;
        newUser.PhoneNumber = user.PhoneNumber;
        newUser.Address = user.Address;
        newUser.UserAccountType = _libraryDbContext.AccountTypes.Single(x => x.Id == user.AccountType);

        _libraryDbContext.Users.Update(newUser);

        _libraryDbContext.SaveChanges();

        return Ok(new User(newUser));
    }

    [HttpDelete]
    [Route("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteUser([FromRoute] Guid userId)
    {
        //TODO: Add request validation
        LibraryUser? user = _libraryDbContext.Users
            .SingleOrDefault(x => x.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        _libraryDbContext.Users.Remove(user);
        _libraryDbContext.SaveChanges();

        return Ok();
    }
}
