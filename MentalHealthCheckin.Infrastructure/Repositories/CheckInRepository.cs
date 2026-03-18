using MentalHealthCheckin.Domain.Entities;
using MentalHealthCheckin.Domain.Interfaces;
using MentalHealthCheckin.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MentalHealthCheckin.Infrastructure.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private readonly AppDbContext _context;

        public CheckInRepository(AppDbContext context)
        {
            _context = context;
        }

        public CheckIn? GetById(Guid id)
        {
            return _context.CheckIns.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<CheckIn> GetByEmployee(string employeeId)
        {
            return _context.CheckIns
                .Where(x => x.EmployeeId == employeeId)
                .ToList();
        }

        public void Add(CheckIn checkIn)
        {
            _context.CheckIns.Add(checkIn);
            _context.SaveChanges();
        }

        public void Update(CheckIn checkIn)
        {
            _context.CheckIns.Update(checkIn);
            _context.SaveChanges();
        }

        public void Delete(CheckIn checkIn)
        {
            _context.CheckIns.Remove(checkIn);
            _context.SaveChanges();
        }

        public IEnumerable<CheckIn> GetAll()
        {
            return _context.CheckIns.OrderByDescending(c => c.Date).ToList();
        }
    }
}
