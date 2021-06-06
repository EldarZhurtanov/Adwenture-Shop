using DataContracts;
using Model.Models;

namespace Core.Managers.Helpers
{
    public static class ApplicationUserCreator
    {
        public static ApplicationUser CreateFromUserDTO(UserDTO userDTO)
        {
            return new ApplicationUser
            {
                Email = userDTO.Email,
                UserName = userDTO.Email,
            };
        }
    }
}
