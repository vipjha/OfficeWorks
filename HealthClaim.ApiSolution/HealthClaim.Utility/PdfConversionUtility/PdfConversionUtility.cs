using System.Net;
using ZipFile = Ionic.Zip.ZipFile;
using iTextSharp.text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using iTextSharp.text.pdf;
using iTextSharp.text.exceptions;
using Document = iTextSharp.text.Document;
using Image = iTextSharp.text.Image;

namespace HealthClaim.Utility.PdfConversionUtility
{
    public class PdfConversionUtility
    {
        public void ConvertAndDownloadPDFs(List<string> pathUrlList, string outputZipFilePath)
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (var pathUrl in pathUrlList)
                {
                    if (IsUrlValid(pathUrl))
                    {
                        using (var webClient = new WebClient())
                        {
                            byte[] bytes = webClient.DownloadData(pathUrl);

                            if (IsPdf(bytes))
                            {
                                AddToZip(zip, bytes, Path.GetFileName(pathUrl));
                            }
                            else
                            {
                                Console.WriteLine($"Converting non-PDF file to PDF: {pathUrl}");
                                byte[] pdfBytes = ConvertToPdf(bytes, Path.GetFileName(pathUrl));
                                if (pdfBytes != null)
                                {
                                    AddToZip(zip, pdfBytes, Path.ChangeExtension(Path.GetFileName(pathUrl), ".pdf"));
                                }
                                else
                                {
                                    Console.WriteLine($"Failed to convert: {pathUrl}");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid URL: {pathUrl}");
                    }
                }

                zip.Save(outputZipFilePath);
            }
        }

        private void AddToZip(ZipFile zip, byte[] data, string entryName)
        {
            using (var stream = new MemoryStream(data))
            {
                zip.AddEntry(entryName, stream.ToArray());
            }
        }

        private bool IsPdf(byte[] data)
        {
            try
            {
                new PdfReader(data);
                return true;
            }
            catch (InvalidPdfException)
            {
                return false;
            }
        }

        private byte[] ConvertToPdf(byte[] data, string originalFileName)
        {
            using (MemoryStream pdfStream = new MemoryStream())
            {
                Document doc = new Document();
                PdfWriter writer = PdfWriter.GetInstance(doc, pdfStream);
                doc.Open();

                switch (Path.GetExtension(originalFileName).ToLower())
                {
                    case ".jpg":
                    case ".jpeg":
                    case ".png":
                    case ".gif":
                        Image img = Image.GetInstance(data);
                        doc.Add((IElement)img);
                        break;

                    case ".txt":
                    case ".doc":
                    case ".docx":
                        string textContent = System.Text.Encoding.UTF8.GetString(data);
                        doc.Add(new Paragraph(textContent));
                        break;

                    case ".xls":
                    case ".xlsx":
                        IWorkbook workbook;
                        if (Path.GetExtension(originalFileName).ToLower() == ".xls")
                        {
                            workbook = new HSSFWorkbook(new MemoryStream(data));
                        }
                        else
                        {
                            workbook = new XSSFWorkbook(new MemoryStream(data));
                        }

                        ISheet sheet = workbook.GetSheetAt(0);

                        foreach (IRow row in sheet)
                        {
                            foreach (ICell cell in row)
                            {
                                doc.Add(new Paragraph(cell.ToString()));
                            }
                        }
                        break;

                    default:
                        Console.WriteLine($"Unsupported file type: {originalFileName}");
                        return null;
                }
                doc.Close();
                return pdfStream.ToArray();
            }
        }

        private bool IsUrlValid(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }

        public string GenerateDownloadUrl(string filePath)
        {
            string baseUrl = "https://uat.dfccil.services.cetpainfotech.com";
            string relativePath = filePath.Replace("wwwroot", "").Replace("\\", "/");
            string downloadUrl = baseUrl + relativePath;
            return downloadUrl;
        }
    }
}
