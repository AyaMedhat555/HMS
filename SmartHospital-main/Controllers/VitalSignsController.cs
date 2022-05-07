using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VitalSignsController : ControllerBase
    {
        private IVitalSignesService VitalSignsService { get; }

        public VitalSignsController(IVitalSignesService _IVitalSignesService)
        {
            VitalSignsService = _IVitalSignesService;
           
        }

        [HttpPost]
        public async Task<IActionResult> AddVitalSignes([FromBody] VitalSignesDto VitalSigns)
        {


            return Ok(await VitalSignsService.AddVitalSignes(VitalSigns));
        }
    }
}
