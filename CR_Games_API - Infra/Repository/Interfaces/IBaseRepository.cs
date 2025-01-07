using CR_Games_API___Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Games_API___Infra.Repoitory.Interfaces
{
    public interface IBaseRepository<TDomain> where TDomain : BaseDomain
    {
    }
}
