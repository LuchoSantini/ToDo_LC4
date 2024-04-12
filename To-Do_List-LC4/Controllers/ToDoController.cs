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

        [HttpPost("lists/createToDoList")]
        public IActionResult CreateToDoList([FromBody] ToDoItemDto toDoDto)
        {
            if (_toDoItemService.CreateToDoList(toDoDto))
            {
                return Ok($"Lista generada correctamente");
            }
            return BadRequest("Ya existe una lista con este nombre o no existe el usuario.");
        }

        [HttpPut("lists/editLists")]
        public IActionResult EditLists([FromBody] ToDoItemToEditDto toDoItemToEditDto)
        {
            if (_toDoItemService.EditLists(toDoItemToEditDto))
            {
                return Ok($"Lista editada correctamente");
            }
            return BadRequest("No existe esta lista");
        }

        [HttpGet("lists/getAllLists")]
        public IActionResult GetAllLists()
        {
            var list = _toDoItemService.GetAllLists();
            return Ok(list);
        }
    }
}
