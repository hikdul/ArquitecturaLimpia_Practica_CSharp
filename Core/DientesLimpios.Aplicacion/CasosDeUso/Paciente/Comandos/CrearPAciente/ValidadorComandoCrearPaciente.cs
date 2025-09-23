using System;
using FluentValidation;

namespace DientesLimpios.Aplicacion.CasosDeUso.Paciente.Comandos.CrearPaciente
{
    public class ValidadorComandoCrearPaciente : AbstractValidator<ComandoCrearPaciente>
    {
        public ValidadorComandoCrearPaciente()
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
