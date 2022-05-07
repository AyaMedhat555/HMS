using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.DTO;
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

        public async Task<Department> AddDepartment(Department department)
        {
            return await _departmentRepository.Add(department);
        }
        public async Task<IEnumerable<Department>> GetAllDepartments()
        {
            return await _departmentRepository.GetAll().ToListAsync();
        }
        public async Task<Department> DeleteDepartment(int id)
        {
            return await _departmentRepository.Delete(id);
        }

        public async Task<Department> UpdateDepartment(Department department)
        {
            return await _departmentRepository.Update(department);
        }

        public async Task<IEnumerable<DepartmentsEmps>> GetAllDepartmentsEmps()
        {
            List<Department> depts = await _departmentRepository.GetAll().ToListAsync();
            List<Doctor> docs = await _doctorRepository.GetAll().ToListAsync();
            List<Nurse> nurses = await _nurseRepository.GetAll().ToListAsync();
            List<DoctorDto> doctors = new List<DoctorDto>();
            List<NurseDto> nursesDtos = new List<NurseDto>();
            foreach (var doc in docs)
            {
                doctors.Add(UserMapper.ToDoctorDto(doc));
            }

            foreach (var nurse in nurses)
            {
                nursesDtos.Add(UserMapper.ToNurseDto(nurse));
            }
      var result = from dept in depts
                         join doctorsGroup in (
                            from d in doctors
                            group new DoctorDto{
                                Id = d.Id,
                                FirstName = d.FirstName,
                                LastName = d.LastName,
                            } by d.DepartmentId into g
                            select g
                         ) on dept.Id equals doctorsGroup.Key
                         join nursesGroup in (
                            from n in nursesDtos
                            group new NurseDto
                            {
                                Id = n.Id,
                                FirstName = n.FirstName,
                                LastName = n.LastName,
                            } by n.DepartmentId into g
                            select g
                         ) on dept.Id equals nursesGroup.Key
                         select new DepartmentsEmps()
                         {
                             DepartmentId = dept.Id,
                             DepartmentName = dept.Department_Name,
                             DoctorDtos = doctorsGroup.ToList(),
                             NurseDtos = nursesGroup.ToList()
                         };
            return result;
        }
    }
}
