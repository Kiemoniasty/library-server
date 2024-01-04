using Library_WebServer.Database;
using Library_WebServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_WebServer.Controllers
{
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
            return Ok();
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostUser([FromBody] User user)
        {
            User newUser = new User()
            {
                Address = user.Address,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                UserAccountType = _libraryDbContext.AccountTypes.Single(x => x.Id == user.UserAccountType.Id)
            };

            _libraryDbContext.Users.Add(newUser);

            _libraryDbContext.SaveChanges();

            return Ok(newUser);
        }

        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PutUser([FromBody] User user)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteUser([FromRoute] Guid userId)
        {
            return Ok();
        }
    }
}
