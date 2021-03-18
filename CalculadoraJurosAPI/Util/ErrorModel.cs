using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace CalculadoraJuros.Domain.Classes
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel'
    public class ErrorModel
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel.ErrorModel(string[])'
        public ErrorModel(string[] messages)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel.ErrorModel(string[])'
        {
            Messages = messages;
        }
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel.ErrorModel(ModelStateDictionary.ValueEnumerable)'
        public ErrorModel(ModelStateDictionary.ValueEnumerable errors)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel.ErrorModel(ModelStateDictionary.ValueEnumerable)'
        {
            var message = errors.Where(x => x.ValidationState == ModelValidationState.Invalid).Select(x => x.Errors[0].ErrorMessage).ToArray();
            Messages = message;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel.Messages'
        public string[] Messages { get; set; }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ErrorModel.Messages'

    }
}
