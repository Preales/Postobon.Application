using System;
using System.Collections.Generic;

namespace Application.Common.Utility.ExceptionResources
{
    /// <summary>
    ///  Excepción General para las validaciones
    /// </summary>
    public sealed class ExceptionValidation : ArgumentException
    {
        public const string ValidationErrorKey = "ValidationError";

        public ExceptionValidation(List<ValidatorError> validationErrors)
            : base(ValidationErrorKey)
        {
            if (!Data.Contains(ValidationErrorKey))
            {
                var message = string.Empty;
                var array = new List<string>();
                foreach (var item in validationErrors)
                {
                    array.Add(string.Format("{0} {1}", item.Property, item.Message));
                }
                message = string.Join(", ", array);
                Data.Add(ValidationErrorKey, message);
                //Data.Add(ValidationErrorKey, JsonConvert.SerializeObject(validationErrors));
            }

            ValidationErrors = validationErrors;
        }

        /// <summary>
        /// Errores de validacion
        /// </summary>
        public List<ValidatorError> ValidationErrors { get; private set; }
    }

    /// <summary>
    /// Representa errores de validación
    /// </summary>
    public class ValidatorError
    {
        /// <summary>
        /// Mensaje de error
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// propiedad que falla la validación
        /// </summary>
        public string Property { get; set; }
    }
}
