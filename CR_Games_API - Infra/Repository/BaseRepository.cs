using CR_Games_API___Domain.Entities.Base;
using CR_Games_API___Infra.DBContext;
using CR_Games_API___Infra.Repoitory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Infra.Repoitory
{
    public class BaseRepository<TDomain> : IBaseRepository<TDomain> where TDomain : BaseDomain
    {
        #region Fields
        protected readonly ApplicationDbContext _dbContext;
        #endregion

        #region Constructor
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        #endregion

        #region Methods
        #endregion
    }
}
