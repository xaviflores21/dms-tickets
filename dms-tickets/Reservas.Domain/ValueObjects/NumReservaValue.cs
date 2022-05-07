using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.ValueObjects
{
    public record NumReservaValue : ValueObject
    {
        public string Value { get; }

        public NumReservaValue(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            //TODO: validar el formato del numero
            Value = value;
        }

        public static implicit operator string(NumReservaValue value)
        {
            return value.Value;
        }

        public static implicit operator NumReservaValue(string value)
        {
            return new NumReservaValue(value);
        }

    }
}
