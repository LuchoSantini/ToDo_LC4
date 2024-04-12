using Microsoft.AspNetCore.Mvc;
using To_Do_List_LC4.Data.Dtos;
using To_Do_List_LC4.Interfaces;
using To_Do_List_LC4.Services;

namespace To_Do_List_LC4.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users/createUser")]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            if (_userService.CreateUser(userDto))
            {
                return Ok($"Usuario generado correctamente");
            }
            return BadRequest("Ya existe este usuario");
        }

        [HttpPut("users/editUser")]
        public IActionResult EditUsers([FromBody] UserToEditDto userToEditDto)
        {
            if (_userService.EditUsers(userToEditDto))
            {
                return Ok($"Usuario editado correctamente");
            }
            return BadRequest("No existe este un usuario con este ID");
        }

        [HttpGet("users/getAllUsers")]
        public IActionResult GetAllLists()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }
    }
}
