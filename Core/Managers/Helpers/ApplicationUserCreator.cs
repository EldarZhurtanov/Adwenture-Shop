using DataContracts;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
