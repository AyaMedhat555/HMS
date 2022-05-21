using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
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

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] PatientDto dto)
        {
            return Ok(await PatientService.AddPatient(dto));
        }

        [HttpPost("AddPatientReport")]
        public async Task<IActionResult> AddPatientReport([FromBody] ReportEntry ReportEntry)
        {
            return Ok( PatientReportService.AddPatientReport(ReportEntry));
        }

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

        [HttpGet("getAllPatients")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await PatientService.GetAllPatients());
        }

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
        
        [HttpPost("ReservePatient")]
        public async Task<IActionResult> ReserveRoom([FromBody] ReservePatientDto ReservePatientDto)
        {
            await IndoorPatientService.ReservePatient(ReservePatientDto);
            int Patient_Id = ReservePatientDto.PatientId;
            return Ok($"Patient With Id {Patient_Id} has been Reserved");
        }

        [HttpGet("GetInDoorPatients/{DepartmentId}")]
        public async Task<IActionResult> GetInDoorPatients([FromRoute]  int DepartmentId)
        {
            return Ok(await IndoorPatientService.GetInDoorPatientsByDept(DepartmentId));
        }


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
    }
}
