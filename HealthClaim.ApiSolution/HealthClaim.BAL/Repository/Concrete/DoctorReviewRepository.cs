using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL.Models;
using HealthClaim.DAL;
using HealthClaim.Model.Dtos.Response;
using HealthClaim.Model.Dtos.DoctorReview;
using HealthClaim.Utility.Eumus;
using Microsoft.EntityFrameworkCore.Storage;
using iTextSharp.text.exceptions;
using iTextSharp.text.pdf;
using System.Net;
using ZipFile = Ionic.Zip.ZipFile;
using static System.Net.Mime.MediaTypeNames;
using iTextSharp.text;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using iTextSharp.text.html.simpleparser;
using static iTextSharp.text.pdf.AcroFields;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Microsoft.AspNetCore.Hosting;
using HealthClaim.Utility.PdfConversionUtility;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class DoctorReviewRepository : GenricRepository<DoctorReview>, IDoctorReviewRepository
    {
        private HealthClaimDbContext _dbContext;
        private readonly PdfConversionUtility _pdfConversionUtility;


        public DoctorReviewRepository(HealthClaimDbContext db, PdfConversionUtility pdfConversionUtility) : base(db)
        {
            _dbContext = db;
            _pdfConversionUtility = pdfConversionUtility;


        }


        //Created doctor review 
        public async Task<ResponeModel> Create(DoctorReviewDetailsModel doctorReviewDetailsModel)
        {

            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (doctorReviewDetailsModel != null)
            {
                DoctorReview doctorReviewDetail = new DoctorReview()
                {
                    ClaimId = doctorReviewDetailsModel.ClaimId,
                    AddmisionAdviseComment = doctorReviewDetailsModel.AddmisionAdviseComment,
                    DischargeSummaryComment = doctorReviewDetailsModel.DischargeSummaryComment,
                    InvestigationReportComment = doctorReviewDetailsModel.InvestigationReportComment,
                    IsSpecialDisease = doctorReviewDetailsModel.IsSpecialDisease,
                    IsTaxable = doctorReviewDetailsModel.IsTaxable,
                    Comment_1 = doctorReviewDetailsModel.Comment_1,
                    Comment_2 = doctorReviewDetailsModel.Comment_2,
                    Comment_3 = doctorReviewDetailsModel.Comment_3,
                    Comment_4 = doctorReviewDetailsModel.Comment_4,
                    Comment_5 = doctorReviewDetailsModel.Comment_5,
                    IsActive = doctorReviewDetailsModel.IsActive,
                    CreatedBy = 18,
                    CreatedDate = DateTime.Now,
                };
                _dbContext.Add(doctorReviewDetail);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = doctorReviewDetail;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Doctor review created successfully.";
            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback
            return responeModel;
        }

        //Get Review Details 
        public async Task<ResponeModel> GetReviewDetail(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var doctorReviewsDetails = _dbContext.DoctorReviews.Where(e => e.IsActive == true && e.Id != 7 && id == 0 ? e.Id == e.Id : e.Id == id).ToList();
            responeModel.Data = doctorReviewsDetails;
            responeModel.DataLength = doctorReviewsDetails.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = doctorReviewsDetails.Count + "Doctor review found.";

            return responeModel;
        }


        public async Task<ResponeModel> GetReviewData(long advanceId, string url)
        {
            ResponeModel responeModel = new ResponeModel();

            var query = from ea in _dbContext.EmpAdvances
                        join em in _dbContext.Employees on ea.EmplId equals em.Id
                        join empc in _dbContext.EmployeeClaims on ea.ClaimId equals empc.Id
                        join ecpd in _dbContext.EmpClaimProcessDetails on empc.Id equals ecpd.ClaimId
                        join ef in _dbContext.EmpFamilys on ea.PatientId equals ef.Id
                        join er in _dbContext.EmpRelations on ef.RelationId equals er.Id
                        join ut in _dbContext.UploadTypeDetails on ea.ClaimId equals ut.ClaimId
                        join ud in _dbContext.UploadDocuments on ut.Id equals ud.AdvanceUploadTypeId
                        join udt in _dbContext.UplodDocType on ut.UploadTypeId equals udt.Id
                        join ecs in _dbContext.EmpClaimStatus on ea.ClaimId equals ecs.ClaimId
                        join cs in _dbContext.ClaimStatusCategory on ecs.StatusId equals cs.Id
                        join e in _dbContext.Employees on ecs.CreatedBy equals e.Id
                        join ec in _dbContext.EmployeeClaims on ea.ClaimId equals ec.Id
                        where ea.Id == advanceId && ecpd.RecipientId == ((long)RecordMasterIds.DoctorId)
                        select new
                        {
                            EmployeeName = em.Name,
                            PatientName = ef.Name,
                            PatinetDBO = ef.DateOfBirth,
                            PatientGender = ef.Gender,
                            IsSpecailDisease = empc.IsSpecailDisease,
                            IsTaxable = empc.IsTaxable,
                            EmployeeDiclartion = ea.Declaration,
                            HospitalName = ea.HospitalName,
                            HospitalRegNo = ea.HospitalRegNo,
                            UploadFileName = ud.FileName,
                            PathUrl = ud.PathUrl,
                            DocumentType = udt.Name,
                            DocumentTypeId = udt.Id
                        };

            List<object> documentLists = new List<object>();
            if (query != null && query.Count() != 0)
            {

                var documentsType = query;
                foreach (var item in documentsType)
                {
                    if (item.DocumentTypeId == ((long)RecordMasterUplodDocType.HospitalIncomeTaxFile) || item.DocumentTypeId == ((long)RecordMasterUplodDocType.HospitalRegstrationDetailsFile))
                    {
                        var document = new { category = item.DocumentType, pathUrl = url + item.PathUrl };
                        documentLists.Add(document);
                    }
                }
                var claims = query.FirstOrDefault();
                var claimBasicDetails = new
                {
                    EmployeeName = claims.EmployeeName,
                    PatientName = claims.PatientName,
                    PatinetDBO = claims.PatinetDBO,
                    PatientGender = claims.PatientGender,
                    IsSpecailDisease = claims.IsSpecailDisease,
                    IsTaxable = claims.IsTaxable,
                    EmployeeDiclartion = claims.EmployeeDiclartion,
                    HospitalName = claims.HospitalName,
                    HospitalRegNo = claims.HospitalRegNo,
                };

                var advanceDetails = new { advanceBasicDetails = claimBasicDetails, documentLists = documentLists };
                responeModel.Data = advanceDetails;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Error = false;
                responeModel.Message = "Doctor page claim details";
            }

            else
            {
                responeModel.Data = null;
                responeModel.DataLength = 0;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.Error = false;
                responeModel.Message = "record not found.";
            }
            return responeModel;
            //throw new NotImplementedException();
        }

        //Update doctor review 
        public async Task<ResponeModel> Update(DoctorReviewDetailsModel doctorReviewDetailsModel, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (doctorReviewDetailsModel != null && id != 0)
            {
                var doctorReviewsdetail = _dbContext.DoctorReviews.Where(e => e.Id == id).FirstOrDefault();

                if (doctorReviewsdetail != null)
                {
                    doctorReviewsdetail.AddmisionAdviseComment = doctorReviewDetailsModel.AddmisionAdviseComment;
                    doctorReviewsdetail.DischargeSummaryComment = doctorReviewDetailsModel.DischargeSummaryComment;
                    doctorReviewsdetail.InvestigationReportComment = doctorReviewDetailsModel.InvestigationReportComment;
                    doctorReviewsdetail.IsSpecialDisease = doctorReviewDetailsModel.IsSpecialDisease;
                    doctorReviewsdetail.IsActive = doctorReviewDetailsModel.IsActive;
                    doctorReviewsdetail.UpdatedBy = 18;
                    doctorReviewsdetail.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = doctorReviewsdetail;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Doctor review updated successfully";
                }
            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback

            return responeModel;
            //throw new NotImplementedException();
        }

        public async Task<ResponeModel> PrintToDoctor(long advanceId, string url)
        {
            ResponeModel responeModel = new ResponeModel();

            var query = (from ecpd in _dbContext.EmpClaimProcessDetails
                        join ea in _dbContext.EmpAdvances on ecpd.ClaimId equals ea.ClaimId
                        join ef in _dbContext.EmpFamilys on ea.PatientId equals ef.Id
                        join emp in _dbContext.Employees on ea.EmplId equals emp.Id
                        join empRel in _dbContext.EmpRelations on ef.RelationId equals empRel.Id
                        join ec in _dbContext.EmployeeClaims on ea.ClaimId equals ec.Id
                        join claimType in _dbContext.ClaimTypes on ecpd.ClaimTypeId equals claimType.Id
                        join utd in _dbContext.UploadTypeDetails on ea.ClaimId equals utd.ClaimId
                        join udt in _dbContext.UplodDocType on utd.UploadTypeId equals udt.Id
                        join ud in _dbContext.UploadDocuments on utd.Id equals ud.AdvanceUploadTypeId
                       // where ea.Id == advanceId && (ud.AdvanceUploadTypeId == 11 || ud.AdvanceUploadTypeId == 12)
                        where ea.Id == advanceId && (ud.AdvanceUploadTypeId == (long)RecordMasterUplodDocType.Diagnosis || ud.AdvanceUploadTypeId == (long)RecordMasterUplodDocType.DischargeSummary)
                        select new
                        {
                            empAdvId = ea.Id,
                            EmployeeName = emp.Name,
                            patientName = ef.Name,
                            relation = empRel.Name,
                            ud.FileName,
                            PathUrl=url+ud.PathUrl,
                            ClaimId = ea.ClaimId,
                            UploadType = udt.Name,
                            UploadTypeId = ud.AdvanceUploadTypeId
                        }).ToList();

            var filesList = query.GroupBy(item => item.PathUrl).Select(group => group.First()).ToList();
            var documentClaimDetail = query.FirstOrDefault();
            var basicDetails = new
            {
                EmployeeName = documentClaimDetail.EmployeeName,
                patientName = documentClaimDetail.patientName,
                relation = documentClaimDetail.relation,
                ClaimId = documentClaimDetail.ClaimId,
            };
            var filesDetails = new { basicDetails = basicDetails, filesList = filesList };
            var PathUrlList = filesList.Select(d=>d.PathUrl).ToList();
            string basePath = "wwwroot/DownloadFolder/";
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            string outputZipFilePath = Path.Combine(basePath, filesDetails.basicDetails.EmployeeName + "_GeneratedFiles.zip");
            _pdfConversionUtility.ConvertAndDownloadPDFs(PathUrlList, outputZipFilePath);
            responeModel.Data = new
            {
               ZipDownloadUrl = _pdfConversionUtility.GenerateDownloadUrl(outputZipFilePath)
            };
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            return responeModel;
        }
    }
}
