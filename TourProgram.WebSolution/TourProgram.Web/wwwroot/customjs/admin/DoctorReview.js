var recipientId = 4;
//Global Declartion
var documentDetails = {
    AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [], ITR: [], DischargeSummary: [], FinalHospitalBill: [],
    Investigation: [], MedicineNot: [], ConsultationNot: [], InvestigationNot: [], OtherNot: [], MedicinePre: [],
    ConsultationPre: [], InvestigationPre: [], ProcedurePre: [], OtherPre: [], RegdCertificate: [], ExemptionLetter: [], PostHospitalizationAdvice: [],

}
var totalMainApprovedBill = 0;
var totalMainNotApprovedBill = 0;
var totalMainPreApprovedBill = 0;
function calulateApprovedAmount(e, type) {
    totalMainApprovedBill = 0;
    totalMainNotApprovedBill = 0;
    for (var e of arrMainBill) {
        if (e.type == "Main") {
            totalMainApprovedBill += getAmountAfterCheckingNaNAndUndefind($("#" + e.key).val());
        }
        else {
            totalMainNotApprovedBill += getAmountAfterCheckingNaNAndUndefind($("#" + e.key).val());
        }
    }

    $("#spanSubTotal").html(totalMainApprovedBill + totalMainNotApprovedBill);
    $("#spanAmountIncludedMainBill").html(totalMainApprovedBill);
    $("#spanAmountNotIncludedMainBill").html(totalMainNotApprovedBill);
    debugger;
    $("#inputApprovedAmount").val(totalMainApprovedBill + totalMainNotApprovedBill + totalMainPreApprovedBill);
    /*alert(e.value + "  " + type);*/
}

function calulateApprovedAmountPre(e, type) {
    totalMainPreApprovedBill = 0;
    for (var e of arrMainBillPre) {
        totalMainPreApprovedBill += getAmountAfterCheckingNaNAndUndefind($("#" + e.key).val())
    }
    $("#tdPreHospitlizationTotal").html(totalMainPreApprovedBill);
    $("#inputApprovedAmount").val(totalMainApprovedBill + totalMainNotApprovedBill + totalMainPreApprovedBill);
}

var topUpDataDetails = [];

var spanTotalLimit = document.getElementById('spanTotalLimit');
var spanUsedLimit = document.getElementById('spanUsedLimit');
var spanBalanceLimit = document.getElementById('spanBalanceLimit');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegdNo = document.getElementById('inputHospitalRegdNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputDateOfAdmission = document.getElementById('inputDateOfAdmission');
var inputEstimateAmount = document.getElementById('inputEstimateAmount');
var inputAdvancePaid = document.getElementById('inputAdvancePaid');
var inputAdditionalDetails = document.getElementById('inputAdditionalDetails');
var inputTotalHospitalBill = document.getElementById('inputTotalHospitalBill');
var textareaClarification = document.getElementById('textareaClarification');

//Events
$(document).ready(function () {

    bindTableClaimApproved();


});
var doctroId = 5;
function bindTableClaimApproved() {

    var tblAdvanceClaim = $('#tbodyClaimApprovedList');
    var url = apiBaseUrl + "/api/Claim/GetDoctorsClaimList/" + doctroId.toString();

    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    $.ajax({
        type: "GET",
        url: url,
        //data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSeend: function () {
            $('.page-loader').show();

        },
        success: function (response) {
            console.log(response)
            console.log(response.statusCode)
            console.log(response.data)
            tblAdvanceClaim.append('');
            var count = 1;
            debugger;
            $.each(response.data, function () {
                var rowAdvanceApproved = ` <tr>
                            <td>${count}</td>
                              
                            <td>
                                ${this.employeeName}                               
                            </td>

                            <td>
                                ${this.patientName}
                            
                            </td>
                            <td>
                                   ${this.relation}
                                    
                            </td>
                           
                            <td>
                                 ${this.requestDate}
                                 
                            </td>                
                          
                            
                            
                            <td>
                                <a onclick="claimed_app(${this.empId},'${this.patientName}','${this.relation}','${this.claimId}','${this.employeeName}' ,'${this.patientId}' ,'${this.directClaimId}')" class="btn btn-primary">Details</a>&nbsp;&nbsp;
                            </td>
                        </tr>`;

                tblAdvanceClaim.append(rowAdvanceApproved);
                count++;
            });
            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function getformdetailes(directClaimId) {
    var url = apiBaseUrl + "/api/Claim/GetDirectClaimDetails/" + directClaimId;
    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    $.ajax({
        type: "GET",
        url: url,
        //data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSeend: function () {
            $('.page-loader').show();
        },
        success: function (response) {
            debugger;
            if (response.statusCode == 200) {
                $('#tdClaimApprovedPatientName').html(response.data.advanceBasicDetails.patientName);
                $('#tdClaimApprovedEmpRelation').html(response.data.advanceBasicDetails.relation);
                $('#tdClaimApprovedEmpDob').html(response.data.advanceBasicDetails.dateOfBirth);
                $('#tdClaimApprovedEmpGender').html(response.data.advanceBasicDetails.gender);
                $('#inputClaimApprovedHospitalName').val(response.data.advanceBasicDetails.hospitalName);
                $('#inputClaimApprovedHospitalRegNo').val(response.data.advanceBasicDetails.hospitalRegNo);
                $('#inputClaimApprovedDocterName').val(response.data.advanceBasicDetails.doctorName);
                $('#inputClaimApprovedDateOfAdmission').val(response.data.advanceBasicDetails.dateOfAdmission);
                $('#inputClaimApprovedDateOfAdmission').val(response.data.advanceBasicDetails.dateOfAdmission);

            }
            else {
                $('#tdClaimApprovedPatientName').html('');
                $('#tdClaimApprovedEmpRelation').html('');
                $('#tdClaimApprovedEmpDob').html('');
                $('#tdClaimApprovedEmpGender').html('');
                $('#inputClaimApprovedHospitalName').val('');
                $('#inputClaimApprovedHospitalRegNo').val('');
                $('#inputClaimApprovedDocterName').val('');
                $('#inputClaimApprovedDateOfAdmission').val('');
            }

            $('.page-loader').hide();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}


//Functions

var claimapproved = document.getElementById("claim_details");
var AdvanceId = 0;
var isDirect = false;
var arrMainBill = [];
var arrMainBillPre = [];
var cId = 0;
function claimed_app(empId, patientName, relation, directClaimId, empname, pId, aId) {
   // $("#divAdvanceApprovedDetails").css('display', 'block');
    debugger;
    cId = directClaimId;
    AdvanceId = aId;
    var url = apiBaseUrl + "/api/Claim/GetClaimDetails/" + AdvanceId;
    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    $.ajax({
        type: "GET",
        url: url,
        //data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        beforeSeend: function () {
            $('.page-loader').show();

        },
        success: function (response) {

            var JsonData = response.data;            
            $("#divAdvanceApprovedDetails").css('display', 'block');
            $("#divPatientDetails").css('display', 'block');
            $("#divPatientDetails").css('display', 'block');
            $("#divPreHospitlizationDetails").css('display', 'block');
            $("#divHospitlizationBillDetails").css('display', 'block');
            $("#divDeclarationEmployee").css('display', 'block');
            $("#divDeclarationDoctor").css('display', 'block');
            $("#divClaimApprovalForm").css('display', 'block');

            //$("#divDoctorReviewForm").css('display', 'block');
            $("#divAddComment").css('display', 'block');
            $("#divSubmit").css('display', 'block');
            if (JsonData.advanceBasicDetails.claimType == "Direct Claim") {
                isDirect = true;

                //$("#divAdvanceTakenDetails").css('display', 'none');

            }
            else {
                isDirect = false;
                $("#divAdvanceTakenDetails").css('display', 'block');
                $("#divApprovedAmount").css('display', 'block');
                $("#spanApprovedAmount").html(JsonData.advanceBasicDetails.claimApprovedAmount);

            }


            documentDetails.AdmissionAdviceUpload = response.data.documentLists.filter(e => e.category == 'AdmissionAdviceUpload');
            $("#spanAdmissionAdviceUploadView").html(documentDetails.AdmissionAdviceUpload.length);
            $("#spanAdmissionAdviceUploadViewDoctor").html(documentDetails.AdmissionAdviceUpload.length);
            documentDetails.DischargeSummary = response.data.documentLists.filter(e => e.category == 'DischargeSummary');
            $("#spanDischargeSummaryView").html(documentDetails.DischargeSummary.length);
            $("#spanDischargeSummaryViewDoctor").html(documentDetails.DischargeSummary.length);
            documentDetails.Investigation = response.data.documentLists.filter(e => e.category == 'Investigation');
            $("#spanInvestigationView").html(documentDetails.Investigation.length);
            $("#spanInvestigationViewDoctor").html(documentDetails.Investigation.length);

            documentDetails.EstimateAmount = response.data.documentLists.filter(e => e.category == 'EstimateAmount');
            $("#spanEstimateAmountView").html(documentDetails.EstimateAmount.length);
            documentDetails.FinalHospitalBill = response.data.documentLists.filter(e => e.category == 'FinalHospitalBill');
            $("#spanFinalHospitalBillView").html(documentDetails.FinalHospitalBill.length);

            tdPatientName.innerHTML = JsonData.advanceBasicDetails.patientName;
            tdPatientRelation.innerHTML = JsonData.advanceBasicDetails.relation;
            tdDateOfBirth.innerHTML = JsonData.advanceBasicDetails.dateOfBirth;
            tdGender.innerHTML = JsonData.advanceBasicDetails.gender;
            debugger;
            $("#radioSpecialDiseaseYes").prop('checked', JsonData.advanceBasicDetails.isSpecailDisease)
            $("#radioSpecialDiseaseNo").prop('checked', !JsonData.advanceBasicDetails.isSpecailDisease)
            $("#radioSpecialDiseaseYesDoctor").prop('checked', JsonData.advanceBasicDetails.isSpecailDisease)
            $("#radioSpecialDiseaseNoDoctor").prop('checked', !JsonData.advanceBasicDetails.isSpecailDisease)
            if (JsonData.advanceBasicDetails.isSpecailDisease) {
                $("#divSpecialDiseaseName").css('display', 'block');
                $("#inputSpecialDiseaseName").html(JsonData.advanceBasicDetails.diseaseName);
            }
            else {
                $("#divSpecialDiseaseName").css('display', 'none');
            }
           

            
            //$("#radioTaxableYes").prop('checked', JsonData.advanceBasicDetails.isTaxable)
            //$("#radioTaxableNo").prop('checked', !JsonData.advanceBasicDetails.isTaxable)
            //$("#radioTaxableYesHr").prop('checked', JsonData.advanceBasicDetails.isTaxable)
            //$("#radioTaxableNoHr").prop('checked', !JsonData.advanceBasicDetails.isTaxable)

            //if (JsonData.advanceBasicDetails.isTaxable) {
            //    $("#taxUploadDoc").css('display', 'none');
            //}
            //else {
            //    $("#taxUploadDoc").css('display', 'block');
            //    documentDetails.RegdCertificate = response.data.documentLists.filter(e => e.category == 'HospitalRegstrationDetailsFile');
            //    $("#spanRegdCertificateView").html(documentDetails.RegdCertificate.length);
            //    documentDetails.ExemptionLetter = response.data.documentLists.filter(e => e.category == 'HospitalIncomeTaxFile');
            //    $("#spanExemptionLetterView").html(documentDetails.ExemptionLetter.length);

            //}

            var iPH = JsonData.advanceBasicDetails.isPostHospitalization;
            $("#radioPostHospitalizationYes").prop('checked', iPH)
            $("#radioPostHospitalizationNo").prop('checked', !iPH)
            debugger;
            if (iPH) {
                /*alert('yes');*/
                $("#divPostHospitalDeclaration").css('display', 'block');
                $("#divPostHospitalDoc").css('display', 'block');
                documentDetails.PostHospitalizationAdvice = response.data.documentLists.filter(e => e.category == 'PostHospitalTreatmentAdviseUpload');
                $("#spanPostHospitalizationAdviceView").html(documentDetails.PostHospitalizationAdvice.length);

            }
            else {
                $("#divPostHospitalDeclaration").css('display', 'none');
                $("#divPostHospitalDoc").css('display', 'none');

            }

            $("#spanFinalHospitalBill").html(JsonData.advanceBasicDetails.finalHospitalBill);
            $("#inputTotalClaimRequested").val(JsonData.advanceBasicDetails.claimAmount);

            $("#spanHospitalName").html(JsonData.advanceBasicDetails.hospitalName);
            $("#spanDoctorName").html(JsonData.advanceBasicDetails.doctorName);
            $("#spanActualDateOfAdmission").html(formatDate(new Date(Date.parse(JsonData.advanceBasicDetails.dateOfAdmission))));
            $("#spanDateOfDisCharge").html(formatDate(new Date(Date.parse(JsonData.advanceBasicDetails.dateofDischarge))));
            $("#spanEstimatedAmount").html(JsonData.advanceBasicDetails.estimatedAmount);
            $("#spanAdvanceRequestedAmount").html(JsonData.advanceBasicDetails.advanceAmount);
            $("#spanTreatmentType").html(JsonData.advanceBasicDetails.ctreatmentType);
            $("#spanDiagnosis").html(JsonData.advanceBasicDetails.digonosis);
            $("#spanPayTo").html(JsonData.advanceBasicDetails.payTo);
            //// Add Beneficiary Details
            debugger;
            // alert(JsonData.advanceBasicDetails.payTo.toUpperCase());
            if (JsonData.advanceBasicDetails.payTo.toUpperCase() == "HOSPITAL") {
                $("#divbankdetails").css('display', 'block');
                $("#spanBeneficiaryName").html(JsonData.hospitalAccoundetail.beneficiaryName);
                $("#spanAccountNo").html(JsonData.hospitalAccoundetail.accountNumber);
                $("#spanBankName").html(JsonData.hospitalAccoundetail.bankName);
                $("#spanBranchName").html(JsonData.hospitalAccoundetail.branchName);
                $("#spanIFSCCode").html(JsonData.hospitalAccoundetail.ifscCode);
                $("#spanGstNo").html(JsonData.hospitalAccoundetail.hospitalGSTNo);
                $("#spanUTRNo").html(JsonData.hospitalAccoundetail.utrNo);
                //$("#spanPayTo").html(JsonData.hospitalAccoundetail.transactionDate);
                //$("#spanPayTo").html(JsonData.hospitalAccoundetail.isHospitalEmpanpanelled);
                // $("#spanPayTo").html(JsonData.hospitalAccoundetail.hospitalId);
                $("#spanSAPReferenceNo").html(JsonData.hospitalAccoundetail.sapRefNumber);
                $("#spanTransactionDate").html(JsonData.hospitalAccoundetail.sapRefDate);
            }
            else {
                $("#divbankdetails").css('display', 'none');
            }
            /// Add HospitlizationData
            arrMainBill.length = 0;
            arrMainBillPre.length = 0;
            arrMainBill.push({ keyComment: 'Medicine', keyTextAreaComment: 'textAreaMedicineComment', key: 'inputMedicineApproved', key2: 'HospitalizationBillApprovelDetails.MedicineAmount', type: 'Main' });
            $("#inputMedicineBilled").val(JsonData.billDetails.medicineBill);
            $("#inputMedicineClaimed").val(JsonData.billDetails.medicineClaim);
            $("#inputMedicineApproved").val(JsonData.billDetails.medicineClaim);
            var arrMedicineNot = JsonData.notInMainBills.filter(e => e.billType == "Medicen Not In Final Bill");
            if (arrMedicineNot.length != 0) {
                arrMainBill.push({ keyComment: 'MedicineNotIn', keyTextAreaComment: 'textAreaMedicineNotComment', key: 'inputMedicineNotApproved', key2: 'HospitalizationBillApprovelDetails.MedicineNotInAmount', type: 'MainNot' });
                $("#trMedicineNot").css('display', '');
                $("#inputMedicineNotBilled").val(getAmountAfterCheckingNaNAndUndefind(arrMedicineNot[0].billAmount));
                $("#inputMedicineNotClaimed").val(getAmountAfterCheckingNaNAndUndefind(arrMedicineNot[0].billClaimAmount));
                $("#inputMedicineNotApproved").val(getAmountAfterCheckingNaNAndUndefind(arrMedicineNot[0].billClaimAmount));
                documentDetails.MedicineNot = response.data.documentLists.filter(e => e.category == 'Medicine not in Final bill');
                $("#spanMedicineNotView").html(documentDetails.MedicineNot.length);

            }
            else {
                $("#trMedicineNot").css('display', 'none');
            }

            ///ConsultationNot
            arrMainBill.push({ keyComment: 'Consultation', keyTextAreaComment: 'textAreaConsultationComment', key: 'inputConsultationApproved', key2: 'HospitalizationBillApprovelDetails.ConsultationAmount', type: 'Main' });
            $("#inputConsultationBilled").val(JsonData.billDetails.consultationBill);
            $("#inputConsultationClaimed").val(JsonData.billDetails.consultationClaim);
            $("#inputConsultationApproved").val(JsonData.billDetails.consultationClaim);
            var arrConsultationNot = JsonData.notInMainBills.filter(e => e.billType == "Consultation Not In Final Bill");
            if (arrConsultationNot.length != 0) {
                arrMainBill.push({ keyComment: 'ConsultationNotIn', keyTextAreaComment: 'textAreaConsultationNotComment', key: 'inputConsultationNotApproved', key2: 'HospitalizationBillApprovelDetails.ConsultationNotInAmount', type: 'MainNot' });
                $("#trConsultationNot").css('display', '');
                $("#inputConsultationNotBilled").val(getAmountAfterCheckingNaNAndUndefind(arrConsultationNot[0].billAmount));
                $("#inputConsultationNotClaimed").val(getAmountAfterCheckingNaNAndUndefind(arrConsultationNot[0].billClaimAmount));
                $("#inputConsultationNotApproved").val(getAmountAfterCheckingNaNAndUndefind(arrConsultationNot[0].billClaimAmount));
                documentDetails.ConsultationNot = response.data.documentLists.filter(e => e.category == 'ConsultationNotFinalBill');
                $("#spanConsultationNotView").html(documentDetails.ConsultationNot.length);

            }
            else {
                $("#trConsultationNot").css('display', 'none');
            }

            ///InvestigationNot
            arrMainBill.push({ keyComment: 'Investigation', keyTextAreaComment: 'textAreaInvestigationComment', key: 'inputInvestigationApproved', key2: 'HospitalizationBillApprovelDetails.InvestigationAmount', type: 'Main' });
            $("#inputInvestigationBilled").val(JsonData.billDetails.investigationBill);
            $("#inputInvestigationClaimed").val(JsonData.billDetails.investigationClaim);
            $("#inputInvestigationApproved").val(JsonData.billDetails.investigationClaim);
            var arrInvestigationNot = JsonData.notInMainBills.filter(e => e.billType == "Investigation Not In FinalBill");
            if (arrInvestigationNot.length != 0) {
                arrMainBill.push({ keyComment: 'InvestigationNotIn', keyTextAreaComment: 'textAreaInvestigationNotComment', key: 'inputInvestigationNotApproved', key2: 'HospitalizationBillApprovelDetails.InvestigationNotInAmount', type: 'MainNot' });
                $("#trInvestigationNot").css('display', '');
                $("#inputInvestigationNotBilled").val(getAmountAfterCheckingNaNAndUndefind(arrInvestigationNot[0].billAmount));
                $("#inputInvestigationNotClaimed").val(getAmountAfterCheckingNaNAndUndefind(arrInvestigationNot[0].billClaimAmount));
                $("#inputInvestigationNotApproved").val(getAmountAfterCheckingNaNAndUndefind(arrInvestigationNot[0].billClaimAmount));
                documentDetails.InvestigationNot = response.data.documentLists.filter(e => e.category == 'InvestigationNotFinalBill');
                $("#spanInvestigationNotView").html(documentDetails.ConsultationNot.length);

            }
            else {
                $("#trInvestigationNot").css('display', 'none');
            }

            ///OtherNot
            arrMainBill.push({ keyComment: 'Other', keyTextAreaComment: 'textAreaOtherComment', key: 'inputOtherApproved', key2: 'HospitalizationBillApprovelDetails.OtherAmount', type: 'Main' });
            $("#inputOtherBilled").val(JsonData.billDetails.othersBill);
            $("#inputOtherClaimed").val(JsonData.billDetails.otherClaim);
            $("#inputOtherApproved").val(JsonData.billDetails.otherClaim);
            var arrOtherNot = JsonData.notInMainBills.filter(e => e.billType == "Other Bill Not In FinalBill");
            if (arrOtherNot.length != 0) {
                arrMainBill.push({ keyComment: 'OtherNotIn', keyTextAreaComment: 'textAreaOtherNotComment', key: 'inputOtherNotApproved', key2: 'HospitalizationBillApprovelDetails.OtherNotInAmount', type: 'MainNot' });
                $("#trOtherNot").css('display', '');
                $("#inputOtherNotBilled").val(getAmountAfterCheckingNaNAndUndefind(arrOtherNot[0].billAmount));
                $("#inputOtherNotClaimed").val(getAmountAfterCheckingNaNAndUndefind(arrOtherNot[0].billClaimAmount));
                $("#inputOtherNotApproved").val(getAmountAfterCheckingNaNAndUndefind(arrOtherNot[0].billClaimAmount));
                documentDetails.OtherNot = response.data.documentLists.filter(e => e.category == 'OtherBillNotFinalBill');
                $("#spanOtherNotView").html(documentDetails.OtherNot.length);

            }
            else {
                $("#trOtherNot").css('display', 'none');
            }

            ///RoomRent
            arrMainBill.push({ keyComment: 'RoomRent', keyTextAreaComment: 'textAreaRoomRentComment', key: 'inputRoomRentApproved', key2: 'HospitalizationBillApprovelDetails.RoomRentAmount', type: 'Main' });
            $("#inputRoomRentBilled").val(JsonData.billDetails.roomRentBill);
            $("#inputRoomRentClaimed").val(JsonData.billDetails.roomRentClaim);
            $("#inputRoomRentApproved").val(JsonData.billDetails.roomRentClaim);

            ///Procedure
            arrMainBill.push({ keyComment: 'Procedure', keyTextAreaComment: 'textAreaProcedureComment', key: 'inputProcedureApproved', key2: 'HospitalizationBillApprovelDetails.ProcedureAmount', type: 'Main' });
            $("#inputProcedureBilled").val(JsonData.billDetails.procedureBill);
            $("#inputProcedureClaimed").val(JsonData.billDetails.procedureClaim);
            $("#inputProcedureApproved").val(JsonData.billDetails.procedureClaim);


            // Add PreHospitlizationData

            if (JsonData.preHospitalizationExpenses.isPresHospitalzation) {
                $("#divPreHospitlizationDetails").css('display', 'block');
                arrMainBillPre.push({ keyComment: 'Procedure', keyTextAreaComment: 'textAreaMedicinePreComment', key: 'inputMedicinePreApprovedAmount', key2: 'PreHospitalizationExpenses.MedicineAmount', type: 'Main' });
                $("#inputMedicinePreBilledDate").val(formatDate(new Date(Date.parse(JsonData.preHospitalizationExpenses.medicineBillDate))));
                $("#inputMedicinePreBilledAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.medicineBillAmount));
                $("#inputMedicinePreClaimedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.medicineClaimAmount));
                $("#inputMedicinePreApprovedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.medicineClaimAmount));
                documentDetails.MedicinePre = response.data.documentLists.filter(e => e.category == 'PreHospitalizationExpensesMedicine');
                $("#spanMedicinePreView").html(documentDetails.MedicinePre.length);

                arrMainBillPre.push({ keyComment: 'Procedure', keyTextAreaComment: 'textAreaConsultationPreComment', key: 'inputConsultationPreApprovedAmount', key2: 'PreHospitalizationExpenses.ConsultationAmount', type: 'Main' });
                $("#inputConsultationPreBilledDate").val(formatDate(new Date(Date.parse(JsonData.preHospitalizationExpenses.consultationBillDate))));
                $("#inputConsultationPreBilledAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.consultationBillAmount));
                $("#inputConsultationPreClaimedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.consultationClaimAmount));
                $("#inputConsultationPreApprovedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.consultationClaimAmount));
                documentDetails.ConsultationPre = response.data.documentLists.filter(e => e.category == 'PreHospitalizationExpensesConsultation');
                $("#spanConsultationPreView").html(documentDetails.ConsultationPre.length);

                arrMainBillPre.push({ keyComment: 'Procedure', keyTextAreaComment: 'textAreaInvestigationPreComment', key: 'inputInvestigationPreApprovedAmount', key2: 'PreHospitalizationExpenses.InvestigationAmount', type: 'Main' });
                $("#inputInvestigationPreBilledDate").val(formatDate(new Date(Date.parse(JsonData.preHospitalizationExpenses.investigationBillDate))));
                $("#inputInvestigationPreBilledAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.investigationBillAmount));
                $("#inputInvestigationPreClaimedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.investigationClaimAmount));
                $("#inputInvestigationPreApprovedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.investigationClaimAmount));
                documentDetails.InvestigationPre = response.data.documentLists.filter(e => e.category == 'PreHospitalizationExpensesConsultation');
                $("#spanInvestigationPreView").html(documentDetails.InvestigationPre.length);

                arrMainBillPre.push({ keyComment: 'Procedure', keyTextAreaComment: 'textAreaProcedurePreComment', key: 'inputProcedurePreApprovedAmount', key2: 'PreHospitalizationExpenses.ProcedureAmount', type: 'Main' });
                $("#inputProcedurePreBilledDate").val(formatDate(new Date(Date.parse(JsonData.preHospitalizationExpenses.procedureBillDate))));
                $("#inputProcedurePreBilledAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.procedureBillAmount));
                $("#inputProcedurePreClaimedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.procedureClaimAmount));
                $("#inputProcedurePreApprovedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.procedureClaimAmount));
                documentDetails.ProcedurePre = response.data.documentLists.filter(e => e.category == 'PreHospitalizationProcedure');
                $("#spanProcedurePreView").html(documentDetails.ProcedurePre.length);

                arrMainBillPre.push({ keyComment: 'Procedure', keyTextAreaComment: 'textAreaOtherPreComment', key: 'inputOtherPreApprovedAmount', key2: 'PreHospitalizationExpenses.OtherAmount', type: 'Main' });
                $("#inputOtherPreBilledDate").val(formatDate(new Date(Date.parse(JsonData.preHospitalizationExpenses.othersBillDate))));
                $("#inputOtherPreBilledAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.otherBillAmount));
                $("#inputOtherPreClaimedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.otherClaimAmount));
                $("#inputOtherPreApprovedAmount").val(getAmountAfterCheckingNaNAndUndefind(JsonData.preHospitalizationExpenses.otherClaimAmount));
                documentDetails.OtherPre = response.data.documentLists.filter(e => e.category == 'PreHospitalizationExpensesOther');
                $("#spanOtherPreView").html(documentDetails.OtherPre.length);

            }
            else {
                $("#divPreHospitlizationDetails").css('display', 'none');
            }




            //documentDetails.Diagnosis = response.data.documentLists.filter(e => e.category == 'Diagnosis');
            //$("#spanDiagnosisView").html(documentDetails.Diagnosis.length);

            if (JsonData.topUpDetails.length != 0) {
                IsTopUp = true;

                $("#divbankdetails").css('display', 'block');
                if (JsonData.advanceBasicDetails.payTo.toUpperCase() == "SELF") {
                    $("#divbankdetails").css('display', 'none');
                    //$("#spanBeneficiaryName").html(JsonData.hospitalAccoundetail.beneficiaryName);
                    ////$("#spanGstNo").html(JsonData.hospitalAccoundetail.hospitalGSTNo);
                    //$("#spanBankName").html(JsonData.hospitalAccoundetail.bankName);
                    //$("#spanIFSCCode").html(JsonData.hospitalAccoundetail.ifscCode);
                    //$("#spanAccountNo").html(JsonData.hospitalAccoundetail.accountNumber);
                    //$("#spanUTRNo").html(JsonData.hospitalAccoundetail.utrNo);
                    //// Two Field Required
                    //$("#spanSAPReferenceNo").html(JsonData.hospitalAccoundetail.sapRefNumber);
                    //$("#spanTransactionDate").html(JsonData.hospitalAccoundetail.transactionDate);

                }
                else {

                    $("#spanBeneficiaryName").html(JsonData.hospitalAccoundetail.beneficiaryName);
                    $("#spanGstNo").html(JsonData.hospitalAccoundetail.hospitalGSTNo);
                    $("#spanBankName").html(JsonData.hospitalAccoundetail.bankName);
                    $("#spanIFSCCode").html(JsonData.hospitalAccoundetail.ifscCode);
                    $("#spanAccountNo").html(JsonData.hospitalAccoundetail.accountNumber);
                    $("#spanUTRNo").html(JsonData.hospitalAccoundetail.utrNo);
                    // Two Field Required
                    $("#spanSAPReferenceNo").html(JsonData.hospitalAccoundetail.sapRefNumber);
                    $("#spanTransactionDate").html(JsonData.hospitalAccoundetail.transactionDate);


                }

            }
            else {
                IsTopUp = false;
                $("#divApprovedAmount").css('display', 'none');
                $("#divbankdetails").css('display', 'none');
                $("#inputNewEstimatedAmount").val(JsonData.advanceBasicDetails.estimatedAmount);
            }


            //addTopUpDetail(JsonData.topUpDetails);
            calulateApprovedAmount();
            calulateApprovedAmountPre();

            $('.page-loader').hide();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
    ShowHideParentLimit(relation, pId, true);

}

var isParent = false;
function ShowHideParentLimit(relation, familyId, isView = false) {
    if (relation.toUpperCase().includes('FATHER') || relation.toUpperCase().includes('MOTHER')) {
        isParent = true;

        getItrDetailsOfParentFromApi(familyId, isView);
    }
    else {
        if (isView) {
            debugger;
            $("#divParentClaimLimitView").css('display', 'none');
            $("#itrParentView").css('display', 'none');

        }
        else {
            divParentClaimLimt.style.display = 'none';
            itrParent.style.display = 'none';
        }
        isParent = false;
    }
}
function getItrDetailsOfParentFromApi(familyId, isView) {
    var _url = apiBaseUrl + "​/api/Common/GetITRDetails/" + familyId;
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    // Start Loader Here
    getApiCall(_url, success, failour);
    function success(response) {
        var jsonData = response.data;
        debugger;
        if (response.statusCode == 200 && response.message == "ITR Details found.") {
            if (isView) {
                $("#divParentClaimLimitView").css('display', 'block');
                $("#itrParentView").css('display', 'block');
                $("#anchorItrView").attr('href', jsonData.itrFilePath);
                spanTotalLimitView.innerHTML = jsonData.totalLimit;
                spanUsedLimitView.innerHTML = jsonData.usedLimit;
                spanBalanceLimitView.innerHTML = parseInt(jsonData.totalLimit) - parseInt(jsonData.usedLimit);
            }
            else {
                divParentClaimLimt.style.display = 'block';
                itrParent.style.display = 'block';
                $("#anchorItr").attr('href', jsonData.itrFilePath);
                spanTotalLimit.innerHTML = jsonData.totalLimit;
                spanUsedLimit.innerHTML = jsonData.usedLimit;
                spanBalanceLimit.innerHTML = parseInt(jsonData.totalLimit) - parseInt(jsonData.usedLimit);

            }

        }
        else {
            divParentClaimLimt.style.display = 'block';
            itrParent.style.display = 'none';

            //swal({
            //    title: 'Invalid !',
            //    text: 'Your Parents Valid ITR Detail is not available with us Please visit profile section and upload valid ITR Details',
            //    type: 'error'
            //});
        }
        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}

function TrigerModalViewFile(type, type2) {
    $("#viewModal").modal('show');
    $("#modelTitle").html(type)
    $("#tbodyViewDocuments").empty();
    count = 1;
    // debugger;
    for (let e of documentDetails[type2]) {
        let row = ` <tr>
                                         <td>${count}.</td>
                                         <td>${type}</td>
                                         <td><a target="_blank" href="${e.pathUrl}" class="file-link"><span class="ti-files"></span></a></td>
                                     </tr>`;
        $("#tbodyViewDocuments").append(row)
        count++;
    }
    //$('#myModalTitle').html(type);
    //$('#spnComment').html(type);
    //loadUploadedFile(type2);
}

function TrigerModalViewFileTopUp(type, type2, index) {
    $("#viewModal").modal('show');
    $("#modelTitle").html(type)
    $("#tbodyViewDocuments").empty();
    count = 1;
    //debugger;top
    for (let e of topUpDataDetails[index].ReviseEstimateFiles) {
        let row = ` <tr>
                                         <td>${count}.</td>
                                         <td>${type}</td>
                                         <td><a target="_blank" href="${e}" class="file-link"><span class="ti-files"></span></a></td>
                                     </tr>`;
        $("#tbodyViewDocuments").append(row)
        count++;
    }
    //$('#myModalTitle').html(type);
    //$('#spnComment').html(type);
    //loadUploadedFile(type2);
}


function addTopUpDetail(topUpDetails) {
    topUpDataDetails.length = 0;
    debugger;
    if (topUpDetails.length != 0) {
        for (let e of topUpDetails) {
            var path = []
            for (let p of e.reviseEstimateFiles) {
                path.push(p.filePath);
            }
            var topUpObject = { ReviseEstimateAmount: e.reviseEstimentedAmount, RequiredTopUpAmount: e.topRequiredAmount, ApprovedTopUpAmount: e.approvedAmount, ReviseEstimateFiles: path }
            topUpDataDetails.push(topUpObject);
        }

    }

    let count = 0;
    $("#topUpDetails").empty();
    for (let e of topUpDataDetails) {
        var newDiv = `<div  class="col-lg-12 grid-margin stretch-card">
    <div class="card">
        <div class="card-body">
            <h4 class="card-title mt-1 mb-2"><span>${count + 1}.</span>&nbsp; Top Up Details</h4>
            <div class="row">
                <div class="col-md-6 mt-2">
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">Revise Estimate Amount</label>
                        <div class="col-sm-3 estimatemobile">
                            <input id="inputReviseEstimateAmount${count + 1}" type="tel" value="${e.ReviseEstimateAmount}" class="form-control amt" placeholder="₹ 1,80,000.00" readonly>
                        </div>
                        <div class="col-sm-4 estimatemobileupload">
                            <div class="form-group">
                                <button type="button" onclick="TrigerModalViewFileTopUp('Revise Estimate Amount','ReviseEstimateAmount',${count})" class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File <span id="spanReviseEstimateAmount${count + 1}" class="file-status">${topUpDataDetails[count].ReviseEstimateFiles.length}</span>  </button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-2">
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">Requested Top Up Amount</label>
                        <div class="col-sm-7">
                            <input id="inputTopUpAmountRequired${count}" value="${e.RequiredTopUpAmount}" type="text" class="form-control amo" placeholder="₹ 80,000.00" readonly>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 mt-2">
                    <div class="form-group row">
                        <label class="col-sm-5 col-form-label">Approved Top Up Amount</label>
                        <div class="col-sm-7">
                            <input id="inputTopUpApprovedAmount${count}" value="${e.ApprovedTopUpAmount}"  type="text" class="form-control amo" placeholder="₹ 80,000.00" readonly>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>`;
        $("#topUpDetails").append(newDiv);
        count++;
    }
}


function seekClarification_Click(e) {
    senderId = 4;
    var claimTypeId = 0;
    if (isDirect) {
        claimTypeId = 3;
    }
    else {
        claimTypeId = 2;
    }
    if (recipientId == 5) {
        statusId = 5;
    }
    if (recipientId == 8) {
        statusId = 3;
    }
    const formDataNew = new FormData();
    formDataNew.append('AdvanceId', AdvanceId);
    formDataNew.append('SenderId', senderId);
    //formDataNew.append('RecipientId', recipientId);
    formDataNew.append('ClaimTypeId', claimTypeId);

    //formDataNew.append('StatusId', statusId);

    for (let e of arrMainBill) {
        if ($('#' + e.keyTextAreaComment).val() != "") {
            formDataNew.append(e.keyComment, $('#' + e.keyTextAreaComment).val());
        }

    }
    if ($("#textAreaClaimApprovedClarification").val() != "") {
        formDataNew.append('OverallClarification', $("#textAreaClaimApprovedClarification").val());

    }


    //var _url = 'https://uat.dfccil.services.cetpainfotech.com/api/Claim/AdvanceRequest​';
    var _url = apiBaseUrl + "​​/api​/Claim​/BillClarificationRequest";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    $.ajax({
        type: "POST",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            $("#seekClarification").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if ((response.statusCode == 201) || (response.statusCode == 200)) {
                swal({
                    title: 'Awesome !',
                    text: response.message,
                    type: 'success'
                });
            }
            else {
                swal({
                    title: 'Invalid !',
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#seekClarification").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#seekClarification").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}

var recipientId = 4;//for Finanace
var recipientIdForDoctor = 5;//for Finanace
var senderId = 4;//for Hr1
var claimTypeIdAdvanceClaim = 2;
var claimTypeIdDirectClaim = 3;
var statusId = 5;//for Doctor Processing
var IsDirectClaim = true;
function btnSendToDoctor_Click(e) {
    //alert('Send to Finance Work in Progress');
    debugger;
    var date = new Date();
    const formDataNew = new FormData();
    formDataNew.append('AdvanceId', parseInt(AdvanceId));
    formDataNew.append('SenderId', senderId);
    formDataNew.append('RecipientId', recipientIdForDoctor);
    if (IsDirectClaim) {
        formDataNew.append('ClaimTypeId', claimTypeIdDirectClaim);
    }
    else {
        formDataNew.append('ClaimTypeId', claimTypeIdAdvanceClaim);
    }

    formDataNew.append('StatusId', statusId);
    formDataNew.append('ApprovalAmount', 25000);

    //var _url = 'https://uat.dfccil.services.cetpainfotech.com/api/Claim/AdvanceRequest​';
    var _url = apiBaseUrl + "​/api​/Claim​/SubmitEmpClaimProcess";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    $.ajax({
        type: "POST",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if ((response.statusCode == 201) || (response.statusCode == 200)) {
                swal({
                    title: 'Awesome !',
                    text: response.message,
                    type: 'success'
                });
            }
            else {
                swal({
                    title: 'Invalid !',
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSubmitAfterBankDetails").html('<i class="fa-solid fa-plus"></i> &nbsp;Add')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });


}

function checkboxDeclaration_cick(e) {

    if (e.checked) {
        AdvanceApprovedSubmit.disabled = false;
    }
    else {
        AdvanceApprovedSubmit.disabled = true;
    }
}
var empId = 4;
var recipientId = 4;//for Finanace
var recipientIdForFinance = 6;//for Finanace bill passing
var senderId = 4;//for Hr1
var claimTypeIdAdvance = 1;//for Hr1
var claimTypeIdTopUp = 4;//for Hr1
var statusId = 21;//for FinanceProcessing Bill Passing
var selectSendTo = document.getElementById("selectSendTo");
function claimApprovedSubmit_Click(e) {
    recipientId = selectSendTo.value;
    var claimTypeId = 0;
    if (isDirect) {
        claimTypeId = 3;
    }
    else {
        claimTypeId = 2;
    }
    if (recipientId == 5) {
        statusId = 5;
    }
    if (recipientId == 8) {
        statusId = 3;
    }
    const formDataNew = new FormData();
    formDataNew.append('AdvanceId', cId);
    formDataNew.append('SenderId', senderId);
    formDataNew.append('RecipientId', recipientId);
    formDataNew.append('ClaimTypeId', claimTypeId);
    formDataNew.append('StatusId', statusId);
    formDataNew.append('ApprovalAmount', $('#inputApprovedAmount').val());
    for (let e of arrMainBill) {
        formDataNew.append(e.key2, $('#' + e.key).val());
    }
    for (let e of arrMainBillPre) {
        formDataNew.append(e.key2, $('#' + e.key).val());
    }



    var _url = apiBaseUrl + "​/api/Claim/SubmitClaimProcess";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    debugger;
    $.ajax({
        type: "POST",
        url: _url,
        data: formDataNew,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('.page-loader').show();
            $("#claimApprovedSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if ((response.statusCode == 201) || (response.statusCode == 200)) {
                swal({
                    title: 'Success !',
                    text: "Your Approval request successfully submited to Finance Team",
                    type: 'success'
                });
            }
            else {
                swal({
                    title: 'Invalid !',
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#claimApprovedSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#claimApprovedSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}
function radio_taxable_click(e) {
    if (radioTaxableNo.checked) {
        taxUploadDoc.style.display = '';
    }
    else {
        taxUploadDoc.style.display = 'none';
    }
}
function specialDisease_Click(e, type) {
    if (type == 'Yes') {
        $("#divSpecialDisease").css('display', 'block')
    }
    else {
        $("#divSpecialDisease").css('display', 'none')
    }
}
function btnPrintForDoctor_Click(e) {
    swal({
        title: 'Info !',
        text: 'Work in Progress... ',
        type: 'info'
    });
}
var radioSpecialDiseaseYesDoctor = document.getElementById('radioSpecialDiseaseYesDoctor');
function btnSendtoHr_Click(e) {

    alert('Page Under Processing');
    /*    return;*/
    var claimTypeID = 0;
    if (isDirect) {
       claimTypeID= 3;
    }
    else {
        claimTypeID = 2;
    }
    
    //const formDataNew = new FormData();
    //formDataNew.append('ClaimId', cId);
    //formDataNew.append('doctorId', 5);
    //formDataNew.append('hrRecipentId', 4);
    
    
    //formDataNew.append('claimStatus', 24);
    var commentObject = [];
    //keyComment: 'Consultation', keyTextAreaComment: 'textAreaConsultationComment'
    debugger;
    for (var e of arrMainBill) {
        
        if ($("#" + e.keyTextAreaComment).val() != undefined && $("#" + e.keyTextAreaComment).val() != '') {
            commentObject.push({ commentKey: e.keyComment, commentValue: $("#" + e.keyTextAreaComment).val() });
        }       
    }
    for (var e of arrMainBillPre) {
        if ($("#" + e.keyTextAreaComment).val() != undefined && $("#" + e.keyTextAreaComment).val() != '') {
            commentObject.push({ commentKey: e.keyComment, commentValue: $("#" + e.keyTextAreaComment).val() });
        }
    }
    if ($("#textAreaSpecialDiseaseComment").val() != undefined && $("#textAreaSpecialDiseaseComment").val() != '') {
        commentObject.push({ commentKey: "SpecialDiseaseComment", commentValue: $("#textAreaSpecialDiseaseComment").val() });
    }
    if ($("#textAreaPostHospitlizationComment").val() != undefined && $("#textAreaPostHospitlizationComment").val() != '') {
        commentObject.push({ commentKey: "PostHospitlizationComment", commentValue: $("#textAreaPostHospitlizationComment").val() });
    }
    if ($("#textAreaAdditionalComments").val() != undefined && $("#textAreaAdditionalComments").val() != '') {
        commentObject.push({ commentKey: "AdditionalComments", commentValue: $("#textAreaAdditionalComments").val() });
    }
    if ($("#textAreaAdmissionAdviceComment").val() != undefined && $("#textAreaAdmissionAdviceComment").val() != '') {
        commentObject.push({ commentKey: "AdmissionAdviceComment", commentValue: $("#textAreaAdmissionAdviceComment").val() });
    }
    if ($("#textAreaDischargeSummaryComment").val() != undefined && $("#textAreaDischargeSummaryComment").val() != '') {
        commentObject.push({ commentKey: "DischargeSummaryComment", commentValue: $("#textAreaDischargeSummaryComment").val() });
    }
    if ($("#textAreaInvestigationReportsComment").val() != undefined && $("#textAreaInvestigationReportsComment").val() != '') {
        commentObject.push({ commentKey: "InvestigationReportsComment", commentValue: $("#textAreaInvestigationReportsComment").val() });
    }
    if ($("#textAreaDigonosis").val() != undefined && $("#textAreaDigonosis").val() != '') {
        commentObject.push({ commentKey: "Digonosis", commentValue: $("#textAreaDigonosis").val() });
    }
    var JsonObj = { ClaimId: parseInt(cId), doctorId: 5, hrRecipentId: 4, claimType: claimTypeID, claimStatus: 24, isSpecailDisease: true, comments: commentObject };
    debugger;
    
    
    var _url = apiBaseUrl + "​​/api​/DoctorReview​/CreateDoctorReview";
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

    debugger;
    $.ajax({
        type: "POST",
        url: _url,
        data: JSON.stringify( JsonObj),
       
        contentType: 'application/json',
        beforeSend: function () {
            $('.page-loader').show();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
        },
        success: function (response) {

            if ((response.statusCode == 201) || (response.statusCode == 200)) {
                swal({
                    title: 'Success !',
                    text: "Your Comments  successfully submited to HR Team",
                    type: 'success'
                });
            }
            else {
                swal({
                    title: 'Invalid !',
                    text: 'Bad request try agin.',
                    type: 'error'
                });
            }

            $('#myModal').modal('hide');

        },
        complete: function () {

            $('.page-loader').hide();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
        },
        error: function (jqXHR, status) {
            $('.page-loader').hide();
            $("#btnSendtoHr").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            swal({
                title: 'Invalid !',
                text: jqXHR.responseJSON.message,
                type: 'error'
            });

        }
    });

}
var btnSendtoHr = document.getElementById('btnSendtoHr');
function verified_click(e) {
    if (e.checked) {
        btnSendtoHr.disabled = false;
    }
    else {
        btnSendtoHr.disabled = true;
    }
}
// ApiCallFunctions
