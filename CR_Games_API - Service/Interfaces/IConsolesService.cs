using CR_Games_API___DTO.Request.Console;
using CR_Games_API___DTO.Response.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Service.Interfaces
{
    public interface IConsolesService
    {
        Task<AddConsoleResponseDTO> AddConsole(AddConsoleRequestDTO request);
    }
}
