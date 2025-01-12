using CR_Games_API___DTO.Request.Auth;
using CR_Games_API___DTO.Response.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Service.Interfaces
{
    public interface IAuthService
    {
        Task<AuthLoginResponseDTO> Authenticate(AuthLoginRequestDTO request);
    }
}
