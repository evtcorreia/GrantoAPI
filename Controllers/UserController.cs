using Granto.Models;
using Microsoft.AspNetCore.Mvc;

namespace Granto.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class UserController
    {
        private static List<User> users = new List<User>();

        [HttpPost]
        public void Adiciona([FromBody] User user)
        {
            users.Add(user);
        }

        [HttpGet]
        public IEnumerable<User> getUsers()
        {
            return users;
        }

        



    }
}
