using MentalHealthCheckin.Application.DTOs;
using MentalHealthCheckin.Application.Services;
using MentalHealthCheckin.Infrastructure.Persistence;
using MentalHealthCheckin.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;

namespace MentalHealthCheckin.Tests
{
    public class CheckInIntegrationTests
    {
        private CheckInService _service;
        private CheckInRepository _repository;
        private AppDbContext _context;

        public CheckInIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;

            _context = new AppDbContext(options);
            _repository = new CheckInRepository(_context);
            _service = new CheckInService(_repository);
        }

        [Fact]
        public void CreateCheckIn_ShouldSaveToDatabase()
        {

            var request = new CreateCheckInRequest
            {
                EmployeeId = "Fave",
                Mood = 3,
                Score = 5,
                Comment = "Feeling happy"
            };

            var result = _service.CreateCheckIn(request);

            Assert.Equal("Fave", result.EmployeeId);
            Assert.Equal(3, result.Mood);
            Assert.Equal(5, result.Score);
            Assert.Equal("Feeling happy", result.Comment);

            var checkInInDb = _context.CheckIns.FirstOrDefault(c => c.EmployeeId == "Fave");
            Assert.NotNull(checkInInDb);
            Assert.Equal(5, checkInInDb.Score.Score);
        }
    }
}