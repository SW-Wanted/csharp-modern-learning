using System;
using System.Collections.Generic;
using System.Text;

namespace architecture.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }

        public User(Guid id, string name, Email email)
        {
            Id = id;
            ChangeName(name);
            Email = email;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("Nome inálido.");

            Name = name;
        }
    }
}
