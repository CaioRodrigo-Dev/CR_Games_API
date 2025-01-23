using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___DTO.Request.Games
{
    public class UpdateGameRequestDTO
    {
        [Required]
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? StockQuantity { get; set; }

        public string? Plataform { get; set; }

        public decimal? Price { get; set; }


    }
}
