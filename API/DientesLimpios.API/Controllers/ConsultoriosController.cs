using DientesLimpios.API.DTOs;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.BorrarConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Consultas.ObtenerListadoConsultorios;
using DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [ApiController]
    [Route("api/Consultorios")]
    public class ConsultoriosController : ControllerBase
    {
        private readonly IMediator mediator;

        public ConsultoriosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Abtiene el listado de consultorios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ConsultorioListadoDTO>>> Get()
        {
            var consulta = new ConsultaObtenerListadoConsultorios();
            var resultado = await mediator.Send(consulta);
            return resultado;
        }

        /// <summary>
        /// Obtiene el id del consultorio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultarioDetalleDTO>> Get(Guid id)
        {
            var consulta = new ConsultaObtenerDetalleConsultorio { Id = id };

            var resultado = await mediator.Send(consulta);

            return resultado;

            //return resultado.EsExitoso ? Ok(resultado.Valor) : NotFound();
        }

        /// <summary>
        /// Crea un nuevo consultorio
        /// </summary>
        /// <param name="_in"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Consultorio_in _in)
        {
            var comando = new CommandCrearConsultorio { Nombre = _in.Nombre };

            await mediator.Send(comando);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Consultorio_up up)
        {
            var comando = new ComandoActualizarConsultorio { Id = id, Nombre = up.Nombre };
            await mediator.Send(comando);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var comando = new ComandoBorrarConsultorio { Id = id };
            await mediator.Send(comando);
            return NoContent();
        }
    }
}
