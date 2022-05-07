using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.ValueObjects
{

    public record PA_Vuelo_Key
    {
        public String Nombre { get; }
        public String Value { get; }
        public PrecioValue Precio { get; private set; }
        public PA_Vuelo_Key(string value)
        {
            if (value != string.Empty)
            {
                throw new BussinessRuleValidationException("Price value cannot be negative");
            }
            Value = value;
        }

        public static implicit operator string(PA_Vuelo_Key value)
        {
            return value.Value;
        }

        public static implicit operator PA_Vuelo_Key(string value)
        {
            return new PA_Vuelo_Key(value);
        }



    }
}
