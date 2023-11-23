using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Utility.Eumus
{
    public static class EnumuDescription
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            return "";
        }
    }

    public enum RecordMasterClaimTypes
    {
        Advance = 1,
        AdvanceClaim = 2,
        Claim = 3,
        //TopUpAmount = 4
    }

    public enum RecordMasterIds
    {
        DoctorId = 5,
        HR_OneID = 4,
        EmpID = 3,
        HR_TwoID = 8,
        FinianceId = 7,
        BillPassingId = 6
    }

    public enum RecordMasterUplodDocType
    {
        Medicine = 1,
        MedicinenotinFinalBill = 2,
        Consultation = 3,
        Others = 4,
    }
    public enum RecordMasterTourRequestStatus
    {
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "Rejected")]
        Rejected = 5,
    }
    public enum RecordMasterClaimStatus
    {
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "FinanceProcessing")]
        FinanceProcessing = 3,
        [Display(Name = "Rejected")]
        Rejected = 5,
    }
    public enum RecordMasterClaimStatusCategory
    {
        [Display(Name = "ClaimInitiated")]
        PendingApproval = 1,
        [Display(Name = "Approved")]
        Approved = 2,
        [Display(Name = "FinanceProcessing")]
        FinanceProcessing = 3,
        [Display(Name = "Rejected")]
        Rejected = 5,
      

    }
    public enum RecordMasterUploadDocType
    {
        [Display(Name = "Travel")]
        Travel = 1,
        [Display(Name = "Accommodation")]
        Accommodation = 2
    }
}
