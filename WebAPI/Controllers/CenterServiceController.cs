using Application.IService.Abstraction;
using Application.Model.KoiServiceModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
 
    public class CenterServiceController : BaseController
    {
        private readonly ICenterServiceService _centerServiceService;
        public CenterServiceController(ICenterServiceService centerServiceService)
        {
            _centerServiceService = centerServiceService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCenterService(CreateServiceModel createServiceModel)
        {
            var isCreated = await _centerServiceService.CreateCenterServiceAysnc(createServiceModel);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllService()
        {
            var listCenterService = await _centerServiceService.GetAllService();
            return Ok(listCenterService);
        }
    }
}
