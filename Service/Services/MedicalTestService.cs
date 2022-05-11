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
            return await TestRepository.GetById(Test_id);
        }

        public async Task<Test> GetTestByName(string Testname)
        {
            var tests = GetAllTests().Result;
            return tests.SingleOrDefault(T => T.Name == Testname);
        }



        //######################################################################################################
        //LAB REQUEST

        public async Task<LabRequest> AddLabRequest(LabRequestDto labRequest)
        {
            LabRequest newLabRequest = new LabRequest()
            {
                LabName = labRequest.LabName,
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
            LabRequest newLabRequest = new LabRequest()
            {
                Id = labRequest.Id,
                LabName = labRequest.LabName,
                CreatedDtm = DateTime.Now,
                DoctorId = labRequest.DoctorId,
                PatientId = labRequest.PatientId
            };
            return await LabRequestRepository.Update(newLabRequest);
        }

        public async Task<LabRequest> GetLabRequestById(int Lab_id)
        {
            return await LabRequestRepository.GetById(Lab_id);
        }

        public async Task<IEnumerable<LabRequest>> GetLabRequestsByPatientId(int Patinet_id)
        {
            return await LabRequestRepository.GetAllLabRequestsForPatient(Patinet_id).ToListAsync();
        }

        public async Task<IEnumerable<LabRequest>> GetLabRequestsByDoctorId(int Doctor_id)
        {
            return await LabRequestRepository.GetAllLabRequestsByDocId(Doctor_id).ToListAsync();
        }

        public async Task<IEnumerable<LabRequest>> GetDoctorLabRequestsByDate(int Doctor_id, DateTime date)
        {
            return await LabRequestRepository.GetDoctorLabRequestsByDate(Doctor_id, date).ToListAsync();
        }

        public async Task<IEnumerable<LabRequest>> GetPatientLabRequestsByDate(int Patient_id, DateTime date)
        {
            return await LabRequestRepository.GetPatientLabRequestByDate(Patient_id, date).ToListAsync();
        }

        public async Task<IEnumerable<LabRequest>> GetAllLabRequests()
        {
            return await LabRequestRepository.GetAll().ToListAsync();
        }



        //######################################################################################################
        //PATIENT TEST

        public async Task<PatientTest> AddPatientTest(PatientTestDto Test)
        {
            int ReqId = Test.LabRequestId;
            LabRequest lab = GetLabRequestById(ReqId).Result;

            int testId = await TestRepository.GetAll().Where(T => T.Name == lab.LabName).Select(T => T.Id).SingleOrDefaultAsync();
            PatientTest newTest = new PatientTest()
            {
                CategoricalDetails = Test.CategoricalDetails,
                NumericalDetails = Test.NumericalDetails,
                TestDate = Test.TestDate,
                DoctorId = lab.DoctorId,
                PatientId = lab.PatientId,
                TestId = testId
            };
            return await PatientTestRepository.Add(newTest);
        }

        public async Task<PatientTest> DeletePatientTest(int Test_id)
        {
            return await PatientTestRepository.Delete(Test_id);
        }

        public async Task<PatientTest> UpdatePatientTest(PatientTestDto Test)
        {
            int ReqId = Test.LabRequestId;
            LabRequest lab = GetLabRequestById(ReqId).Result;

            int testId = await TestRepository.GetAll().Where(T => T.Name == lab.LabName).Select(T => T.Id).SingleOrDefaultAsync();
            PatientTest newTest = new PatientTest()
            {
                CategoricalDetails = Test.CategoricalDetails,
                NumericalDetails = Test.NumericalDetails,
                TestDate = Test.TestDate,
                DoctorId = lab.DoctorId,
                PatientId = lab.PatientId,
                TestId = testId
            };
            return await PatientTestRepository.Update(newTest);
        }

        public async Task<PateintTestResponse> GetPatientTestById(int Test_id)
        {
            PatientTest patientTest = await PatientTestRepository.GetById(Test_id);
            string testName = TestRepository.GetAll().Where(T => T.Id == patientTest.TestId).Select(T => T.Name).SingleOrDefault();
            PateintTestResponse pateintTestResponse = new PateintTestResponse()
            {
                CategoricalDetails = patientTest.CategoricalDetails,
                NumericalDetails = patientTest.NumericalDetails,
                DoctorId = patientTest.DoctorId,
                PatientId = patientTest.PatientId,
                TestName = testName,
                PatientTestId = patientTest.PatientTestId,
                TestDate = patientTest.TestDate
            };
            return pateintTestResponse;
        }

        public async Task<IEnumerable<PatientTest>> GetPatientTestsByPatientId(int Patient_id)
        {
            return await PatientTestRepository.GetAllPatientTestsForPatient(Patient_id).ToListAsync();
        }

        public async Task<IEnumerable<PatientTest>> GetPatientTestsByDoctorId(int Doctor_id)
        {
            return await PatientTestRepository.GetAllPatientTestsByDocId(Doctor_id).ToListAsync();
        }

        public async Task<IEnumerable<PatientTest>> GetPatientTestsByDate(int Patient_id, DateTime date)
        {
            return await PatientTestRepository.GetPatientTestByDate(Patient_id, date).ToListAsync();
        }

        public async Task<IEnumerable<PatientTest>> GetDoctorTestsByDate(int Doctor_id, DateTime date)
        {
            return await PatientTestRepository.GetDoctorTestsByDate(Doctor_id, date).ToListAsync();
        }

        public async Task<IEnumerable<PatientTest>> GetallPatientTests()
        {
            return await PatientTestRepository.GetAll().ToListAsync();
        }
    }
}
