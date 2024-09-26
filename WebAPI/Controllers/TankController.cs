﻿using Application.IService.Abstraction;
using Application.Model.TankModel;
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
        [HttpGet]
        public async Task<IActionResult> GetAllTank()
        {
            var listTank=await _centerTankService.GetAllTanksAsync();
            return Ok(listTank);
        }
    }
}