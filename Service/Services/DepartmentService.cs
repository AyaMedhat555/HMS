using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.DTO.Users;
using Service.Helpers;
using Service.IServices;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class DepartmentService: IDepartmentService
    {
        private IDepartmentRepository _departmentRepository { get; }
        private IDoctorRepository _doctorRepository { get; }
        private INurseRepository _nurseRepository { get; }


        public DepartmentService(IDepartmentRepository iDepartmentRepository, IDoctorRepository iDoctorRepository, INurseRepository iNurseRepository)
        {
            _departmentRepository = iDepartmentRepository;
            _doctorRepository = iDoctorRepository;
            _nurseRepository = iNurseRepository;
        }

        public async Task<Department> AddDepartment(DepartmentResponse department)
        {

            return await _departmentRepository.Add(new Department()
            {
                Department_Name = department.DepartmentName,
                Location = department.DepartmentLocation,
                IsActive = department.IsActive
            });
        }
        public async Task<IEnumerable<DepartmentResponse>> GetAllDepartments()
        {
            return await _departmentRepository.GetAll().Select(d => new DepartmentResponse
            {
                DepartmentId = d.Id,
                DepartmentName = d.Department_Name,
                DepartmentLocation = d.Location == null ? "" : d.Location,
                IsActive = d.IsActive
            }).ToListAsync();
        }
        public async Task<Department> DeleteDepartment(int id)
        {
            return await _departmentRepository.Delete(id);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {            
            return await _departmentRepository.Update(department);
        }

        public async Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsEmps()
        {
            List<Department> departments = await _departmentRepository.GetAll().Include(D => D.Doctors).Include(D => D.Nurses).ToListAsync();
            List<DepartmentResponse> allDepartmentsEmps = new List<DepartmentResponse>();
            foreach (var dept in departments)
            {
                List<DoctorDto> docs = new List<DoctorDto>();
                List<NurseDto> nurses = new List<NurseDto>();
                foreach(var doc in dept.Doctors)
                {
                    DoctorDto doctorDto = new DoctorDto()
                    {
                        Id = doc.Id,
                        FirstName = doc.FirstName,
                        LastName = doc.LastName,
                        Age = doc.Age,
                        PhoneNumber = doc.PhoneNumber
                    };
                    docs.Add(doctorDto);
                }
                foreach(var nurse in dept.Nurses)
                {
                    NurseDto nurseDto = new NurseDto()
                    {
                        Id = nurse.Id,
                        FirstName = nurse.FirstName,
                        LastName = nurse.LastName,
                        Age = nurse.Age,
                        PhoneNumber = nurse.PhoneNumber
                    };
                    nurses.Add(nurseDto);
                }
                DepartmentResponse departmentemps = new DepartmentResponse()
                {
                    DepartmentId = dept.Id,
                    DepartmentName = dept.Department_Name,
                    DoctorDtos = docs,
                    NurseDtos = nurses
                };
                allDepartmentsEmps.Add(departmentemps);
            }
            return allDepartmentsEmps;
        }
        public async Task<IEnumerable<DepartmentResponse>> GetAllDepartmentsPatients()
        {
            List<Department> departments = await _departmentRepository.GetAll().Include(D => D.Patients).ToListAsync();
            List<DepartmentResponse> allDepartmentsResponses = new List<DepartmentResponse>();
            
            foreach (var dept in departments)
            {
                List<PatientDto> patients = new List<PatientDto>();
                foreach (var patient in dept.Patients)
                {
                    PatientDto patientDto = new PatientDto()
                    {
                        Id = patient.Id,
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        Age = patient.Age,
                        PhoneNumber = patient.PhoneNumber
                    };
                    patients.Add(patientDto);
                }
                DepartmentResponse departmentResponse = new DepartmentResponse()
                {
                    DepartmentId = dept.Id,
                    DepartmentName = dept.Department_Name,
                    PatientDtos = patients
                };
                allDepartmentsResponses.Add(departmentResponse);
            }
            return allDepartmentsResponses;

        }

        public async Task<DepartmentResponse> GetDepartmentEmpsById(int id)
        {
            var dept = await _departmentRepository.GetEmpsById(id);
            DepartmentResponse departmentResponse = new DepartmentResponse()
            {
                DepartmentId = dept.Id,
                DepartmentName= dept.Department_Name,
                IsActive = dept.IsActive,
                DoctorDtos = dept.Doctors.Select(d => new DoctorDto()
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Age = d.Age,
                    PhoneNumber = d.PhoneNumber
                }).ToList(),
                NurseDtos = dept.Nurses.Select(n => new NurseDto()
                {
                    Id = n.Id,
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    Age = n.Age,
                    PhoneNumber = n.PhoneNumber
                }).ToList()
            };
            return departmentResponse;
        }

        public async Task<DepartmentResponse> GetDepartmentPatientsById(int id)
        {
            var dept = await _departmentRepository.GetPatientsById(id);
            DepartmentResponse departmentResponse = new DepartmentResponse()
            {
                DepartmentId = dept.Id,
                DepartmentName= dept.Department_Name,
                IsActive = dept.IsActive,
                PatientDtos = dept.Patients.Select(p => new PatientDto()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age,
                    PhoneNumber = p.PhoneNumber
                }).ToList()
            };
            return departmentResponse;
        }

        public async Task<DepartmentResponse> GetDepartmentEmpsByName(string name)
        {
            var dept = await _departmentRepository.GetEmpsByName(name);
            DepartmentResponse departmentResponse = new DepartmentResponse()
            {
                DepartmentId = dept.Id,
                DepartmentName= dept.Department_Name,
                IsActive = dept.IsActive,
                DoctorDtos = dept.Doctors.Select(d => new DoctorDto()
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName,
                    Age = d.Age,
                    PhoneNumber = d.PhoneNumber
                }).ToList(),
                NurseDtos = dept.Nurses.Select(n => new NurseDto()
                {
                    Id = n.Id,
                    FirstName = n.FirstName,
                    LastName = n.LastName,
                    Age = n.Age,
                    PhoneNumber = n.PhoneNumber
                }).ToList()
            };
            return departmentResponse;
        }

        public async Task<DepartmentResponse> GetDepartmentPatientsByName(string name)
        {
            var dept = await _departmentRepository.GetPatientsByName(name);
            DepartmentResponse departmentResponse = new DepartmentResponse()
            {
                DepartmentId = dept.Id,
                DepartmentName= dept.Department_Name,
                IsActive = dept.IsActive,
                PatientDtos = dept.Patients.Select(p => new PatientDto()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age,
                    PhoneNumber = p.PhoneNumber
                }).ToList()
            };
            return departmentResponse;
        }
    }
}
