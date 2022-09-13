using SISPUN.Api.BusinessLogic.Models.RequestDTO;
using SISPUN.Api.BusinessLogic.Models.ResponseDTO;
using SISPUN.Api.DataAccess.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SISPUN.Api.Aplication.Mappers
{
       public static class PersonaMapper
    {
        public static PersonaEntity Map(PersonaRequest model)
        {
            return new PersonaEntity()
            {
                COD_PER = model.COD_PER,
                NOMBRES = model.NOMBRES,
                APELLIDOS = model.APELLIDOS
            };
        }
        public static PersonaResponse Map(PersonaEntity dto)
        {
            return new PersonaResponse()
            {
                COD_PER = dto.COD_PER,
                NOMBRES = dto.NOMBRES,
                APELLIDOS = dto.APELLIDOS
            };

        }
      
    }
}
