using Domain.Models;
using Domain.Models.Labs;
using Repository.IRepositories;
using Service.IServices;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PatientReportService : IPatientReportService
    {

        private IPatientReportRepository _PatientReportRepository { get; }

        private IIndoorPatientRepository _IndoorPatientRepository { get; }

        private IPatientTestRepository  _IPatientTestRepository { get; }

        private IPatientScanRepository _PatientScanRepository { get; }
        private IPrescriptionRepository _PrescriptionRepository { get; }

        private IIndoorPatientService _IndoorPatientService { get; }

        private IBedRepository _BedRepository { get; }
        private IAdminService   _AdminService { get; }


        public PatientReportService(IPatientReportRepository PatientReportRepository, IIndoorPatientRepository IndoorPatientRepository, IPatientTestRepository PatientTestRepository, IPatientScanRepository PatientScanRepository, IPrescriptionRepository PrescriptionRepository, IIndoorPatientService IndoorPatientService, IBedRepository BedRepository, IAdminService adminService)
        {
            _PatientReportRepository = PatientReportRepository;
            _IndoorPatientRepository = IndoorPatientRepository;
            _IPatientTestRepository = PatientTestRepository;
            _PatientScanRepository = PatientScanRepository;
            _PrescriptionRepository = PrescriptionRepository;
            _IndoorPatientService = IndoorPatientService;
            _BedRepository = BedRepository;
            _AdminService = adminService;

        }

        public async Task<PatientReport> AddPatientReport(ReportEntry ReportEntry)
        {
            int PatientId = ReportEntry.PatientId;

            

            IndoorPatientRecord CurrentRecord = await _IndoorPatientRepository.GetLastRecordBeforeDischarging(PatientId);
            int IndoorPatientId = CurrentRecord.Id;
            DoctorPrescriptionResponce LastPrescription = await _IndoorPatientService.GetLastPrescriptionByIndoorPatientId(IndoorPatientId);


            List<Prescription> AllPrescriptions = _PrescriptionRepository.GetPrescriptionsByIndoorPatientId(IndoorPatientId, ReportEntry.DateOfDischarge).ToList();


          List <PrescriptionItem> AllMedicines = new List<PrescriptionItem>();
          List<PrescriptionItem> PrescriptionItems;

            for (int i = 0; i < AllPrescriptions.Count; i++)
            {

                foreach (var item in AllPrescriptions[i].PrescriptionItems)
                {
                    AllMedicines.Add(item);
                }



            }
///////////////////////////////////////////////TestNames////////////////////////////////////////

            List<string> AllTestsNames = new List<string> ();
            List<PatientTest> PatientTests = new List<PatientTest>();

            
            PatientTests = _IPatientTestRepository.GetInDoorPatientTests(IndoorPatientId).ToList();

            for (int k = 0; k < PatientTests.Count; k++)
            {
                string TestName;
                TestName = PatientTests[k].Test.Name;
                AllTestsNames.Add(TestName);
            }
            /////////////////////////////////////////////////Scan////////////////////////////////////////////

            List<string> AllScansNames = new List<string>();
            List<PatientScan> PatientScans;
            PatientScans = _PatientScanRepository.GetInDoorPatientScans(IndoorPatientId).ToList();
            string ScanName;

            for (int s = 0; s < PatientScans.Count; s++)
            {

                ScanName = PatientScans[s].Scan.ScanName;
                AllScansNames.Add(ScanName);
            }


            //////////////////////////////////////////PrepareReportObject/////////////////////////////////
            PatientReport PatientReport = new PatientReport()
            {
               Recommendation = ReportEntry.Recommendation,
               DateOfDischarge=ReportEntry.DateOfDischarge ,
               PatientId= ReportEntry.PatientId,
               CauseOfAdmission = CurrentRecord.CauseOfAdmission,
               LastPrescription= LastPrescription,
               ListOfMedicineNames= AllMedicines,
               ScanNames= AllScansNames,
               TestNames= AllTestsNames
            };

            CurrentRecord.Recommendation = ReportEntry.Recommendation;
            CurrentRecord.DischargeDate = ReportEntry.DateOfDischarge;
            CurrentRecord.Disharged = true;
            Bed bed = await _BedRepository.GetById(CurrentRecord.BedId);
            bed.Reserved = false;
            _BedRepository.Update(bed);
            

            _AdminService.ReserveRoom(CurrentRecord.RoomId);

            _IndoorPatientRepository.Update(CurrentRecord);

           return PatientReport;
        }

        public async Task < PatientReport > GetPatientReport(int PatientId, DateTime DateOfDischarge)
        {
            IndoorPatientRecord CurrentRecord = _IndoorPatientRepository.GetPatientReport(PatientId, DateOfDischarge);

            int IndoorPatientId = CurrentRecord.Id;
            DoctorPrescriptionResponce LastPrescription = await _IndoorPatientService.GetLastPrescriptionByIndoorPatientId(IndoorPatientId);


            List<Prescription> AllPrescriptions = _PrescriptionRepository.GetPrescriptionsByIndoorPatientId(IndoorPatientId, CurrentRecord.DischargeDate).ToList();


            List<PrescriptionItem> AllMedicines = new List<PrescriptionItem>();
            List<PrescriptionItem> PrescriptionItems;

            for (int i = 0; i < AllPrescriptions.Count; i++)
            {

                foreach (var item in AllPrescriptions[i].PrescriptionItems)
                {
                    AllMedicines.Add(item);
                }



            }
            ///////////////////////////////////////////////TestNames////////////////////////////////////////

            List<string> AllTestsNames = new List<string>();
            List<PatientTest> PatientTests = new List<PatientTest>();

            
            PatientTests = _IPatientTestRepository.GetInDoorPatientTests(IndoorPatientId).ToList();

            for (int k = 0; k < PatientTests.Count; k++)
            {
                string TestName;
                TestName = PatientTests[k].Test.Name;
                AllTestsNames.Add(TestName);
            }

            /////////////////////////////////////////////////Scan////////////////////////////////////////////

            int IndoorPatientRecordId = CurrentRecord.Id;
            List<string> AllScansNames = new List<string>();
            List<PatientScan> PatientScans = new List<PatientScan>();
            PatientScans = _PatientScanRepository.GetInDoorPatientScans(IndoorPatientRecordId).ToList();
            string ScanName;

            for (int s = 0; s < PatientScans.Count; s++)
            {

                ScanName = PatientScans[s].Scan.ScanName;
                AllScansNames.Add(ScanName);
            }

            //////////////////////////////////////////PrepareReportObject/////////////////////////////////
            PatientReport PatientReport = new PatientReport()
            {
                Recommendation = CurrentRecord.Recommendation,
                DateOfDischarge = CurrentRecord.DischargeDate,
                PatientId = CurrentRecord.PatientId,
                CauseOfAdmission = CurrentRecord.CauseOfAdmission,
                LastPrescription = LastPrescription,
                ListOfMedicineNames = AllMedicines,
                ScanNames = AllScansNames,
                TestNames = AllTestsNames,
                EnterDate= CurrentRecord.EnterDate

            };

            return PatientReport;

        }

        public IEnumerable<PatientScan> GetPatientScan(int IndoorPatientRecordId)
        {
            List<PatientScan> PatientScans = new List<PatientScan>();
            PatientScans = _PatientScanRepository.GetInDoorPatientScans(IndoorPatientRecordId).ToList();
            return PatientScans;
        }
    }
}



