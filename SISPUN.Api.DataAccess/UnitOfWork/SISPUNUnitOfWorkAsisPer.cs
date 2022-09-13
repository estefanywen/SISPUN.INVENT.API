using SISPUN.Api.DataAccess.Interface.Entities;
using SISPUN.Api.DataAccess.Interface.UniOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Minedu.Comun.Data;
namespace SISPUN.Api.DataAccess.UnitOfWork
{
    public partial class SISPUNUnitOfWork : ISISPUNUnitOfWorkAsisPer
    {
        public async Task<IEnumerable<PersonaEntity>> ObtenerPersona(PersonaEntity parametros)
        {
            var param = new Parameter[]
            {
                new Parameter("@cod_per" , parametros.COD_PER)
            };

            try
            {
                var result = this.ExecuteReader<PersonaEntity>(
                    "USP_SEL_PERSONAS"
                    , CommandType.StoredProcedure
                    , ref param
                    );

                return result;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
