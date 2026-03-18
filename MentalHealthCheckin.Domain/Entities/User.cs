using System;
using System.Collections.Generic;
using System.Text;

namespace MentalHealthCheckin.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public bool IsHR { get; private set; }

        public User(string fullName, string email, bool isHR)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Full name is required.");
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email is required.");

            FullName = fullName;
            Email = email;
            IsHR = isHR;
        }
    }
}
