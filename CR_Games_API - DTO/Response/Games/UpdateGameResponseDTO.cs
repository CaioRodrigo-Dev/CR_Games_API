using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___DTO.Response.Games
{
    public class UpdateGameResponseDTO
    {
        public bool IsUpdated { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Title { get; set; }
        public int StockQuantity { get; set; }
        public string Plataform { get; set; }
        public decimal Price { get; set; }

    }
}
