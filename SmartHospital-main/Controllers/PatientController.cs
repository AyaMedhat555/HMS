using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.DTO.Users;
using Service.IServices;
using Service.Responses;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IIndoorPatientService IndoorPatientService { get; }
        private IPatientService PatientService { get; }
        private IPatientReportService PatientReportService { get; }

        public PatientController(IIndoorPatientService _IndoorPatientService, IPatientService _PatientService, IPatientReportService _PatientReportService)
        {
            IndoorPatientService = _IndoorPatientService;
            PatientService = _PatientService;

            PatientReportService = _PatientReportService;


        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto dto)
        {
            Console.WriteLine(dto.ToString());
            //check if username already used
            var user = await PatientService.GetUserByName(dto.UserName);
            if (user != null)
            {
                return Ok("Username already taken.");
            }
            await PatientService.AddPatient(dto);
            return Ok("User: "+dto.UserName+" was added successfully!");
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost("AddPatientReport")]
        public async Task<IActionResult> AddPatientReport([FromBody] ReportEntry ReportEntry)
        {
            return Ok( await PatientReportService.AddPatientReport(ReportEntry));
        }

        [Authorize(Roles = "Patient,Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            PatientDto user = await PatientService.GetPatientById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return Ok("User not found!");

        }

        [Authorize(Roles = "Doctor,Nurse,Receptionist")]
        [HttpGet("getAllPatients")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await PatientService.GetAllPatients());
        }

        [Authorize(Roles = "Patient")]
        [HttpPut("update")]
        public async Task<IActionResult> Update(PatientDto userDto)
        {
            return Ok(await PatientService.UpdatePatient(userDto));
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await PatientService.DeletePatient(id));
        }


        /// <summary>
        /// /////////////////////////////////////BusineesPart///////////////////////////////////////
        /// </summary>

        [Authorize(Roles = "Nurse,Receptionist")]
        [HttpPost("ReservePatient")]
        public async Task<IActionResult> ReserveRoom([FromBody] ReservePatientDto ReservePatientDto)
        {
            await IndoorPatientService.ReservePatient(ReservePatientDto);
            int Patient_Id = ReservePatientDto.PatientId;
            return Ok($"Patient With Id {Patient_Id} has been Reserved");
        }

        [Authorize(Roles = "Doctor,Nurse")]
        [HttpGet("GetInDoorPatients/{DepartmentId}")]
        public async Task<IActionResult> GetInDoorPatients([FromRoute]  int DepartmentId)
        {
            return Ok(await IndoorPatientService.GetInDoorPatientsByDept(DepartmentId));
        }

        [Authorize(Roles = "Doctor,Patient")]
        [HttpGet("GetPatientReport/{PatientId}/{DateOfDischarge}")]
        public async Task<IActionResult> GetPatientReport( int PatientId, DateTime DateOfDischarge )
        {
            return Ok( PatientReportService.GetPatientReport(PatientId, DateOfDischarge));
        }


        [HttpGet("GetScanByRecord/{Record}")]
        public async Task<IActionResult> GetPatientScanByRecordId(int Record)
        {
            return Ok(PatientReportService.GetPatientScan(Record));
        }


        [Authorize(Roles = "Nurse")]
        [HttpGet("GetLastPrescriptionByInDoorId/{InDoorRecord_Id}")]
        public async Task<IActionResult> GetLastPrescriptionByInDoorId(int InDoorRecord_Id)
        {
            return Ok(IndoorPatientService.GetLastPrescriptionByIndoorPatientId(InDoorRecord_Id));
        }


        [HttpGet("GetDischargedDatesByPatientId/{PatientId}")]
        public async Task<IActionResult> GetDischargedDatesByPatientId(int PatientId)
        {
            return Ok(IndoorPatientService.GetDischargeDatesByPatientId(PatientId));
        }

        [Authorize(Roles = "Doctor,Patient")]
        [HttpGet("GetIndoorPatientRecords/{PatientId}")]
        public async Task<IActionResult> GetIndoorPatientRecords(int PatientId)
        {
            return Ok(IndoorPatientService.GetIndoorPatientRecords(PatientId));
        }

        [HttpGet("GetIndoorPatientRecordsByPatientId/{PatientId}")]
        public async Task<IActionResult> GetIndoorPatientRecordsByPatientId(int PatientId)
        {
            return Ok(await IndoorPatientService.GetInDoorRecordsByPatientId(PatientId));
        }

        [HttpGet("GetAllOutPatient")]
        public async Task<IActionResult> GetAllOutPatient()
        {
            return Ok(await PatientService.GetAllOutPatient());
        }

        [HttpGet("GetAllInPatients")]
        public async Task<IActionResult> GetAllInPatients()
        {
            return Ok(await IndoorPatientService.GetInDoorRecords());
        }

        [HttpGet("GetPatientByNationalId/{NationalId}")]
        public async Task<IActionResult> GetPatientByNationalId(string NationalId)
        {
            return Ok(await PatientService.GetPatientByNationalId(NationalId));
        }

        //[HttpGet("getPatientBill/{id}")]
        //public async Task<IActionResult> GetPatientBill([FromRoute] int id)
        //{
        //    BillDto bill = await PatientService.GetPatientBill(id);
        //    if (bill != null)
        //    {
        //        return Ok(bill);
        //    }
        //    return Ok("Bill not found!");
        //}

        }    
}