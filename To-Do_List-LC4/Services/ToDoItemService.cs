using To_Do_List_LC4.Context;
using To_Do_List_LC4.Data.Dtos;
using To_Do_List_LC4.Data.Entities;
using To_Do_List_LC4.Interfaces;

namespace To_Do_List_LC4.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly ToDoContext _context;
        public ToDoItemService(ToDoContext context)
        {
            _context = context;
        }

        public bool CreateToDoList(ToDoItemDto toDoDto)
        {
            ToDoItem existingItem = _context.ToDoItems.FirstOrDefault(c => c.Title == toDoDto.Title);
            User existingUser = _context.Users.FirstOrDefault(c => c.Id == toDoDto.UserId);

            if (existingItem == null && existingUser != null)
            {
                var newItem = new ToDoItem()
                {
                    UserId = existingUser.Id,
                    Title = toDoDto.Title,
                    Description = toDoDto.Description,
                };

                _context.ToDoItems.Add(newItem);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
