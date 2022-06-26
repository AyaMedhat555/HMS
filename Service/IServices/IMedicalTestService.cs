using Domain.Models.Labs;
using Service.DTO.Labs;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IMedicalTestService
    {
        Task<Test> AddTest(TestDto test);
        Task<Test> DeleteTest(int Test_id);
        Task<Test> UpdateTest(Test test_dto);
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> GetTestById(int Test_id);
        Task<Test> GetTestByName(String Testname);


        Task<LabRequest> AddLabRequest(LabRequestDto LabRequest);
        Task<LabRequest> DeleteLabRequest (int Lab_id);
        Task<LabRequest> UpdateLabRequest(LabRequestDto LabRequest);
        Task<LabRequestResponse> GetLabRequestById(int Lab_id);
        Task<IEnumerable<LabRequestResponse>> GetLabRequestsByPatientId(int Patinet_id);
        Task<IEnumerable<LabRequestResponse>> GetLabRequestsByDoctorId(int Doctor_id);
        Task<IEnumerable<LabRequestResponse>> GetDoctorLabRequestsByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<LabRequestResponse>> GetPatientLabRequestsByDate(int Patient_id, DateTime date);
        Task<IEnumerable<LabRequestResponse>> GetAllLabRequests();
        Task<IEnumerable<LabRequest>> AddLabRequests(List<LabRequestDto> LabRequests);



        Task<PatientTest> AddPatientTest(PatientTestDto Test);
        Task<PatientTest> DeletePatientTest(int Test_id);
        Task<PatientTest> UpdatePatientTest(PatientTestDto Test);
        Task<PatientTestResponse> GetPatientTestById(int Test_id);
        Task<IEnumerable<PatientTestResponse>> GetPatientTestsByPatientId(int Patient_id);
        Task<IEnumerable<PatientTestResponse>> GetPatientTestsByDoctorId(int Doctor_id);
        Task<IEnumerable<PatientTestResponse>> GetPatientTestsByDate(int Patient_id, DateTime date);
        Task<IEnumerable<PatientTestResponse>> GetDoctorTestsByDate(int Doctor_id, DateTime date);
        Task<IEnumerable<PatientTestResponse>> GetallPatientTests();



    }
}
