using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.ValueObjects
{
   // internal class Nro_Vuelo
     public record Nro_Pago : ValueObject
    {
        public string Value { get; }

        public Nro_Pago(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            //TODO: validar el formato del numero
            Value = value;
        }


        public static implicit operator string(Nro_Pago value)
        {
            return value.Value;
        }

        public static implicit operator Nro_Pago(string value)
        {
            return new Nro_Pago(value);
        }



    }
}
