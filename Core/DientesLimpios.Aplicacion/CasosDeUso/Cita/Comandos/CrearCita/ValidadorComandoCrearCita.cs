using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Cita.Comando.Crear
{
    public class ValidadorComandoCrearCita : AbstractValidator<ComandoCrearCita>
    {
        public ValidadorComandoCrearCita()
        {
            RuleFor(c => c.Inicio)
                .GreaterThan(x => x.Fin)
                .WithMessage("La fecha de inicio debe ser mayor a la fecha de fin")
                .GreaterThan(DateTime.Now)
                .WithMessage("La fecha de inicio debe ser mayor a la fecha actual");
            RuleFor(c => c.PacienteId).NotEmpty();
            RuleFor(c => c.ConsultorioId).NotEmpty();
            RuleFor(c => c.DentistaId).NotEmpty();
        }
    }
}
