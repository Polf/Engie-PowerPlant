using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PowerPlant.API.Dtos;
using PowerPlant.API.Services;


namespace PowerPlant.API.Controllers
{
    [ApiController]
    public class PowerPlantController : ControllerBase
    {

        private readonly IPowerPlantService _service;

        public PowerPlantController(IPowerPlantService service)
        {
            _service = service;
        }
        
        [HttpPost]
        [Route("productionplan")]
        public  IActionResult ProductionPlan(PayLoadDto payload)
        {
            try
            {
                var dtos = _service.Compute(payload);
                var responses = (from dto in dtos select new { name = dto.Name, p = dto.Power}).ToArray();
                return Ok(responses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
