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

        //[Authorize(Roles = "Staff")]
        [HttpPost]
        public async Task<IActionResult> AddAccountToSchedule([FromBody] AddAccountScheduleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _accountScheduleService.AddAccountToScheduleAsync(request.AccountId, request.ScheduleId);
                return CreatedAtAction(nameof(GetSchedulesByAccountId), new { accountId = request.AccountId }, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetSchedulesByAccountId(Guid accountId)
        {
            try
            {
                var schedules = await _accountScheduleService.GetSchedulesByAccountIdAsync(accountId);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{accountId}/{scheduleId}")]
        public async Task<IActionResult> GetAccountScheduleById(Guid accountId, Guid scheduleId)
        {
            var accountSchedule = await _accountScheduleService.GetAccountScheduleByIdAsync(accountId, scheduleId);
            if (accountSchedule == null)
            {
                return NotFound("AccountSchedule not found.");
            }
            return Ok(accountSchedule);
        }

        [HttpPatch("{accountId}/{scheduleId}")]
        public async Task<IActionResult> UpdateAccountSchedule(Guid accountId, Guid scheduleId, [FromBody] UpdateAccountScheduleRequest request)
        {
            try
            {
                await _accountScheduleService.UpdateAccountScheduleAsync(accountId, scheduleId, request);
                return Ok("Account schedule updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{accountId}/{scheduleId}")]
        public async Task<IActionResult> DeleteAccountSchedule(Guid accountId, Guid scheduleId)
        {
            try
            {
                await _accountScheduleService.DeleteAccountScheduleAsync(accountId, scheduleId);
                return Ok("Account schedule deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

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