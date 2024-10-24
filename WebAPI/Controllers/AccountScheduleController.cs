
using Application.IService.Abstraction;
using Application.Model.AccountSchedule;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class AccountScheduleController : BaseController
    {
        private readonly IAccountScheduleService _accountScheduleService;

        public AccountScheduleController(IAccountScheduleService accountScheduleService)
        {
            _accountScheduleService = accountScheduleService;
        }

        [Authorize(Roles = "Staff")]
        [HttpPost]
        public async Task<IActionResult> AddAccountToSchedule([FromBody] AddAccountScheduleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                var response = await _accountScheduleService.AddAccountToScheduleAsync(request);

                return CreatedAtAction(nameof(GetAccountScheduleById),
                    new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{veterinarianId}")]
        public async Task<IActionResult> GetDetailSchedule(Guid veterinarianId)
        {
            try
            {
                var schedules = await _accountScheduleService.GetSchedulesByAccountIdAsync(veterinarianId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountScheduleById(Guid id)
        {
            var result = await _accountScheduleService.GetAccountScheduleByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUserSchedule()
        {
            try
            {
                var response = await _accountScheduleService.GetAccountScheduleByCurrentUserAsync();
                if (response == null)
                {
                    return NotFound("No schedule found for the current user.");
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAccountSchedule(Guid id, [FromBody] UpdateAccountScheduleRequest request)
        {
            try
            {
                var updatedAccountSchedule = await _accountScheduleService.UpdateAccountScheduleAsync(id, request);
                return Ok(updatedAccountSchedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountSchedule(Guid id)
        {
            try
            {
                await _accountScheduleService.DeleteAccountScheduleAsync(id);
                return Ok("Account schedule deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{veterinarianId}")]
        public async Task<IActionResult> GetSchedulesByAccountId(Guid veterinarianId)
        {
            try
            {
                var schedules = await _accountScheduleService.GetSchedulesByAccountIdAsync(veterinarianId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

       /* [HttpGet("{veterinarianId}/{scheduleId}")]
        public async Task<IActionResult> GetAccountScheduleById(Guid veterinarianId, Guid scheduleId)
        {
            var accountSchedule = await _accountScheduleService.GetAccountScheduleByIdAsync(veterinarianId, scheduleId);
            if (accountSchedule == null)
            {
                return NotFound("AccountSchedule not found.");
            }
            return Ok(accountSchedule);
        }

        [HttpPatch("{veterinarianId}/{scheduleId}")]
        public async Task<IActionResult> UpdateAccountSchedule(Guid veterinarianId, Guid scheduleId, [FromBody] UpdateAccountScheduleRequest request)
        {
            try
            {
                await _accountScheduleService.UpdateAccountScheduleAsync(veterinarianId, scheduleId, request);
                return Ok("Account schedule updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/

       /* [HttpDelete("{veterinarianId}/{scheduleId}")]
        public async Task<IActionResult> DeleteAccountSchedule(Guid veterinarianId, Guid scheduleId)
        {
            try
            {
                await _accountScheduleService.DeleteAccountScheduleAsync(veterinarianId, scheduleId);
                return Ok("Account schedule deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/


        [HttpGet("all")]
        public async Task<IActionResult> GetAllAccountSchedules()
        {
            try
            {
                var accountSchedules = await _accountScheduleService.GetAllAccountSchedulesAsync();
                return Ok(accountSchedules);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}


