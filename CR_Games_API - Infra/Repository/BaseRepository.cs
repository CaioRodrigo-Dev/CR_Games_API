using CR_Games_API___Domain.Entities.Base;
using CR_Games_API___Infra.DBContext;
using CR_Games_API___Infra.Repoitory.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<TDomain> Find(Expression<Func<TDomain, bool>> whereByExpression) =>
            await _dbContext.Set<TDomain>().Where(whereByExpression).Where(x => x.DeletedAt == null).FirstOrDefaultAsync();
        public async Task Insert(TDomain entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TDomain entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(TDomain entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
