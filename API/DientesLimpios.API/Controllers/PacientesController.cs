using DientesLimpios.API.DTOs;
using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.CrearPaciente;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IMediator mediator;

        public PacientesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Paciente_in ins)
        {
            var command = new ComandoCrearPaciente { Nombre = ins.Nombre, Email = ins.Email };
            await mediator.Send(command);
            //return CreatedAtAction(nameof(CrearPaciente), new { id = resultado }, null);
            return Ok();
        }
    }
}
