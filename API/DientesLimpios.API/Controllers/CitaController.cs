using DientesLimpios.API.DTOs;
using DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Actualizar;
using DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Borrar;
using DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Crear;
using DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerDetallePorID;
using DientesLimpios.Aplicacion.CasosDeUso.Cita.Consulta.ObtenerListado;
using DientesLimpios.Aplicacion.Utilidades.Mediador;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DientesLimpios.API.Controllers
{
    [ApiController]
    [Route("api/Consultorios")]
    public class CitaController: ControllerBase
    {
        private readonly IMediator mediator;

        public CitaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(Guid id)
        {
            var consulta = new ConsultaObtengeCitaPorID { Id = id };
            var resultado = await mediator.Send(consulta);
            return Ok(resultado);
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var consulta = new ConsultaObtenerListado();
            var result = await mediator.Send(consulta);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cita_in ins)
        {
            var command = new ComandoCrearCita
            {
                PacienteId = ins.PacienteId,
                ConsultorioId = ins.ConsultorioId,
                Inicio = ins.Inicio,
                Fin = ins.Fin,
                DentistaId = ins.DentistaId,
            };
            var result = await mediator.Send(command);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Cita_in ins)
        {
            var command = new ComandoActualizarCita
            {
                Id = id,
                PacienteId = ins.PacienteId,
                ConsultorioId = ins.ConsultorioId,
                Inicio = ins.Inicio,
                Fin = ins.Fin,
                DentistaId = ins.DentistaId,
            };

            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var comando = new ComandoBorrarCita { Id = Id };
            await mediator.Send(comando);
            return NoContent();
        }
    }
}
