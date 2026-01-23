using architecture.Domain.Entities;
using architecture.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;

namespace architecture.Application.Services
{
    public class UserRegistrationService
    {
        public User Register(string name, Email email)
        {
            return new User(Guid.NewGuid(), name, email);
        }
    }
}