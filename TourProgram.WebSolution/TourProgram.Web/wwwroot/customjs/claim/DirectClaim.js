var rupee = new Intl.NumberFormat('en-IN', {
    style: 'currency',
    currency: 'INR',
});
var tdPreHospitlizationTotal = document.getElementById('tdPreHospitlizationTotal');
// Summary Veriables start
var trTATA = document.getElementById('trTATA');
var trPHB = document.getElementById('trPHB');
var trFHB = document.getElementById('trFHB');
//var trAA = document.getElementById('trAA');

var trTB = document.getElementById('trTB');
var trDP = document.getElementById('trDP');
var trBC = document.getElementById('trBC');


var tdTATA = document.getElementById('tdTATA');
var tdPHB = document.getElementById('tdPHB');
var tdFHB = document.getElementById('tdFHB');
//var tdAA = document.getElementById('tdAA');

var tdTB = document.getElementById('tdTB');
var tdDP = document.getElementById('tdDP');
var tdBC = document.getElementById('tdBC');
// Summary Veriables ends
var btnInpatientSubmit = document.getElementById('btnInpatientSubmit');
var checkboxDeclaration = document.getElementById('checkboxDeclaration');
var taxUploadDoc = document.getElementById('taxUploadDoc');
var radioTaxableNo = document.getElementById('radioTaxableNo');
var spanTotalLimit = document.getElementById('spanTotalLimit');
var spanUsedLimit = document.getElementById('spanUsedLimit');
var spanBalanceLimit = document.getElementById('spanBalanceLimit');

var spanAmountIncludedMainBill = document.getElementById('spanAmountIncludedMainBill');
var spanAmountNotIncludedMainBill = document.getElementById('spanAmountNotIncludedMainBill');
var spanFinalBill = document.getElementById('spanFinalBill');
var chkPreHospitlization = document.getElementById('chkPreHospitlization');

/// Hospitlization Variables start
var inputMedicine = document.getElementById('inputMedicine');
inputMedicine.value = 0.00;
var inputMedicineClaim = document.getElementById('inputMedicineClaim');
inputMedicineClaim.value = 0.00;

var inputConsultation = document.getElementById('inputConsultation');
inputConsultation.value = 0.00;
var inputConsultationClaim = document.getElementById('inputConsultationClaim');
inputConsultationClaim.value = 0.00;

var inputInvestigation = document.getElementById('inputInvestigation');
inputInvestigation.value = 0.00;
var inputInvestigationClaim = document.getElementById('inputInvestigationClaim');
inputInvestigationClaim.value = 0.00;


var inputRoomRent = document.getElementById('inputRoomRent');
inputRoomRent.value = 0.00;
var inputRoomRentClaim = document.getElementById('inputRoomRentClaim');
inputRoomRentClaim.value = 0.00;
var inputProcedure = document.getElementById('inputProcedure');
inputProcedure.value = 0.00;
var inputProcedureClaim = document.getElementById('inputProcedureClaim');
inputProcedureClaim.value = 0.00;

var inputOther = document.getElementById('inputOther');
inputOther.value = 0.00;
var inputOtherClaim = document.getElementById('inputOtherClaim');
inputOtherClaim.value = 0.00;
/// Hospitlization Variables Ends


/// Pre Hospitlization Variables start


var inputMedicineDate = document.getElementById('inputMedicineDate');
var inputMedicinePre = document.getElementById('inputMedicinePre');
inputMedicinePre.value = 0.00;
var inputMedicinePreClaim = document.getElementById('inputMedicinePreClaim');
inputMedicinePreClaim.value = 0.00;

var inputConsultationDate = document.getElementById('inputConsultationDate');
var inputConsultationPre = document.getElementById('inputConsultationPre');
inputConsultationPre.value = 0.00;
var inputConsultationPreClaim = document.getElementById('inputConsultationPreClaim');
inputConsultationPreClaim.value = 0.00;

var inputInvestigationDate = document.getElementById('inputInvestigationDate');
var inputInvestigationPre = document.getElementById('inputInvestigationPre');
inputInvestigationPre.value = 0.00;
var inputInvestigationPreClaim = document.getElementById('inputInvestigationPreClaim');
inputInvestigationPreClaim.value = 0.00;

var inputProcedureDate = document.getElementById('inputProcedureDate');
var inputProcedurePre = document.getElementById('inputProcedurePre');
inputProcedurePre.value = 0.00;
var inputProcedurePreClaim = document.getElementById('inputProcedurePreClaim');
inputProcedurePreClaim.value = 0.00;

var inputOtherDate = document.getElementById('inputOtherDate');
var inputOtherPre = document.getElementById('inputOtherPre');
inputOtherPre.value = 0.00;
var inputOtherPreClaim = document.getElementById('inputOtherPreClaim');
inputOtherPreClaim.value = 0.00;


//Global Declartion
var empId = 3;

/// View Document Code
var documentDetails = { AdmissionAdviceUpload: [], Diagnosis: [], EstimateAmount: [], ITR: [], ReviseEstimateAmount: [] }
var topUpDataDetails = [];
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

// Upload Multiple JavaScript start
var IsNotInBill = false;
var IsPreHosPitlization = false;
var Rowindex = 1;
var selectedIndex = 1;
var uploadType = '';
var uploadKey = '';
var uploadTypeNotInBill = '';
var uploadKeyNotInBill = '';
var uploadIndexNotInBill = 0;
var uploadTypePreHosPitlization = '';
var uploadKeyPreHosPitlization = '';
var fileData = [];
var uploadDetails = { AdmissionAdvice: [], Diagnosis: [], Procedure: [], EstimateAmount: [], ITRIncomeProof: [], FinalHospitalBill: [], FinalHospitalBillSettle: [], DischargeSummary: [], DischargeSummarySettle: [], InvestigationReports: [], InvestigationReportsSettle: [], RegdCertificate: [], ExemptionLetter: [], PostTreatment: [] };
//{ index:1,row:r, type:Medicine ,uoloadedFile: clone, billAmount: 10000, clientPath: URL.createObjectURL(clone)}
var uploadDetailsNotInBill = { Medicine: [], Consultation: [], Investigation: [], Other: [], RoomRent: [] };
var AmountDetailsNotInBill = { Medicine: { count: 0, amount: 0, amountClaim: 0, rowIndex: -1 }, Consultation: { count: 0, amount: 0, amountClaim: 0, rowIndex: -1 }, Investigation: { count: 0, amount: 0, amountClaim: 0, rowIndex: -1 }, Other: { count: 0, amount: 0, amountClaim: 0, rowIndex: -1 }, RoomRent: { count: 0, amount: 0, amountClaim: 0, rowIndex: -1 }, Procedure: { count: 0, amount: 0, amountClaim: 0, rowIndex: -1 } };
var uploadDetailsPreHospitlization = { Medicine: [], Consultation: [], Procedure: [], Investigation: [], Other: [] };
var imgUpload = document.getElementById('upload-img')
    , imgPreview = document.getElementById('img-preview')
    , imgUploadForm = document.getElementById('form-upload')
    , totalFiles
    , previewTitle
    , previewTitleText
    , img;

imgUpload.addEventListener('change', previewImgs, true);
var trBodyUploadDoc = document.getElementById('trBodyUploadDoc');
function loadUploadedFile(key) {
    var row = '';
    let count = 1;
    if (uploadDetails[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetails[key]) {
        row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${uploadType}
                                           
                </td>
                <td>
                        ${e.comment}
                </td>

                <td>
					<a href="${e.clientPath}" target='_blank'>
                    <i style="font-size:20px; color:red;" class="fa-solid fa-file-lines" aria-hidden="true"></i>
					</a>
                </td>

                <td>
                    <i onclick="delete_file(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}
function loadUploadedFileNotInBill(key, index) {
    var row = '';
    let count = 1;
    if (uploadDetailsNotInBill[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetailsNotInBill[key]) {
        if (e.index == index) {
            row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${key}
                                           
                </td>
                <td>
                        ${e.comment}
                </td>

                <td>
					<a href="${e.clientPath}" target='_blank'>
                    <i style="font-size:20px; color:red;" class="fa-solid fa-file-lines" aria-hidden="true"></i>
					</a>
                </td>

                <td>
                    <i onclick="delete_fileNotInBill(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
        }

        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}
function loadUploadedFilePreHospitlization(key) {
    var row = '';
    let count = 1;
    if (uploadDetailsPreHospitlization[key].length == 0) {
        trBodyUploadDoc.innerHTML = '';
        return;
    }
    for (let e of uploadDetailsPreHospitlization[key]) {
        row += `<tr>
               <td class="py-1">${count}</td>
                <td>
                    ${uploadTypePreHosPitlization}
                                           
                </td>
                <td>
                        ${e.comment}
                </td>

                <td>
					<a href="${e.clientPath}" target='_blank'>
                    <i style="font-size:20px; color:red;" class="fa-solid fa-file-lines" aria-hidden="true"></i>
					</a>
                </td>

                <td>
                    <i onclick="delete_filePreHospitlization(${count - 1})" class="fa fa-trash trashFontAwesome" aria-hidden="true"></i>
                </td>
                </tr>`;
        count++;

    }
    trBodyUploadDoc.innerHTML = row;
}

function getUploadedElementByKeyAndIndex(key, index) {
    for (var e of uploadDetailsNotInBill[key]) {
        if (e.index == index)
            return e;
    }
}
function previewImgs(event) {
    if (IsNotInBill) {
        previewImgsNotInBill(event)
        return;
    }
    if (IsPreHosPitlization) {
        previewImgsPreHospitlization(event);
        return;
    }

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;
   
    uploadDetails[uploadKey].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    $("#span" + uploadKey).html(uploadDetails[uploadKey].length);
    imgUpload.value = null;
    loadUploadedFile(uploadKey);
}
function previewImgsNotInBill(event) {

    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;
    uploadDetailsNotInBill[uploadKeyNotInBill].push({ index: selectedIndex, type: uploadKeyNotInBill, uploadedFile: clone, billAmount: 0, clientPath: URL.createObjectURL(clone) });
    $("#span" + uploadKeyNotInBill + selectedIndex).html(uploadDetailsNotInBill[uploadKeyNotInBill].length);
    imgUpload.value = null;
    loadUploadedFileNotInBill(uploadKeyNotInBill, selectedIndex);
}
function previewImgsPreHospitlization(event) {

    debugger;
    if (imgUpload.files.length == 0) {
        return;
    }
    const original = imgUpload.files[0];
    const clone = new File([original], original.name, {
        type: original.type,
        lastModified: original.lastModified,
    });
    let comment = textareaComment.value;

    uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].push({ uploadedFile: clone, comment: comment, clientPath: URL.createObjectURL(clone) });
    debugger;
    $("#spanPre" + uploadKeyPreHosPitlization).html(uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].length);
    imgUpload.value = null;
    loadUploadedFilePreHospitlization(uploadKeyPreHosPitlization);
}
function getAmount(uploadKey, uploadIndexNotInBill) {
    var e = document.getElementById(uploadKey + uploadIndexNotInBill.toString());
    if (e)
        return e.value;
}
function delete_file(index) {
    uploadDetails[uploadKey].splice(index, 1);
    $("#span" + uploadKey).html(uploadDetails[uploadKey].length);
    loadUploadedFile(uploadKey);
}
function delete_fileNotInBill(index) {
    uploadDetailsNotInBill[uploadKeyNotInBill].splice(index, 1);
    $("#span" + uploadKeyNotInBill + uploadIndexNotInBill).html(uploadDetailsNotInBill[uploadKeyNotInBill].length);
    loadUploadedFileNotInBill(uploadKeyNotInBill, index);
}
function delete_filePreHospitlization(index) {
    uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].splice(index, 1);
    $("#spanPre" + uploadKeyPreHosPitlization).html(uploadDetailsPreHospitlization[uploadKeyPreHosPitlization].length);
    loadUploadedFilePreHospitlization(uploadKeyPreHosPitlization);
}

function TrigerModalUploadFile(type, type2) {
    IsNotInBill = false;
    IsPreHosPitlization = false;
    uploadType = type;
    uploadKey = type2;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFile(type2);
}
function TrigerModalUploadFileNotInBill(type, type2, index) {
    IsNotInBill = true;
    IsPreHosPitlization = false;
    uploadTypeNotInBill = type;
    uploadKeyNotInBill = type2;
    uploadIndexNotInBill = index;
    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    selectedIndex = index;
    loadUploadedFileNotInBill(type2, index);

}
function TrigerModalUploadFilePreHospitlization(type, type2) {
    IsNotInBill = false;
    IsPreHosPitlization = true
    uploadTypePreHosPitlization = type;
    uploadKeyPreHosPitlization = type2;

    $("#myModal").modal('show');
    $('#myModalTitle').html(type);
    $('#spnComment').html(type);
    loadUploadedFilePreHospitlization(type2);
}

function loadFamilyMembers() {
    var url = apiBaseUrl + "/api/Employeefamily/GetFamily/" + empId.toString();
    // Start Loader Here
    getApiCall(url = url, success, failour);
    function success(response) {
        var jsonData = response.data;
        selectMember.append('');

        for (let e of jsonData) {
            let option = new Option(e['memberName'] + "(" + e['relation'] + ")", e['id']);
            selectMember.add(option, undefined);
        }
        ShowHideParentLimit(selectMember.options[0].text, selectMember.options[0].value);
        calculateAndDisplayPrice('NA');
        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}
// Upload Multiple JavaScript End
// Global Elements
//var amountInBill = 0.0;
//var amountNotinBill = 0.0;
//var preHospitlizationBill = 0.0;

function calculate_onchange(element, type) {
    //debugger;
    calculateAndDisplayPrice(type)
}
var totalActualHospitalBillAmount = 0.0;
var totalItemWiseHosptalBillAmount = 0.0;
var totalItemWiseHosptalClaimAmount = 0.0;
var totalItemWiseHosptalNotInBillAmount = 0.0;
var totalItemWiseHosptalNotInBillClaimAmount = 0.0;
var totalPreHospitlizationBillAmount = 0.0;
var totalPreHospitlizationClaimAmount = 0.0;
var totalParentDeductionBillAmount = 0.0;
function preHospitlizationBillDateValidation() {
    var dateOfAdmission = '';
    try {
        dateOfAdmission = new Date(inputDateOfAdmission.value);
    }
    catch {

    }
    try {
        dateMedicine = new Date(inputMedicineDate.value);
    }
    catch {

    }

}
function getAdvanceTakenAmount() {
    var amt = $("#spanApprovedAmount").html();
    if (!isNaN(amt))
        return parseInt(amt);
    else
        return 0;
}
function getTopUpTakenAmount() {
    let amt = 0;
    //{ ReviseEstimateAmount: e.reviseEstimentedAmount, RequiredTopUpAmount: e.topRequiredAmount, ApprovedTopUpAmount: e.approvedAmount, ReviseEstimateFiles: path }
    for (var e of topUpDataDetails) {
        amt += e.ApprovedTopUpAmount;
    }
    return amt;
}
function getTotalApprovedAdvance() {
    return getAdvanceTakenAmount() + getTopUpTakenAmount();
}
function calculateAndDisplayPrice(type) {
    totalItemWiseHosptalBillAmount = 0.0;
    totalItemWiseHosptalClaimAmount = 0.0;
    totalItemWiseHosptalNotInBillAmount = 0.0;
    totalItemWiseHosptalNotInBillClaimAmount = 0.0;
    totalPreHospitlizationBillAmount = 0.0;
    totalPreHospitlizationClaimAmount = 0.0;
    getSumOfItemWiseAmount();
    getSumOfAmountNotInBill();
    if (chkPreHospitlization.checked)
        getSumOfItemWiseAmountPreHospitlization();

    spanSubTotal.innerHTML = totalItemWiseHosptalClaimAmount + totalItemWiseHosptalNotInBillClaimAmount
    spanAmountIncludedMainBill.innerHTML = totalItemWiseHosptalClaimAmount;
    spanAmountNotIncludedMainBill.innerHTML = totalItemWiseHosptalNotInBillClaimAmount;
    // spanFinalBill.innerHTML = amountInBill + amountNotinBill + preHospitlizationBill;
    debugger;
    $("#tdPreHospitlizationTotal").html(totalPreHospitlizationClaimAmount);

    //var varFHB = parseFloat(inputFinalHospitalBill.value);
    //var varFHB = totalItemWiseHosptalClaimAmount + totalItemWiseHosptalNotInBillClaimAmount;
    var varFHB = 0;
    if (isDirect) {
        varFHB = parseFloat(inputFinalHospitalBill.value) + totalItemWiseHosptalNotInBillClaimAmount;
    }
    else {
        varFHB = parseFloat(inputFinalHospitalBillSettle.value) + totalItemWiseHosptalNotInBillClaimAmount;
    }
    
    if (isNaN(varFHB))
        varFHB = 0.0;
    // var varAA = 0.0;
    var varTB = 0.0;
    var varPHB = 0.0;
    var varDP = 0.0;
    // var varBC = 0.0;
    varTB = varFHB;
    tdFHB.innerHTML = varFHB;
    //varAA = amountNotinBill;
    //if (isNaN(varAA))
    //    varAA = 0.0
    //tdAA.innerHTML = varAA;
    varPHB = totalPreHospitlizationClaimAmount;

    var varTATA = 0;
    // spanFinalBill.innerHTML = amountInBill + amountNotinBill + preHospitlizationBill;
    if (!isDirect) {
        varTATA = getTotalApprovedAdvance();
        tdTATA.innerHTML = varTATA;
        trTATA.style.display = '';
    }
    else {
        trTATA.style.display = 'none';
    }

    if (isNaN(varPHB))
        varPHB = 0.0;
    if (chkPreHospitlization.checked) {
        trPHB.style.display = '';
        tdPHB.innerHTML = varPHB;
        varTB = varFHB + varPHB;
        tdTB.innerHTML = varTB;
        if (isParent) {
            varDP = (varTB * .20).toFixed(2);
            trDP.style.display = '';
            tdDP.innerHTML = varDP;
            tdBC.innerHTML = varTB - varDP;
            trTB.style.display = '';
        }
        else {

            trDP.style.display = 'none';
            
            tdBC.innerHTML = varTB;
            trTB.style.display = '';

        }
    }
    else {
        trPHB.style.display = 'none';
        // tdPHB.innerHTML = varPHB;
        varTB = varFHB;
        tdTB.innerHTML = varTB;
        if (isParent) {
            varDP = (varTB * .20).toFixed(2);
            trDP.style.display = '';
            tdDP.innerHTML = varDP;
            tdBC.innerHTML = varTB - varDP;
            trTB.style.display = '';
        }
        else {

            trDP.style.display = 'none';
            //tdDP.innerHTML = varDP;
            tdBC.innerHTML = varTB;
            trTB.style.display = '';

        }


    }

    if (!isDirect) {
        tdBC.innerHTML = parseInt(tdBC.innerHTML) - varTATA;
    }
    if (parseInt(tdBC.innerHTML) < 0) {
        trNP.style.display = '';
        checkboxDeclaration.disabled = true;
        btnClaimSubmit.disabled = true;
    }
    else {
        trNP.style.display = 'none';
        checkboxDeclaration.disabled = false;
        if (checkboxDeclaration.checked) {
            btnClaimSubmit.disabled = false;
        }
        else {
            btnClaimSubmit.disabled = true;

        }
      
    }

   

}
var trNP = document.getElementById('trNP');
function getSumOfItemWiseAmount() {
    try {
        let p = parseFloat(inputMedicine.value);
        let pClaim = parseFloat(inputMedicineClaim.value);
        if (p == NaN) {
            p = 0
            inputMedicine.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputMedicineClaim.value = 0.00;
        }
        totalItemWiseHosptalBillAmount += p
        totalItemWiseHosptalClaimAmount += pClaim
    }
    catch {
        inputMedicine.value = 0.00;
        inputMedicineClaim.value = 0.00;
    }
    try {
        let p = parseFloat(inputConsultation.value);
        let pClaim = parseFloat(inputConsultationClaim.value);
        if (p == NaN) {
            p = 0
            inputConsultation.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputConsultationClaim.value = 0.00;
        }
        totalItemWiseHosptalBillAmount += p
        totalItemWiseHosptalClaimAmount += pClaim
    }
    catch {
        inputConsultation.value = 0.00;
        inputConsultationClaim.value = 0.00;
    }

    try {
        let p = parseFloat(inputInvestigation.value);
        let pClaim = parseFloat(inputInvestigationClaim.value);
        if (p == NaN) {
            p = 0
            inputInvestigation.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputInvestigationClaim.value = 0.00;
        }
        totalItemWiseHosptalBillAmount += p
        totalItemWiseHosptalClaimAmount += pClaim
    }
    catch {
        inputInvestigation.value = 0.00;
        inputInvestigationClaim.value = 0.00;
    }

    try {
        let p = parseFloat(inputRoomRent.value);
        let pClaim = parseFloat(inputRoomRentClaim.value);
        if (p == NaN) {
            p = 0
            inputRoomRent.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputRoomRentClaim.value = 0.00;
        }
        totalItemWiseHosptalBillAmount += p
        totalItemWiseHosptalClaimAmount += pClaim
    }
    catch {
        inputRoomRent.value = 0.00;
        inputRoomRentClaim.value = 0.00;
    }

    try {
        let p = parseFloat(inputOther.value);
        let pClaim = parseFloat(inputOtherClaim.value);
        if (p == NaN) {
            p = 0
            inputOther.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputOtherClaim.value = 0.00;
        }
        totalItemWiseHosptalBillAmount += p
        totalItemWiseHosptalClaimAmount += pClaim
    }
    catch {
        inputOther.value = 0.00;
        inputOtherClaim.value = 0.00;
    }

    try {
        let p = parseFloat(inputProcedure.value);
        let pClaim = parseFloat(inputProcedureClaim.value);
        if (p == NaN) {
            p = 0
            inputProcedure.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputProcedureClaim.value = 0.00;
        }
        totalItemWiseHosptalBillAmount += p
        totalItemWiseHosptalClaimAmount += pClaim
    }
    catch {
        inputProcedure.value = 0.00;
        inputProcedureClaim.value = 0.00;
    }





}
function getSumOfItemWiseAmountPreHospitlization() {
    try {
        let p = parseFloat(inputMedicinePre.value);
        let pClaim = parseFloat(inputMedicinePreClaim.value);
        if (p == NaN) {
            p = 0
            inputMedicinePre.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputMedicinePreClaim.value = 0.00;
        }
        totalPreHospitlizationBillAmount += p
        totalPreHospitlizationClaimAmount += pClaim
    }
    catch {
        inputMedicinePre.value = 0.00;
        inputMedicinePreClaim.value = 0.00;
    }
    try {
        let p = parseFloat(inputConsultationPre.value);
        let pClaim = parseFloat(inputConsultationPreClaim.value);
        if (p == NaN) {
            p = 0
            inputConsultationPre.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputConsultationPreClaim.value = 0.00;
        }
        totalPreHospitlizationBillAmount += p
        totalPreHospitlizationClaimAmount += pClaim
    }
    catch {
        inputConsultationPre.value = 0.00;
        inputConsultationPreClaim.value = 0.00;
    }

    try {
        let p = parseFloat(inputInvestigationPre.value);
        let pClaim = parseFloat(inputInvestigationPreClaim.value);
        if (p == NaN) {
            p = 0
            inputInvestigationPre.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputInvestigationClaimPre.value = 0.00;
        }
        totalPreHospitlizationBillAmount += p
        totalPreHospitlizationClaimAmount += pClaim
    }
    catch {
        inputInvestigationPre.value = 0.00;
        inputInvestigationPreClaim.value = 0.00;
    }

    try {
        let p = parseFloat(inputOtherPre.value);
        let pClaim = parseFloat(inputOtherPreClaim.value);
        if (p == NaN) {
            p = 0
            inputOtherPre.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputOtherPreClaim.value = 0.00;
        }
        totalPreHospitlizationBillAmount += p
        totalPreHospitlizationClaimAmount += pClaim
    }
    catch {
        inputOtherPre.value = 0.00;
        inputOtherPreClaim.value = 0.00;
    }

    try {
        let p = parseFloat(inputProcedurePre.value);
        let pClaim = parseFloat(inputProcedurePreClaim.value);
        if (p == NaN) {
            p = 0
            inputProcedurePre.value = 0.00;
        }
        if (pClaim == NaN) {
            pClaim = 0
            inputProcedurePreClaim.value = 0.00;
        }
        totalPreHospitlizationBillAmount += p
        totalPreHospitlizationClaimAmount += pClaim
    }
    catch {
        inputProcedurePre.value = 0.00;
        inputProcedurePreClaim.value = 0.00;
    }





}

function getSumOfAmountNotInBill() {
    debugger;
    for (let e in AmountDetailsNotInBill) {
        if (AmountDetailsNotInBill[e].rowIndex != -1) {
            totalItemWiseHosptalNotInBillAmount += AmountDetailsNotInBill[e].amount;
            totalItemWiseHosptalNotInBillClaimAmount += AmountDetailsNotInBill[e].amountClaim;
        }
    }
}
function calculatePreHospitlizationBill() {
    try {
        let p = parseFloat(inputMedicinePre.value);
        if (p == NaN) {
            p = 0
            inputMedicinePre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputMedicinePre.value = 0.00;
    }
    try {
        let p = parseFloat(inputConsultationPre.value);
        if (p == NaN) {
            p = 0
            inputConsultationPre.value = rupee.format(0.00);
        }
        preHospitlizationBill += p
    }
    catch {
        inputConsultationPre.value = 0;
    }
    try {
        let p = parseFloat(inputInvestigationPre.value);
        if (p == NaN) {
            p = 0
            inputInvestigationPre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputInvestigationPre.value = 0.00;
    }

    try {
        let p = parseFloat(inputOtherPre.value);
        if (p == NaN) {
            p = 0
            inputOtherPre.value = 0.00;
        }
        preHospitlizationBill += p
    }
    catch {
        inputOtherPre.value = 0.00;
    }
}


var selectMember = document.getElementById('selectMember');
var inputHospitalName = document.getElementById('inputHospitalName');
var inputHospitalRegdNo = document.getElementById('inputHospitalRegdNo');
var inputDoctorName = document.getElementById('inputDoctorName');
var inputDateOfAdmission = document.getElementById('inputDateOfAdmission');
var btnAdmissionAdvice = document.getElementById('btnAdmissionAdvice');
var inputDateOfDischarge = document.getElementById('inputDateOfDischarge');
var btnDischargeSummary = document.getElementById('btnDischargeSummary');
var inputFinalHospitalBill = document.getElementById('inputFinalHospitalBill');
var inputFinalHospitalBillSettle = document.getElementById('inputFinalHospitalBillSettle');
var radioSpecialDiseaseYes = document.getElementById('radioSpecialDiseaseYes');
var radioSpecialDiseaseNo = document.getElementById('radioSpecialDiseaseNo');
var checkboxDeclaration = document.getElementById('checkboxDeclaration');
var btnAdmissionAdvice = document.getElementById('btnAdmissionAdvice');
var itrParent = document.getElementById('itrParent');
var anchorItr = document.getElementById('anchorItr');


var divHospitalName = document.getElementById('divHospitalName');
var inputDiagnosis = document.getElementById('inputDiagnosis');
var inputBranchName = document.getElementById('inputBranchName');
var selectTreatmentType = document.getElementById('selectTreatmentType');
var radioEmpanelledHospitalsYes = document.getElementById('radioEmpanelledHospitalsYes');


//Events
function selectMember_OnChange(e) {

    ShowHideParentLimit(e.options[e.selectedIndex].text, e.options[e.selectedIndex].value);
    calculateAndDisplayPrice('NA');
}
//Functions

function NotInBill_cilck(e, type, typeKey) {
    //var newObject = { index: medicineCount, row: e, type: type, uoloadedFile: clone, billAmount: 10000, clientPath: URL.createObjectURL(clone) }
    if (AmountDetailsNotInBill[type].count == 1) {
        alert('Please add sum of all other ' + type + ' bill amount into given input box and uoload all files one by one. ');
        return;
    }
    AmountDetailsNotInBill[type].count++;
    AmountDetailsNotInBill[type].rowIndex = Rowindex;
    // Below Code Delete td
    //<td>
    //    <button class="btn"><i class="fa fa-eye" aria-hidden="true"></i> View File</button>
    //</td>
    var element = `<tr data-key="${typeKey}" data-index="${Rowindex.toString()}" id="trid">
                            <td></td>
                            <td>${type}</td>

                            <td>
                                <input id="${typeKey + Rowindex.toString()}" onfocusout="not_in_bill_amount_change(this,'${type}','${typeKey}','${Rowindex}')" type="text" class="form-control" value="0">
                            </td>
                            <td>
                                <input id="claim${typeKey + Rowindex.toString()}" onfocusout="not_in_bill_claim_change(this,'${type}','${typeKey}','${Rowindex}')" type="text" class="form-control" value="0">
                            </td>
                            <td>
                                <label class="col-sm-12 col-form-label notinclude"> Not included in Final Bill</label>
                            </td>
                            <td>
                                <button onclick="TrigerModalUploadFileNotInBill('${type}','${typeKey}','${Rowindex}')" type="button" class="btn"><i class="fa fa-upload" aria-hidden="true"></i> Upload File<span id="span${typeKey}${Rowindex}" class="file-status">0</span></button>
                            </td>

                            
                            <td>
                                <button onclick="delete_bill(this,'${typeKey}','${Rowindex.toString()}')" type="button" class="btn"><i class="fa fa-trash" aria-hidden="true"></i></i> Delete</button>
                            </td>

                        </tr>`;
    $('#tbody' + typeKey).append(element);
    Rowindex++;

}
function not_in_bill_amount_change(element, type, typeKey, Rowindex) {
    debugger;
    try {
        let p = parseFloat(element.value);
        if (p == NaN) {
            element.value = 0.00;
        }
        else {
            AmountDetailsNotInBill[typeKey].amount = p;
        }

    }
    catch {
        AmountDetailsNotInBill[typeKey].amount = 0;
    }
    calculateAndDisplayPrice(typeKey);

}
function not_in_bill_claim_change(element, type, typeKey, Rowindex) {
    debugger;
    try {
        let p = parseFloat(element.value);
        if (p == NaN) {
            element.value = 0.00;
        }
        else {
            AmountDetailsNotInBill[typeKey].amountClaim = p;
        }

    }
    catch {
        AmountDetailsNotInBill[typeKey].amountClaim = 0;
    }
    calculateAndDisplayPrice(typeKey);

}


function delete_element_with_type_index(type, index) {
    var i = 0;
    for (let e of uploadDetailsNotInBill[type]) {
        if (e.index == index) {
            uploadDetailsNotInBill[type].splice(i, 1);
            return true;
        }
        i++;
    }
    return false;
}
function delete_row_from_upload_details_not_in_bill(type, index) {
    while (delete_element_with_type_index(type, index));
    AmountDetailsNotInBill[type].count--;
    AmountDetailsNotInBill[type].amount = 0;
    AmountDetailsNotInBill[type].rowIndex = -1;

}
function delete_bill(e, type, index) {
    var i = e.parentNode.parentNode.rowIndex;
    document.getElementById('billdetails').deleteRow(i);
    delete_row_from_upload_details_not_in_bill(type, index);
    AmountDetailsNotInBill[type].count--;
    AmountDetailsNotInBill[type].amount = 0;
    AmountDetailsNotInBill[type].rowIndex = -1;

    calculateAndDisplayPrice(type);
}
function prehospitlization_click(e) {
    //var pre1 = document.getElementById('pre1');
    //var pre2 = document.getElementById('pre2');
    ////var row1 = document.getElementById('row1');
    ////var row2 = document.getElementById('row2');
    ////var r_amount = document.getElementById('r_amount');

    //if (e.checked) {
    //    pre1.style.display = 'block';
    //    pre2.style.display = 'block';
    //    //row1.style.display = '';
    //    //row2.style.display = '';
    //    // r_amount.innerHTML = '0';

    //}
    //else {
    //    pre1.style.display = 'none';
    //    pre2.style.display = 'none';
    //    //row1.style.display = 'none';
    //    //row2.style.display = 'none';
    //    // r_amount.innerHTML = '0';
    //}
    if (e.checked) {
        $('#divPreHospitlizationDetails').css('display', 'block')
    }
    else {
        $('#divPreHospitlizationDetails').css('display', 'none')
    }

    calculateAndDisplayPrice('NA');

}
// ApiCallFunctions
//function loadFamilyMembers() {
//    var url = apiBaseUrl + "/api/Employeefamily/GetFamily/" + empId.toString();
//    url = url.replace(/[\u200B-\u200D\uFEFF]/g, '');
//    // Start Loader Here
//    getApiCall(url = url, success, failour);
//    function success(response) {
//        var jsonData = response.data;
//        selectMember.append('');

//        for (let e of jsonData) {
//            let option = new Option(e['memberName'] + "(" + e['relation'] + ")", e['id']);
//            selectMember.add(option, undefined);
//        }
//        ShowHideParentLimit(selectMember.options[0].text);
//        //// Close Loader Here;
//    }
//    function failour(response) {
//        //// Close Loader Here;
//    }
//}
function getItrDetailsOfParentFromApi(familyId) {
    var _url = apiBaseUrl + "​/api/Common/GetITRDetails/" + familyId;
    _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');
    // Start Loader Here
    getApiCall(_url, success, failour);
    function success(response) {
        var jsonData = response.data;
        if (response.statusCode == 200 && response.message == "ITR Details found.") {
            divParentClaimLimt.style.display = 'block';
            itrParent.style.display = 'block';
            $("#anchorItr").attr('href', jsonData.itrFilePath);
            spanTotalLimit.innerHTML = jsonData.totalLimit;
            spanUsedLimit.innerHTML = jsonData.usedLimit;
            spanBalanceLimit.innerHTML = parseInt(jsonData.totalLimit) - parseInt(jsonData.usedLimit);
        }
        else {
            divParentClaimLimt.style.display = 'none';
            itrParent.style.display = 'none';

            swal({
                title: 'Invalid !',
                text: 'Your Parents Valid ITR Detail is not available with us Please visit profile section and upload valid ITR Details',
                type: 'error'
            });
        }
        //// Close Loader Here;
    }
    function failour(response) {
        //// Close Loader Here;
    }
}
var isParent = false;
//var radioPaytoSelf = document.getElementById('radioPaytoSelf');

function radio_taxable_click(e) {
    if (radioTaxableNo.checked) {
        taxUploadDoc.style.display = '';
    }
    else {
        taxUploadDoc.style.display = 'none';
    }
}
function checkboxDeclaration_cick(e) {

    if (e.checked) {
        btnClaimSubmit.disabled = false;
    }
    else {
        btnClaimSubmit.disabled = true;
    }
}

var divtaxable = document.getElementById('divtaxable');

function specialDisease_Click(e, type) {
    if (type == 'Yes') {
        $("#divSpecialDisease").css('display', 'block')
    }
    else {
        $("#divSpecialDisease").css('display', 'none')
    }
}

$(document).ready(function () {
    loadFamilyMembers();
    bindTableAdvanceClaim();
    //setDirectClaimValue();

});
function bindTableAdvanceClaim() {
    var tblAdvanceClaim = $('#tbodyAdvanceApprovedList');
    var url = apiBaseUrl + "/api/Claim/GetAdvanceClaimApproved?empId=" + empId.toString();
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
            /*console.log(response)
            console.log(response.statusCode)*/
            tblAdvanceClaim.append('');
            var count = 1;
            $.each(response.data, function () {

                debugger;
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
                                ${this.advanceAmount}
                               
                            </td>
                            <td>
                                 ${this.requestDate}
                                 
                            </td>
                            <td>
                                ${this.approvedAmount}
                                
                            <td>
                                ${this.approvedDate}
                                
                            </td>
                            <td>
                                <input type="button" onclick="topup_click(${this.empId},'${this.patientName}','${this.relation}',${this.advanceId},${this.patientid})" class="btn btn-primary" value="Settle">
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


//var divhospitaldetails = document.getElementById('divhospitaldetails');
var itrParent = document.getElementById('itrParent');
function chkDirectClaimRequest_click(e) {
    $("#divSettleDetails").css('display', 'none');
    if (e.checked) {
        isDirect = true;
        $("#divDirectClaimRequest").css('display', 'block');
        $("#divDirectClaimForm").css('display', 'block');
        $("#divSubmit").css('display', 'block');

    }
    else {
        isDirect = false;
        $("#divDirectClaimRequest").css('display', 'none');

        $("#divSubmit").css('display', 'none');
    }
}
var AdvanceId = 0;
function topup_click(emp_id, patient_name, relation, advanceId, pId) {
    isDirect = false;
    AdvanceId = advanceId;
    //cur_relation = relation;
    
    $("#chkDirectClaimRequest").prop('checked', false);
    $("#divNewAdvanceRequest").css('display', 'none');

    $("#divSettleDetails").css('display', 'block');
    $("#divSubmit").css('display', 'block');

    $("#divDirectClaimRequest").css('display', 'block');
    $("#divDirectClaimForm").css('display', 'none');

    $("#radioPaytoSelfTopUp").prop('checked', true);
    //divhospitaldetails.style.display = 'none';


    getAndFillAdvanceApprovedAndTopDetailDetailsByAdvanceID(advanceId);
    ShowHideParentLimit(relation, pId, true);
    
}
var inputTreatmentType = document.getElementById('inputTreatmentType');
var inputPayTo = document.getElementById('inputPayTo');
function getAndFillAdvanceApprovedAndTopDetailDetailsByAdvanceID(advanceID) {
    debugger;
    var url = apiBaseUrl + "/api/Claim/GetClaimDetails/" + advanceID.toString();
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
            documentDetails.AdmissionAdviceUpload = response.data.documentLists.filter(e => e.category == 'AdmissionAdviceUpload');
            $("#spanAdmissionAdviceUploadView").html(documentDetails.AdmissionAdviceUpload.length);
            //documentDetails.Diagnosis = response.data.documentLists.filter(e => e.category == 'Diagnosis');
            //$("#spanDiagnosisView").html(documentDetails.Diagnosis.length);
            documentDetails.EstimateAmount = response.data.documentLists.filter(e => e.category == 'EstimateAmount');
            $("#spanEstimateAmountView").html(documentDetails.EstimateAmount.length);
            tdPatientName.innerHTML = JsonData.advanceBasicDetails.patientName;
            tdPatientRelation.innerHTML = JsonData.advanceBasicDetails.relation;
            tdDateOfBirth.innerHTML = JsonData.advanceBasicDetails.dateOfBirth;
            tdGender.innerHTML = JsonData.advanceBasicDetails.gender;
            $("#spanHospitalName").html(JsonData.advanceBasicDetails.hospitalName);
            $("#spanDoctorName").html(JsonData.advanceBasicDetails.doctorName);
            $("#spanActualDateOfAdmission").html(formatDate(new Date(Date.parse(JsonData.advanceBasicDetails.likelyDate))));
            $("#spanEstimatedAmount").html(JsonData.advanceBasicDetails.estimatedAmount);
            $("#spanApprovedAmount").html(JsonData.advanceBasicDetails.claimApprovedAmount);
            $("#spanTreatmentType").html(JsonData.advanceBasicDetails.ctreatmentType);
            $("#spanDiagnosis").html(JsonData.advanceBasicDetails.digonosis);
            $("#spanPayTo").html(JsonData.advanceBasicDetails.payTo);
            if (JsonData.topUpDetails.length != 0) {

                $("#divApprovedAmount").css('display', 'block');
                $("#divbankdetails").css('display', 'block');
                $("#spanApprovedAmount").html(JsonData.advanceBasicDetails.claimApprovedAmount);
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
                $("#divApprovedAmount").css('display', 'none');
                $("#divbankdetails").css('display', 'none');
            }
            //if (JsonData.advanceBasicDetails.payTo.toUpperCase() == "SELF") {
            //    $("#divbankdetails").css('display', 'block');
            //    $("#spanBeneficiaryName").html(JsonData.hospitalAccoundetail.beneficiaryName);
            //    $("#spanGstNo").html(JsonData.hospitalAccoundetail.hospitalGSTNo);
            //    $("#spanBankName").html(JsonData.hospitalAccoundetail.bankName);
            //    $("#spanIFSCCode").html(JsonData.hospitalAccoundetail.ifscCode);
            //    $("#spanAccountNo").html(JsonData.hospitalAccoundetail.accountNumber);
            //    $("#spanUTRNo").html(JsonData.hospitalAccoundetail.utrNo);
            //    // Two Field Required
            //    $("#spanSAPReferenceNo").html(JsonData.hospitalAccoundetail.sapRefNumber);
            //    $("#spanTransactionDate").html(JsonData.hospitalAccoundetail.transactionDate);

            //}
            //else {
            //    $("#divbankdetails").css('display', 'none');


            //}
            addTopUpDetail(JsonData.topUpDetails);
            calculateAndDisplayPrice('NA');
            $('.page-loader').hide();

        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
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



function radioEmpanelledHospitals_Click(e, type) {
    if (type == "Yes") {
        $("#divEmpanelledHospitals").css('display', 'block');
        $("#divHospitalName").css('display', 'none');
        $("#divHospitalRegdNo").css('display', 'none');

    }
    else {
        $("#divEmpanelledHospitals").css('display', 'none');
        $("#divHospitalName").css('display', 'block');
        $("#divHospitalRegdNo").css('display', 'block');
    }
}
function radioPostHospitalization_Click(e, type) {
    if (type == 'Yes') {
        $("#divPostHospitlizationTreatment").css('display', 'block');
    }
    else {
        $("#divPostHospitlizationTreatment").css('display', 'none');
    }
}
var isDirect = false;

var radioPostHospitalizationYes = document.getElementById('radioPostHospitalizationYes');
var selectHospital = document.getElementById('selectHospital');
var inputDateOfAdmissionSettle = document.getElementById('inputDateOfAdmissionSettle');
var inputDateOfDischargeSettle = document.getElementById('inputDateOfDischargeSettle');
function btnClaimSubmit_Click(e) {
    //var date = new Date();
    if (isDirect) {
        const formDataNew = new FormData();

        formDataNew.append('IsSpecailDisease', radioSpecialDiseaseYes.checked);
        formDataNew.append('IsTaxAble', !radioTaxableNo.checked);
        formDataNew.append('SpecialDiseaseName', $("#inputSpecialDiseaseName").val());

        formDataNew.append('ClaimAmount', parseInt(tdBC.innerText));

        for (var e of uploadDetails.AdmissionAdvice) {
            formDataNew.append('AdmissionAdviceUpload', e.uploadedFile);
        }
        for (var e of uploadDetails.DischargeSummary) {
            formDataNew.append('DischargeSummaryUpload', e.uploadedFile);
        }
        for (var e of uploadDetails.InvestigationReports) {
            formDataNew.append('InvestigationReportsUpload', e.uploadedFile);
        }
        //for (var e of uploadDetails.Diagnosis) {
        //    formDataNew.append('DiagnosisUpload', e.uploadedFile);
        //}

        formDataNew.append('EmpId', empId);

        formDataNew.append('FinalHospitalBill', parseInt(inputFinalHospitalBill.value));
        for (var e of uploadDetails.FinalHospitalBill) {
            formDataNew.append('FinalHospitalBillUpload', e.uploadedFile);
        }

        formDataNew.append('MedicenBill.BilledAmount', parseInt(inputMedicine.value));
        formDataNew.append('MedicenBill.ClaimedAmount', parseInt(inputMedicineClaim.value));
        formDataNew.append('MedicenNotFinalBill.Amount', parseInt(AmountDetailsNotInBill.Medicine.amount));
        for (var e of uploadDetailsNotInBill.Medicine) {
            formDataNew.append('MedicenNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('MedicenNotFinalBill.AmountCliam', parseInt(AmountDetailsNotInBill.Medicine.amountClaim));

        formDataNew.append('Consultation.BilledAmount', parseInt(inputConsultation.value));
        formDataNew.append('Consultation.ClaimedAmount', parseInt(inputConsultationClaim.value));
        formDataNew.append('ConsultationNotFinalBill.BilledAmount', parseInt(AmountDetailsNotInBill.Consultation.amount));
        for (var e of uploadDetailsNotInBill.Consultation) {
            formDataNew.append('ConsultationNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('ConsultationNotFinalBill.AmountCliam', parseInt(AmountDetailsNotInBill.Consultation.amountClaim));


        formDataNew.append('Investigation.BilledAmount', parseInt(inputInvestigation.value));
        formDataNew.append('Investigation.ClaimedAmount', parseInt(inputInvestigationClaim.value));
        formDataNew.append('InvestigationNotFinalBill.BilledAmount', parseInt(AmountDetailsNotInBill.Investigation.amount));
        for (var e of uploadDetailsNotInBill.Investigation) {
            formDataNew.append('InvestigationNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('InvestigationNotFinalBill.AmountCliam', parseInt(AmountDetailsNotInBill.Investigation.amountClaim));


        formDataNew.append('RoomRent.BilledAmount', parseInt(inputRoomRent.value));
        formDataNew.append('RoomRent.ClaimedAmount', parseInt(inputRoomRentClaim.value));


        formDataNew.append('OtherBill.BilledAmount', parseInt(inputOther.value));
        formDataNew.append('OtherBill.ClaimedAmount', parseInt(inputOtherClaim.value));

        formDataNew.append('Procedure.BilledAmount', parseInt(inputProcedure.value));
        formDataNew.append('Procedure.ClaimedAmount', parseInt(inputProcedureClaim.value));


        formDataNew.append('OtherBillNotFinalBill.BilledAmount', parseInt(AmountDetailsNotInBill.Other.amount));



        for (var e of uploadDetailsNotInBill.Other) {
            formDataNew.append('OtherBillNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('OtherBillNotFinalBill.ClaimedAmount', parseInt(AmountDetailsNotInBill.Other.amountClaim));


        var pId = selectMember.value;
        formDataNew.append('PatientId', parseInt(pId));

        formDataNew.append('RequestName', 'NA');

        formDataNew.append('Reason', 'NA');


        //if (radioPaytoSelf.checked) {
        //    formDataNew.append('PayTo', 'Self');
        //}
        //else {
        //    formDataNew.append('PayTo', 'Hospital');
        //}
        formDataNew.append('PayTo', 'Self');
        formDataNew.append('HospitalName', inputHospitalName.value);
        formDataNew.append('HospitalRegNo', inputHospitalRegdNo.value);
        formDataNew.append('DateOfAdmission', inputDateOfAdmission.value);
        formDataNew.append('DateofDischarge', inputDateOfDischarge.value);
        formDataNew.append('DoctorName', inputDoctorName.value);

        formDataNew.append('IsPreHospitalizationExpenses', chkPreHospitlization.checked);


        formDataNew.append('PreHospitalizationExpensesMedicine.BilledAmount', parseInt(inputMedicinePre.value));
        // In future Remove Below Update it will be nullable
        for (var e of uploadDetailsPreHospitlization.Medicine) {
            formDataNew.append('PreHospitalizationExpensesMedicine.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesMedicine.ClaimedAmount', parseInt(inputMedicinePreClaim.value));
        formDataNew.append('PreHospitalizationExpensesMedicine.ClaimDate', inputMedicineDate.value);


        formDataNew.append('PreHospitalizationExpensesConsultation.BilledAmount', parseInt(inputConsultationPre.value));

        for (var e of uploadDetailsPreHospitlization.Consultation) {
            formDataNew.append('PreHospitalizationExpensesConsultation.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesConsultation.ClaimedAmount', parseInt(inputConsultationPreClaim.value));
        formDataNew.append('PreHospitalizationExpensesConsultation.ClaimDate', inputConsultationDate.value);


        formDataNew.append('PreHospitalizationExpensesInvestigation.BilledAmount', parseInt(inputInvestigationPre.value));

        for (var e of uploadDetailsPreHospitlization.Investigation) {
            formDataNew.append('PreHospitalizationExpensesInvestigation.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesInvestigation.ClaimedAmount', parseInt(inputInvestigationPreClaim.value));
        formDataNew.append('PreHospitalizationExpensesInvestigation.ClaimDate', inputInvestigationDate.value);


        formDataNew.append('PreHospitalizationExpensesOther.BilledAmount', parseInt(inputOtherPre.value));

        for (var e of uploadDetailsPreHospitlization.Other) {
            formDataNew.append('PreHospitalizationExpensesOther.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesOther.ClaimedAmount', parseInt(inputOtherPreClaim.value));
        formDataNew.append('PreHospitalizationExpensesOther.ClaimDate', inputOtherDate.value);

        formDataNew.append('PreHospitalizationProcedure.BilledAmount', parseInt(inputConsultationPre.value));

        for (var e of uploadDetailsPreHospitlization.Procedure) {
            formDataNew.append('PreHospitalizationProcedure.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationProcedure.ClaimedAmount', parseInt(inputProcedureClaim.value));
        formDataNew.append('PreHospitalizationProcedure.ClaimDate', inputProcedureDate.value);

        for (var e of uploadDetails.PostTreatment) {
            formDataNew.append('PostHospitalTreatmentAdviseUpload', e.uploadedFile);
        }


        formDataNew.append('Digonosis', inputDiagnosis.value);
        formDataNew.append('TreatmentType', selectTreatmentType.value);
        formDataNew.append('IsHospitialEmpanpanelled', radioEmpanelledHospitalsYes.checked);
        formDataNew.append('HospitalId', selectHospital.value);
        formDataNew.append('IsPostHospitalization', radioPostHospitalizationYes.checked);

        for (var e of uploadDetails.ExemptionLetter) {
            formDataNew.append('HospitalIncomeTaxFile.Files', e.uploadedFile);
        }
        for (var e of uploadDetails.RegdCertificate) {
            formDataNew.append('HospitalRegstrationDetailsFile.Files', e.uploadedFile);
        }

        debugger;


        var _url = apiBaseUrl + "​/api/Claim/DirectClaimRequest";
        _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

        $.ajax({
            type: "POST",
            url: _url,
            data: formDataNew,
            processData: false,
            contentType: false,
            beforeSend: function () {
                $('.page-loader').show();
                $("#btnClaimSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
            },
            success: function (response) {

                if (response.statusCode == 201) {
                    swal({
                        title: 'Success !',
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
                $("#btnClaimSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            },
            error: function (jqXHR, status) {
                $('.page-loader').hide();
                $("#btnClaimSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
                swal({
                    title: 'Invalid !',
                    text: jqXHR.responseJSON.message,
                    type: 'error'
                });

            }
        });
    }
    else {
        const formDataNew = new FormData();

        formDataNew.append('AdvanceId', AdvanceId);
        formDataNew.append('EmpId', empId);

        formDataNew.append('IsSpecailDisease', radioSpecialDiseaseYes.checked);
        formDataNew.append('IsTaxAble', !radioTaxableNo.checked);
        //formDataNew.append('SpecialDiseaseName', $("#inputSpecialDiseaseName").val());

        formDataNew.append('Declaration', true);
        for (var e of uploadDetails.DischargeSummarySettle) {
            formDataNew.append('DischargeSummaryUpload', e.uploadedFile);
        }
        //for (var e of uploadDetails.AdmissionAdvice) {
        //    formDataNew.append('AdmissionAdviceUpload', e.uploadedFile);
        //}

        for (var e of uploadDetails.InvestigationReportsSettle) {
            formDataNew.append('InvestigationReportsUpload', e.uploadedFile);
        }
        //for (var e of uploadDetails.Diagnosis) {
        //    formDataNew.append('DiagnosisUpload', e.uploadedFile);
        //}

        

        formDataNew.append('FinalHospitalBill', parseInt(inputFinalHospitalBillSettle.value));
        formDataNew.append('ClaimAmount', parseInt(tdBC.innerText));


        for (var e of uploadDetails.FinalHospitalBillSettle) {
            formDataNew.append('FinalHospitalBillUpload', e.uploadedFile);
        }

        formDataNew.append('MedicenBill.BilledAmount', parseInt(inputMedicine.value));
        formDataNew.append('MedicenBill.ClaimedAmount', parseInt(inputMedicineClaim.value));
        formDataNew.append('MedicenNotFinalBill.Amount', parseInt(AmountDetailsNotInBill.Medicine.amount));
        for (var e of uploadDetailsNotInBill.Medicine) {
            formDataNew.append('MedicenNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('MedicenNotFinalBill.AmountCliam', parseInt(AmountDetailsNotInBill.Medicine.amountClaim));

        formDataNew.append('Consultation.BilledAmount', parseInt(inputConsultation.value));
        formDataNew.append('Consultation.ClaimedAmount', parseInt(inputConsultationClaim.value));
        formDataNew.append('ConsultationNotFinalBill.BilledAmount', parseInt(AmountDetailsNotInBill.Consultation.amount));
        for (var e of uploadDetailsNotInBill.Consultation) {
            formDataNew.append('ConsultationNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('ConsultationNotFinalBill.AmountCliam', parseInt(AmountDetailsNotInBill.Consultation.amountClaim));


        formDataNew.append('Investigation.BilledAmount', parseInt(inputInvestigation.value));
        formDataNew.append('Investigation.ClaimedAmount', parseInt(inputInvestigationClaim.value));
        formDataNew.append('InvestigationNotFinalBill.BilledAmount', parseInt(AmountDetailsNotInBill.Investigation.amount));
        for (var e of uploadDetailsNotInBill.Investigation) {
            formDataNew.append('InvestigationNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('InvestigationNotFinalBill.AmountCliam', parseInt(AmountDetailsNotInBill.Investigation.amountClaim));


        formDataNew.append('RoomRent.BilledAmount', parseInt(inputRoomRent.value));
        formDataNew.append('RoomRent.ClaimedAmount', parseInt(inputRoomRentClaim.value));


        formDataNew.append('OtherBill.BilledAmount', parseInt(inputOther.value));
        formDataNew.append('OtherBill.ClaimedAmount', parseInt(inputOtherClaim.value));

        formDataNew.append('Procedure.BilledAmount', parseInt(inputProcedure.value));
        formDataNew.append('Procedure.ClaimedAmount', parseInt(inputProcedureClaim.value));


        formDataNew.append('OtherBillNotFinalBill.BilledAmount', parseInt(AmountDetailsNotInBill.Other.amount));



        for (var e of uploadDetailsNotInBill.Other) {
            formDataNew.append('OtherBillNotFinalBill.Files', e.uploadedFile);
        }
        formDataNew.append('OtherBillNotFinalBill.ClaimedAmount', parseInt(AmountDetailsNotInBill.Other.amountClaim));

        formDataNew.append('DateofDischarge', inputDateOfDischargeSettle.value);
        formDataNew.append('IsPreHospitalizationExpenses', chkPreHospitlization.checked);
        formDataNew.append('PreHospitalizationExpensesMedicine.BilledAmount', parseInt(inputMedicinePre.value));
        // In future Remove Below Update it will be nullable
        for (var e of uploadDetailsPreHospitlization.Medicine) {
            formDataNew.append('PreHospitalizationExpensesMedicine.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesMedicine.ClaimedAmount', parseInt(inputMedicinePreClaim.value));
        formDataNew.append('PreHospitalizationExpensesMedicine.ClaimDate', inputMedicineDate.value);


        formDataNew.append('PreHospitalizationExpensesConsultation.BilledAmount', parseInt(inputConsultationPre.value));

        for (var e of uploadDetailsPreHospitlization.Consultation) {
            formDataNew.append('PreHospitalizationExpensesConsultation.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesConsultation.ClaimedAmount', parseInt(inputConsultationPreClaim.value));
        formDataNew.append('PreHospitalizationExpensesConsultation.ClaimDate', inputConsultationDate.value);


        formDataNew.append('PreHospitalizationExpensesInvestigation.BilledAmount', parseInt(inputInvestigationPre.value));

        for (var e of uploadDetailsPreHospitlization.Investigation) {
            formDataNew.append('PreHospitalizationExpensesInvestigation.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesInvestigation.ClaimedAmount', parseInt(inputInvestigationPreClaim.value));
        formDataNew.append('PreHospitalizationExpensesInvestigation.ClaimDate', inputInvestigationDate.value);


        formDataNew.append('PreHospitalizationExpensesOther.BilledAmount', parseInt(inputOtherPre.value));

        for (var e of uploadDetailsPreHospitlization.Other) {
            formDataNew.append('PreHospitalizationExpensesOther.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationExpensesOther.ClaimedAmount', parseInt(inputOtherPreClaim.value));
        formDataNew.append('PreHospitalizationExpensesOther.ClaimDate', inputOtherDate.value);

        formDataNew.append('PreHospitalizationProcedure.BilledAmount', parseInt(inputConsultationPre.value));

        for (var e of uploadDetailsPreHospitlization.Procedure) {
            formDataNew.append('PreHospitalizationProcedure.Files', e.uploadedFile);
        }
        formDataNew.append('PreHospitalizationProcedure.ClaimedAmount', parseInt(inputProcedureClaim.value));
        formDataNew.append('PreHospitalizationProcedure.ClaimDate', inputProcedureDate.value);


        for (var e of uploadDetails.ExemptionLetter) {
            formDataNew.append('HospitalIncomeTaxFile.Files', e.uploadedFile);
        }
        for (var e of uploadDetails.RegdCertificate) {
            formDataNew.append('HospitalRegstrationDetailsFile.Files', e.uploadedFile);
        }

        for (var e of uploadDetails.PostTreatment) {
            formDataNew.append('PostHospitalTreatmentAdviseUpload', e.uploadedFile);
        }
        //formDataNew.append('Digonosis', inputDiagnosis.value);
        //formDataNew.append('TreatmentType', selectTreatmentType.value);
       // formDataNew.append('IsHospitialEmpanpanelled', radioEmpanelledHospitalsYes.checked);
       // formDataNew.append('HospitalId', selectHospital.value);
        formDataNew.append('IsPostHospitalization', radioPostHospitalizationYes.checked);
        formDataNew.append('DateOfAdmission', inputDateOfAdmissionSettle.value);
        formDataNew.append('SpecialDiseaseName', $("#inputSpecialDiseaseName").val());

        //var pId = selectMember.value;
        //formDataNew.append('PatientId', parseInt(pId));

        //formDataNew.append('RequestName', 'NA');

        //formDataNew.append('Reason', 'NA');


        //if (radioPaytoSelf.checked) {
        //    formDataNew.append('PayTo', 'Self');
        //}
        //else {
        //    formDataNew.append('PayTo', 'Hospital');
        //}
        //formDataNew.append('PayTo', 'Self');
        //formDataNew.append('HospitalName', inputHospitalName.value);
        //formDataNew.append('HospitalRegNo', inputHospitalRegdNo.value);
        //formDataNew.append('DateOfAdmission', inputDateOfAdmission.value);
       
        //formDataNew.append('DoctorName', inputDoctorName.value);

        

        


        
       

        debugger;


        var _url = apiBaseUrl + "​​/api​/Claim​/AdvanceClaimSettle";
        _url = _url.replace(/[\u200B-\u200D\uFEFF]/g, '');

        $.ajax({
            type: "POST",
            url: _url,
            data: formDataNew,
            processData: false,
            contentType: false,
            beforeSend: function () {
                $('.page-loader').show();
                $("#btnClaimSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Please wait..')
            },
            success: function (response) {

                if (response.statusCode == 201) {
                    swal({
                        title: 'Success !',
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
                $("#btnClaimSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
            },
            error: function (jqXHR, status) {
                $('.page-loader').hide();
                $("#btnClaimSubmit").html('<i class="fa-solid fa-plus"></i> &nbsp;Submit')
                swal({
                    title: 'Invalid !',
                    text: jqXHR.responseJSON.message,
                    type: 'error'
                });

            }
        });

    }
}
function dateofAdmission_focusOut(e) {
    
    var admissionDate = Date.parse(e.value);
    var onDay = 1000 * 60 * 60 * 24;
    var minDay = admissionDate - (30 * onDay);
    var maxDay = admissionDate - onDay;
    $('#inputMedicineDate').attr('min', formatDate(new Date(minDay)));
    $('#inputMedicineDate').attr('max', formatDate(new Date(maxDay)));
    $('#inputMedicineDate').prop('disabled', false);

    $('#inputConsultationDate').attr('min', formatDate(new Date(minDay)));
    $('#inputConsultationDate').attr('max', formatDate(new Date(maxDay)));
    $('#inputConsultationDate').prop('disabled', false);

    $('#inputInvestigationDate').attr('min', formatDate(new Date(minDay)));
    $('#inputInvestigationDate').attr('max', formatDate(new Date(maxDay)));
    $('#inputInvestigationDate').prop('disabled', false);

    $('#inputProcedureDate').attr('min', formatDate(new Date(minDay)));
    $('#inputProcedureDate').attr('max', formatDate(new Date(maxDay)));
    $('#inputProcedureDate').prop('disabled', false);

    $('#inputOtherDate').attr('min', formatDate(new Date(minDay)));
    $('#inputOtherDate').attr('max', formatDate(new Date(maxDay)));
    $('#inputOtherDate').prop('disabled', false);
}