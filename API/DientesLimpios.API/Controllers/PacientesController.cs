using DientesLimpios.API.DTOs;
using DientesLimpios.API.Utils;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.CrearPaciente;
using DientesLimpios.Aplicacion.CasosDeUso.Paciente.Consultas;
using DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio;
using DientesLimpios.Aplicacion.Utilidades.Common;
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

        [HttpGet]
        public async Task<ActionResult<List<PacienteListadoDTO>>> Get(
            [FromQuery] ConsultaObtenerListadoClientes consulta
        )
        {
            //var consulta = new ConsultaObtenerListadoClientes();
            var result = await mediator.Send(consulta);
            HttpContext.InsertarPaginacionEnCabecera(result.Total);
            return result.Elements;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDetalleDTO>> GetById(Guid id)
        {
            var consulta = new ConsultaObtenerDetallePaciente { Id = id };
            var result = await mediator.Send(consulta);
            return result;
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
