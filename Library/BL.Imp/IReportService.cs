using BL.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abs
{
    public interface IReportService
    {
        byte[] CreateReport(DateTime StartDate, DateTime EndDate);
        IResult PrintReport(byte[] ReportDoc);
    }
}
