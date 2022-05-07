using ShareKernel.Core;
using ShareKernel.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareKernel.ValueObjects
{
    public record PersonCIValue : ValueObject
    {
        public string CI { get; }

        public PersonCIValue(string ci)
        {
            CheckRule(new StringNotNullOrEmptyRule(ci));
            if(ci.Length > 10)
            {
                throw new BussinessRuleValidationException("PersonCI can't be more than 10 characters");
            }
            CI = ci;
        }

        public static implicit operator string(PersonCIValue value)
        {
            return value.CI;
        }

        public static implicit operator PersonCIValue(string ci)
        {
            return new PersonCIValue(ci);
        }
    }
}
