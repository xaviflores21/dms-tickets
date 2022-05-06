using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.ValueObjects
{
    public record NumeroTicket : ValueObject
    {
        public string Value { get; }

        public NumeroTicket(string value)
        {
            CheckRule(new StringNotNullOrEmptyRule(value));
            Value = value;
        }

        public static implicit operator string(NumeroTicket value)
        {
            return value.Value;
        }

        public static implicit operator NumeroTicket(string value)
        {
            return new NumeroTicket(value);
        }


    }
}
