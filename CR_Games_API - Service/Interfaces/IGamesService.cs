using CR_Games_API___DTO.Request.Games;
using CR_Games_API___DTO.Response.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Service.Interfaces
{
    public interface IGamesService
    {
        Task<AddGameResponseDTO> AddGame(AddGameRequestDTO request);
    }
}
