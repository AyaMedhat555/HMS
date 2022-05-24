using Domain.Models;
using Domain.Models.Labs;
using Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IPatientReportService
    {
        PatientReport AddPatientReport(ReportEntry ReportEntry);
        PatientReport GetPatientReport(int PatientId, DateTime DateOfDischarge);
        IEnumerable<PatientScan> GetPatientScan(int IndoorPatientRecordId );


    }
}
