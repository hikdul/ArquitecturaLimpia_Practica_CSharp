using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio
{
    public class ValidadorComandoCrearConsultorio :  AbstractValidator<CommandCrearConsultorio>
    {
        public ValidadorComandoCrearConsultorio()
        {
            RuleFor(p => p.Nombre).NotEmpty().WithMessage("El campo {propertyName} es requerido");
        }
    }
}
