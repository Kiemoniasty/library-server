using Library_WebServer.Database;
using Library_WebServer.Models;
using Library_WebServer.Models.User.Database;
using Library_WebServer.Models.User.Request;
using Library_WebServer.Models.User.Response;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetUser([FromRoute] Guid userId)
    {
        //TODO: Add request validation
        UserDbModel? user = _libraryDbContext.Users
            .Include(x => x.UserAccountType)
            .Include(x => x.LibraryRentals)
                .ThenInclude(x => x.LibraryPublication)
            .SingleOrDefault(x => x.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(new UserResponseModel(user));
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostUser([FromBody] UserRequestBaseModel user)
    {
        //TODO: Add request validation
        //TODO: Add db data validation

        UserDbModel newUser = new UserDbModel()
        {
            Address = user.Address,
            Email = user.Email,
            Name = user.Name,
            Password = user.Password,
            PhoneNumber = user.PhoneNumber,
            UserAccountType = _libraryDbContext.AccountTypes.Single(x => x.Id == user.AccountType),
            LibraryRentals = new ()
        };

        _libraryDbContext.Users.Add(newUser);

        _libraryDbContext.SaveChanges();

        return Ok(new UserResponseModel(newUser));
    }

    [HttpPut]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PutUser([FromBody] UserRequestUpdateModel user)
    {
        //TODO: Add request validation
        //TODO: Add db data validation
        UserDbModel? newUser = _libraryDbContext.Users
            .Include(x => x.LibraryRentals)
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

        return Ok(new UserResponseModel(newUser));
    }

    [HttpDelete]
    [Route("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseModel))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteUser([FromRoute] Guid userId)
    {
        //TODO: Add request validation
        UserDbModel? user = _libraryDbContext.Users
            .SingleOrDefault(x => x.Id == userId);

        if (user == null)
        {
            return NotFound();
        }

        _libraryDbContext.Users.Remove(user);
        _libraryDbContext.SaveChanges();

        return Ok();
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseModel<UserResponseModel>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetUsers([FromQuery] int? top, [FromQuery] int? skip)
    {
        //TODO: Add request validation
        List<UserResponseModel> users = _libraryDbContext.Users
            .Include(x => x.UserAccountType)
            .Include(x => x.LibraryRentals)
                .ThenInclude(x => x.LibraryPublication)
            .OrderBy(x => x.Name)
            .Take(top ?? 10)
            .Skip(skip ?? 0)
            .Select(x => new UserResponseModel(x))
            .ToList();

        int count = _libraryDbContext.Users.Count();

        return Ok(new PaginationResponseModel<UserResponseModel>(users, count));
    }
}
