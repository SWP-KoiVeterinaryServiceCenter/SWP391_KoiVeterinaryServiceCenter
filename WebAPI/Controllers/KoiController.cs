using Application.Model.KoiModel;
using AutoMapper;
using MassTransit.JobService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KoiController : BaseController
    {
        private readonly IKoiService _koiService;

        public KoiController(IKoiService koiService)
        {
            _koiService = koiService;
        }

        // API để tạo mới Koi
        [HttpPost]
        public async Task<IActionResult> CreateKoi(CreateKoi model)
        {
            bool isCreated = await _koiService.CreateKoiAsync(model);
            if (isCreated)
            {
                return Ok();
            }
            return BadRequest();
        }

        // API để cập nhật Koi
        [HttpPut]
        public async Task<IActionResult> UpdateKoi(UpdateKoi model)
        {
            bool isUpdated = await _koiService.UpdateKoiAsync();
            if (isUpdated)
            {
                return Ok();
            }
            return BadRequest();
        }

        // API để lấy danh sách các Koi hiện có
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllKoi()
        {
            var koiList = await _koiService.GetAllKoiAsync();
            if (koiList == null)
            {
                return BadRequest();
            }
            return Ok(koiList);
        }

        // API để lấy thông tin chi tiết của một con Koi
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetKoi()
        {
            var koi = await _koiService.GetKoiByIdAsync();
            if (koi == null)
            {
                return NotFound();
            }
            return Ok(koi);
        }
    }
}
