using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___DTO.Response.Games
{
    public class AddGameResponseDTO
    {
        public bool IsCreated { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
