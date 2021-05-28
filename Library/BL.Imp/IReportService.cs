using BL.Imp;
using System;
using System.Collections.Generic;
using System.Text;
using Aspose.Pdf;


namespace BL.Abs
{
    public interface IReportService
    {
        Document CreateReport(DateTime StartDate, DateTime EndDate);
        IResult PrintReport(Document ReportDoc, string reportName);
    }
}
