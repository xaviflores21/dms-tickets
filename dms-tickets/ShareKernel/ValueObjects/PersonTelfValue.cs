using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record PersonTelfValue : ValueObject
    {
        public string Telf { get; }

        public PersonTelfValue(string tel)
        {
            CheckRule(new StringNotNullOrEmptyRule(tel));
            if(tel.Length > 10)
            {
                throw new BussinessRuleValidationException("PersonTelefono can't be more than 10 characters");
            }
            Telf = tel;
        }

        public static implicit operator string(PersonTelfValue value)
        {
            return value.Telf;
        }

        public static implicit operator PersonTelfValue(string tel)
        {
            return new PersonTelfValue(tel);
        }
    }
}
