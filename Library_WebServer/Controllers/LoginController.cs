using Library_WebServer.Database;
using Library_WebServer.Models.Login.Request;
using Library_WebServer.Models.User.Database;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebServer.Controllers;

public class LoginController : ControllerBase
{
    private readonly ILogger<LoginController> _logger;
    private readonly LibraryDbContext _libraryDbContext;

    public LoginController(ILogger<LoginController> logger, LibraryDbContext libraryDbContext)
    {
        _logger = logger;
        _libraryDbContext = libraryDbContext;
    }

    [HttpPost]
    [Route("")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostLogin([FromBody] LoginRequestBaseModel login)
    {
        UserDbModel? loginDB = _libraryDbContext.Users.SingleOrDefault(x => x.Id == login.Id);

        bool pass = (loginDB != null && loginDB.Password == login.Password) ? true : false;

        return Ok(pass);
    }
}
