using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CalculadoraJuros.Domain.Classes
{
    public class ErrorModel
    {
        public ErrorModel(string[] messages)
        {
            Messages = messages;
        }
        public ErrorModel(ModelStateDictionary.ValueEnumerable errors)
        {
            var message = errors.Where(x => x.ValidationState == ModelValidationState.Invalid).Select(x => x.Errors[0].ErrorMessage).ToArray();
            Messages = message;
        }

        public string[] Messages { get; set; }

    }
}
