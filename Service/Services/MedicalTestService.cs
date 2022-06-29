using Domain.Models.Labs;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.DTO.Labs;
using Service.IServices;
using Service.Responses;
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

        public async Task<Test> AddTest(TestDto testDto)
        {
            Test test = new Test()
            {
                Name = testDto.Name,
                TestCharge = testDto.TestCharge,
                NumericalParamters = testDto.NumericalParamters.Select(p => new TestParameterNumerical()
                {
                    TestParameterName = p.TestParameterName,
                    FieldType = p.FieldType,
                    InputPattern = p.InputPattern,
                    Unit = p.Unit,
                    Max_Range = p.Max_Range,
                    Min_Range = p.Min_Range                    
                }).ToList(),
                CategoricalParamters = testDto.CategoricalParamters.Select(p => new TestParameterCategorical()
                {
                    TestParameterName = p.TestParameterName,
                    FieldType = p.FieldType,
                    InputPattern = p.InputPattern,
                    Unit = p.Unit,
                    Normalvalue = p.Normalvalue                   
                }).ToList()
            };
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
                PatientId = labRequest.PatientId,
                IndoorPatientRecordId = labRequest.IndoorPatientRecordId
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
                Id = labRequest.Id,
                TestId = testId,
                CreatedDtm = DateTime.Now,
                DoctorId = labRequest.DoctorId,
                PatientId = labRequest.PatientId
            };
            return await LabRequestRepository.Update(newLabRequest);
        }

        public async Task<LabRequestResponse> GetLabRequestById(int Lab_id)
        {
            LabRequest labRequest = await LabRequestRepository.GetLabRequestById(Lab_id);
            LabRequestResponse labRequestResponse = new LabRequestResponse()
            {
                Id = labRequest.Id,
                LabName = labRequest.Test.Name,
                TestId = labRequest.Test.Id,
                CreatedDtm = labRequest.CreatedDtm,
                DoctorName = labRequest.Doctor.FirstName+" "+labRequest.Doctor.LastName,
                PatientName = labRequest.Patient.FirstName+" "+labRequest.Patient.LastName,
                DoctorId = labRequest.DoctorId,
                PatientId = labRequest.PatientId,
                IndoorPatientRecordId = labRequest.IndoorPatientRecordId
            };
            return labRequestResponse;
        }

        public async Task<IEnumerable<LabRequestResponse>> GetLabRequestsByPatientId(int Patinet_id)
        {
            return await LabRequestRepository.GetAllLabRequestsForPatient(Patinet_id).Select(L => new LabRequestResponse()
            {
                Id = L.Id,
                LabName = L.Test.Name,
                TestId = L.Test.Id,
                CreatedDtm = L.CreatedDtm,
                DoctorName = L.Doctor.FirstName+" "+L.Doctor.LastName,
                PatientName = L.Patient.FirstName+" "+L.Patient.LastName,
                DoctorId = L.DoctorId,
                PatientId = L.PatientId,
                IndoorPatientRecordId = L.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<LabRequestResponse>> GetLabRequestsByDoctorId(int Doctor_id)
        {
            return await LabRequestRepository.GetAllLabRequestsByDocId(Doctor_id).Select(L => new LabRequestResponse()
            {
                Id = L.Id,
                LabName = L.Test.Name,
                TestId = L.Test.Id,
                CreatedDtm = L.CreatedDtm,
                DoctorName = L.Doctor.FirstName+" "+L.Doctor.LastName,
                PatientName = L.Patient.FirstName+" "+L.Patient.LastName,
                DoctorId = L.DoctorId,
                PatientId = L.PatientId,
                IndoorPatientRecordId = L.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<LabRequestResponse>> GetDoctorLabRequestsByDate(int Doctor_id, DateTime date)
        {
            return await LabRequestRepository.GetDoctorLabRequestsByDate(Doctor_id, date).Select(L => new LabRequestResponse()
            {
                Id = L.Id,
                LabName = L.Test.Name,
                TestId = L.Test.Id,
                CreatedDtm = L.CreatedDtm,
                DoctorName = L.Doctor.FirstName+" "+L.Doctor.LastName,
                PatientName = L.Patient.FirstName+" "+L.Patient.LastName,
                DoctorId = L.DoctorId,
                PatientId = L.PatientId,
                IndoorPatientRecordId = L.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<LabRequestResponse>> GetPatientLabRequestsByDate(int Patient_id, DateTime date)
        {
            return await LabRequestRepository.GetPatientLabRequestByDate(Patient_id, date).Select(L => new LabRequestResponse()
            {
                Id = L.Id,
                LabName = L.Test.Name,
                TestId = L.Test.Id,
                CreatedDtm = L.CreatedDtm,
                DoctorName = L.Doctor.FirstName+" "+L.Doctor.LastName,
                PatientName = L.Patient.FirstName+" "+L.Patient.LastName,
                DoctorId = L.DoctorId,
                PatientId = L.PatientId,
                IndoorPatientRecordId = L.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<LabRequestResponse>> GetAllLabRequests()
        {
            return await LabRequestRepository.GetAllLabRequests().Select(L => new LabRequestResponse()
            {
                Id = L.Id,
                LabName = L.Test.Name,
                TestId = L.Test.Id,
                CreatedDtm = L.CreatedDtm,
                DoctorName = L.Doctor.FirstName+" "+L.Doctor.LastName,
                PatientName = L.Patient.FirstName+" "+L.Patient.LastName,
                DoctorId = L.DoctorId,
                PatientId = L.PatientId,
                IndoorPatientRecordId = L.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<LabRequest>> AddLabRequests(List<LabRequestDto> labRequestsDtos)
        {
            List<Test> tests = await TestRepository.GetAll().ToListAsync();
            List<LabRequest> labRequests = labRequestsDtos.Select(S => new LabRequest()
            {
                TestId = tests.Where(t => t.Name == S.LabName).Select(t => t.Id).SingleOrDefault(),
                CreatedDtm = DateTime.Now,
                DoctorId = S.DoctorId,
                PatientId = S.PatientId,
                IndoorPatientRecordId = S.IndoorPatientRecordId
            }).ToList();
            foreach (LabRequest labRequest in labRequests)
            {
                await LabRequestRepository.Add(labRequest);
            }
            return labRequests;
        }


        //######################################################################################################
        //PATIENT TEST

        public async Task<PatientTest> AddPatientTest(PatientTestDto Test)
        {
            int ReqId = Test.LabRequestId;
            LabRequest lab = await LabRequestRepository.GetById(ReqId);
            PatientTest newTest = new PatientTest()
            {
                CategoricalDetails = Test.CategoricalDetails.Select(d => new TestDetailsCategorical()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.MeasuredValue
                }).ToList(),
                NumericalDetails = Test.NumericalDetails.Select(d => new TestDetailsNumerical()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.NumericalValue
                }).ToList(),
                TestDate = DateTime.Now,
                DoctorId = lab.DoctorId,
                PatientId = lab.PatientId,
                TestId = lab.TestId,
                IndoorPatientRecordId = lab.IndoorPatientRecordId
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
            PatientTest currentTest = await PatientTestRepository.GetById(Test.PatientTestId);
            currentTest.CategoricalDetails = Test.CategoricalDetails.Select(d => new TestDetailsCategorical()
            {
                MeasuredValue = d.MeasuredValue,
                TestParameterId=d.TestParameterId
            }).ToList();

            currentTest.NumericalDetails = Test.NumericalDetails.Select(d => new TestDetailsNumerical()
            {
                TestParameterId = d.TestParameterId,
                MeasuredValue=d.NumericalValue
            }).ToList();
            return await PatientTestRepository.Update(currentTest);
        }

        public async Task<PatientTestResponse> GetPatientTestById(int Test_id)
        {
            List<PatientTestResponse> responses =  await PatientTestRepository.GetAllPatientsTests().Where(P => P.PatientTestId == Test_id).Select(P => new PatientTestResponse()
            {
                CategoricalDetails = P.CategoricalDetails.Select(d => new CategoricalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.MeasuredValue,
                    NormalValue = ((TestParameterCategorical)d.TestParameter).Normalvalue,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                NumericalDetails = P.NumericalDetails.Select(d => new NeumericalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    NumericalValue = d.MeasuredValue,
                    Min_Range = ((TestParameterNumerical)d.TestParameter).Min_Range,
                    Max_Range = ((TestParameterNumerical)d.TestParameter).Max_Range,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                DoctorId = P.DoctorId,
                PatientId = P.PatientId,
                DoctorName = P.Doctor.FirstName+" "+P.Doctor.LastName,
                PatientName = P.Patient.FirstName+" "+P.Patient.LastName,
                TestName = P.Test.Name,
                PatientTestId = P.PatientTestId,
                TestDate = P.TestDate,
                IndoorPatientRecordId = P.IndoorPatientRecordId
            }).ToListAsync();
            PatientTestResponse patientTestResponse = responses.FirstOrDefault();
            return patientTestResponse;
        }

        public async Task<IEnumerable<PatientTestResponse>> GetPatientTestsByPatientId(int Patient_id)
        {
            return await PatientTestRepository.GetAllPatientTestsForPatient(Patient_id).Select(P => new PatientTestResponse()
            {
                CategoricalDetails = P.CategoricalDetails.Select(d => new CategoricalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.MeasuredValue,
                    NormalValue = ((TestParameterCategorical)d.TestParameter).Normalvalue,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                NumericalDetails = P.NumericalDetails.Select(d => new NeumericalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    NumericalValue = d.MeasuredValue,
                    Min_Range = ((TestParameterNumerical)d.TestParameter).Min_Range,
                    Max_Range = ((TestParameterNumerical)d.TestParameter).Max_Range,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                DoctorId = P.DoctorId,
                PatientId = P.PatientId,
                DoctorName = P.Doctor.FirstName+" "+P.Doctor.LastName,
                PatientName = P.Patient.FirstName+" "+P.Patient.LastName,
                TestName = P.Test.Name,
                PatientTestId = P.PatientTestId,
                TestDate = P.TestDate,
                IndoorPatientRecordId = P.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientTestResponse>> GetPatientTestsByDoctorId(int Doctor_id)
        {
            return await PatientTestRepository.GetAllPatientTestsByDocId(Doctor_id).Select(P => new PatientTestResponse()
            {
                CategoricalDetails = P.CategoricalDetails.Select(d => new CategoricalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.MeasuredValue,
                    NormalValue = ((TestParameterCategorical)d.TestParameter).Normalvalue,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                NumericalDetails = P.NumericalDetails.Select(d => new NeumericalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    NumericalValue = d.MeasuredValue,
                    Min_Range = ((TestParameterNumerical)d.TestParameter).Min_Range,
                    Max_Range = ((TestParameterNumerical)d.TestParameter).Max_Range,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                DoctorId = P.DoctorId,
                PatientId = P.PatientId,
                DoctorName = P.Doctor.FirstName+" "+P.Doctor.LastName,
                PatientName = P.Patient.FirstName+" "+P.Patient.LastName,
                TestName = P.Test.Name,
                PatientTestId = P.PatientTestId,
                TestDate = P.TestDate,
                IndoorPatientRecordId = P.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientTestResponse>> GetPatientTestsByDate(int Patient_id, DateTime date)
        {
            return await PatientTestRepository.GetPatientTestByDate(Patient_id, date).Select(P => new PatientTestResponse()
            {
                CategoricalDetails = P.CategoricalDetails.Select(d => new CategoricalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.MeasuredValue,
                    NormalValue = ((TestParameterCategorical)d.TestParameter).Normalvalue,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                NumericalDetails = P.NumericalDetails.Select(d => new NeumericalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    NumericalValue = d.MeasuredValue,
                    Min_Range = ((TestParameterNumerical)d.TestParameter).Min_Range,
                    Max_Range = ((TestParameterNumerical)d.TestParameter).Max_Range,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                DoctorId = P.DoctorId,
                PatientId = P.PatientId,
                DoctorName = P.Doctor.FirstName+" "+P.Doctor.LastName,
                PatientName = P.Patient.FirstName+" "+P.Patient.LastName,
                TestName = P.Test.Name,
                PatientTestId = P.PatientTestId,
                TestDate = P.TestDate,
                IndoorPatientRecordId = P.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientTestResponse>> GetDoctorTestsByDate(int Doctor_id, DateTime date)
        {
            return await PatientTestRepository.GetDoctorTestsByDate(Doctor_id, date).Select(P => new PatientTestResponse()
            {
                CategoricalDetails = P.CategoricalDetails.Select(d => new CategoricalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.MeasuredValue,
                    NormalValue = ((TestParameterCategorical)d.TestParameter).Normalvalue,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                NumericalDetails = P.NumericalDetails.Select(d => new NeumericalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    NumericalValue = d.MeasuredValue,
                    Min_Range = ((TestParameterNumerical)d.TestParameter).Min_Range,
                    Max_Range = ((TestParameterNumerical)d.TestParameter).Max_Range,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                DoctorId = P.DoctorId,
                PatientId = P.PatientId,
                DoctorName = P.Doctor.FirstName+" "+P.Doctor.LastName,
                PatientName = P.Patient.FirstName+" "+P.Patient.LastName,
                TestName = P.Test.Name,
                PatientTestId = P.PatientTestId,
                TestDate = P.TestDate,
                IndoorPatientRecordId = P.IndoorPatientRecordId
            }).ToListAsync();
        }

        public async Task<IEnumerable<PatientTestResponse>> GetallPatientTests()
        {
            return await PatientTestRepository.GetAllPatientsTests().Select(P => new PatientTestResponse()
            {
                CategoricalDetails = P.CategoricalDetails.Select(d => new CategoricalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    MeasuredValue = d.MeasuredValue,
                    NormalValue = ((TestParameterCategorical)d.TestParameter).Normalvalue,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                NumericalDetails = P.NumericalDetails.Select(d => new NeumericalDetailsDto()
                {
                    TestParameterId = d.TestParameterId,
                    NumericalValue = d.MeasuredValue,
                    Min_Range = ((TestParameterNumerical)d.TestParameter).Min_Range,
                    Max_Range = ((TestParameterNumerical)d.TestParameter).Max_Range,
                    TestParameterName = d.TestParameter.TestParameterName,
                    Unit = d.TestParameter.Unit
                }).ToList(),
                DoctorId = P.DoctorId,
                PatientId = P.PatientId,
                DoctorName = P.Doctor.FirstName+" "+P.Doctor.LastName,
                PatientName = P.Patient.FirstName+" "+P.Patient.LastName,
                TestName = P.Test.Name,
                PatientTestId = P.PatientTestId,
                TestDate = P.TestDate,
                IndoorPatientRecordId = P.IndoorPatientRecordId
            }).ToListAsync();
        }
    }
}
