using Domain.Models.Labs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;
using Service.IServices;
using SmartHospital.Models.Labs;

namespace SmartHospital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalTestController : ControllerBase
    {
        private IMedicalTestService _medicalTestService { get; }

        public MedicalTestController(IMedicalTestService medicalTestService)
        {
            _medicalTestService=medicalTestService;
        }


        //######################################################################################################
        //TEST

        [HttpPost("add")]
        public async Task<IActionResult> Add(TestDto test)
        {
            Console.WriteLine(test.ToString());
            //check if name already used
            var foundTest = await _medicalTestService.GetTestByName(test.Name);
            if (foundTest != null)
            {
                return Ok("a test with the name "+test.Name+" already exists.");
            }
            return Ok(await _medicalTestService.AddTest(test));
        }

        [HttpDelete("delete/{test_id}")]
        public async Task<IActionResult> Delete([FromRoute] int test_id)
        {
            Console.WriteLine(test_id.ToString());
            return Ok(await _medicalTestService.DeleteTest(test_id));
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Test test)
        {
            Console.WriteLine(test.ToString());
            return Ok(await _medicalTestService.UpdateTest(test));
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _medicalTestService.GetAllTests());
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _medicalTestService.GetTestById(id));
        }

        [HttpGet("getByName")]
        public async Task<IActionResult> GetByName(string Testname)
        {
            return Ok(await _medicalTestService.GetTestByName(Testname));
        }



        //######################################################################################################
        //LAB REQUEST

        [HttpPost("addLabRequest")]
        public async Task<IActionResult> LabRequest(LabRequestDto labRequest)
        {
            Console.WriteLine(labRequest.ToString());
            return Ok(await _medicalTestService.AddLabRequest(labRequest));
        }

        [HttpDelete("deleteLabRequest/{labRequest_id}")]
        public async Task<IActionResult> DeleteLabRequest([FromRoute] int labRequest_id)
        {
            Console.WriteLine(labRequest_id.ToString());
            return Ok(await _medicalTestService.DeleteLabRequest(labRequest_id));
        }

        [HttpPut("updateLabRequest")]
        public async Task<IActionResult> UpdateLabRequest(LabRequestDto labRequest)
        {
            Console.WriteLine(labRequest.ToString());
            return Ok(await _medicalTestService.UpdateLabRequest(labRequest));
        }

        [HttpGet("getAllLabRequest")]
        public async Task<IActionResult> GetAllLabRequest()
        {
            return Ok(await _medicalTestService.GetAllLabRequests());
        }

        [HttpGet("getLabRequestById/{id}")]
        public async Task<IActionResult> GetLabRequestById([FromRoute] int id)
        {
            return Ok(await _medicalTestService.GetLabRequestById(id));
        }

        [HttpGet("getLabRequestsByPatientId/{id}")]
        public async Task<IActionResult> GetLabRequestsByPatientId([FromRoute] int id)
        {
            return Ok(await _medicalTestService.GetLabRequestsByPatientId(id));
        }

        [HttpGet("getLabRequestsByDoctorId/{id}")]
        public async Task<IActionResult> GetLabRequestsByDoctorId([FromRoute] int id)
        {
            return Ok(await _medicalTestService.GetLabRequestsByDoctorId(id));
        }

        [HttpGet("GetPatientLabRequestsByDate/{patient_id}/{LabRequestDate}")]
        public async Task<IActionResult> GetPatientLabRequestsByDate(int patient_id, DateTime LabRequestDate)
        {
            return Ok(await _medicalTestService.GetPatientLabRequestsByDate(patient_id, LabRequestDate));
        }

        [HttpGet("GetDoctorLabRequestsByDate/{doctor_id}/{LabRequestDate}")]
        public async Task<IActionResult> GetDoctorLabRequestsByDate(int doctor_id, DateTime LabRequestDate)
        {
            return Ok(await _medicalTestService.GetDoctorLabRequestsByDate(doctor_id, LabRequestDate));
        }

        [HttpPost("addLabRequests")]
        public async Task<IActionResult> AddLabRequests(List<LabRequestDto> labRequestsDtos)
        {
            Console.WriteLine(labRequestsDtos.ToString());
            return Ok(await _medicalTestService.AddLabRequests(labRequestsDtos));
        }

        //######################################################################################################
        //PATIENT TEST

        [HttpPost("addPatientTest")]
        public async Task<IActionResult> PatientTest(PatientTestDto patientTestDto)
        {
            Console.WriteLine(patientTestDto.ToString());
            return Ok(await _medicalTestService.AddPatientTest(patientTestDto));
        }

        [HttpDelete("deletePatientTest/{patientTest_id}")]
        public async Task<IActionResult> DeletePatientTest([FromRoute] int patientTest_id)
        {
            Console.WriteLine(patientTest_id.ToString());
            return Ok(await _medicalTestService.DeletePatientTest(patientTest_id));
        }

        [HttpPut("updatePatientTest")]
        public async Task<IActionResult> UpdatePatientTest(PatientTestDto patientTestDto)
        {
            Console.WriteLine(patientTestDto.ToString());
            return Ok(await _medicalTestService.UpdatePatientTest(patientTestDto));
        }

        [HttpGet("getAllPatientTest")]
        public async Task<IActionResult> GetAllPatientTest()
        {
            return Ok(await _medicalTestService.GetallPatientTests());
        }

        [HttpGet("getPatientTestById/{id}")]
        public async Task<IActionResult> GetPatientTestById([FromRoute] int id)
        {
            return Ok(await _medicalTestService.GetPatientTestById(id));
        }

        [HttpGet("getPatientTestsByPatientId/{id}")]
        public async Task<IActionResult> GetPatientTestsByPatientId([FromRoute] int id)
        {
            return Ok(await _medicalTestService.GetPatientTestsByPatientId(id));
        }

        [HttpGet("getPatientTestsByDoctorId/{id}")]
        public async Task<IActionResult> GetPatientTestsByDoctorId([FromRoute] int id)
        {
            return Ok(await _medicalTestService.GetPatientTestsByDoctorId(id));
        }

        [HttpGet("GetPatientPatientTestsByDate/{patient_id}/{PatientTestDate}")]
        public async Task<IActionResult> GetPatientByDate(int patient_id, DateTime PatientTestDate)
        {
            return Ok(await _medicalTestService.GetPatientTestsByDate(patient_id, PatientTestDate));
        }

        [HttpGet("GetDoctorPatientTestsByDate/{doctor_id}/{PatientTestDate}")]
        public async Task<IActionResult> GetDoctorTestsByDate(int doctor_id, DateTime PatientTestDate)
        {
            return Ok(await _medicalTestService.GetDoctorTestsByDate(doctor_id, PatientTestDate));
        }

    }
}
