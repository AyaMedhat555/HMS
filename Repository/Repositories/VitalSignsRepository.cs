using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Repository.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class VitalSignsRepository : GenericRepository<VitalSign>, IVitalSignsRepository
    {
        private IUnitOfWork _unitOfWork;
        public VitalSignsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }



        public IQueryable<VitalSign> GetVitalSignesByRangeOfDate(int PatientId, DateTime StartDate, DateTime EndDate)
        {
            //var T = _unitOfWork.Context.VitalSigns.Include("Nurse.FirstName").FirstOrDefault();

            return _unitOfWork.Context.VitalSigns.Where(

               V => (V.Patientid == PatientId) && (V.vitals_date >= StartDate && V.vitals_date <= EndDate)).Include(V => V.Nurse).Include(V=>V.Patient);


            //var test = context.Tests
            //      .Include("Question.QuestionLocale")
            //      .FirstOrDefault();

            //var test = context.Tests
            //    .Include(x => x.Question.Select(child => child.QuestionLocale))
            //    .FirstOrDefault()



            /*(IQueryable<VitalSign>)*/

            //      var blogs = context.Blogs
            //.Include(blog => blog.Posts)
            //.ThenInclude(post => post.Author)
            //.ToList();

            //return (IQueryable<VitalSign>)T;
        }

        //public  async Task  res GetVitalSignesByRangeOfDate2(int PatientId, DateTime StartDate, DateTime EndDate)
        //{
        //    var r= await  _unitOfWork.Context.VitalSigns.Where(

        //       V => (V.Patientid == PatientId) && (V.vitals_date >= StartDate && V.vitals_date <= EndDate)).Include(V => V.Nurse).Include(V => V.Patient);

        //    var y =  r.Select(r => new res {  name = r.Nurse.FirstName }).FirstOrDefault();
        //    return y;

        //    /*(IQueryable<VitalSign>)*/

        //    //      var blogs = context.Blogs
        //    //.Include(blog => blog.Posts)
        //    //.ThenInclude(post => post.Author)
        //    //.ToList();


        //}

    }
    
}