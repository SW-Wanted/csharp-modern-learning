using System;
using System.Collections.Generic;
using System.Text;

namespace architecture.Domain.ValueObjects
{
    public sealed record Email
    {
        public string Value { get; }

        public Email(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException("Email inválido.");
            if (!value.Contains("@"))
                throw new DomainException("Formato de email inválido.");

            Value = value;
        }

        public override string ToString() => Value;
    }
}
