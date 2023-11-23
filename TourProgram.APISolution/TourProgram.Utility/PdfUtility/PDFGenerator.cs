//using Document = iTextSharp.text.Document;
using Document = iText.Layout.Document;
using Paragraph = iText.Layout.Element.Paragraph;
using TextAlignment = iText.Layout.Properties.TextAlignment;
using Table = iText.Layout.Element.Table;
using TourProgram.Model.Dtos.EmpTourPlanDtos;

namespace TourProgram.Utility.PdfUtility
{
    public  class PDFGenerator
    {
        public void GeneratePDF(TourPlanDetails employeeDetails, List<TentativeTourPlans> tentativeTourPlans, string outputPath)
        {
             
            // Create a new PDF document
            using (var pdfDocument = new iText.Kernel.Pdf.PdfDocument(new iText.Kernel.Pdf.PdfWriter(outputPath)))
            {
                var document = new Document(pdfDocument);

                // Add content to the PDF
                var title = new Paragraph("Employee Details").SetTextAlignment(TextAlignment.CENTER);
                document.Add(title);

                var employeeTable = new Table(new float[] { 1, 3 });
                employeeTable.AddCell("Employee No:");
                employeeTable.AddCell(employeeDetails.EmployeeNo != null ? employeeDetails.EmployeeNo : "N/A");
                employeeTable.AddCell("Employee Name:");
                employeeTable.AddCell(employeeDetails.EmployeeName != null ? employeeDetails.EmployeeName : "N/A");
                employeeTable.AddCell("Designation:");
                employeeTable.AddCell(employeeDetails.Designation != null ? employeeDetails.Designation : "N/A");
                employeeTable.AddCell("Purpose Of Tour:");
                employeeTable.AddCell(employeeDetails.PurposeOfTour != null ? employeeDetails.PurposeOfTour : "N/A");
                employeeTable.AddCell("Source:");
                employeeTable.AddCell(employeeDetails.Source != null ? employeeDetails.Source : "N/A");
                employeeTable.AddCell("Destination:");
                employeeTable.AddCell(employeeDetails.Destination != null ? employeeDetails.Destination : "N/A");
                employeeTable.AddCell("Employee Department:");
                employeeTable.AddCell(employeeDetails.EmployeeDepartment != null ? employeeDetails.EmployeeDepartment : "N/A");
                employeeTable.AddCell("Tentative Start Date:");
                employeeTable.AddCell(employeeDetails.TentativeStartDate != null ? employeeDetails.TentativeStartDate : "N/A");
                employeeTable.AddCell("No Of Days:");
                employeeTable.AddCell(employeeDetails.NoOfDays != null ? employeeDetails.NoOfDays : "N/A");
                employeeTable.AddCell("Units:");
                employeeTable.AddCell(employeeDetails.Units != null ? employeeDetails.Units : "N/A");
                // Add more cells for other employee details

                document.Add(employeeTable);

                // Add tentative tour plans
                var tentativePlansTitle = new Paragraph("Tentative Tour Plans").SetTextAlignment(TextAlignment.CENTER);
                document.Add(tentativePlansTitle);

                foreach (var plan in tentativeTourPlans)
                {

                    var planTable = new Table(new float[] { 1, 3 });
                    planTable.AddCell("Date:");
                    planTable.AddCell(plan.Date != null ? plan.Date : "N/A");
                    planTable.AddCell("From:");
                    planTable.AddCell(plan.From != null ? plan.From : "N/A");
                    planTable.AddCell("To:");
                    planTable.AddCell(plan.To != null ? plan.To : "N/A");
                    planTable.AddCell("Travel Mode:");
                    planTable.AddCell(plan.TravelMode != null ? plan.TravelMode : "N/A");
                    planTable.AddCell("Class Of City:");
                    planTable.AddCell(plan.ClassOfCity != null ? plan.ClassOfCity : "N/A");
                    planTable.AddCell("Remark:");
                    planTable.AddCell(plan.Remark != null ? plan.Remark : "N/A");
                    //planTable.AddCell(plan.Remark);

                    document.Add(planTable);
                }
            }
        }

        public string GenerateDownloadUrl(string filePath, string baseUrl)
        {
            string relativePath = filePath.Replace("wwwroot/", "").Replace("\\", "/");
            string downloadUrl = baseUrl + relativePath;
            return downloadUrl;
        }
    }
}
