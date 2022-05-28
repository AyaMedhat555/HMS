using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;
using Service.Responses;

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
            Console.WriteLine(dto.ToString());
            //check if username already used
            var user = await DoctorService.GetUserByName(dto.UserName);
            if (user != null)
            {
                return Ok("Username already taken.");
            }
            await DoctorService.AddDoctor(dto);
            return Ok("User: "+dto.UserName+" was added successfully!");
        }

        [HttpGet("getAllDoctors")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await DoctorService.GetAllDoctors());
        }

        [HttpGet("getByState")]
        public async Task<IActionResult> GetByState(bool state)
        {
            return Ok(await DoctorService.GetDoctorsByState(state));
        }

        [HttpGet("getBySpecialization")]
        public async Task<IActionResult> GetBySpecialization(string specialization)
        {
            return Ok(await DoctorService.GetDoctorsBySpecialization(specialization));
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

        [HttpGet("getByName")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            DoctorDto user = await DoctorService.GetDoctorByName(name);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok("User not found!");

        }

        [HttpPost("AddPrescription")]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDto dto)
        {
            return Ok(await DoctorService.AddPrescription(dto));
        }


        [HttpGet("GetDoctorPrescriptions/{DoctorId}")]
        public async Task<IActionResult> GetDoctorPrescriptions([FromRoute] int DoctorId)
        {
            return Ok(await DoctorService.GetAllPrescriptionsByDoctorId(DoctorId));
        }

        [HttpGet("GetDoctorPrescriptionsForAll")]
        public async Task<IActionResult> GetDoctorPrescriptionsForAll()
        {
            return Ok(await DoctorService.GetAllPrescriptionsForALL());
        }

        [HttpGet("GetDoctorPrescriptionsForPatient/{ParientId}")]
        public async Task<IActionResult> GetDoctorPrescriptionsForPatient([FromRoute] short ParientId)
        {
            return Ok(await DoctorService.GetAllPrescriptonsForPatient(ParientId));
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

        

        [HttpGet("GetDoctorsByDepartment_Id/{Department_ID}")]
        public async Task<IActionResult> GetDoctorsByDepartment_Id([FromRoute] int Department_ID)
        {
            return Ok(await DoctorService.GetDoctorsByDepartment_Id(Department_ID));
        }
        
    }
      }

