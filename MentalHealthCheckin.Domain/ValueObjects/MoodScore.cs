using System;
using System.Collections.Generic;
using System.Text;

namespace MentalHealthCheckin.Domain.ValueObjects
{
    public class MoodScore
    {
        public int Score { get; }

        public MoodScore(int score)
        {
            if (score < 1 || score > 10)
                throw new ArgumentException("Mood score must be between 1 and 10.");
            Score = score;
        }

        public override bool Equals(object? obj)
            => obj is MoodScore other && Score == other.Score;

        public override int GetHashCode() => Score.GetHashCode();
    }
}
