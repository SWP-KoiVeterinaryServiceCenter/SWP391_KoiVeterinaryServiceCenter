using Application.IService.Abstraction;
using Application.Model.WorkingScheduleModel;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class WorkingScheduleController : BaseController
    {
        private readonly IWorkingScheduleService _workingScheduleService;

        public WorkingScheduleController(IWorkingScheduleService workingScheduleService)
        {
            _workingScheduleService = workingScheduleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _workingScheduleService.GetAllAsync();
            return Ok(schedules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var schedule = await _workingScheduleService.GetByIdAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return Ok(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWorkingScheduleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdSchedule = await _workingScheduleService.CreateAsync(request);
            if (createdSchedule == null)
            {
                return BadRequest("Failed to create the working schedule.");
            }
            return CreatedAtAction(nameof(GetById), new { id = createdSchedule.Id }, createdSchedule);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateWorkingScheduleRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingSchedule = await _workingScheduleService.GetByIdAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }

            await _workingScheduleService.UpdateAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingSchedule = await _workingScheduleService.GetByIdAsync(id);
            if (existingSchedule == null)
            {
                return NotFound();
            }
            await _workingScheduleService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetAllByAccountId(Guid accountId)
        {
            var schedules = await _workingScheduleService.GetAllByAccountIdAsync(accountId);
            return Ok(schedules);
        }
    }
}
