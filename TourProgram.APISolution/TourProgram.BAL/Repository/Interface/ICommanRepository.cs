using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProgram.Model.Dtos.Comman;

namespace TourProgram.BAL.Repository.Interface
{
    public interface ICommanRepository
    {
        public Task<List<UploadDocumentResponseModel>> UploadDocumets(List<IFormFile> files, string folderPathName = "Cooman");

    }
}
