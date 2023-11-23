using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.Comman;

namespace TourProgram.BAL.Repository.Concrete
{
    public class CommanRepository : ICommanRepository
    {
        public async Task<List<UploadDocumentResponseModel>> UploadDocumets(List<IFormFile> files, string folderPathName = "AdmissionAdvice")
        {
            List<UploadDocumentResponseModel> filePaths = new();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string basePath = "wwwroot/UploadDocuments/" + folderPathName + "";
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string filePathName = basePath;
                        if (!Directory.Exists(filePathName))
                        {
                            Directory.CreateDirectory(filePathName);
                        }
                        string filePath = Path.Combine(filePathName, fileName); // Save in 'admission_advice' folder
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        // Save the file path to the model
                        filePath = filePath.Replace("wwwroot", "");
                        var uploadDocumentResponse = new UploadDocumentResponseModel { filePath = filePath, fileName = file.FileName };
                        filePaths.Add(uploadDocumentResponse);
                    }
                }
            }
            return filePaths;
        }
    }
}
