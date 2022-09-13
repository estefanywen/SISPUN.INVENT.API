using SISPUN.Api.Aplication.Interface.Services;
using SISPUN.Api.Aplication.Mappers;
using SISPUN.Api.BusinessLogic.Models.RequestDTO;
using SISPUN.Api.BusinessLogic.Models.ResponseDTO;
using SISPUN.Api.DataAccess.Interface.UniOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SISPUN.Api.Aplication.Services
{
    public  class PersonaService: IPersonaService
    {
        private readonly ISISPUNUnitOfWorkAsisPer _asisPerUnitOfWorkAsisPer;

        public PersonaService(ISISPUNUnitOfWorkAsisPer asisPerUnitOfWorkAsisPer)
        {
            _asisPerUnitOfWorkAsisPer = asisPerUnitOfWorkAsisPer;
        }

        public async Task<IEnumerable<PersonaResponse>> ObtenerPersona(PersonaRequest model)
        {
            var result = await _asisPerUnitOfWorkAsisPer.ObtenerPersona(PersonaMapper.Map(model));
            return result.Select(PersonaMapper.Map);
        }
    }
}
