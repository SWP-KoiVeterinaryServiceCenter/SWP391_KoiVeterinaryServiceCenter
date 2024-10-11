using Application.IService.Abstraction;
using Application.Model.TankModel;
using Application.Service.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  
    public class TankController : BaseController
    {
        private readonly ICenterTankService _centerTankService;
        public TankController(ICenterTankService centerTankService)
        {
            _centerTankService = centerTankService;
        }
        [Authorize(Roles = "Admin,Staff")]
        [HttpPost]
        public async Task<IActionResult> CreateTank(CreateTankModel model)
        {
            var isCreated=await _centerTankService.CreateTankAsync(model);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest(new {message="Create error"});
        }
        [Authorize(Roles = "Admin,Staff")]
        [HttpGet]
        public async Task<IActionResult> GetAllTank()
        {
            var listTank=await _centerTankService.GetAllTanksAsync();
            return Ok(listTank);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTank(Guid id)
        {
            var isRemoved = await _centerTankService.DeleteTankAsync(id);
            if (isRemoved)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}
