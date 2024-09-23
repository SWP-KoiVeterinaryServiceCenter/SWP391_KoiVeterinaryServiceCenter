using Application.IService.Abstraction;
using Application.Model.KoiServiceModel;
using Application.Model.ServiceTypeModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  
    public class ServiceTypeController : BaseController
    {
        private readonly IServiceTypeService _serviceTypeService;
        public ServiceTypeController(IServiceTypeService serviceTypeService)
        {
            _serviceTypeService = serviceTypeService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateServiceType(CreateServiceTypeModel createServiceTypeModel)
        {
            var isCreated=await _serviceTypeService.CreateServiceTypeAsync(createServiceTypeModel);
            if (!isCreated)
            {
                return BadRequest(new { message = "Create error" });
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllServiceType()
        {
            var serviceTypeList=await _serviceTypeService.GetAllServiceTypeAsync();
            return Ok(serviceTypeList);
        }
    }
}
