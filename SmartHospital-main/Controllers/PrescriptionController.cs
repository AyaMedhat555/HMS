using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Service.Services;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase

    {
        private IDoctorService DoctorService { get; }
        private IIndoorPatientService IndoorPatientService { get; }

        public PrescriptionController(IDoctorService _DoctorService, IIndoorPatientService _IndoorPatientService)
        {
            DoctorService = _DoctorService;
            IndoorPatientService = _IndoorPatientService;
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

        [HttpGet("GetPrescription/{Prescription_ID}")]
        public async Task<IActionResult> GetPrescriptionId(int Prescription_ID)
        {
            return Ok(await DoctorService.GetPrescriptionById(Prescription_ID));
        }

        [HttpGet("GetLastPrescriptionByInDoorId/{InDoorRecord_Id}")]
        public async Task<IActionResult> GetLastPrescriptionByInDoorId(int InDoorRecord_Id)
        {
            return Ok(IndoorPatientService.GetLastPrescriptionByIndoorPatientId(InDoorRecord_Id));
        }
    }
}
