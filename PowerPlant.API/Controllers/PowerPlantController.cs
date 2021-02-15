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
                return Ok(from dto in dtos select (dto.Name, dto.Power));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
