using To_Do_List_LC4.Context;
using To_Do_List_LC4.Data.Dtos;
using To_Do_List_LC4.Data.Entities;
using To_Do_List_LC4.Interfaces;

namespace To_Do_List_LC4.Services
{
    public class UserService : IUserService
    {
        private readonly ToDoContext _context;
        public UserService(ToDoContext context)
        {
            _context = context;
        }

        public bool CreateUser(UserDto userDto)
        {
            User existingUser = _context.Users.FirstOrDefault(c => c.Name == userDto.Name);

            if (existingUser == null)
            {
                var newUser = new User()
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Address = userDto.Address,
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditUsers(UserToEditDto userToEditDto)
        {
            User userToEdit = _context.Users.FirstOrDefault(p => p.Id == userToEditDto.Id);

            if (userToEdit != null)
            {
                userToEdit.Id = userToEdit.Id;
                userToEdit.Name = userToEditDto.Name;
                userToEdit.Email = userToEditDto.Email;
                userToEdit.Address = userToEditDto.Address;

                _context.Update(userToEdit);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }
    }
}
