using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestAppAPI.Data;
using RestAppAPI.Models;

namespace RestAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IContext context;
        public UserController(IContext context)
        {
            this.context = context;

        }

        [HttpPost("/LogIn")]
        public async Task<ActionResult<User>> LogInUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var u = await context.GetUserByEmailAndPasswordAsync(user.email, user.password);

            if (u == null)
            {
                return NotFound();
            }
            return u;
        }

        [HttpGet("/User")]
        public async Task<ActionResult<User>> GetUserByEmail(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            var u = await context.GetUserByEmailAsync(user.email);

            if(u == null)
            {
                return NotFound();
            }

            return u;
        }
        [HttpGet("/User/{id}")]
        public async Task<ActionResult<User>> GetUserById(int user)
        {
            

            var u = await context.GetUserByIdAsync(user);

            if (u == null)
            {
                return NotFound();  
            }

            return u;
        }

        [HttpPost("/Register")]
        public async Task<ActionResult<User>>RegisterNewUser(User user)
        {
            if (user== null)
            {
                return BadRequest();
            }
            bool t = await context.CreateNewUser(user);

            var u = await context.GetUserByEmailAsync(user.email);

            if (u==null)
            {
                return BadRequest();
            }

            return u;
          
            
        }


    }
}
