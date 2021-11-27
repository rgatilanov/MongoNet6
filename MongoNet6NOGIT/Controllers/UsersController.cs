using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoNet6NOGIT.Models;
using MongoNet6NOGIT.Services;

namespace MongoNet6NOGIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
          _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
                return NotFound();

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            user.Id = String.Empty;
            _userService.Create(user);

            return CreatedAtRoute("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userObj)
        {
            var user = _userService.Get(id);

            if (user == null)
                return NotFound();

            _userService.Update(id, userObj);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
                return NotFound();

            _userService.Remove(user.Id);

            return NoContent();
        }
    }
}
