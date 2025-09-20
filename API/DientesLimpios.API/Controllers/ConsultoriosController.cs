using DientesLimpios.API.DTOs;
using DientesLimpios.Aplicacion.Consultas.ObtenerDetallesConsultorio;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [APIController]
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
            var consulta = new ConsultarConsultorioPorId { Id = id };

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
        public async Task<ActionResult> Post(Consultorio_in _in)
        {
            var comando = new CrearConsultorio { Nombre = _in.Nombre };

            var resultado = await mediator.Send(comando);

            return Ok();

            //return resultado.EsExitoso ? Ok(resultado.Valor) : BadRequest(resultado.Error);
        }
    }
}
