using Microsoft.AspNetCore.Mvc;
using MentalHealthCheckin.Application.DTOs;
using MentalHealthCheckin.Application.Interfaces;
using System;
using System.Collections.Generic;

namespace MentalHealthCheckin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly ICheckInService _checkInService;

        public CheckInController(ICheckInService checkInService)
        {
            _checkInService = checkInService;
        }

        /// check-in
        [HttpPost]
        public ActionResult<CheckInDto> Create([FromBody] CreateCheckInRequest request)
        {
            try
            {
                var result = _checkInService.CreateCheckIn(request);
                return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// check-in by Id
        [HttpGet("{id}")]
        public ActionResult<CheckInDto> GetById(Guid id)
        {
            var result = _checkInService.GetById(id);
            if (result == null)
                return NotFound(new { message = "Check-in not found" });

            return Ok(result);
        }

        /// all check-ins for a specific employee
        [HttpGet("employee/{employeeId}")]
        public ActionResult<IEnumerable<CheckInDto>> GetByEmployee(string employeeId)
        {
            var result = _checkInService.GetByEmployee(employeeId);
            return Ok(result);
        }

        /// all check-ins
        [HttpGet]
        public ActionResult<IEnumerable<CheckInDto>> GetAll()
        {
            var result = _checkInService.GetAll();
            return Ok(result);
        }
    }
}