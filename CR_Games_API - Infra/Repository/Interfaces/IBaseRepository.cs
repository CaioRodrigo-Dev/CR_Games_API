using CR_Games_API___Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Infra.Repoitory.Interfaces
{
    public interface IBaseRepository<TDomain> where TDomain : BaseDomain
    {
        Task<TDomain> Find(Expression<Func<TDomain, bool>> whereByExpression);
        Task Insert(TDomain entity);
        Task Update(TDomain entity);
        Task Delete(TDomain entity);
        Task<List<TDomain>> GetAllUsers();
        Task<List<TDomain>> FindAll(Expression<Func<TDomain, bool>> whereByExpression);
        Task DeleteAllUsers();
        Task<List<TDomain>> FindAllWithIncludes(Expression<Func<TDomain, bool>> whereByExpression, params Expression<Func<TDomain, object>>[] includes);

    }
}
