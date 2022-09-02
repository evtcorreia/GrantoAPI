using AutoMapper;
using Granto.Data;
using Granto.Data.Dtos.User;
using Granto.Models;
using Granto.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Granto.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class UserController: ControllerBase
    {
        private AppGrantoContext _context;
        private IMapper _mapper;

            public UserController(AppGrantoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("/v1/user/insert")]
        public IActionResult Adiciona([FromBody] CreateUserDto userDto)
        {

            User user = _mapper.Map<User>(userDto);

            _context.Users.Add(user);
            _context.SaveChanges();

            

            return CreatedAtAction(nameof(getUser), new { Id = user.Id }, user);
        }

        [HttpGet]
        [Route("/v1/users/all")]
        public IActionResult getUsers()
        {


            
            return Ok(_context.Users);
        }

        [HttpGet]
        [Route("/v1/user/{id:int}")]
        public IActionResult getUser(int id)
        {
           User user = _context.Users.FirstOrDefault(user => user.Id == id);

            ReadUserDto userDto = _mapper.Map<ReadUserDto>(user);

            if(user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }
        [HttpPut]
        [Route("/v1/user/update/{id:int}")]
        public IActionResult AtualizaUser(int id, [FromBody] UpdateUserDto userDto)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _mapper.Map(userDto, user);

            _context.SaveChanges();
            

            return NoContent();
        }

        [HttpDelete]
        [Route("/v1/user/delete/{id:int}")]
        public IActionResult DeletaUser(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Remove(user);
            _context.SaveChanges();


            return NoContent();



        }

        



    }
}
