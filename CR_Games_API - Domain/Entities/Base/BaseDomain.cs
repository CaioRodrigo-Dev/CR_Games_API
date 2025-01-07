using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Domain.Entities.Base
{
    public abstract class BaseDomain
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? DeletedAt { get; set; }

        #endregion
    }
}
