using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Consultorios.Command.CrearDentista
{
    public class ValidadorComandoCrearDentista : AbstractValidator<ComandoCrearDentista>
    {
        public ValidadorComandoCrearDentista()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("El nombre es obligatorio")
                .MaximumLength(250)
                .WithMessage("El nombre no puede tener más de 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("El email es obligatorio")
                .EmailAddress()
                .WithMessage("El email no es válido")
                .MaximumLength(250)
                .WithMessage("El email no puede tener más de 100 caracteres");
        }
    }
}
