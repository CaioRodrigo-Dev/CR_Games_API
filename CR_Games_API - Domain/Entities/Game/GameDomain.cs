using CR_Games_API___Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Domain.Entities.Game
{
    public class GameDomain : BaseDomain
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Plataform { get; set; }

        public int StockQuantity { get; set; }
    }
}
