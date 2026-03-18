using System;
using System.Collections.Generic;
using MentalHealthCheckin.Domain.Entities;

namespace MentalHealthCheckin.Domain.Interfaces
{
    public interface ICheckInRepository
    {
        CheckIn? GetById(Guid id);
        IEnumerable<CheckIn> GetByEmployee(string employeeId);
        void Add(CheckIn checkIn);
        void Update(CheckIn checkIn);
        void Delete(CheckIn checkIn);
        IEnumerable<CheckIn> GetAll();
    }
}