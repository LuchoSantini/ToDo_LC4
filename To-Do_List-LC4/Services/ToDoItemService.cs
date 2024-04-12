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

        public bool EditLists(ToDoItemToEditDto toDoItemToEditDto)
        {
            ToDoItem listsToEdit = _context.ToDoItems.FirstOrDefault(p => p.Id == toDoItemToEditDto.Id);

            if (listsToEdit != null)
            {
                listsToEdit.Id = listsToEdit.Id;
                listsToEdit.Title = toDoItemToEditDto.Title;
                listsToEdit.Description = toDoItemToEditDto.Description;

                _context.Update(listsToEdit);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<ToDoItem> GetAllLists()
        {
            var lists = _context.ToDoItems.ToList();
            return lists;
        }
    }
}
