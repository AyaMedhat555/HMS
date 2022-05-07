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
        Task<Test> UpdateTest(Test test_dto);
        Task<IEnumerable<Test>> GetAllTests();
        Task<Test> GetTestById(int Test_id);
        Task<Test> DeleteTest(int Test_id);
        Task<Test> GetTestByName(String Testname);
    }
}
