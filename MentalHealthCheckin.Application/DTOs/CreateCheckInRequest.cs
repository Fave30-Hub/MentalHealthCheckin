using System;
using System.Collections.Generic;
using System.Text;

namespace MentalHealthCheckin.Application.DTOs
{
    public class CreateCheckInRequest
    {
        public string EmployeeId { get; set; } = string.Empty;
        public int Mood { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
