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
    public class PrescriptionRepository :GenericRepository<Prescription>, IPrescriptionRepository
    {
        private IUnitOfWork _unitOfWork;
        public PrescriptionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public IQueryable<Prescription> GetAllDoctorToPatientPrescriptions(int Patient_id, int doctor_id)
        {
            return _unitOfWork.Context.Prescriptions.Where(

               P => (P.PatientId == Patient_id) && (P.DoctorId== doctor_id)).Include(P => P.PrescriptionItems).OrderByDescending(P => P.Prescription_Date);

        }

        public IQueryable<Prescription> GetAllPrescriptonsByDocId(int doctor_id)
        {
            return _unitOfWork.Context.Prescriptions.Where(
                
                P => P.DoctorId == doctor_id).Include(P=>P.PrescriptionItems).OrderByDescending(P => P.Prescription_Date); ;
        }

        public IQueryable<Prescription> GetAllPrescriptonsForAll()
        {
            
            return _unitOfWork.Context.Prescriptions.Include(P => P.PrescriptionItems).OrderByDescending(P => P.Prescription_Date);
           
        }

        public IQueryable<Prescription> GetAllPrescriptonsForPatient(short Patient_id)
        {
            return _unitOfWork.Context.Prescriptions.Where(

                P => P.PatientId== Patient_id).Include(P => P.PrescriptionItems).OrderByDescending(P => P.Prescription_Date); 
        
    }

        public IQueryable<Prescription> GetDoctorPrescriptionsByDate(int doctor_id, DateTime PrescriptionDate)
        {
            return _unitOfWork.Context.Prescriptions.Where(

               P => (P.DoctorId == doctor_id) && (P.Prescription_Date == PrescriptionDate)).Include(P => P.PrescriptionItems);

        }

        public IQueryable<Prescription> GetPatientPrescriptionByDate(int Patient_id, DateTime PrescriptionDate)
        {
            return _unitOfWork.Context.Prescriptions.Where(

               P => (P.PatientId == Patient_id) && (P.Prescription_Date == PrescriptionDate)).Include(P => P.PrescriptionItems);


        }
    }
}