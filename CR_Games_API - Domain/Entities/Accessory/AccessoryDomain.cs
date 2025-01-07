using CR_Games_API___Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Domain.Entities.Accessory
{
    public class AccessoryDomain : BaseDomain
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CompatibleConsoles { get; set; }

        public int StockQuantity { get; set; }
    }
}
