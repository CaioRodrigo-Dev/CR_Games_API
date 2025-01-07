using CR_Games_API___DTO.Response.User;
using CR_Games_API___DTO.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CR_Games_API___Service.Interfaces
{
    public interface IUserService
    {
        Task<CreateUserResponseDTO> CreateUser(CreateUserRequestDTO request);
    }
}
