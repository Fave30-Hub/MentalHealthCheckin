using MentalHealthCheckin.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MentalHealthCheckin.Application.Interfaces
{
    public interface ICheckInService
    {
        CheckInDto CreateCheckIn(CreateCheckInRequest request);
        CheckInDto? GetById(Guid id);
        IEnumerable<CheckInDto> GetByEmployee(string employeeId);

        IEnumerable<CheckInDto> GetAll();
    }
}
