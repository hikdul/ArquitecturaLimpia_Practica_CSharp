using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio
{
    public class ValidadorComandoCrearConsultorio : AbstractValidator<CommandCrearConsultorio>
    {
        public ValidadorComandoCrearConsultorio()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty()
                .WithMessage("El campo {propertyName} es requerido")
                .MaximumLength(150)
                .WithMessage("El nombre del consultorio no puede exceder los 150 caracteres.");
        }
    }
}
