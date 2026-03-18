using System;
using System.Collections.Generic;
using System.Text;

namespace MentalHealthCheckin.Application.DTOs
{
    public class CheckInDto
    {
        public Guid Id { get; set; }
        //public Guid EmployeeId { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int Mood { get; set; }
        public int Score { get; set; }
        public string? Comment { get; set; }
    }
}
