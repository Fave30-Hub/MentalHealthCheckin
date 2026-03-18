using MentalHealthCheckin.Application.DTOs;
using MentalHealthCheckin.Application.Interfaces;
using MentalHealthCheckin.Domain.Entities;
using MentalHealthCheckin.Domain.Enums;
using MentalHealthCheckin.Domain.Interfaces;
using MentalHealthCheckin.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MentalHealthCheckin.Application.Services
{
    public class CheckInService : ICheckInService
    {
        private readonly ICheckInRepository _repository;

        public CheckInService(ICheckInRepository repository)
        {
            _repository = repository;
        }

        public CheckInDto CreateCheckIn(CreateCheckInRequest request)
        {
            var mood = (MoodLevel)request.Mood;
            var score = new MoodScore(request.Score);
            var comment = request.Comment != null ? new Comment(request.Comment) : null;

            var checkIn = new CheckIn(
                request.EmployeeId,
                mood,
                score,
                comment
            );

            _repository.Add(checkIn);

            return MapToDto(checkIn);
        }

        public IEnumerable<CheckInDto> GetByEmployee(string employeeId)
        {
            var data = _repository.GetByEmployee(employeeId);
            return data.Select(MapToDto);
        }

        public CheckInDto? GetById(Guid id)
        {
            var checkIn = _repository.GetById(id);
            return checkIn == null ? null : MapToDto(checkIn);
        }

        public IEnumerable<CheckInDto> GetAll()
        {
            var data = _repository.GetAll();
            return data.Select(MapToDto);
        }

        private CheckInDto MapToDto(CheckIn checkIn)
        {
            return new CheckInDto
            {
                Id = checkIn.Id,
                EmployeeId = checkIn.EmployeeId,
                Date = checkIn.Date,
                Mood = (int)checkIn.Mood,
                Score = checkIn.Score.Score,
                Comment = checkIn.Comment?.Value
            };
        }
    }
}
