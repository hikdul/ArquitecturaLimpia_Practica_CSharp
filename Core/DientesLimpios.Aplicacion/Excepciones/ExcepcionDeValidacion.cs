using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace DientesLimpios.Aplicacion.Excepcion
{
    public class ExcepcionDeValidacion : Exception
    {
        public List<string> ErroresDeValidacion { get; set; } = [];

        public ExcepcionDeValidacion(string errorMessage)
        {
            ErroresDeValidacion.Add(errorMessage);
        }

        public ExcepcionDeValidacion(ValidationResult validationResult)
        {
            foreach (var err in validationResult.Errors)
            {
                ErroresDeValidacion.Add(err.ErrorMessage);
            }
        }
    }
}
