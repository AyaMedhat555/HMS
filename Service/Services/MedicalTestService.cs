using Domain.Models.Labs;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.DTO;
using Service.IServices;
using Service.Responses;
using SmartHospital.Models.Labs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MedicalTestService : IMedicalTestService
    {
        private IGenericRepository<Test> TestRepository { get; }
        private IPatientTestRepository PatientTestRepository { get; }
        private ILabRequestRepository LabRequestRepository { get; }

        public MedicalTestService(IGenericRepository<Test> testRepository, IPatientTestRepository patientTestRepository, ILabRequestRepository labRequestRepository)
        {
            TestRepository=testRepository;
            PatientTestRepository=patientTestRepository;
            LabRequestRepository=labRequestRepository;
        }


        //######################################################################################################
        //TEST

        public async Task<Test> AddTest(Test test)
        {
            return await TestRepository.Add(test);
        }
        public async Task<Test> DeleteTest(int Test_id)
        {
            return await TestRepository.Delete(Test_id);
        }
        public async Task<Test> UpdateTest(Test test_dto)
        {
            return await TestRepository.Update(test_dto);
        }
        public async Task<IEnumerable<Test>> GetAllTests()
        {
            return await TestRepository.GetAll().Include(T => T.NumericalParamters).Include(T => T.CategoricalParamters).ToListAsync();
        }

        public async Task<Test> GetTestById(int Test_id)
        {
            var tests = await GetAllTests();
            return tests.SingleOrDefault(T => T.Id == Test_id);
        }

        public async Task<Test> GetTestByName(string Testname)
        {
            var tests = await GetAllTests();
            return tests.SingleOrDefault(T => T.Name == Testname);
        }



        //######################################################################################################
        //LAB REQUEST

        public async Task<LabRequest> AddLabRequest(LabRequestDto labRequest)
        {
            int testId = await TestRepository.GetAll().Where(T => T.Name == labRequest.LabName).Select(T => T.Id).SingleOrDefaultAsync();
            LabRequest newLabRequest = new LabRequest()
            {
                TestId = testId,
                CreatedDtm = DateTime.Now,
                DoctorId = labRequest.DoctorId,
                PatientId = labRequest.PatientId
            };
            return await LabRequestRepository.Add(newLabRequest);
        }

        public async Task<LabRequest> DeleteLabRequest(int Lab_id)
        {
            return await LabRequestRepository.Delete(Lab_id);
        }

        public async Task<LabRequest> UpdateLabRequest(LabRequestDto labRequest)
        {
            int testId = await TestRepository.GetAll().Where(T => T.Name == labRequest.LabName).Select(T => T.Id).SingleOrDefaultAsync();
            LabRequest newLabRequest = new LabRequest()
            {
                TestId = testId,
                CreatedDtm = DateTime.Now,
                DoctorId = labRequest.DoctorId,
                PatientId = labRequest.PatientId
            };
            return await LabRequestRepository.Update(newLabRequest);
        }

        public async Task<LabRequestResponse> GetLabRequestById(int Lab_id)
        {
            LabRequest labRequest = await LabRequestRepository.GetById(Lab_id);
            LabRequestResponse labRequestResponse = new LabRequestResponse()
            {
                Id = labRequest.Id,
                LabName = labRequest.Test.Name,
                TestId = labRequest.Test.Id,
                CreatedDtm = labRequest.CreatedDtm,
                DoctorName = labRequest.Doctor.FirstName+" "+labRequest.Doctor.LastName,
                PatientName = labRequest.Patient.FirstName+" "+labRequest.Patient.LastName,
                DoctorId = labRequest.DoctorId,
                PatientId = labRequest.PatientId
            };
            return labRequestResponse;
        }

        public async Task<IEnumerable<LabRequestResponse>> GetLabRequestsByPatientId(int Patinet_id)
        {
            List<LabRequest> requests = await LabRequestRepository.GetAllLabRequestsForPatient(Patinet_id).ToListAsync();
            List<LabRequestResponse> requestsResponse = new List<LabRequestResponse>();
            foreach(LabRequest labRequest in requests)
            {
                LabRequestResponse response = new LabRequestResponse()
                {
                    Id = labRequest.Id,
                    LabName = labRequest.Test.Name,
                    TestId = labRequest.Test.Id,
                    CreatedDtm = labRequest.CreatedDtm,
                    DoctorName = labRequest.Doctor.FirstName+" "+labRequest.Doctor.LastName,
                    PatientName = labRequest.Patient.FirstName+" "+labRequest.Patient.LastName,
                    DoctorId = labRequest.DoctorId,
                    PatientId = labRequest.PatientId
                };
                requestsResponse.Add(response);                                
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<LabRequestResponse>> GetLabRequestsByDoctorId(int Doctor_id)
        {
            List<LabRequest> requests = await LabRequestRepository.GetAllLabRequestsByDocId(Doctor_id).ToListAsync();
            List<LabRequestResponse> requestsResponse = new List<LabRequestResponse>();
            foreach (LabRequest labRequest in requests)
            {
                LabRequestResponse response = new LabRequestResponse()
                {
                    Id = labRequest.Id,
                    LabName = labRequest.Test.Name,
                    TestId = labRequest.Test.Id,
                    CreatedDtm = labRequest.CreatedDtm,
                    DoctorName = labRequest.Doctor.FirstName+" "+labRequest.Doctor.LastName,
                    PatientName = labRequest.Patient.FirstName+" "+labRequest.Patient.LastName,
                    DoctorId = labRequest.DoctorId,
                    PatientId = labRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<LabRequestResponse>> GetDoctorLabRequestsByDate(int Doctor_id, DateTime date)
        {
            List<LabRequest> requests = await LabRequestRepository.GetDoctorLabRequestsByDate(Doctor_id, date).ToListAsync();
            List<LabRequestResponse> requestsResponse = new List<LabRequestResponse>();
            foreach (LabRequest labRequest in requests)
            {
                LabRequestResponse response = new LabRequestResponse()
                {
                    Id = labRequest.Id,
                    LabName = labRequest.Test.Name,
                    TestId = labRequest.Test.Id,
                    CreatedDtm = labRequest.CreatedDtm,
                    DoctorName = labRequest.Doctor.FirstName+" "+labRequest.Doctor.LastName,
                    PatientName = labRequest.Patient.FirstName+" "+labRequest.Patient.LastName,
                    DoctorId = labRequest.DoctorId,
                    PatientId = labRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<LabRequestResponse>> GetPatientLabRequestsByDate(int Patient_id, DateTime date)
        {
            List<LabRequest> requests = await LabRequestRepository.GetPatientLabRequestByDate(Patient_id, date).ToListAsync();
            List<LabRequestResponse> requestsResponse = new List<LabRequestResponse>();
            foreach (LabRequest labRequest in requests)
            {
                LabRequestResponse response = new LabRequestResponse()
                {
                    Id = labRequest.Id,
                    LabName = labRequest.Test.Name,
                    TestId = labRequest.Test.Id,
                    CreatedDtm = labRequest.CreatedDtm,
                    DoctorName = labRequest.Doctor.FirstName+" "+labRequest.Doctor.LastName,
                    PatientName = labRequest.Patient.FirstName+" "+labRequest.Patient.LastName,
                    DoctorId = labRequest.DoctorId,
                    PatientId = labRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }

        public async Task<IEnumerable<LabRequestResponse>> GetAllLabRequests()
        {
            List<LabRequest> requests = await LabRequestRepository.GetAll().ToListAsync();
            List<LabRequestResponse> requestsResponse = new List<LabRequestResponse>();
            foreach (LabRequest labRequest in requests)
            {
                LabRequestResponse response = new LabRequestResponse()
                {
                    Id = labRequest.Id,
                    LabName = labRequest.Test.Name,
                    TestId = labRequest.Test.Id,
                    CreatedDtm = labRequest.CreatedDtm,
                    DoctorName = labRequest.Doctor.FirstName+" "+labRequest.Doctor.LastName,
                    PatientName = labRequest.Patient.FirstName+" "+labRequest.Patient.LastName,
                    DoctorId = labRequest.DoctorId,
                    PatientId = labRequest.PatientId
                };
                requestsResponse.Add(response);
            }
            return requestsResponse;
        }



        //######################################################################################################
        //PATIENT TEST

        public async Task<PatientTest> AddPatientTest(PatientTestDto Test)
        {
            int ReqId = Test.LabRequestId;
            LabRequest lab = await LabRequestRepository.GetById(ReqId);
            PatientTest newTest = new PatientTest()
            {
                CategoricalDetails = Test.CategoricalDetails,
                NumericalDetails = Test.NumericalDetails,
                TestDate = DateTime.Now,
                DoctorId = lab.DoctorId,
                PatientId = lab.PatientId,
                TestId = lab.TestId                
            };
            await DeleteLabRequest(ReqId);
            return await PatientTestRepository.Add(newTest);
        }

        public async Task<PatientTest> DeletePatientTest(int Test_id)
        {
            return await PatientTestRepository.Delete(Test_id);
        }

        public async Task<PatientTest> UpdatePatientTest(PatientTestDto Test)
        {
            int ReqId = Test.LabRequestId;
            LabRequest lab = await LabRequestRepository.GetById(ReqId);
            PatientTest newTest = new PatientTest()
            {
                CategoricalDetails = Test.CategoricalDetails,
                NumericalDetails = Test.NumericalDetails,
                TestDate = DateTime.Now,
                DoctorId = lab.DoctorId,
                PatientId = lab.PatientId,
                TestId = lab.TestId
            };
            return await PatientTestRepository.Update(newTest);
        }

        public async Task<PatientTestResponse> GetPatientTestById(int Test_id)
        {
            PatientTest patientTest = await PatientTestRepository.GetById(Test_id);
            PatientTestResponse pateintTestResponse = new PatientTestResponse()
            {
                CategoricalDetails = patientTest.CategoricalDetails,
                NumericalDetails = patientTest.NumericalDetails,
                DoctorId = patientTest.DoctorId,
                PatientId = patientTest.PatientId,
                TestName = patientTest.Test.Name,
                PatientTestId = patientTest.PatientTestId,
                TestDate = patientTest.TestDate
            };
            return pateintTestResponse;
        }

        public async Task<IEnumerable<PatientTestResponse>> GetPatientTestsByPatientId(int Patient_id)
        {
            List<PatientTest> tests = await PatientTestRepository.GetAllPatientTestsForPatient(Patient_id).ToListAsync();
            List<PatientTestResponse> testsResponses = new List<PatientTestResponse>();
            foreach (var patientTest in tests)
            {
                PatientTestResponse pateintTestResponse = new PatientTestResponse()
                {
                    CategoricalDetails = patientTest.CategoricalDetails,
                    NumericalDetails = patientTest.NumericalDetails,
                    DoctorId = patientTest.DoctorId,
                    PatientId = patientTest.PatientId,
                    TestName = patientTest.Test.Name,
                    PatientTestId = patientTest.PatientTestId,
                    TestDate = patientTest.TestDate
                };
                testsResponses.Add(pateintTestResponse);
            }
            return testsResponses;
        }

        public async Task<IEnumerable<PatientTestResponse>> GetPatientTestsByDoctorId(int Doctor_id)
        {
            List<PatientTest> tests = await PatientTestRepository.GetAllPatientTestsByDocId(Doctor_id).ToListAsync();
            List<PatientTestResponse> testsResponses = new List<PatientTestResponse>();
            foreach (var patientTest in tests)
            {
                PatientTestResponse pateintTestResponse = new PatientTestResponse()
                {
                    CategoricalDetails = patientTest.CategoricalDetails,
                    NumericalDetails = patientTest.NumericalDetails,
                    DoctorId = patientTest.DoctorId,
                    PatientId = patientTest.PatientId,
                    TestName = patientTest.Test.Name,
                    PatientTestId = patientTest.PatientTestId,
                    TestDate = patientTest.TestDate
                };
                testsResponses.Add(pateintTestResponse);
            }
            return testsResponses;
        }

        public async Task<IEnumerable<PatientTestResponse>> GetPatientTestsByDate(int Patient_id, DateTime date)
        {
            List<PatientTest> tests = await PatientTestRepository.GetPatientTestByDate(Patient_id, date).ToListAsync();
            List<PatientTestResponse> testsResponses = new List<PatientTestResponse>();
            foreach (var patientTest in tests)
            {
                PatientTestResponse pateintTestResponse = new PatientTestResponse()
                {
                    CategoricalDetails = patientTest.CategoricalDetails,
                    NumericalDetails = patientTest.NumericalDetails,
                    DoctorId = patientTest.DoctorId,
                    PatientId = patientTest.PatientId,
                    TestName = patientTest.Test.Name,
                    PatientTestId = patientTest.PatientTestId,
                    TestDate = patientTest.TestDate
                };
                testsResponses.Add(pateintTestResponse);
            }
            return testsResponses;
        }

        public async Task<IEnumerable<PatientTestResponse>> GetDoctorTestsByDate(int Doctor_id, DateTime date)
        {
            List<PatientTest> tests = await PatientTestRepository.GetDoctorTestsByDate(Doctor_id, date).ToListAsync();
            List<PatientTestResponse> testsResponses = new List<PatientTestResponse>();
            foreach (var patientTest in tests)
            {
                PatientTestResponse pateintTestResponse = new PatientTestResponse()
                {
                    CategoricalDetails = patientTest.CategoricalDetails,
                    NumericalDetails = patientTest.NumericalDetails,
                    DoctorId = patientTest.DoctorId,
                    PatientId = patientTest.PatientId,
                    TestName = patientTest.Test.Name,
                    PatientTestId = patientTest.PatientTestId,
                    TestDate = patientTest.TestDate
                };
                testsResponses.Add(pateintTestResponse);
            }
            return testsResponses;
        }

        public async Task<IEnumerable<PatientTestResponse>> GetallPatientTests()
        {
            List<PatientTest> tests = await PatientTestRepository.GetAll().ToListAsync();
            List<PatientTestResponse> testsResponses = new List<PatientTestResponse>();
            foreach (var patientTest in tests)
            {
                PatientTestResponse pateintTestResponse = new PatientTestResponse()
                {
                    CategoricalDetails = patientTest.CategoricalDetails,
                    NumericalDetails = patientTest.NumericalDetails,
                    DoctorId = patientTest.DoctorId,
                    PatientId = patientTest.PatientId,
                    TestName = patientTest.Test.Name,
                    PatientTestId = patientTest.PatientTestId,
                    TestDate = patientTest.TestDate
                };
                testsResponses.Add(pateintTestResponse);
            }
            return testsResponses;
        }
    }
}
