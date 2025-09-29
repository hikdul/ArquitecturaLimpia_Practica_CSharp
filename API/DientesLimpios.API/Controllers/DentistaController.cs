using DientesLimpios.API.DTOs;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.BorrarDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearDentista;
using DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.EditarDentista;
using DientesLimpios.Aplicacion.Consultas.ObtenerDetallesDentista;
using DientesLimpios.Aplicacion.Consultas.ObtenerListadoDentista;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [ApiController]
    [Route("api/Consultorios")]
    public class DentistaController : ControllerBase
    {
        private readonly IMediator mediator;

        public DentistaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<DentistaDetalle_out>> Detalles(Guid Id)
        {
            var consulta = new ConsultaObtenerDetalleDentista { Id = Id };
            var result = await mediator.Send(consulta);
            return result;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dentista_out>>> Listar(Guid Id)
        {
            var consulta = new ConsultaObtenerListadoDentistas();
            var result = await mediator.Send(consulta);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Crear(Dentista_in ins)
        {
            var comando = new ComandoCrearDentista { Nombre = ins.Nombre, Email = ins.Email };
            await mediator.Send(comando);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(Guid id, Dentista_up ins)
        {
            var comando = new ComandoEditarDentista
            {
                Id = id,
                Nombre = ins.Nombre,
                Email = ins.Email,
            };
            await mediator.Send(comando);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Borrar(Guid id)
        {
            var command = new ComandoBorrarDentista { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
