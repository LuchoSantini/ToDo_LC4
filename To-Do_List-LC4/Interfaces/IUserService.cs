using To_Do_List_LC4.Data.Dtos;

namespace To_Do_List_LC4.Interfaces
{
    public interface IUserService
    {
        public bool CreateUser(UserDto userDto);
    }
}
