using System;
using System.Collections.Generic;
using System.Text;

using MentalHealthCheckin.Domain.Enums;
using MentalHealthCheckin.Domain.ValueObjects;

namespace MentalHealthCheckin.Domain.Entities
{
    public class CheckIn
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        //public Guid EmployeeId { get; private set; }
        public string EmployeeId { get; set; } = string.Empty;
        public DateTime Date { get; private set; } = DateTime.UtcNow;

        public MoodLevel Mood { get; private set; }
        public MoodScore Score { get; private set; }
        public Comment? Comment { get; private set; }

        public CheckIn(string employeeId, MoodLevel mood, MoodScore score, Comment? comment = null)
        {
            EmployeeId = employeeId;
            Mood = mood;
            Score = score;
            Comment = comment;
        }

        public void UpdateCheckIn(MoodLevel mood, MoodScore score, Comment? comment = null)
        {
            Mood = mood;
            Score = score;
            if (comment != null)
                Comment = comment;
        }
    }
}
