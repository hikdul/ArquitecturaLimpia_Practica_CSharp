using System;
using System.Security.Principal;
using DientesLimpios.Dominio.Enums;
using DientesLimpios.Dominio.Excepciones;
using DientesLimpios.Dominio.ObjetosDeValor;

namespace DientesLimpios.Dominio.Entidades
{
    public class Cita
    {
        public Guid Id { get; private set; }
        public Guid PacienteId { get; private set; }
        public Guid DentistaId { get; private set; }
        public Guid ConsultorioId { get; private set; }
        public EstadoCita Estado { get; private set; }
        public IntervaloDeTiempo IntervaloDeTiempo { get; private set; }

        //?: props nav
        public Paciente? Paciente { get; private set; }
        public Dentista? Dentista { get; private set; }
        public Consultorio? Consultorio { get; private set; }

        public Cita(
            Guid pacienteid,
            Guid dentistaid,
            Guid consultorioid,
            IntervaloDeTiempo intervaloDeTiempo
        )
        {
            if (intervaloDeTiempo.Inicio < DateTime.UtcNow)
            {
                throw new EXcepcionDeReglaDeNegocio($"Esta fecha ya paso");
            }

            Id = Guid.CreateVersion7();
            this.Estado = EstadoCita.Programada;
            this.PacienteId = pacienteid;
            this.ConsultorioId = consultorioid;
            this.DentistaId = dentistaid;
            this.IntervaloDeTiempo = intervaloDeTiempo;
        }

        //?: para modificar elemneto solo se hacen desde esta misma clase, para que de este modo se cumplan las reglas del negocio

        public void Cacelar()
        {
            if (this.Estado != EstadoCita.Programada)
            {
                throw new EXcepcionDeReglaDeNegocio("Solo se cancelan las citas programadas");
            }
            this.Estado = EstadoCita.Cancelada;
        }

        public void Completar()
        {
            if (this.Estado != EstadoCita.Programada)
            {
                throw new EXcepcionDeReglaDeNegocio("Solo se Completan las citas programadas");
            }
            this.Estado = EstadoCita.Completada;
        }
    }
}
