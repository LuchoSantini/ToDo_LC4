using Microsoft.AspNetCore.Mvc;
using To_Do_List_LC4.Data.Dtos;
using To_Do_List_LC4.Interfaces;

namespace To_Do_List_LC4.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoItemService _toDoItemService;
        public ToDoController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpPost("Agrear Lista")]
        public IActionResult CreateToDoList([FromBody] ToDoItemDto toDoDto)
        {
            if (_toDoItemService.CreateToDoList(toDoDto))
            {
                return Ok($"Lista generada correctamente");
            }
            return BadRequest("Ya existe una lista con este nombre o no existe el usuario.");
        }
    }
}
