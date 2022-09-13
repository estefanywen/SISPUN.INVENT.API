using Minedu.Comun.IData;
using SISPUN.Api.DataAccess.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.DataAccess.Interface.UniOfWork
{
    public partial interface ISISPUNUnitOfWorkAsisPer : IBaseUnitOfWork
    {
        Task<IEnumerable<PersonaEntity>> ObtenerPersona(PersonaEntity dto);
    }
}
