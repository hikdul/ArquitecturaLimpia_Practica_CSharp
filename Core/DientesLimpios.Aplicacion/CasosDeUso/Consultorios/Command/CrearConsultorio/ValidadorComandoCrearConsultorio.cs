using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearConsultorio
{
    public class ValidadorComandoCrearConsultorio : AbstracValidator<CommandCrearConsultorio>
    {
        public ValidadorComandoCrearConsultorio()
        {
            RuleFor(p => p.Nombre).NotEmpty().WihtMessage("El campo {propertyName} es requerido");
        }
    }
}
