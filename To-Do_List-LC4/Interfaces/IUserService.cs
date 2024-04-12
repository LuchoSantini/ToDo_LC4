using To_Do_List_LC4.Data.Dtos;
using To_Do_List_LC4.Data.Entities;

namespace To_Do_List_LC4.Interfaces
{
    public interface IUserService
    {
        public bool CreateUser(UserDto userDto);
        public bool EditUsers(UserToEditDto userToEditDto);
        public List<User> GetAllUsers();
    }
}
