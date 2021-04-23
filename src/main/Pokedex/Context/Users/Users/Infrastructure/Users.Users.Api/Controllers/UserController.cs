using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Users.Users.Application.UseCase;
using Users.Users.Domain.Exceptions;

namespace Users.Users.Api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly CreateUser _createUser;

        public UserController(CreateUser createUser)
        {
            _createUser = createUser;
        }

        [HttpPut("user/create/{userId}")]
        public async Task<IActionResult> Put(string userId)
        {
            try
            {
                await _createUser.Execute(userId);
                return Accepted();
            }
            catch (InvalidUserException ex)
            {
                return Conflict(ex.Message);
            }
            catch (UserExistsException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}