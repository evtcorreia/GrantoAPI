using Granto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Granto.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class UserController: ControllerBase
    {
        private static List<User> users = new List<User>();

        private static int id = 1;

        [HttpPost]
        public IActionResult Adiciona([FromBody] User user)
        {
            user.Id = id++;
            users.Add(user);

            return CreatedAtAction(nameof(getUser), new { Id = user.Id }, user);
        }

        [HttpGet]
        public IActionResult getUsers()
        {
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult getUser(int id)
        {
           User user = users.FirstOrDefault(user => user.Id == id);

            if(user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        



    }
}
