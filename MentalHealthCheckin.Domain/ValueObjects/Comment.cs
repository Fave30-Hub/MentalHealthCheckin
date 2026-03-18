using System;
using System.Collections.Generic;
using System.Text;

namespace MentalHealthCheckin.Domain.ValueObjects
{
    public class Comment
    {
        public string Value { get; }

        public Comment(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Comment cannot be empty.");
            if (value.Length > 500)
                throw new ArgumentException("Comment cannot exceed 500 characters.");
            Value = value;
        }
        public override bool Equals(object? obj)
            => obj is Comment other && Value == other.Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
