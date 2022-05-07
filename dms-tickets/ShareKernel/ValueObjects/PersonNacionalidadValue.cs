using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record PersonNacionalidadValue : ValueObject
    {
        public string Nacionalidad { get; }

        public PersonNacionalidadValue(string nac)
        {
            CheckRule(new StringNotNullOrEmptyRule(nac));
            if(nac.Length > 10)
            {
                throw new BussinessRuleValidationException("PersonNacionalidad can't be more than 30 characters");
            }
            Nacionalidad = nac;
        }

        public static implicit operator string(PersonNacionalidadValue value)
        {
            return value.Nacionalidad;
        }

        public static implicit operator PersonNacionalidadValue(string nac)
        {
            return new PersonNacionalidadValue(nac);
        }
    }
}
