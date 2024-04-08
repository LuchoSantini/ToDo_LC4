using Microsoft.AspNetCore.Mvc;
using To_Do_List_LC4.Data.Dtos;
using To_Do_List_LC4.Interfaces;

namespace To_Do_List_LC4.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Agrear Usuario")]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            if (_userService.CreateUser(userDto))
            {
                return Ok($"Usuario generado correctamente");
            }
            return BadRequest("Ya existe este usuario");
        }

    }
}
