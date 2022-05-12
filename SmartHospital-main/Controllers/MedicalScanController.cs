using Domain.Models.Labs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalScanController : ControllerBase
    {
        private IMedicalScanService _medicalScanService { get; }

        public MedicalScanController(IMedicalScanService medicalScanService)
        {
            _medicalScanService=medicalScanService;
        }


        //######################################################################################################
        //TEST

        [HttpPost("add")]
        public async Task<IActionResult> Add(Scan scan)
        {
            Console.WriteLine(scan.ToString());
            //check if username already used
            return Ok(await _medicalScanService.AddScan(scan));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int scan_id)
        {
            Console.WriteLine(scan_id.ToString());
            await _medicalScanService.DeleteScan(scan_id);
            return Ok(await _medicalScanService.DeleteScan(scan_id));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Scan scan)
        {
            Console.WriteLine(scan.ToString());
            return Ok(await _medicalScanService.UpdateScan(scan));
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _medicalScanService.GetAllScans());
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _medicalScanService.GetScanById(id));
        }

        [HttpGet("getByName")]
        public async Task<IActionResult> GetByName(string Scanname)
        {
            return Ok(await _medicalScanService.GetScanByName(Scanname));
        }



        //######################################################################################################
        //LAB REQUEST

        [HttpPost("addScanRequest")]
        public async Task<IActionResult> ScanRequest(ScanRequestDto scanRequest)
        {
            Console.WriteLine(scanRequest.ToString());
            return Ok(await _medicalScanService.AddScanRequest(scanRequest));
        }

        [HttpDelete("deleteScanRequest/{id}")]
        public async Task<IActionResult> DeleteScanRequest([FromRoute] int scanRequest_id)
        {
            Console.WriteLine(scanRequest_id.ToString());
            return Ok(await _medicalScanService.DeleteScanRequest(scanRequest_id));
        }

        [HttpPut("updateScanRequest")]
        public async Task<IActionResult> UpdateScanRequest(ScanRequestDto scanRequest)
        {
            Console.WriteLine(scanRequest.ToString());
            return Ok(await _medicalScanService.UpdateScanRequest(scanRequest));
        }

        [HttpGet("getAllScanRequest")]
        public async Task<IActionResult> GetAllScanRequest()
        {
            return Ok(await _medicalScanService.GetAllScanRequests());
        }

        [HttpGet("getScanRequestById/{id}")]
        public async Task<IActionResult> GetScanRequestById([FromRoute] int id)
        {
            return Ok(await _medicalScanService.GetScanRequestById(id));
        }

        [HttpGet("getScanRequestsByPatientId/{id}")]
        public async Task<IActionResult> GetScanRequestsByPatientId([FromRoute] int id)
        {
            return Ok(await _medicalScanService.GetScanRequestsByPatientId(id));
        }

        [HttpGet("getScanRequestsByDoctorId/{id}")]
        public async Task<IActionResult> GetScanRequestsByDoctorId([FromRoute] int id)
        {
            return Ok(await _medicalScanService.GetScanRequestsByDoctorId(id));
        }

        [HttpGet("GetPatientScanRequestsByDate/{patient_id}/{ScanRequestDate}")]
        public async Task<IActionResult> GetPatientScanRequestsByDate(int patient_id, DateTime ScanRequestDate)
        {
            return Ok(await _medicalScanService.GetPatientScanRequestsByDate(patient_id, ScanRequestDate));
        }

        [HttpGet("GetDoctorScanRequestsByDate/{doctor_id}/{ScanRequestDate}")]
        public async Task<IActionResult> GetDoctorScanRequestsByDate(int doctor_id, DateTime ScanRequestDate)
        {
            return Ok(await _medicalScanService.GetDoctorScanRequestsByDate(doctor_id, ScanRequestDate));
        }

        //######################################################################################################
        //PATIENT TEST

        [HttpPost("addPatientScan")]
        public async Task<IActionResult> PatientScan(PatientScanDto patientScanDto)
        {
            Console.WriteLine(patientScanDto.ToString());
            return Ok(await _medicalScanService.AddPatientScan(patientScanDto));
        }

        [HttpDelete("deletePatientScan/{id}")]
        public async Task<IActionResult> DeletePatientScan([FromRoute] int patientScan_id)
        {
            Console.WriteLine(patientScan_id.ToString());
            return Ok(await _medicalScanService.DeletePatientScan(patientScan_id));
        }

        [HttpPut("updatePatientScan")]
        public async Task<IActionResult> UpdatePatientScan(PatientScanDto patientScanDto)
        {
            Console.WriteLine(patientScanDto.ToString());
            return Ok(await _medicalScanService.UpdatePatientScan(patientScanDto));
        }

        [HttpGet("getAllPatientScan")]
        public async Task<IActionResult> GetAllPatientScan()
        {
            return Ok(await _medicalScanService.GetallPatientScans());
        }

        [HttpGet("getPatientScanById/{id}")]
        public async Task<IActionResult> GetPatientScanById([FromRoute] int id)
        {
            return Ok(await _medicalScanService.GetPatientScanById(id));
        }

        [HttpGet("getPatientScansByPatientId/{id}")]
        public async Task<IActionResult> GetPatientScansByPatientId([FromRoute] int id)
        {
            return Ok(await _medicalScanService.GetPatientScansByPatientId(id));
        }

        [HttpGet("getPatientScansByDoctorId/{id}")]
        public async Task<IActionResult> GetPatientScansByDoctorId([FromRoute] int id)
        {
            return Ok(await _medicalScanService.GetPatientScansByDoctorId(id));
        }

        [HttpGet("GetPatientPatientScansByDate/{patient_id}/{PatientScanDate}")]
        public async Task<IActionResult> GetPatientByDate(int patient_id, DateTime PatientScanDate)
        {
            return Ok(await _medicalScanService.GetPatientScansByDate(patient_id, PatientScanDate));
        }

        [HttpGet("GetDoctorPatientScansByDate/{doctor_id}/{PatientScanDate}")]
        public async Task<IActionResult> GetDoctorScansByDate(int doctor_id, DateTime PatientScanDate)
        {
            return Ok(await _medicalScanService.GetDoctorScansByDate(doctor_id, PatientScanDate));
        }

    }
}
