using Minedu.Comun.Data;
using SISPUN.Api.DataAccess.Interface.UniOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.DataAccess.UnitOfWork
{
    public partial class SISPUNUnitOfWork : BaseUnitOfWork, ISISPUNUnitOfWork
    {
        public SISPUNUnitOfWork(IDbContext context) : base(context, true)
        {

        }
    }
}
