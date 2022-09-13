using Microsoft.AspNetCore.Mvc;
using SISPUN.Api.Aplication.Interface.Services;
using SISPUN.Api.BusinessLogic.Models.RequestDTO;

namespace SISPUN.ASISPER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;  
        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService; 
        }
        [HttpPost]
        [Route("ObtenerPersona")]
        [Produces("application/json")]
        public async Task<IActionResult> ObtenerPersona([FromBody] PersonaRequest viewModel)
        {
            var resultList = await _personaService.ObtenerPersona(viewModel);
            return Ok(resultList);
        } 

    }
}
