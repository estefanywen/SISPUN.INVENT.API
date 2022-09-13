using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.DataAccess.Interface.Repositories.Actions
{
    public interface IReadRepository<T, Y> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Y id);
    }
}
