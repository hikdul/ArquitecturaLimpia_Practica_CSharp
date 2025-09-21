using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.ActualizarConsultorios
{
    public class ValidadorComandoActualizarConsultorio: AbstractValidator<ComandoActualizarConsultorio>
    {
        public ValidadorComandoActualizarConsultorio()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty()
                .WithMessage("El campo nombre es requerido")
                .MaximumLength(150)
                .WithMessage("El nombre del consultorio no puede exceder los 150 caracteres.");
        }
    }
}
