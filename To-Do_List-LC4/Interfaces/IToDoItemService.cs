using To_Do_List_LC4.Data.Dtos;
using To_Do_List_LC4.Data.Entities;

namespace To_Do_List_LC4.Interfaces
{
    public interface IToDoItemService
    {
        public bool CreateToDoList(ToDoItemDto toDoDto);
        public bool EditLists(ToDoItemToEditDto toDoItemToEditDto);
        public List<ToDoItem> GetAllLists();
    }
}
