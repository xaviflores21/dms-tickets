using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Domain.ValueObjects
{
    public record NumeroVenta : ValueObject
    {
        public string Value { get; }

        public NumeroVenta(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            //TODO: validar el formato del numero
            Value = value;
        }


        public static implicit operator string(NumeroVenta value)
        {
            return value.Value;
        }

        public static implicit operator NumeroVenta(string value)
        {
            return new NumeroVenta(value);
        }



    }
}
