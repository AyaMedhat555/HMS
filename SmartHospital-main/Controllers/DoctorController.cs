using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private IDoctorService DoctorService { get; }

        public DoctorController(IDoctorService _DoctorService)
        {
            DoctorService = _DoctorService;

        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDto dto)
        {
            return Ok(await DoctorService.AddDoctor(dto));
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetUserById([FromRoute] int id)
        //{
        //    DoctorDto user = await DoctorService.GetDoctorById(id);
        //    if (user != null)
        //    {
        //        return Ok(user);
        //    }
        //    return Ok("User not found!");

        //}

        [HttpGet("getAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await DoctorService.GetAllDoctors());
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(DoctorDto userDto)
        {
            return Ok(await DoctorService.UpdateDoctor(userDto));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await DoctorService.DeleteDoctor(id));
        }

        [HttpPost("AddPrescription")]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDto dto)
        {
            return Ok(await DoctorService.AddPrescription(dto));
        }


        [HttpGet("GetDoctorPrescriptions/{id}")]
        public async Task<IActionResult> GetDoctorPrescriptions([FromRoute] int id)
        {
            return Ok(await DoctorService.GetAllPrescriptionsByDoctorId(id));
        }

        [HttpGet("GetDoctorPrescriptionsForAll")]
        public async Task<IActionResult> GetDoctorPrescriptionsForAll()
        {
            return Ok(await DoctorService.GetAllPrescriptionsForALL());
        }

        [HttpGet("GetDoctorPrescriptionsForPatient/{id2}")]
        public async Task<IActionResult> GetDoctorPrescriptionsForPatient([FromRoute] short id2)
        {
            return Ok(await DoctorService.GetAllPrescriptonsForPatient(id2));
        }

        [HttpGet(" GetDoctorPrescriptionsForPatient/{patient_id}/{doctor_id}")]
        public async Task<IActionResult> GetDoctorPrescriptionsForPatient(int patient_id, int doctor_id)
        {
            return Ok(await DoctorService.GetAllDoctorToPatientPrescriptions(patient_id, doctor_id));
        }

        [HttpGet("GetPatientPrescriptionByDate/{patient_id}/{PrescriptionDate}")]
        public async Task<IActionResult> GetPatientPrescriptionByDate(int patient_id, DateTime PrescriptionDate)
        {
            return Ok(await DoctorService.GetPatientPrescriptionByDate(patient_id, PrescriptionDate));
        }

        [HttpGet("GetDoctorPrescriptionsByDate/{Doctor_id}/{PrescriptionDate}")]
        public async Task<IActionResult> GetDoctorPrescriptionsByDate(int Doctor_id, DateTime PrescriptionDate)
        {
            return Ok(await DoctorService.GetDoctorPrescriptionsByDate(Doctor_id, PrescriptionDate));
        }

        [HttpPut("updatePrescription")]
        public async Task<IActionResult> Update(PrescriptionDto PrescriptionDto)
        {
            return Ok(await DoctorService.UpdatePrescription(PrescriptionDto));
        }
    }
      }

