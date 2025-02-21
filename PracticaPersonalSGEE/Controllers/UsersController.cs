using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaPersonalSGEE.DTOs;
using PracticaPersonalSGEE.Models;
using PracticaPersonalSGEE.Services;

namespace PracticaPersonalSGEE.Controllers
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

        [HttpPost("Register")]
        public async Task<ActionResult<Users>> RegisterUser(UserDTO userDTO)
        {
            try
            {
                var createUser = await _userService.RegisterUser(userDTO);

                return Ok(createUser);

            }catch(ArgumentException ex)
            {
               
                return BadRequest(new {message = ex.Message});
            }
            catch (Exception ex) 
            { 
                return StatusCode(500, new {message = "Error al intentar registrar usuario", error = ex.Message});
            }
        
        }
        
    }
}
