using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.BusinessLogic.Models.RequestDTO
{
    public class PersonaRequest
    {
        public string COD_PER { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
    }
}
