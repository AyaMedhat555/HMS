using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.IServices;
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

        public MedicalTestService(IGenericRepository<Test> testRepository)
        {
            TestRepository=testRepository;
        }

        public async Task<Test> AddTest(Test test)
        {
            return await TestRepository.Add(test);
        }
        public async Task<Test> DeleteTest(int Test_id)
        {
            return await TestRepository.Delete(Test_id);
        }

        public async Task<IEnumerable<Test>> GetAllTests()
        {
            return await TestRepository.GetAll().ToListAsync();
        }

        public async Task<Test> GetTestById(int Test_id)
        {
            return await TestRepository.GetById(Test_id);
        }

        public async Task<Test> GetTestByName(string Testname)
        {
            var tests = await TestRepository.GetAll().ToListAsync();
            
            var newTest = from test in tests
            where test.Name == Testname
            select test;

            return newTest.SingleOrDefault();
        }

        public Task<Test> UpdateTest(Test test_dto)
        {
            throw new NotImplementedException();
        }
    }
}
