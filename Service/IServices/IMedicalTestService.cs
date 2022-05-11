using Domain.Models.Labs;
using Service.DTO;
using Service.Responses;
using SmartHospital.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IMedicalTestService
    {
        Task<Test> AddTest(Test test);
        Task<Test> DeleteTest(int Test_id);
        Task<Test> UpdateTest(Test test_dto);
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> GetTestById(int Test_id);
        Task<Test> GetTestByName(String Testname);


        Task<LabRequest> AddLabRequest(LabRequestDto LabRequest);
        Task<LabRequest> DeleteLabRequest (int Lab_id);
        Task<LabRequest> UpdateLabRequest(LabRequestDto LabRequest);
        Task<LabRequest> GetLabRequestById(int Lab_id);
        Task<IEnumerable<LabRequest>> GetLabRequestsByPatientId(int Patinet_id);
        Task<IEnumerable<LabRequest>> GetLabRequestsByDoctorId(int Doctor_id);
        Task<IEnumerable<LabRequest>> GetDoctorLabRequestsByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<LabRequest>> GetPatientLabRequestsByDate(int Patient_id, DateTime date);
        Task<IEnumerable<LabRequest>> GetAllLabRequests();


        Task<PatientTest> AddPatientTest(PatientTestDto Test);
        Task<PatientTest> DeletePatientTest(int Test_id);
        Task<PatientTest> UpdatePatientTest(PatientTestDto Test);
        Task<PateintTestResponse> GetPatientTestById(int Test_id);
        Task<IEnumerable<PatientTest>> GetPatientTestsByPatientId(int Patient_id);
        Task<IEnumerable<PatientTest>> GetPatientTestsByDoctorId(int Doctor_id);
        Task<IEnumerable<PatientTest>> GetPatientTestsByDate(int Patient_id, DateTime date);
        Task<IEnumerable<PatientTest>> GetDoctorTestsByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<PatientTest>> GetallPatientTests();



    }
}
