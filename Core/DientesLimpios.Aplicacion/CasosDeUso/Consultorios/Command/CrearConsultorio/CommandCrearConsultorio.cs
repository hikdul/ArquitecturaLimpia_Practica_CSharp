using System;
using DientesLimpios.Aplicacion.Utilidades.Mediador;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio
{
    public class CommandCrearConsultorio : IRequest<Guid>
    {
        public required string Nombre { get; set; }
    }
}
