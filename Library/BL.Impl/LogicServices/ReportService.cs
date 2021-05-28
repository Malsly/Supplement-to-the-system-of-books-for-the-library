using Aspose.Pdf;
using BL.Abs;
using BL.Imp;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Impl.LogicServices
{
    public class ReportService : IReportService
    {
        public Document CreateReport(DateTime StartDate, DateTime EndDate)
        {
            // Initialize document object
            Document document = new Document();

            // Add page
            Page page = document.Pages.Add();

            // Add text to new page
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Hello World!"));

            
            return document;
        }

        public IResult PrintReport(Document ReportDoc, string reportName)
        {
            // Save PDF 
            ReportDoc.Save(@$"D:\univer\unic3kurs\Cursova\Профес.практика програм.інж\proj\{reportName}.pdf");

            return new Result()
            {
                ResponceStatusType = ResponceStatusType.Successed
            };
        }
    }
}
