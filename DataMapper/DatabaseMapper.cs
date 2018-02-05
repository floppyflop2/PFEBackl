using DataModel;
using Models;
using System.Collections.Generic;

namespace DataMapper
{
    public class DatabaseMapper
    {
        public static UserDTO MapToUserDTO(Users user)
        {
            return new UserDTO()
            {
                Id = user.UserId,
                Email = user.UserEmail,
            };
        }
        public static List<UserDTO> MapToUserDTO(List<Users> users)
        {
            List<UserDTO> listOfUsers = new List<UserDTO>();
            users.ForEach(s => listOfUsers.Add(MapToUserDTO(s)));
            return listOfUsers;
        }
    }
}
