using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IPrescriptionRepository : IGenericRepository<Prescription>
    {
        IQueryable<Prescription> GetAllPrescriptonsByDocId(int doctor_id);
        IQueryable<Prescription> GetAllPrescriptonsForAll();
        IQueryable<Prescription> GetAllPrescriptonsForPatient(short Patient_id);
        IQueryable<Prescription> GetAllDoctorToPatientPrescriptions(int Patient_id,int doctor_id);
        IQueryable<Prescription> GetPatientPrescriptionByDate(int Patient_id, DateTime PrescriptionDate);
        IQueryable<Prescription> GetDoctorPrescriptionsByDate(int doctor_id, DateTime PrescriptionDate);
        Prescription GetPrescriptionsByInDoorPatient(int IndoorPatientRecordId);

        IQueryable<Prescription> GetPrescriptionsByIndoorPatientId(int IndoorPatientRecordId);

    }
}
