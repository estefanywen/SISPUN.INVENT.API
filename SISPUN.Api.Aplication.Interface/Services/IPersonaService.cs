using SISPUN.Api.BusinessLogic.Models.RequestDTO;
using SISPUN.Api.BusinessLogic.Models.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.Aplication.Interface.Services
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaResponse>> ObtenerPersona(PersonaRequest model);

    }
}
